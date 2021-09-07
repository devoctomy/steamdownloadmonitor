using System.Collections.Generic;
using System.Linq;

namespace SteamDownloadMonitor.Services
{
    public class AcfFileReader : IAcfFileReader
    {
        public string ReadFirstField(
            IEnumerable<string> fileLines,
            string field)
        {
            var fieldWithQuotes = $"\"{field}\"";
            var fieldLine = fileLines.FirstOrDefault(x => x.Contains(fieldWithQuotes));
            if (fieldLine == null)
            {
                return null;
            }

            fieldLine = fieldLine.Replace(fieldWithQuotes, string.Empty);
            fieldLine = fieldLine.Trim();
            fieldLine = fieldLine.Replace("\"", string.Empty);
            return fieldLine;
        }
    }
}
