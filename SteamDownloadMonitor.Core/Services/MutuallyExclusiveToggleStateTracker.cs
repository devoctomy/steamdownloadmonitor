using System.Collections.Generic;

namespace SteamDownloadMonitor.Core.Services
{
    public class MutuallyExclusiveToggleStateTracker : IMutuallyExclusiveToggleStateTracker
    {
        private List<string> _items;
        private string _selectedName = string.Empty;

        public MutuallyExclusiveToggleStateTracker()
        {
            _items = new List<string>();
        }

        public void AddItem(string name)
        {
            _items.Add(name);
        }

        public bool GetItemState(string name)
        {
            CheckItemExists(name);

            return _selectedName == name;
        }

        public void RemoveItem(string name)
        {
            CheckItemExists(name);

            _items.Remove(name);
        }

        public bool ToggleItemState(string name)
        {
            CheckItemExists(name);

            if (_selectedName == name)
            {
                _selectedName = string.Empty;
                return false;
            }

            _selectedName = name;
            return true;
        }

        public void SetItemState(
            string name,
            bool state)
        {
            CheckItemExists(name);

            if (state)
            {
                _selectedName = name;
                return;
            }

            if(_selectedName == name)
            {
                _selectedName = string.Empty;
            }
        }

        public string GetSelected()
        {
            return _selectedName;
        }

        private void CheckItemExists(string name)
        {
            if(!_items.Contains(name))
            {
                throw new KeyNotFoundException($"Item with the name '{name}' was not found.");
            }
        }
    }
}
