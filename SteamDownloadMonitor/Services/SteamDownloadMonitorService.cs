using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SteamDownloadMonitor.Services
{
    public class SteamDownloadMonitorService : ISteamDownloadMonitorService
    {
        public event EventHandler<DownloadStartedEventArgs> DownloadStarted;
        public event EventHandler<DownloadFinishedEventArgs> DownloadFinished;

        private readonly SteamDownloadMonitorServiceConfig _config;
        private readonly IAcfFileReader _acfFileReader;
        private readonly List<string> _downloading;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _monitoring;

        public SteamDownloadMonitorService(
            SteamDownloadMonitorServiceConfig config,
            IAcfFileReader acfFileReader)
        {
            _config = config;
            _acfFileReader = acfFileReader;
            _downloading = new List<string>();
        }

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _monitoring = DoStart(_cancellationTokenSource.Token);
        }

        public async Task Stop()
        {
            _cancellationTokenSource.Cancel();
            await _monitoring;
        }

        private async Task DoStart(CancellationToken cancellationToken)
        {
            await Task.Yield();
            while(!cancellationToken.IsCancellationRequested)
            {
                CheckDownloadQueue();
                await Task.Delay(_config.CheckInterval);
            }
        }

        private void CheckDownloadQueue()
        {
            var checkedApps = new List<string>();
            var files = Directory.GetFiles(_config.SteamAppsPath, "*.acf");
            foreach (var curFile in files)
            {
                var allLines = File.ReadLines(curFile).ToList();
                var name = _acfFileReader.ReadFirstField(allLines, "name");
                checkedApps.Add(name);
                var bytesToDownloadValue = _acfFileReader.ReadFirstField(allLines, "BytesToDownload");
                var bytesDownloadedValue = _acfFileReader.ReadFirstField(allLines, "BytesDownloaded");
                if (bytesToDownloadValue != null && bytesDownloadedValue != null)
                {
                    long bytesToDownload = long.Parse(bytesToDownloadValue);
                    long bytesDownloaded = long.Parse(bytesDownloadedValue);
                    if (bytesToDownload - bytesDownloaded > 0)
                    {
                        Console.WriteLine($"{name} is currently downloading...");
                        if (!_downloading.Contains(name))
                        {
                            DownloadStarted?.Invoke(this, new DownloadStartedEventArgs { Name = name });
                            _downloading.Add(name);
                        }
                    }
                    else
                    {
                        if (_downloading.Contains(name))
                        {
                            DownloadFinished?.Invoke(this, new DownloadFinishedEventArgs { Name = name });
                            _downloading.Remove(name);
                        }
                    }
                }
            }

            var notChecked = _downloading.Where(x => !checkedApps.Contains(x)).ToList();
            foreach(var curApp in notChecked)
            {
                DownloadFinished?.Invoke(this, new DownloadFinishedEventArgs { Name = curApp });
                _downloading.Remove(curApp);
            }
        }
    }
}
