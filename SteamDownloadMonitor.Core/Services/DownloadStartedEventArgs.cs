using System;

namespace SteamDownloadMonitor.Core.Services
{
    public class DownloadStartedEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
