using System.Collections.Generic;

namespace SteamDownloadMonitor.Services
{
    public interface IAcfFileReader
    {
        string ReadFirstField(
            IEnumerable<string> fileLines,
            string field);
    }
}
