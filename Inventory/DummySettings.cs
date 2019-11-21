using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace Inventory
{
    /* Helper dummy class, instead of settings loading system 
     * See implementation of Inventory logic in Inventory.cs */
    static class DummySettings
    {
        public readonly static int CellsMaxAmount = 16;

        public readonly static InventoryItem[] GameItems = new InventoryItem[]
        {
            new InventoryItem(InventoryItemType.Consumable, 1, "Health potion", 50, 10, Properties.Resources.Health),
            new InventoryItem(InventoryItemType.Consumable, 2, "Speed potion", 35, 10, Properties.Resources.Speed),
            new InventoryItem(InventoryItemType.Euipment, 3, "Mighty sword", 100, 10, Properties.Resources.Sword),
            new InventoryItem(InventoryItemType.Trash, 4, "Key", 0, 1, Properties.Resources.Key, true),
            new InventoryItem(InventoryItemType.Euipment, 5, "Lantern", 0, 1, Properties.Resources.Lantern, true),
            new InventoryItem(InventoryItemType.Trash, 6, "Horns and hoofs", 15, 5, Properties.Resources.Horns),
        };

        public static InventoryItem GetItemById(int id)
        {
            for (int i = 0; i < GameItems.Length; i++)
                if (GameItems[i].Id == id)
                    return GameItems[i];

            return null;
        }
    }
}
