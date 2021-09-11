
namespace SteamDownloadMonitor
{
    partial class SettingsDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadsListView = new System.Windows.Forms.ListView();
            this.DownloadName = new System.Windows.Forms.ColumnHeader();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContextMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Steam Download Manager";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(94, 32);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(90, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // DownloadsListView
            // 
            this.DownloadsListView.CheckBoxes = true;
            this.DownloadsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DownloadName});
            this.DownloadsListView.HideSelection = false;
            this.DownloadsListView.Location = new System.Drawing.Point(12, 12);
            this.DownloadsListView.Name = "DownloadsListView";
            this.DownloadsListView.Size = new System.Drawing.Size(286, 255);
            this.DownloadsListView.TabIndex = 1;
            this.DownloadsListView.UseCompatibleStateImageBehavior = false;
            this.DownloadsListView.View = System.Windows.Forms.View.Details;
            this.DownloadsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.DownloadsListView_ItemChecked);
            // 
            // DownloadName
            // 
            this.DownloadName.Text = "Name";
            this.DownloadName.Width = 200;
            // 
            // StartStopButton
            // 
            this.StartStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartStopButton.Location = new System.Drawing.Point(12, 284);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(104, 34);
            this.StartStopButton.TabIndex = 2;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = false;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 330);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.DownloadsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.Text = "Steam Download Monitor";
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView DownloadsListView;
        private System.Windows.Forms.ColumnHeader DownloadName;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Button button1;
    }
}

