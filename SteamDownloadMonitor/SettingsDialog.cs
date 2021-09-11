﻿using SteamDownloadMonitor.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamDownloadMonitor
{
    public partial class SettingsDialog : Form
    {
        private readonly ISteamDownloadMonitorService _streamDownloadMonitorService;
        private readonly Dictionary<string, ToolStripMenuItem> _menuItems;
        private readonly Dictionary<string, ListViewItem> _listViewItems;
        private string _shutdownAppName = string.Empty;
        private bool _isRunning = false;

        public bool AllowVisible { get; set; }
        public bool AllowClose { get; set; }

        public SettingsDialog(ISteamDownloadMonitorService streamDownloadMonitorService)
        {
            _streamDownloadMonitorService = streamDownloadMonitorService;
            _streamDownloadMonitorService.DownloadStarted += _streamDownloadMonitorService_DownloadStarted;
            _streamDownloadMonitorService.DownloadFinished += _streamDownloadMonitorService_DownloadFinished;
            _menuItems = new Dictionary<string, ToolStripMenuItem>();
            _listViewItems = new Dictionary<string, ListViewItem>();
            InitializeComponent();
            _streamDownloadMonitorService.Start();
            ToggleStartStopButton(true);
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

        private void ToggleStartStopButton(bool isStarted)
        {
            StartStopButton.Text = isStarted ? "Stop" : "Start";
            StartStopButton.BackColor = isStarted ? Color.Red : Color.Green;
            _isRunning = isStarted;
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
            
            if(_listViewItems.TryGetValue(e.Name, out var listViewItem))
            {
                DownloadsListView.Items.Remove(listViewItem);
                _listViewItems.Remove(e.Name);
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

            var listViewItem = CreateListViewItem(e.Name);
            DownloadsListView.Items.Add(listViewItem);
            _listViewItems.Add(e.Name, listViewItem);
        }

        private ToolStripMenuItem CreateMenuItem(string name)
        {
            var menuItem = new ToolStripMenuItem(name);
            menuItem.Click += MenuItem_Click;
            return menuItem;
        }

        private ListViewItem CreateListViewItem(string name)
        {
            var listViewItem = new ListViewItem(name);
            return listViewItem;
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

        private async void StartStopButton_Click(object sender, EventArgs e)
        {
            await Task.Yield();
            Invoke((MethodInvoker)async delegate
            {
                StartStopButton.Enabled = false;
                if(_isRunning)
                {
                    await _streamDownloadMonitorService.Stop();
                    ToggleStartStopButton(false);
                }
                else
                {
                    _streamDownloadMonitorService.Start();
                    ToggleStartStopButton(true);
                }
                StartStopButton.Enabled = true;
            });
        }
    }
}
