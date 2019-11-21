using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Helper version of inventory view - to help develop Inventory API and
 * just to be sure that Inventory implementation works how it's meant to. 
 * See implementation of Inventory logic in Inventory.cs*/
namespace Inventory
{
    public partial class InventoryView : Form
    {
        class CellView
        {
            public int id;
            public Panel slot;
            public PictureBox icon;
            public Label name;
            public Label count;
        }

        Inventory _inventory;
        CellView[] _cellViews;
        int _selectedId;

        public InventoryView()
        {
            InitializeComponent();
        }

        void AddAllExamplesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DummySettings.GameItems.Length; i++)
                _inventory.AddItem(DummySettings.GameItems[i].Id, 1);
            _inventory.PrintInventory();
            UpdateInventoryGrid();
        }

        void InventoryView_Load(object sender, EventArgs e)
        {
            _inventory = new Inventory();
            InitInventoryGrid();
        }

        void SortByPriceButton_Click(object sender, EventArgs e)
        {
            _inventory.SortByPrice();
            UpdateInventoryGrid();
        }

        void SortByTypeButton_Click(object sender, EventArgs e)
        {
            _inventory.SortByType();
            UpdateInventoryGrid();
        }

        void AddButton_Click(object sender, EventArgs e)
        {
            InventoryCell cell = _inventory.GetCellsContent()[_selectedId];
            if (cell.ItemsCount > 0)
            {
                _inventory.AddItem(cell.ItemId, 1);
                UpdateInventoryGrid();
            }
        }

        void InitInventoryGrid()
        {
            _cellViews = new CellView[DummySettings.CellsMaxAmount];
            for (int i = 0; i < _cellViews.Length; i++)
            {
                Panel slot = new Panel();
                slot.ContextMenu = new ContextMenu();
                slot.BackColor = Color.White;
                slot.Size = new Size(100, 100);
                slot.Name = "";
                slot.Padding = new Padding(5);
                PictureBox icon = new PictureBox();
                icon.Size = new Size(40, 40);
                icon.Dock = DockStyle.Left;
                slot.Controls.Add(icon);
                Label name = new Label();
                name.Text = "";
                name.Size = new Size(90, 40);
                name.Dock = DockStyle.Bottom;
                slot.Controls.Add(name);
                Label count = new Label();
                count.Size = new Size(20, 20);
                count.Dock = DockStyle.Right;
                slot.Controls.Add(count);
                tableLayoutPanel1.Controls.Add(slot);

                CellView cellView = new CellView()
                {
                    id = i,
                    slot = slot,
                    name = name,
                    icon = icon,
                    count = count,
                };
                slot.MouseClick += (s, e) =>
                {
                    _selectedId = cellView.id;
                    UpdateSelectedColor();
                };
                icon.MouseClick += (s, e) =>
                {
                    _selectedId = cellView.id;
                    UpdateSelectedColor();
                };
                name.MouseClick += (s, e) =>
                {
                    _selectedId = cellView.id;
                    UpdateSelectedColor();
                };
                count.MouseClick += (s, e) =>
                {
                    _selectedId = cellView.id;
                    UpdateSelectedColor();
                };

                _cellViews[i] = cellView;
            }

            CellIndexUpDown.Minimum = 1;
            CellIndexUpDown.Maximum = DummySettings.CellsMaxAmount;
        }

        void UpdateSelectedColor()
        {
            for (int i = 0; i < _cellViews.Length; i++)
                _cellViews[i].slot.BackColor = i == _selectedId ? Color.LightBlue : Color.White;
        }

        void UpdateInventoryGrid()
        {
            InventoryCell[] cells = _inventory.GetCellsContent();
            for (int i = 0; i < cells.Length; i++)
            {
                InventoryCell cell = cells[i];
                InventoryItem item = DummySettings.GetItemById(cell.ItemId);
                CellView cw = _cellViews[i];
                cw.slot.ContextMenu.MenuItems.Clear();

                if (item != null)
                {
                    cw.name.Text = item.Name;
                    cw.icon.Image = item.Icon;
                    cw.icon.Visible = true;
                    cw.count.Text = cell.ItemsCount.ToString();

                    Dictionary<InventoryItemActions, string> actions = _inventory.GetContextMenuActions(i);
                    if (actions != null)
                    {
                        foreach (KeyValuePair<InventoryItemActions, string> action in actions)
                        {
                            MenuItem menuItem = new MenuItem(action.Value);
                            menuItem.Click += (s, e) =>
                            {
                                _inventory.ApplyActionToItemInCell(action.Key, cw.id);
                                UpdateInventoryGrid();
                                UpdateEquipmentSlot();
                            };
                            cw.slot.ContextMenu.MenuItems.Add(menuItem);
                        }
                    }
                }
                else
                {
                    cw.name.Text = "";
                    cw.icon.Visible = false;
                    cw.count.Text = "";
                }
            }
        }

        void UpdateEquipmentSlot()
        {
            InventoryItem item = DummySettings.GetItemById(_inventory.EquippedItemId);
            if (item != null)
            {
                EquipmentIconBox.Image = item.Icon;
                EquipmentIconBox.Visible = true;
                EquipmentItemName.Text = item.Name;
            }
            else
            {
                EquipmentIconBox.Visible = false;
                EquipmentItemName.Text = "";
            }
        }

        void RemoveItemButton_Click(object sender, EventArgs e)
        {
            _inventory.RemoveItemsByCell(_selectedId, 1);
            UpdateInventoryGrid();
            UpdateEquipmentSlot();
        }

        void ClearCellButton_Click(object sender, EventArgs e)
        {
            _inventory.ClearCell(_selectedId);
            UpdateInventoryGrid();
            UpdateEquipmentSlot();
        }

        void CellNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        void MoveItemButton_Click(object sender, EventArgs e)
        {
            int cellIndex = (int)CellIndexUpDown.Value - 1;
            _inventory.MoveItemToCell(_selectedId, cellIndex);
            UpdateInventoryGrid();
        }
    }
}
