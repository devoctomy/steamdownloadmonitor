using SteamDownloadMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace SteamDownloadMonitor
{
    public partial class SettingsDialog : Form
    {
        private readonly ISteamDownloadMonitorService _streamDownloadMonitorService;
        private readonly Dictionary<string, ToolStripMenuItem> _menuItems;
        private string _shutdownAppName = string.Empty;

        public bool AllowVisible { get; set; }
        public bool AllowClose { get; set; }

        public SettingsDialog(ISteamDownloadMonitorService streamDownloadMonitorService)
        {
            _streamDownloadMonitorService = streamDownloadMonitorService;
            _streamDownloadMonitorService.DownloadStarted += _streamDownloadMonitorService_DownloadStarted;
            _streamDownloadMonitorService.DownloadFinished += _streamDownloadMonitorService_DownloadFinished;
            _menuItems = new Dictionary<string, ToolStripMenuItem>();
            InitializeComponent();
            _streamDownloadMonitorService.Start();
        }

        public void ToggleAppShutDownWhenFinished(string name)
        {
            if(!string.IsNullOrEmpty(_shutdownAppName))
            {
                if (_menuItems.TryGetValue(_shutdownAppName, out var currentMenuItem))
                {
                    currentMenuItem.Checked = false;
                    _shutdownAppName = string.Empty;
                }
            }

            if (_menuItems.TryGetValue(name, out var newMenuItem))
            {
                newMenuItem.Checked = !newMenuItem.Checked;
                _shutdownAppName = newMenuItem.Checked ? name : string.Empty;
            }
        }

        private void _streamDownloadMonitorService_DownloadFinished(
            object sender,
            DownloadFinishedEventArgs e)
        {
            if( _menuItems.TryGetValue(e.Name, out var menuItem ))
            {
                ContextMenu.Items.Remove(menuItem);
                _menuItems.Remove(e.Name);
            }
            TestAndPerformShutdown(e.Name);
        }

        private void _streamDownloadMonitorService_DownloadStarted(
            object sender,
            DownloadStartedEventArgs e)
        {
            var menuItem = CreateMenuItem(e.Name);
            ContextMenu.Items.Insert(0, menuItem);
            _menuItems.Add(e.Name, menuItem);
        }

        private ToolStripMenuItem CreateMenuItem(string name)
        {
            var menuItem = new ToolStripMenuItem(name);
            menuItem.Click += MenuItem_Click;
            return menuItem;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            ToggleAppShutDownWhenFinished(menuItem.Text);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(AllowVisible ? value : AllowVisible);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !AllowClose;
            base.OnClosing(e);
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            AllowVisible = !AllowVisible;
            Visible = !Visible;
        }

        private async void exitToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            AllowClose = true;
            await _streamDownloadMonitorService.Stop();
            Close();
        }

        private void TestAndPerformShutdown(string name)
        {
            if(name.Equals(_shutdownAppName))
            {
                //Display warning dialog first to give the opportunity to cancel shutdown

                var psi = new ProcessStartInfo("shutdown", "/s /t 0")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi);
            }
        }
    }
}
