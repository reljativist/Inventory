using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Main logic file for test task of implementing game inventory. 
 * Other files in this solution contain helpers to demonstrate this inventory implementation. */

 namespace Inventory
{
    enum InventoryItemType
    {
        Consumable,
        Euipment,
        Trash,
    }

    enum InventoryItemActions
    {
        Use,
        Sell,
        Drop,
    }

    class InventoryItem
    {
        InventoryItemType _type;
        int _id;
        string _name;
        int _price;
        int _maxStackSize;
        bool _quest;
        Bitmap _icon;

        public InventoryItem(InventoryItemType itemType, int itemId, string itemName, int itemPrice, int itemMaxStackSize, Bitmap icon, bool isQuestItem = false)
        {
            _type = itemType;
            _id = itemId;
            _name = itemName;
            _price = itemPrice;
            _maxStackSize = itemMaxStackSize;
            _icon = icon;
            _quest = isQuestItem;
        }

        public InventoryItemType Type { get { return _type; } }
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public int MaxStackSize { get { return _maxStackSize; } }
        public bool Quest { get { return _quest; } }
        public Bitmap Icon { get { return _icon; } }

        public List<InventoryItemActions> GetItemActions()
        {
            List<InventoryItemActions> availableActions = new List<InventoryItemActions>();
            if (_type == InventoryItemType.Consumable || _type == InventoryItemType.Euipment)
                availableActions.Add(InventoryItemActions.Use);

            if (!_quest)
            {
                availableActions.Add(InventoryItemActions.Sell);
                availableActions.Add(InventoryItemActions.Drop);
            }

            return availableActions;
        }
    }

    class InventoryCell
    {
        public int ItemId;
        public int ItemsCount;
    }

    class Inventory
    {
        enum SortType
        {
            Unsorted,
            Price,
            Type,
        }

        // We have same sorting type but with different conditions - so I'm setting custom conditions
        delegate bool SortCondition(InventoryCell a, InventoryCell b);
        
        InventoryCell[] _cells;
        SortType _currentSort;
        int _equippedItemId;

        public Inventory()
        {
            _equippedItemId = -1;
            _currentSort = SortType.Unsorted;
            _cells = new InventoryCell[DummySettings.CellsMaxAmount];
            for (int i = 0; i < DummySettings.CellsMaxAmount; i++)
                _cells[i] = new InventoryCell() { ItemId = -1, ItemsCount = 0 };
        }

        public int EquippedItemId { get { return _equippedItemId; } }

        public void ApplyActionToItemInCell(InventoryItemActions action, int cellId)
        {
            InventoryItem item = DummySettings.GetItemById(_cells[cellId].ItemId);
            if (item.GetItemActions().Exists(a => a == action))
            {
                switch (action)
                {
                    case InventoryItemActions.Use:
                        UseItemFromCell(cellId);
                        break;
                    case InventoryItemActions.Sell:
                        // Some sell item event call
                        //..
                        RemoveItemsByCell(cellId, 1);
                        break;
                    case InventoryItemActions.Drop:
                        // Some drop item event call
                        //..
                        RemoveItemsByCell(cellId, 1);
                        break;
                }
            }
        }

        public InventoryCell[] GetCellsContent()
        {
            InventoryCell[] cellsCopy = new InventoryCell[_cells.Length];
            Array.Copy(_cells, cellsCopy, _cells.Length);

            return cellsCopy;
        }

        public void AddItem(int itemId, int amount)
        {
            InventoryItem item = DummySettings.GetItemById(itemId);
            if (item.Quest && item.MaxStackSize == 1 && Array.FindIndex(_cells, c => c.ItemId == itemId) > -1)
            {
                Console.WriteLine("Cannot add quest item " + item.Name + ": non-stackable");
                return;
            }

            InventoryCell[] cells = Array.FindAll(_cells, c => c.ItemId == itemId && c.ItemsCount < item.MaxStackSize);
            if (cells.Length > 0)
            {
                SortByCondition(cells, CompareCount);

                for (int i = 0; i < cells.Length; i++)
                {
                    InventoryCell cell = cells[i];
                    int free = item.MaxStackSize - cell.ItemsCount;
                    cell.ItemsCount += amount <= free ? amount : free;
                    amount -= free;
                    if (amount <= 0)
                        break;
                }
            }
            else
            {
                for (int i = 0; i < _cells.Length; i++)
                {
                    InventoryCell cell = _cells[i];
                    if (cell.ItemsCount > 0)
                        continue;
                    else
                        cell.ItemId = itemId;

                    int free = item.MaxStackSize - cell.ItemsCount;
                    cell.ItemsCount += amount <= free ? amount : free;
                    amount -= free;
                    if (amount <= 0)
                        break;
                }
            }
        }

        // Debug function
        public void PrintInventory()
        {
            Console.WriteLine("--Print Inventory Content--");
            for (int i = 0; i < _cells.Length; i++)
            {
                if (_cells[i].ItemsCount > 0)
                {
                    InventoryItem item = DummySettings.GetItemById(_cells[i].ItemId);
                    Console.WriteLine("Cell " + i.ToString() + " contains " + item.Name);
                }
                else
                {
                    Console.WriteLine("Cell " + i.ToString() + " is empty");
                }
            }
        }

        public void ClearCell(int cellId)
        {
            _cells[cellId].ItemId = -1;
            _cells[cellId].ItemsCount = 0;
            UpdateCurrentSorting();
            UpdateEquipment();
        }

        public void RemoveItemsByCell(int cellId, int amount)
        {
            InventoryCell cell = _cells[cellId];
            cell.ItemsCount = (cell.ItemsCount > amount) ? cell.ItemsCount - amount : 0;
            if (cell.ItemsCount < 1)
            {
                cell.ItemId = -1;
                UpdateCurrentSorting();
            }
            UpdateEquipment();
        }

        public void RemoveItemsById(int itemId, int amount)
        {
            InventoryCell[] cells = Array.FindAll(_cells, c => c.ItemId == itemId && c.ItemsCount > 0);
            SortByCondition(cells, CompareCount);
            for (int i = cells.Length - 1; i >= 0; i--)
            {
                InventoryCell cell = cells[i];
                int count = cell.ItemsCount;
                cell.ItemsCount = count > amount ? count - amount : 0;
                amount -= count;
                if (amount <= 0)
                    break;
            }
            UpdateCurrentSorting();
            UpdateEquipment();
        }

        public void MoveItemToCell(int sourceCellId, int destCellId)
        {
            _currentSort = SortType.Unsorted;

            InventoryCell source = _cells[sourceCellId];
            InventoryCell dest = _cells[destCellId];

            if (dest.ItemsCount > 0)
            {
                if (source.ItemId == dest.ItemId) // If we have same items in this cells - we exchange numbers until stack is full
                {
                    InventoryItem item = DummySettings.GetItemById(source.ItemId);
                    int free = item.MaxStackSize - dest.ItemsCount;
                    dest.ItemsCount += free;
                    source.ItemsCount = source.ItemsCount > free ? source.ItemsCount - free : 0;
                }
                else
                {
                    int itemId = dest.ItemId;
                    int itemsCount = dest.ItemsCount;
                    dest.ItemId = source.ItemId;
                    dest.ItemsCount = source.ItemsCount;
                    source.ItemId = itemId;
                    source.ItemsCount = itemsCount;
                }
            }
            else
            {
                dest.ItemId = source.ItemId;
                dest.ItemsCount = source.ItemsCount;
                source.ItemId = -1;
                source.ItemsCount = 0;
            }
        }

        public Dictionary<InventoryItemActions, string> GetContextMenuActions(int cellId)
        {
            InventoryCell cell = _cells[cellId];
            if (cell.ItemsCount > 0)
            {
                InventoryItem item = DummySettings.GetItemById(cell.ItemId);
                List<InventoryItemActions> actions = item.GetItemActions();
                Dictionary<InventoryItemActions, string> actionDescs = new Dictionary<InventoryItemActions, string>();

                foreach (InventoryItemActions action in actions)
                {
                    switch (action)
                    {
                        case InventoryItemActions.Use:
                            actionDescs[action] = "Use " + item.Name;
                            break;
                        case InventoryItemActions.Sell:
                            int price = item.Price * cell.ItemsCount;
                            string amountInfo = cell.ItemsCount > 1 ? "(" + cell.ItemsCount.ToString() + ")" : "";
                            actionDescs[action] = "Sell " + item.Name + amountInfo + " for " + price.ToString();
                            break;
                        case InventoryItemActions.Drop:
                            actionDescs[action] = "Drop " + item.Name;
                            break;
                    }
                }

                return actionDescs;
            }

            return null;
        }

        public void SortByPrice()
        {
            _currentSort = SortType.Price;
            SortByCondition(_cells, ComparePrice);
        }

        public void SortByType()
        {
            _currentSort = SortType.Type;
            SortByCondition(_cells, CompareType);
        }

        void UseItemFromCell(int cellId)
        {
            InventoryCell cell = _cells[cellId];
            InventoryItem item = DummySettings.GetItemById(cell.ItemId);

            switch (item.Type)
            {
                case InventoryItemType.Consumable:
                    // Todo: invoke event to inform the system about used consumable
                    //..
                    RemoveItemsByCell(cellId, 1);
                    break;
                case InventoryItemType.Euipment:
                    _equippedItemId = item.Id;
                    // Todo: invoke event to inform the system about equipped item
                    break;
            }
        }

        void UpdateEquipment()
        {
            if (_equippedItemId > -1 && Array.FindIndex(_cells, c => c.ItemId == _equippedItemId) == -1)
                _equippedItemId = -1;
        }

        void UpdateCurrentSorting()
        {
            switch (_currentSort)
            {
                case SortType.Price:
                    SortByPrice();
                    break;
                case SortType.Type:
                    SortByType();
                    break;
            }
        }

        bool CompareCount(InventoryCell a, InventoryCell b)
        {
            return a.ItemsCount < b.ItemsCount;
        }

        bool ComparePrice(InventoryCell a, InventoryCell b)
        {
            if (a.ItemsCount < 1 && b.ItemsCount > 0)
                return true;
            else if (a.ItemsCount > 0 && b.ItemsCount < 1 || a.ItemsCount < 1 && b.ItemsCount < 1)
                return false;

            InventoryItem itemA = DummySettings.GetItemById(a.ItemId);
            InventoryItem itemB = DummySettings.GetItemById(b.ItemId);
            return a.ItemsCount * itemA.Price < b.ItemsCount * itemB.Price;

        }

        bool CompareType(InventoryCell a, InventoryCell b)
        {
            if (a.ItemsCount < 1 && b.ItemsCount > 0)
                return true;
            else if (a.ItemsCount > 0 && b.ItemsCount < 1 || a.ItemsCount < 1 && b.ItemsCount < 1)
                return false;

            InventoryItem itemA = DummySettings.GetItemById(a.ItemId);
            InventoryItem itemB = DummySettings.GetItemById(b.ItemId);
            return itemA.Type > itemB.Type;
        }

        void SortByCondition(InventoryCell[] cells, SortCondition condition)
        {
            // I'm using Bubble sort here because it's simple and our data set isn't large
            bool swapped = false;
            for (int i = 0; i < cells.Length - 1; i++)
            {
                for (int j = 0; j < cells.Length - 1 - i; j++)
                {
                    if (condition(cells[j], cells[j + 1]))
                    {
                        InventoryCell temp = cells[j];
                        cells[j] = cells[j + 1];
                        cells[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
    }
}
