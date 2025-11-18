namespace HumanitarianProjectManagement.Forms
{
    partial class StockItemListForm
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnClearSearchStockItem = new System.Windows.Forms.Button();
            this.btnSearchStockItem = new System.Windows.Forms.Button();
            this.txtSearchStockItem = new System.Windows.Forms.TextBox();
            this.lblSearchItem = new System.Windows.Forms.Label();
            this.dgvStockItems = new System.Windows.Forms.DataGridView();
            this.pnlStockItemControls = new System.Windows.Forms.Panel();
            this.btnViewItemHistory = new System.Windows.Forms.Button();
            this.btnRecordTransaction = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockItems)).BeginInit();
            this.pnlStockItemControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnClearSearchStockItem);
            this.pnlSearch.Controls.Add(this.btnSearchStockItem);
            this.pnlSearch.Controls.Add(this.txtSearchStockItem);
            this.pnlSearch.Controls.Add(this.lblSearchItem);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(784, 50);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnClearSearchStockItem
            // 
            this.btnClearSearchStockItem.Location = new System.Drawing.Point(477, 13);
            this.btnClearSearchStockItem.Name = "btnClearSearchStockItem";
            this.btnClearSearchStockItem.Size = new System.Drawing.Size(100, 23);
            this.btnClearSearchStockItem.TabIndex = 3;
            this.btnClearSearchStockItem.Text = "Clear/Refresh";
            this.btnClearSearchStockItem.UseVisualStyleBackColor = true;
            this.btnClearSearchStockItem.Click += new System.EventHandler(this.btnClearSearchStockItem_Click);
            // 
            // btnSearchStockItem
            // 
            this.btnSearchStockItem.Location = new System.Drawing.Point(371, 13);
            this.btnSearchStockItem.Name = "btnSearchStockItem";
            this.btnSearchStockItem.Size = new System.Drawing.Size(100, 23);
            this.btnSearchStockItem.TabIndex = 2;
            this.btnSearchStockItem.Text = "Search";
            this.btnSearchStockItem.UseVisualStyleBackColor = true;
            this.btnSearchStockItem.Click += new System.EventHandler(this.btnSearchStockItem_Click);
            // 
            // txtSearchStockItem
            // 
            this.txtSearchStockItem.Location = new System.Drawing.Point(150, 15);
            this.txtSearchStockItem.Name = "txtSearchStockItem";
            this.txtSearchStockItem.Size = new System.Drawing.Size(215, 20);
            this.txtSearchStockItem.TabIndex = 1;
            // 
            // lblSearchItem
            // 
            this.lblSearchItem.AutoSize = true;
            this.lblSearchItem.Location = new System.Drawing.Point(12, 18);
            this.lblSearchItem.Name = "lblSearchItem";
            this.lblSearchItem.Size = new System.Drawing.Size(132, 13);
            this.lblSearchItem.TabIndex = 0;
            this.lblSearchItem.Text = "Search Item (Name/Desc):";
            // 
            // dgvStockItems
            // 
            this.dgvStockItems.AllowUserToAddRows = false;
            this.dgvStockItems.AllowUserToDeleteRows = false;
            this.dgvStockItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockItems.Location = new System.Drawing.Point(0, 50);
            this.dgvStockItems.Name = "dgvStockItems";
            this.dgvStockItems.ReadOnly = true;
            this.dgvStockItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockItems.Size = new System.Drawing.Size(784, 466);
            this.dgvStockItems.TabIndex = 1;
            // 
            // pnlStockItemControls
            // 
            this.pnlStockItemControls.Controls.Add(this.btnViewItemHistory);
            this.pnlStockItemControls.Controls.Add(this.btnRecordTransaction);
            this.pnlStockItemControls.Controls.Add(this.btnDeleteItem);
            this.pnlStockItemControls.Controls.Add(this.btnEditItem);
            this.pnlStockItemControls.Controls.Add(this.btnAddNewItem);
            this.pnlStockItemControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStockItemControls.Location = new System.Drawing.Point(0, 516);
            this.pnlStockItemControls.Name = "pnlStockItemControls";
            this.pnlStockItemControls.Size = new System.Drawing.Size(784, 45);
            this.pnlStockItemControls.TabIndex = 2;
            // 
            // btnViewItemHistory
            // 
            this.btnViewItemHistory.Location = new System.Drawing.Point(477, 10);
            this.btnViewItemHistory.Name = "btnViewItemHistory";
            this.btnViewItemHistory.Size = new System.Drawing.Size(110, 23);
            this.btnViewItemHistory.TabIndex = 4;
            this.btnViewItemHistory.Text = "View Item History";
            this.btnViewItemHistory.UseVisualStyleBackColor = true;
            this.btnViewItemHistory.Click += new System.EventHandler(this.btnViewItemHistory_Click);
            // 
            // btnRecordTransaction
            // 
            this.btnRecordTransaction.Location = new System.Drawing.Point(341, 10);
            this.btnRecordTransaction.Name = "btnRecordTransaction";
            this.btnRecordTransaction.Size = new System.Drawing.Size(130, 23);
            this.btnRecordTransaction.TabIndex = 3;
            this.btnRecordTransaction.Text = "Record Transaction";
            this.btnRecordTransaction.UseVisualStyleBackColor = true;
            this.btnRecordTransaction.Click += new System.EventHandler(this.btnRecordTransaction_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(225, 10);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(110, 23);
            this.btnDeleteItem.TabIndex = 2;
            this.btnDeleteItem.Text = "Delete Selected Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(118, 10);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(101, 23);
            this.btnEditItem.TabIndex = 1;
            this.btnEditItem.Text = "Edit Selected Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Location = new System.Drawing.Point(12, 10);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(100, 23);
            this.btnAddNewItem.TabIndex = 0;
            this.btnAddNewItem.Text = "Add New Item";
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // StockItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvStockItems);
            this.Controls.Add(this.pnlStockItemControls);
            this.Controls.Add(this.pnlSearch);
            this.Name = "StockItemListForm";
            this.Text = "Stock Item Management";
            this.Load += new System.EventHandler(this.StockItemListForm_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockItems)).EndInit();
            this.pnlStockItemControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnClearSearchStockItem;
        private System.Windows.Forms.Button btnSearchStockItem;
        private System.Windows.Forms.TextBox txtSearchStockItem;
        private System.Windows.Forms.Label lblSearchItem;
        private System.Windows.Forms.DataGridView dgvStockItems;
        private System.Windows.Forms.Panel pnlStockItemControls;
        private System.Windows.Forms.Button btnAddNewItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnRecordTransaction;
        private System.Windows.Forms.Button btnViewItemHistory;
    }
}
