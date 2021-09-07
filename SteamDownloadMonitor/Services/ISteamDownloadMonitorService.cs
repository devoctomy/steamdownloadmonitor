﻿using System;
using System.Threading.Tasks;

namespace SteamDownloadMonitor.Services
{
    public interface ISteamDownloadMonitorService
    {
        event EventHandler<DownloadStartedEventArgs> DownloadStarted;
        event EventHandler<DownloadFinishedEventArgs> DownloadFinished;

        void Start();
        Task Stop();
    }
}
