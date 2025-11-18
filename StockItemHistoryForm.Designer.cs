namespace HumanitarianProjectManagement.Forms
{
    partial class StockItemHistoryForm
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
            this.lblStockItemNameDisplay = new System.Windows.Forms.Label();
            this.pnlDateFilter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearDateFilter = new System.Windows.Forms.Button();
            this.btnApplyDateFilter = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.chkFilterToDate = new System.Windows.Forms.CheckBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkFilterFromDate = new System.Windows.Forms.CheckBox();
            this.dgvTransactionHistory = new System.Windows.Forms.DataGridView();
            this.pnlDateFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStockItemNameDisplay
            // 
            this.lblStockItemNameDisplay.AutoSize = true;
            this.lblStockItemNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockItemNameDisplay.Location = new System.Drawing.Point(12, 9);
            this.lblStockItemNameDisplay.Name = "lblStockItemNameDisplay";
            this.lblStockItemNameDisplay.Size = new System.Drawing.Size(156, 17);
            this.lblStockItemNameDisplay.TabIndex = 0;
            this.lblStockItemNameDisplay.Text = "Item History for: [Item]";
            // 
            // pnlDateFilter
            // 
            this.pnlDateFilter.Controls.Add(this.btnClose);
            this.pnlDateFilter.Controls.Add(this.btnClearDateFilter);
            this.pnlDateFilter.Controls.Add(this.btnApplyDateFilter);
            this.pnlDateFilter.Controls.Add(this.dtpToDate);
            this.pnlDateFilter.Controls.Add(this.chkFilterToDate);
            this.pnlDateFilter.Controls.Add(this.dtpFromDate);
            this.pnlDateFilter.Controls.Add(this.chkFilterFromDate);
            this.pnlDateFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDateFilter.Location = new System.Drawing.Point(0, 35); // Height of lblStockItemNameDisplay + padding
            this.pnlDateFilter.Name = "pnlDateFilter";
            this.pnlDateFilter.Size = new System.Drawing.Size(784, 45);
            this.pnlDateFilter.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(697, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearDateFilter
            // 
            this.btnClearDateFilter.Location = new System.Drawing.Point(490, 10);
            this.btnClearDateFilter.Name = "btnClearDateFilter";
            this.btnClearDateFilter.Size = new System.Drawing.Size(120, 23);
            this.btnClearDateFilter.TabIndex = 5;
            this.btnClearDateFilter.Text = "Clear Filter / Show All";
            this.btnClearDateFilter.UseVisualStyleBackColor = true;
            this.btnClearDateFilter.Click += new System.EventHandler(this.btnClearDateFilter_Click);
            // 
            // btnApplyDateFilter
            // 
            this.btnApplyDateFilter.Location = new System.Drawing.Point(384, 10);
            this.btnApplyDateFilter.Name = "btnApplyDateFilter";
            this.btnApplyDateFilter.Size = new System.Drawing.Size(100, 23);
            this.btnApplyDateFilter.TabIndex = 4;
            this.btnApplyDateFilter.Text = "Apply Filter";
            this.btnApplyDateFilter.UseVisualStyleBackColor = true;
            this.btnApplyDateFilter.Click += new System.EventHandler(this.btnApplyDateFilter_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(248, 12);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // chkFilterToDate
            // 
            this.chkFilterToDate.AutoSize = true;
            this.chkFilterToDate.Location = new System.Drawing.Point(196, 14);
            this.chkFilterToDate.Name = "chkFilterToDate";
            this.chkFilterToDate.Size = new System.Drawing.Size(42, 17);
            this.chkFilterToDate.TabIndex = 2;
            this.chkFilterToDate.Text = "To:";
            this.chkFilterToDate.UseVisualStyleBackColor = true;
            this.chkFilterToDate.CheckedChanged += new System.EventHandler(this.chkFilterToDate_CheckedChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(60, 12);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 20);
            this.dtpFromDate.TabIndex = 1;
            // 
            // chkFilterFromDate
            // 
            this.chkFilterFromDate.AutoSize = true;
            this.chkFilterFromDate.Location = new System.Drawing.Point(12, 14);
            this.chkFilterFromDate.Name = "chkFilterFromDate";
            this.chkFilterFromDate.Size = new System.Drawing.Size(52, 17);
            this.chkFilterFromDate.TabIndex = 0;
            this.chkFilterFromDate.Text = "From:";
            this.chkFilterFromDate.UseVisualStyleBackColor = true;
            this.chkFilterFromDate.CheckedChanged += new System.EventHandler(this.chkFilterFromDate_CheckedChanged);
            // 
            // dgvTransactionHistory
            // 
            this.dgvTransactionHistory.AllowUserToAddRows = false;
            this.dgvTransactionHistory.AllowUserToDeleteRows = false;
            this.dgvTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactionHistory.Location = new System.Drawing.Point(0, 80); // Adjusted for lblStockItemNameDisplay and pnlDateFilter
            this.dgvTransactionHistory.Name = "dgvTransactionHistory";
            this.dgvTransactionHistory.ReadOnly = true;
            this.dgvTransactionHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactionHistory.Size = new System.Drawing.Size(784, 481);
            this.dgvTransactionHistory.TabIndex = 2;
            // 
            // StockItemHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvTransactionHistory);
            this.Controls.Add(this.pnlDateFilter);
            this.Controls.Add(this.lblStockItemNameDisplay); // Add label to controls
            this.Name = "StockItemHistoryForm";
            this.Text = "Transaction History"; // Base title, will be updated dynamically
            this.Load += new System.EventHandler(this.StockItemHistoryForm_Load);
            this.pnlDateFilter.ResumeLayout(false);
            this.pnlDateFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockItemNameDisplay;
        private System.Windows.Forms.Panel pnlDateFilter;
        private System.Windows.Forms.CheckBox chkFilterFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox chkFilterToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnApplyDateFilter;
        private System.Windows.Forms.Button btnClearDateFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvTransactionHistory;
    }
}
