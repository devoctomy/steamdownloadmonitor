using System.Collections.Generic;

namespace SteamDownloadMonitor.Core.Services
{
    public interface IAcfFileReader
    {
        string ReadFirstField(
            IEnumerable<string> fileLines,
            string field);
    }
}
