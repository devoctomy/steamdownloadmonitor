using System;

namespace SteamDownloadMonitor.Services
{
    public class DownloadFinishedEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
