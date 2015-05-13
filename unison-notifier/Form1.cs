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
      MenuItem statusMenuItem = new MenuItem(),
        settingsMenuItem = new MenuItem(),
        exitMenuItem = new MenuItem();

      statusMenuItem.Text = "Status";
      statusMenuItem.Click += new EventHandler(statusMenuItem_Click);
      contextMenu.MenuItems.Add(statusMenuItem);

      settingsMenuItem.Text = "Settings";
      settingsMenuItem.Click += new EventHandler(settingsMenuItem_Click);
      contextMenu.MenuItems.Add(settingsMenuItem);

      contextMenu.MenuItems.Add("-");

      exitMenuItem.Text = "Exit";
      exitMenuItem.Click += new EventHandler(exitMenuItem_Click);
      contextMenu.MenuItems.Add(exitMenuItem);

      notifyIcon1.DoubleClick += new EventHandler(statusMenuItem_Click);
      notifyIcon1.ContextMenu = contextMenu;

      notifierThread = new Thread(notifier);
      notifierThread.Start();
    }

    private Process unisonProcess = new Process();
    private Thread notifierThread;
    private ManualResetEvent notifierResetEvent = new ManualResetEvent(false);
    private bool terminate = false, firstTimeShown = true;
    private delegate void updateStatusDelegate(string line);
    private delegate void clearStatusDelegate();

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
            if (line.Contains("Looking for changes"))
            {
              notifyIcon1.Icon = Properties.Resources.SyncingIcon;
            }
            else if (line.Contains("Nothing to do"))
            {
              notifyIcon1.Icon = Properties.Resources.SyncedIcon;
            }

            safeInvoke(new updateStatusDelegate(updateStatus), line + Environment.NewLine);
          }
        }

        notifyIcon1.Icon = Properties.Resources.ErrorIcon;
        notifierResetEvent.WaitOne(10000);
        safeInvoke(new clearStatusDelegate(clearStatus));
      }
    }

    private void safeInvoke(Delegate method, params object[] args)
    {
      if (!terminate)
      {
        Invoke(method, args);
      }
    }

    private void updateStatus(string line)
    {
      richTextBox1.AppendText(line);
    }

    private void clearStatus()
    {
      richTextBox1.Clear();
    }

    private void statusMenuItem_Click(object sender, EventArgs e)
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