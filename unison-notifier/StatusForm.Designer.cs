namespace UnisonNotifier
{
  partial class StatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.UnisonProcess = new System.Diagnostics.Process();
            this.NotepadProcess = new System.Diagnostics.Process();
            this.ReconnectButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.HideButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Unison";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // NotifyIconContextMenuStrip
            // 
            this.NotifyIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.NotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.NotifyIconContextMenuStrip.Name = "contextMenuStrip1";
            this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(204, 148);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(203, 46);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.StatusToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(203, 46);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(203, 46);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // StatusRichTextBox
            // 
            this.StatusRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatusRichTextBox.Location = new System.Drawing.Point(51, 62);
            this.StatusRichTextBox.Margin = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.StatusRichTextBox.Name = "StatusRichTextBox";
            this.StatusRichTextBox.ReadOnly = true;
            this.StatusRichTextBox.Size = new System.Drawing.Size(1407, 638);
            this.StatusRichTextBox.TabIndex = 0;
            this.StatusRichTextBox.Text = "";
            this.StatusRichTextBox.WordWrap = false;
            // 
            // UnisonProcess
            // 
            this.UnisonProcess.StartInfo.CreateNoWindow = true;
            this.UnisonProcess.StartInfo.Domain = "";
            this.UnisonProcess.StartInfo.FileName = "unison.exe";
            this.UnisonProcess.StartInfo.LoadUserProfile = false;
            this.UnisonProcess.StartInfo.Password = null;
            this.UnisonProcess.StartInfo.RedirectStandardError = true;
            this.UnisonProcess.StartInfo.StandardErrorEncoding = null;
            this.UnisonProcess.StartInfo.StandardOutputEncoding = null;
            this.UnisonProcess.StartInfo.UserName = "";
            this.UnisonProcess.StartInfo.UseShellExecute = false;
            this.UnisonProcess.SynchronizingObject = this;
            // 
            // NotepadProcess
            // 
            this.NotepadProcess.StartInfo.Domain = "";
            this.NotepadProcess.StartInfo.FileName = "notepad.exe";
            this.NotepadProcess.StartInfo.LoadUserProfile = false;
            this.NotepadProcess.StartInfo.Password = null;
            this.NotepadProcess.StartInfo.StandardErrorEncoding = null;
            this.NotepadProcess.StartInfo.StandardOutputEncoding = null;
            this.NotepadProcess.StartInfo.UserName = "";
            this.NotepadProcess.SynchronizingObject = this;
            // 
            // ReconnectButton
            // 
            this.ReconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReconnectButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ReconnectButton.Location = new System.Drawing.Point(384, 744);
            this.ReconnectButton.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.ReconnectButton.Name = "ReconnectButton";
            this.ReconnectButton.Size = new System.Drawing.Size(293, 55);
            this.ReconnectButton.TabIndex = 2;
            this.ReconnectButton.Text = "Reconnect";
            this.ReconnectButton.UseVisualStyleBackColor = true;
            this.ReconnectButton.Click += new System.EventHandler(this.ReconnectButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(43, 14);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(256, 32);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "Status: Connecting";
            // 
            // HideButton
            // 
            this.HideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HideButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HideButton.Location = new System.Drawing.Point(1171, 744);
            this.HideButton.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(293, 55);
            this.HideButton.TabIndex = 3;
            this.HideButton.Text = "Hide";
            this.HideButton.UseVisualStyleBackColor = true;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DisconnectButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DisconnectButton.Location = new System.Drawing.Point(51, 744);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(293, 55);
            this.DisconnectButton.TabIndex = 1;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 813);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.HideButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ReconnectButton);
            this.Controls.Add(this.StatusRichTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(1080, 236);
            this.Name = "StatusForm";
            this.ShowInTaskbar = false;
            this.Text = "Unison";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusForm_FormClosing);
            this.Load += new System.EventHandler(this.StatusForm_Load);
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon NotifyIcon;
    private System.Windows.Forms.RichTextBox StatusRichTextBox;
    private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Diagnostics.Process UnisonProcess;
    private System.Diagnostics.Process NotepadProcess;
    private System.Windows.Forms.Button ReconnectButton;
    private System.Windows.Forms.Button HideButton;
    private System.Windows.Forms.Label StatusLabel;
    private System.Windows.Forms.Button DisconnectButton;
  }
}

