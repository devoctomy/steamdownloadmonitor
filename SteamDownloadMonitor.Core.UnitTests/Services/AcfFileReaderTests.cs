using SteamDownloadMonitor.Core.Services;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SteamDownloadMonitor.Core.UnitTests.Services
{
    public class AcfFileReaderTests
    {

        [Theory]
        [InlineData("Data/appmanifest_000001.acf", "appid", "000001")]
        [InlineData("Data/appmanifest_000001.acf", "Universe", "1")]
        [InlineData("Data/appmanifest_000001.acf", "LauncherPath", @"C:\\Program Files (x86)\\Steam\\steam.exe")]
        [InlineData("Data/appmanifest_000001.acf", "name", "Some Game")]
        [InlineData("Data/appmanifest_000001.acf", "StateFlags", "4")]
        [InlineData("Data/appmanifest_000001.acf", "installdir", "Some Game")]
        [InlineData("Data/appmanifest_000001.acf", "LastUpdated", "1629042284")]
        [InlineData("Data/appmanifest_000001.acf", "UpdateResult", "0")]
        [InlineData("Data/appmanifest_000001.acf", "SizeOnDisk", "54945651331")]
        [InlineData("Data/appmanifest_000001.acf", "buildid", "5979231")]
        [InlineData("Data/appmanifest_000001.acf", "LastOwner", "76561198035876811")]
        [InlineData("Data/appmanifest_000001.acf", "BytesToDownload", "55382650464")]
        [InlineData("Data/appmanifest_000001.acf", "BytesDownloaded", "55382650464")]
        [InlineData("Data/appmanifest_000001.acf", "BytesToStage", "54945651331")]
        [InlineData("Data/appmanifest_000001.acf", "BytesStaged", "54945651331")]
        [InlineData("Data/appmanifest_000001.acf", "AutoUpdateBehavior", "0")]
        [InlineData("Data/appmanifest_000001.acf", "AllowOtherDownloadsWhileRunning", "0")]
        [InlineData("Data/appmanifest_000001.acf", "ScheduledAutoUpdate", "0")]
        public async Task GivenActFileLines_AndTopLevelField_ThenCorrectValueReturned(
            string appFileName,
            string topLevelFieldName,
            string expectedValue)
        {
            // Arrange
            var appFileLines = await File.ReadAllLinesAsync(appFileName);
            var sut = new AcfFileReader();

            // Act
            var value = sut.ReadFirstField(
                appFileLines.ToList(),
                topLevelFieldName);

            // Assert
            Assert.Equal(expectedValue, value);
        }

    }
}
