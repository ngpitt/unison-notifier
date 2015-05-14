using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Drawing;

namespace unison_notifier
{
  public partial class statusForm : Form
  {
    public statusForm()
    {
      InitializeComponent();
      notepadProcess.StartInfo.Arguments = Environment.ExpandEnvironmentVariables(@"%HomePath%\.unison\default.prf");
    }

    private bool firstTimeShown = true;
    private ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    private delegate void updateStatusDelegate(Icon icon, string status);
    private delegate void updateLogDelegate(string line);
    private delegate void clearLogDelegate();

    private void Form1_Load(object sender, EventArgs e)
    {
      Hide();
      backgroundWorker.RunWorkerAsync();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (backgroundWorker.IsBusy)
      {
        Hide();
        e.Cancel = true;
      }
    }

    private void statusToolStripMenuItem_Click(object sender, EventArgs e)
    {
      statusRichTextBox.SelectionStart = statusRichTextBox.Text.Length;
      statusRichTextBox.ScrollToCaret();
      if (firstTimeShown)
      {
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        CenterToScreen();
        firstTimeShown = false;
      }
      Show();
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      notepadProcess.Start();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      exitBackgroundWorker(true);
    }

    private void notifyIcon1_DoubleClick(object sender, EventArgs e)
    {
      statusToolStripMenuItem_Click(sender, e);
    }

    private void disconnectButton_Click(object sender, EventArgs e)
    {
      exitBackgroundWorker(true);
    }

    private void reconnectButton_Click(object sender, EventArgs e)
    {
      exitBackgroundWorker(false);
    }

    private void hideButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      while (true)
      {
        unisonProcess.Start();
        Invoke(new updateStatusDelegate(updateStatus), Properties.Resources.UnisonIcon, "Connecting");
        manualResetEvent.Reset();

        while (!unisonProcess.HasExited)
        {
          string output = unisonProcess.StandardError.ReadLine();

          if (backgroundWorker.CancellationPending)
          {
            return;
          }
          if (output != null)
          {
            if (output.Contains("Looking for changes"))
            {
              Invoke(new updateStatusDelegate(updateStatus), Properties.Resources.SyncingIcon, "Syncing");
            }
            else if (output.Contains("Nothing to do"))
            {
              Invoke(new updateStatusDelegate(updateStatus), Properties.Resources.SyncedIcon, "Synced");
            }
            Invoke(new updateLogDelegate(updateLog), output + Environment.NewLine);
          }
        }

        Invoke(new updateStatusDelegate(updateStatus), Properties.Resources.ErrorIcon, "Disconnected");
        manualResetEvent.WaitOne(10000);
        if (backgroundWorker.CancellationPending)
        {
          return;
        }
        Invoke(new clearLogDelegate(clearLog));
      }
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Close();
    }

    private void updateStatus(Icon icon, string status)
    {
      notifyIcon.Icon = icon;
      statusLabel.Text = "Status: " + status;
    }

    private void updateLog(string output)
    {
      statusRichTextBox.AppendText(output);
    }

    private void clearLog()
    {
      statusRichTextBox.Clear();
    }

    private void exitBackgroundWorker(bool restart)
    {
      if (restart)
      {
        backgroundWorker.CancelAsync();
      }
      if (!unisonProcess.HasExited)
      {
        unisonProcess.Kill();
      }
      manualResetEvent.Set();
    }
  }
}