using System;

namespace SteamDownloadMonitor.Services
{
    public class DownloadStartedEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
