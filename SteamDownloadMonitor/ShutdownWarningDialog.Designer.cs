
namespace SteamDownloadMonitor
{
    partial class ShutdownWarningDialog
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
            this.Cancel = new System.Windows.Forms.Button();
            this.RemainingSecondsLabel = new System.Windows.Forms.Label();
            this.LayoutPanel = new System.Windows.Forms.Panel();
            this.LayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.LayoutTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel.Location = new System.Drawing.Point(3, 187);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(293, 90);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RemainingSecondsLabel
            // 
            this.RemainingSecondsLabel.AutoSize = true;
            this.RemainingSecondsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemainingSecondsLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemainingSecondsLabel.ForeColor = System.Drawing.Color.Red;
            this.RemainingSecondsLabel.Location = new System.Drawing.Point(3, 64);
            this.RemainingSecondsLabel.Name = "RemainingSecondsLabel";
            this.RemainingSecondsLabel.Size = new System.Drawing.Size(293, 120);
            this.RemainingSecondsLabel.TabIndex = 1;
            this.RemainingSecondsLabel.Text = "00";
            this.RemainingSecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Controls.Add(this.LayoutTable);
            this.LayoutPanel.Location = new System.Drawing.Point(355, 147);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Size = new System.Drawing.Size(299, 280);
            this.LayoutPanel.TabIndex = 2;
            // 
            // LayoutTable
            // 
            this.LayoutTable.ColumnCount = 1;
            this.LayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutTable.Controls.Add(this.WarningLabel, 0, 0);
            this.LayoutTable.Controls.Add(this.RemainingSecondsLabel, 0, 1);
            this.LayoutTable.Controls.Add(this.Cancel, 0, 2);
            this.LayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutTable.Location = new System.Drawing.Point(0, 0);
            this.LayoutTable.Name = "LayoutTable";
            this.LayoutTable.RowCount = 3;
            this.LayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.LayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.LayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.LayoutTable.Size = new System.Drawing.Size(299, 280);
            this.LayoutTable.TabIndex = 0;
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WarningLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WarningLabel.ForeColor = System.Drawing.Color.White;
            this.WarningLabel.Location = new System.Drawing.Point(3, 0);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(293, 64);
            this.WarningLabel.TabIndex = 2;
            this.WarningLabel.Text = "Your computer will shut down when the timer reaches 0. Press \'Cancel\' to abort.";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShutdownWarningDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(998, 658);
            this.Controls.Add(this.LayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShutdownWarningDialog";
            this.Opacity = 0.75D;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ShutdownWarning";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.ShutdownWarningDialog_VisibleChanged);
            this.Resize += new System.EventHandler(this.ShutdownWarningDialog_Resize);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutTable.ResumeLayout(false);
            this.LayoutTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label RemainingSecondsLabel;
        private System.Windows.Forms.Panel LayoutPanel;
        private System.Windows.Forms.TableLayoutPanel LayoutTable;
        private System.Windows.Forms.Label WarningLabel;
    }
}