namespace unison_notifier
{
  partial class statusForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(statusForm));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusRichTextBox = new System.Windows.Forms.RichTextBox();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.unisonProcess = new System.Diagnostics.Process();
      this.notepadProcess = new System.Diagnostics.Process();
      this.reconnectButton = new System.Windows.Forms.Button();
      this.statusLabel = new System.Windows.Forms.Label();
      this.hideButton = new System.Windows.Forms.Button();
      this.disconnectButton = new System.Windows.Forms.Button();
      this.notifyIconContextMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Unison";
      this.notifyIcon.Visible = true;
      this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
      // 
      // notifyIconContextMenuStrip
      // 
      this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
      this.notifyIconContextMenuStrip.Name = "contextMenuStrip1";
      this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(117, 76);
      // 
      // statusToolStripMenuItem
      // 
      this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
      this.statusToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.statusToolStripMenuItem.Text = "Status";
      this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.settingsToolStripMenuItem.Text = "Settings";
      this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // statusRichTextBox
      // 
      this.statusRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.statusRichTextBox.Location = new System.Drawing.Point(19, 26);
      this.statusRichTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
      this.statusRichTextBox.Name = "statusRichTextBox";
      this.statusRichTextBox.ReadOnly = true;
      this.statusRichTextBox.Size = new System.Drawing.Size(530, 270);
      this.statusRichTextBox.TabIndex = 0;
      this.statusRichTextBox.Text = "";
      this.statusRichTextBox.WordWrap = false;
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.WorkerSupportsCancellation = true;
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      // 
      // unisonProcess
      // 
      this.unisonProcess.StartInfo.CreateNoWindow = true;
      this.unisonProcess.StartInfo.Domain = "";
      this.unisonProcess.StartInfo.FileName = "unison.exe";
      this.unisonProcess.StartInfo.LoadUserProfile = false;
      this.unisonProcess.StartInfo.Password = null;
      this.unisonProcess.StartInfo.RedirectStandardError = true;
      this.unisonProcess.StartInfo.StandardErrorEncoding = null;
      this.unisonProcess.StartInfo.StandardOutputEncoding = null;
      this.unisonProcess.StartInfo.UserName = "";
      this.unisonProcess.StartInfo.UseShellExecute = false;
      this.unisonProcess.SynchronizingObject = this;
      // 
      // notepadProcess
      // 
      this.notepadProcess.StartInfo.Domain = "";
      this.notepadProcess.StartInfo.FileName = "notepad.exe";
      this.notepadProcess.StartInfo.LoadUserProfile = false;
      this.notepadProcess.StartInfo.Password = null;
      this.notepadProcess.StartInfo.StandardErrorEncoding = null;
      this.notepadProcess.StartInfo.StandardOutputEncoding = null;
      this.notepadProcess.StartInfo.UserName = "";
      this.notepadProcess.SynchronizingObject = this;
      // 
      // reconnectButton
      // 
      this.reconnectButton.Location = new System.Drawing.Point(144, 312);
      this.reconnectButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.reconnectButton.Name = "reconnectButton";
      this.reconnectButton.Size = new System.Drawing.Size(110, 23);
      this.reconnectButton.TabIndex = 1;
      this.reconnectButton.Text = "Reconnect";
      this.reconnectButton.UseVisualStyleBackColor = true;
      this.reconnectButton.Click += new System.EventHandler(this.reconnectButton_Click);
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Location = new System.Drawing.Point(16, 6);
      this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(97, 13);
      this.statusLabel.TabIndex = 2;
      this.statusLabel.Text = "Status: Connecting";
      // 
      // hideButton
      // 
      this.hideButton.Location = new System.Drawing.Point(439, 312);
      this.hideButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.hideButton.Name = "hideButton";
      this.hideButton.Size = new System.Drawing.Size(110, 23);
      this.hideButton.TabIndex = 3;
      this.hideButton.Text = "Hide";
      this.hideButton.UseVisualStyleBackColor = true;
      this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
      // 
      // disconnectButton
      // 
      this.disconnectButton.Location = new System.Drawing.Point(19, 312);
      this.disconnectButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.disconnectButton.Name = "disconnectButton";
      this.disconnectButton.Size = new System.Drawing.Size(110, 23);
      this.disconnectButton.TabIndex = 4;
      this.disconnectButton.Text = "Disconnect";
      this.disconnectButton.UseVisualStyleBackColor = true;
      this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
      // 
      // statusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(569, 341);
      this.Controls.Add(this.disconnectButton);
      this.Controls.Add(this.hideButton);
      this.Controls.Add(this.statusLabel);
      this.Controls.Add(this.reconnectButton);
      this.Controls.Add(this.statusRichTextBox);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "statusForm";
      this.ShowInTaskbar = false;
      this.Text = "Unison";
      this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.notifyIconContextMenuStrip.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.RichTextBox statusRichTextBox;
    private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Diagnostics.Process unisonProcess;
    private System.Diagnostics.Process notepadProcess;
    private System.Windows.Forms.Button reconnectButton;
    private System.Windows.Forms.Button hideButton;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.Button disconnectButton;
  }
}

