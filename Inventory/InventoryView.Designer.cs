namespace Inventory
{
    partial class InventoryView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddAllExamplesButton = new System.Windows.Forms.Button();
            this.SortByPriceButton = new System.Windows.Forms.Button();
            this.SortByTypeButton = new System.Windows.Forms.Button();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.ClearCellButton = new System.Windows.Forms.Button();
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.MoveItemButton = new System.Windows.Forms.Button();
            this.CellIndexUpDown = new System.Windows.Forms.NumericUpDown();
            this.EquipmentIconBox = new System.Windows.Forms.PictureBox();
            this.EquipmentItemName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellIndexUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentIconBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 41);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add item";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddAllExamplesButton
            // 
            this.AddAllExamplesButton.Location = new System.Drawing.Point(11, 12);
            this.AddAllExamplesButton.Name = "AddAllExamplesButton";
            this.AddAllExamplesButton.Size = new System.Drawing.Size(116, 23);
            this.AddAllExamplesButton.TabIndex = 1;
            this.AddAllExamplesButton.Text = "Add examples";
            this.AddAllExamplesButton.UseVisualStyleBackColor = true;
            this.AddAllExamplesButton.Click += new System.EventHandler(this.AddAllExamplesButton_Click);
            // 
            // SortByPriceButton
            // 
            this.SortByPriceButton.Location = new System.Drawing.Point(11, 128);
            this.SortByPriceButton.Name = "SortByPriceButton";
            this.SortByPriceButton.Size = new System.Drawing.Size(75, 23);
            this.SortByPriceButton.TabIndex = 2;
            this.SortByPriceButton.Text = "Sort by price";
            this.SortByPriceButton.UseVisualStyleBackColor = true;
            this.SortByPriceButton.Click += new System.EventHandler(this.SortByPriceButton_Click);
            // 
            // SortByTypeButton
            // 
            this.SortByTypeButton.Location = new System.Drawing.Point(11, 157);
            this.SortByTypeButton.Name = "SortByTypeButton";
            this.SortByTypeButton.Size = new System.Drawing.Size(75, 23);
            this.SortByTypeButton.TabIndex = 3;
            this.SortByTypeButton.Text = "Sort by type";
            this.SortByTypeButton.UseVisualStyleBackColor = true;
            this.SortByTypeButton.Click += new System.EventHandler(this.SortByTypeButton_Click);
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Location = new System.Drawing.Point(11, 70);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(89, 23);
            this.RemoveItemButton.TabIndex = 10;
            this.RemoveItemButton.Text = "Remove Item";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // ClearCellButton
            // 
            this.ClearCellButton.Location = new System.Drawing.Point(11, 98);
            this.ClearCellButton.Name = "ClearCellButton";
            this.ClearCellButton.Size = new System.Drawing.Size(88, 23);
            this.ClearCellButton.TabIndex = 11;
            this.ClearCellButton.Text = "Clear cell";
            this.ClearCellButton.UseVisualStyleBackColor = true;
            this.ClearCellButton.Click += new System.EventHandler(this.ClearCellButton_Click);
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.AutoSize = true;
            this.InventoryPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InventoryPanel.Location = new System.Drawing.Point(284, 98);
            this.InventoryPanel.MaximumSize = new System.Drawing.Size(200, 300);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(0, 0);
            this.InventoryPanel.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(160, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(15, 6);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // MoveItemButton
            // 
            this.MoveItemButton.Location = new System.Drawing.Point(11, 186);
            this.MoveItemButton.Name = "MoveItemButton";
            this.MoveItemButton.Size = new System.Drawing.Size(89, 23);
            this.MoveItemButton.TabIndex = 16;
            this.MoveItemButton.Text = "Move to cell:";
            this.MoveItemButton.UseVisualStyleBackColor = true;
            this.MoveItemButton.Click += new System.EventHandler(this.MoveItemButton_Click);
            // 
            // CellIndexUpDown
            // 
            this.CellIndexUpDown.Location = new System.Drawing.Point(107, 189);
            this.CellIndexUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.CellIndexUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CellIndexUpDown.Name = "CellIndexUpDown";
            this.CellIndexUpDown.Size = new System.Drawing.Size(40, 20);
            this.CellIndexUpDown.TabIndex = 18;
            this.CellIndexUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EquipmentIconBox
            // 
            this.EquipmentIconBox.Location = new System.Drawing.Point(3, 3);
            this.EquipmentIconBox.Name = "EquipmentIconBox";
            this.EquipmentIconBox.Size = new System.Drawing.Size(40, 40);
            this.EquipmentIconBox.TabIndex = 20;
            this.EquipmentIconBox.TabStop = false;
            // 
            // EquipmentItemName
            // 
            this.EquipmentItemName.AutoSize = true;
            this.EquipmentItemName.Location = new System.Drawing.Point(3, 46);
            this.EquipmentItemName.Name = "EquipmentItemName";
            this.EquipmentItemName.Size = new System.Drawing.Size(0, 13);
            this.EquipmentItemName.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.EquipmentIconBox);
            this.panel1.Controls.Add(this.EquipmentItemName);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 69);
            this.panel1.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 100);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equipped item:";
            // 
            // InventoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 526);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CellIndexUpDown);
            this.Controls.Add(this.MoveItemButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.InventoryPanel);
            this.Controls.Add(this.ClearCellButton);
            this.Controls.Add(this.RemoveItemButton);
            this.Controls.Add(this.SortByTypeButton);
            this.Controls.Add(this.SortByPriceButton);
            this.Controls.Add(this.AddAllExamplesButton);
            this.Controls.Add(this.AddButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InventoryView";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.InventoryView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellIndexUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentIconBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button AddAllExamplesButton;
        private System.Windows.Forms.Button SortByPriceButton;
        private System.Windows.Forms.Button SortByTypeButton;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.Button ClearCellButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button MoveItemButton;
        private System.Windows.Forms.NumericUpDown CellIndexUpDown;
        private System.Windows.Forms.PictureBox EquipmentIconBox;
        private System.Windows.Forms.Label EquipmentItemName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

