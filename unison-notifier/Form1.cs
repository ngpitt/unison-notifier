using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Drawing;

namespace unison_notifier
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      process2.StartInfo.Arguments = Environment.ExpandEnvironmentVariables(@"%HomePath%\.unison\default.prf");
    }

    private bool firstTimeShown = true;
    private ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    private delegate void updateStatusDelegate(string line);
    private delegate void clearStatusDelegate();

    private void Form1_Load(object sender, EventArgs e)
    {
      Hide();
      backgroundWorker1.RunWorkerAsync();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      richTextBox1.Width = Width - 40;
      richTextBox1.Height = Height - 63;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (backgroundWorker1.IsBusy)
      {
        Hide();
        e.Cancel = true;
      }
    }

    private void statusToolStripMenuItem_Click(object sender, EventArgs e)
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

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      process2.Start();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      backgroundWorker1.CancelAsync();
      if (!process1.HasExited)
      {
        process1.Kill();
      }
      else
      {
        manualResetEvent.Set();
      }
    }

    private void notifyIcon1_DoubleClick(object sender, EventArgs e)
    {
      statusToolStripMenuItem_Click(sender, e);
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      while (true)
      {
        process1.Start();

        while (!process1.HasExited)
        {
          string line = process1.StandardError.ReadLine();

          if (backgroundWorker1.CancellationPending)
          {
            return;
          }
          if (line.Contains("Looking for changes"))
          {
            notifyIcon1.Icon = Properties.Resources.SyncingIcon;
          }
          else if (line.Contains("Nothing to do"))
          {
            notifyIcon1.Icon = Properties.Resources.SyncedIcon;
          }
          Invoke(new updateStatusDelegate(updateStatus), line + Environment.NewLine);
        }

        notifyIcon1.Icon = Properties.Resources.ErrorIcon;
        manualResetEvent.WaitOne(10000);
        if (backgroundWorker1.CancellationPending)
        {
          return;
        }
        Invoke(new clearStatusDelegate(clearStatus));
      }
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Close();
    }

    private void updateStatus(string line)
    {
      richTextBox1.AppendText(line);
    }

    private void clearStatus()
    {
      richTextBox1.Clear();
    }
  }
}