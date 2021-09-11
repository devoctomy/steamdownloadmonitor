using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamDownloadMonitor
{
    public partial class ShutdownWarningDialog : Form
    {
        private readonly System.Timers.Timer _timer;
        private int _delaySecondsRemaining;

        public ShutdownWarningDialog()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                if (_delaySecondsRemaining > 0)
                {
                    _delaySecondsRemaining -= 1;
                    RemainingSecondsLabel.Text = _delaySecondsRemaining.ToString();
                    return;
                }

                _timer.Stop();
                DialogResult = DialogResult.OK;
            });
        }

        public DialogResult ShowTimedDialog(int delaySeconds)
        {
            Location = new Point(0, 0);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            LayoutPanel.Location = new Point(
                (Width / 2) - (LayoutPanel.Width / 2),
                (Height / 2) - (LayoutPanel.Height / 2));
            _delaySecondsRemaining = delaySeconds;
            RemainingSecondsLabel.Text = _delaySecondsRemaining.ToString();
            return ShowDialog();
        }

        private void ShutdownWarningDialog_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
            {
                _timer.Start();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            DialogResult = DialogResult.Cancel;
        }

        private void ShutdownWarningDialog_Resize(object sender, EventArgs e)
        {
            LayoutTable.Location = new Point(
                (Bounds.Width / 2) - (LayoutTable.Width / 2),
                (Bounds.Height / 2) - (LayoutTable.Height / 2));
        }
    }
}
