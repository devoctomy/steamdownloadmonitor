using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamDownloadMonitor.Core.Services
{
    public interface IMutuallyExclusiveToggleStateTracker
    {
        void AddItem(string name);
        void RemoveItem(string name);
        bool GetItemState(string name);
        bool ToggleItemState(string name);
        void SetItemState(
            string name,
            bool state);
        string GetSelected();
    }
}
