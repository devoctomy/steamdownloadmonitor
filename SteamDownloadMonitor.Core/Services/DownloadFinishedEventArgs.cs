using System;

namespace SteamDownloadMonitor.Core.Services
{
    public class DownloadFinishedEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
