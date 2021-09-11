using SteamDownloadMonitor.Core.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SteamDownloadMonitor.Core.UnitTests.Services
{
    public class SteamDownloadMonitorServiceTests
    {
        [Fact]
        [TestIsolatedOutputDirectory("output/GivenConfig_AndServiceStarted_WhenAppAdded_ThenDownloadStartedRaised")]
        public async Task GivenConfig_AndServiceStarted_WhenAppAdded_ThenDownloadStartedRaised()
        {
            // Arrange
            var outputDir = "output/GivenConfig_AndServiceStarted_WhenAppAdded_ThenDownloadStartedRaised";
            var config = new SteamDownloadMonitorServiceConfig
            {
                SteamAppsPath = outputDir,
                CheckInterval = 1000
            };
            var sut = new SteamDownloadMonitorService(
                config,
                new AcfFileReader());
            var manualResetEvent = new ManualResetEvent(false);
            var startedName = string.Empty;
            sut.DownloadStarted += delegate (object sender, DownloadStartedEventArgs e) {
                manualResetEvent.Set();
                startedName = e.Name;
            };
            sut.Start();

            // Act
            await CreateAcfFileFromTemplate(
                "appmanifest_limitedtemplate.acf",
                $"{outputDir}/appmanifest_000000.acf",
                new Dictionary<string, string>
                {
                    { "$name", "Hello World!" },
                    { "$BytesToDownload", "100" },
                    { "$BytesDownloaded", "0" }
                });
            var downloadStarted = manualResetEvent.WaitOne(2000);
            await sut.Stop();

            // Assert
            Assert.True(downloadStarted);
            Assert.Equal("Hello World!", startedName);
        }

        [Fact]
        [TestIsolatedOutputDirectory("output/GivenConfig_AndServiceStarted_WhenAppAdded_ThenDownloadStartedRaised")]
        public async Task GivenConfig_AndServiceStarted_WhenAppFinishedDownloading_ThenDownloadFinishedRaised()
        {
            // Arrange
            var outputDir = "output/GivenConfig_AndServiceStarted_WhenAppAdded_ThenDownloadStartedRaised";
            var config = new SteamDownloadMonitorServiceConfig
            {
                SteamAppsPath = outputDir,
                CheckInterval = 1000
            };
            var sut = new SteamDownloadMonitorService(
                config,
                new AcfFileReader());
            var manualResetEvent = new ManualResetEvent(false);
            var finishedName = string.Empty;
            sut.DownloadFinished += delegate (object sender, DownloadFinishedEventArgs e) {
                manualResetEvent.Set();
                finishedName = e.Name;
            };
            await CreateAcfFileFromTemplate(
                "appmanifest_limitedtemplate.acf",
                $"{outputDir}/appmanifest_000001.acf",
                new Dictionary<string, string>
                {
                    { "$name", "Hello World!" },
                    { "$BytesToDownload", "100" },
                    { "$BytesDownloaded", "0" }
                });
            sut.Start();

            // Act
            await Task.Delay(100);
            await CreateAcfFileFromTemplate(
                "appmanifest_limitedtemplate.acf",
                $"{outputDir}/appmanifest_000001.acf",
                new Dictionary<string, string>
                {
                    { "$name", "Hello World!" },
                    { "$BytesToDownload", "100" },
                    { "$BytesDownloaded", "100" }
                });
            var downloadFinished = manualResetEvent.WaitOne(2000);
            await sut.Stop();

            // Assert
            Assert.True(downloadFinished);
            Assert.Equal("Hello World!", finishedName);
        }

        private async Task CreateAcfFileFromTemplate(
            string templateName,
            string outputFileName,
            Dictionary<string, string> fields)
        {
            var fileData = await File.ReadAllTextAsync($"Data/{templateName}");
            foreach(var curFieldKey in fields.Keys)
            {
                fileData = fileData.Replace(curFieldKey, fields[curFieldKey]);
            }
            await File.WriteAllTextAsync(
                outputFileName,
                fileData);
        }
    }
}
