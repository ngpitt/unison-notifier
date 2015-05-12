using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace unison_notifier
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      unisonProcess.StartInfo.FileName = "unison.exe";
      unisonProcess.StartInfo.RedirectStandardError = true;
      unisonProcess.StartInfo.UseShellExecute = false;
      unisonProcess.StartInfo.CreateNoWindow = true;

      Load += new EventHandler(Form1_Load);
      Resize += new EventHandler(Form1_Resize);
      FormClosing += new FormClosingEventHandler(Form1_Closing);

      ContextMenu contextMenu = new ContextMenu();
      MenuItem logMenuItem = new MenuItem(),
        settingsMenuItem = new MenuItem(),
        exitMenuItem = new MenuItem();

      logMenuItem.Text = "Log";
      logMenuItem.Click += new EventHandler(logMenuItem_Click);
      contextMenu.MenuItems.Add(logMenuItem);

      settingsMenuItem.Text = "Settings";
      settingsMenuItem.Click += new EventHandler(settingsMenuItem_Click);
      contextMenu.MenuItems.Add(settingsMenuItem);

      contextMenu.MenuItems.Add("-");

      exitMenuItem.Text = "Exit";
      exitMenuItem.Click += new EventHandler(exitMenuItem_Click);
      contextMenu.MenuItems.Add(exitMenuItem);

      notifyIcon1.MouseClick += new MouseEventHandler(notifyIcon1_MouseClick);
      notifyIcon1.ContextMenu = contextMenu;

      notifierThread = new Thread(notifier);
      notifierThread.Start();
    }

    private Process unisonProcess = new Process();
    private Thread notifierThread;
    private ManualResetEvent notifierResetEvent = new ManualResetEvent(false);
    private bool terminate = false, firstTimeShown = true;
    private delegate void notifyDelegate(Icon icon, string title, string text);
    private delegate void updateLogDelegate(string line);
    private delegate void clearLogDelegate();

    private void notifier()
    {
      while (!terminate)
      {
        unisonProcess.Start();

        while (!unisonProcess.HasExited && !terminate)
        {
          string line = unisonProcess.StandardError.ReadLine();
          
          if (line != null)
          {
            if (line.Contains("Nothing to do"))
            {
              safeInvoke(new notifyDelegate(notify), Properties.Resources.SyncedIcon, "Synced", "Unison is connected and synced.");
            }
            else if (line.Contains("Propagating updates"))
            {
              safeInvoke(new notifyDelegate(notify), Properties.Resources.SyncingIcon, "Syncing", "Unison is syncing files...");
            }

            safeInvoke(new updateLogDelegate(updateLog), line + Environment.NewLine);
          }
        }

        safeInvoke(new notifyDelegate(notify), Properties.Resources.ErrorIcon, "Disconnected", "Unison has lost connection.");
        notifierResetEvent.WaitOne(10000);
        safeInvoke(new clearLogDelegate(clearLog));
      }
    }

    private void safeInvoke(Delegate method, params object[] args)
    {
      if (!terminate)
      {
        Invoke(method, args);
      }
    }

    private void notify(Icon icon, string title, string text)
    {
      notifyIcon1.Icon = icon;
      notifyIcon1.BalloonTipTitle = title;
      notifyIcon1.BalloonTipText = text;
    }

    private void updateLog(string line)
    {
      richTextBox1.AppendText(line);
    }

    private void clearLog()
    {
      richTextBox1.Clear();
    }

    private void logMenuItem_Click(object sender, EventArgs e)
    {
      if (firstTimeShown)
      {
        firstTimeShown = false;
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        CenterToScreen();
      }
      richTextBox1.SelectionStart = richTextBox1.Text.Length;
      richTextBox1.ScrollToCaret();
      Show();
    }

    private void settingsMenuItem_Click(object sender, EventArgs e)
    {
      string systemRoot = Environment.ExpandEnvironmentVariables("%systemroot%");
      string homePath = Environment.ExpandEnvironmentVariables("%homepath%");

      Process.Start(systemRoot + "\\System32\\notepad.exe", homePath + "\\.unison\\default.prf");
    }

    private void exitMenuItem_Click(object sender, EventArgs e)
    {
      terminate = true;
      Close();
    }

    private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        notifyIcon1.ShowBalloonTip(5000);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Hide();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      richTextBox1.Width = Width - 40;
      richTextBox1.Height = Height - 63;
    }

    private void Form1_Closing(object sender, FormClosingEventArgs e)
    {
      if (!terminate)
      {
        Hide();
        e.Cancel = true;
      }
      else
      {
        notifierResetEvent.Set();
        if (!unisonProcess.HasExited)
        {
          unisonProcess.Kill();
        }
        notifierThread.Join();
      }
    }
  }
}