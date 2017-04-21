using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnisonNotifier.Properties;

namespace UnisonNotifier
{
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
            NotepadProcess.StartInfo.Arguments = Environment.ExpandEnvironmentVariables(@"%HomePath%\.unison\default.prf");
        }

        private bool FirstTimeShown = true;
        private bool Reconnect = true;
        private CancellationTokenSource TokenSource;
        private enum CtrlTypes : uint { CTRL_C_EVENT = 0 }
        private delegate bool HandlerRoutine(CtrlTypes ctrlType);

        private async void StatusForm_Load(object sender, EventArgs e)
        {
            Hide();

            while (Reconnect)
            {
                TokenSource = new CancellationTokenSource();
                UnisonProcess.Start();
                UpdateStatus(Resources.UnisonIcon, "Connecting");

                while (!UnisonProcess.HasExited)
                {
                    var output = await UnisonProcess.StandardError.ReadLineAsync();

                    if (output != null)
                    {
                        if (output.Contains("Looking for changes"))
                        {
                            UpdateStatus(Resources.SyncingIcon, "Syncing");
                        }
                        else if (output.Contains("Nothing to do"))
                        {
                            UpdateStatus(Resources.SyncedIcon, "Synced");
                        }

                        AppendToLog(output);
                    }
                }

                UpdateStatus(Resources.ErrorIcon, "Disconnected");

                if (!TokenSource.IsCancellationRequested)
                {
                    AppendToLog("Reconnecting in 10 seconds...");
                    await Task.Delay(TimeSpan.FromSeconds(10), TokenSource.Token).ContinueWith(t => { });
                }
                else
                {
                    SetConsoleCtrlHandler(null, false);
                }

                ClearLog();
            }

            Close();
        }

        private void StatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UnisonProcess.HasExited || Reconnect)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void StatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusRichTextBox.SelectionStart = StatusRichTextBox.Text.Length;
            StatusRichTextBox.ScrollToCaret();

            if (FirstTimeShown)
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                CenterToScreen();
                FirstTimeShown = false;
            }

            Show();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadProcess.Start();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopUnison(false);
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            StatusToolStripMenuItem_Click(sender, e);
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            StopUnison(false);
        }

        private void ReconnectButton_Click(object sender, EventArgs e)
        {
            StopUnison(true);
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateStatus(Icon icon, string status)
        {
            NotifyIcon.Icon = icon;
            StatusLabel.Text = $"Status: {status}";
        }

        private void AppendToLog(string text)
        {
            StatusRichTextBox.AppendText($"{text}{Environment.NewLine}");
        }

        private void ClearLog()
        {
            StatusRichTextBox.Clear();
        }

        private void StopUnison(bool reconnect)
        {
            Reconnect = reconnect;
            TokenSource.Cancel();

            if (!UnisonProcess.HasExited)
            {
                FreeConsole();
                AttachConsole((uint)UnisonProcess.Id);
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
            }
        }

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(HandlerRoutine handler, bool add);
    }
}
