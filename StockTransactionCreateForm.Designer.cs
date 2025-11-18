namespace HumanitarianProjectManagement.Forms
{
    partial class StockTransactionCreateForm
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
            this.lblStockItemDisplay = new System.Windows.Forms.Label();
            this.txtStockItemDisplay = new System.Windows.Forms.TextBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblDistributedTo = new System.Windows.Forms.Label();
            this.txtDistributedTo = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSaveTransaction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStockItemDisplay
            // 
            this.lblStockItemDisplay.AutoSize = true;
            this.lblStockItemDisplay.Location = new System.Drawing.Point(20, 23);
            this.lblStockItemDisplay.Name = "lblStockItemDisplay";
            this.lblStockItemDisplay.Size = new System.Drawing.Size(62, 13);
            this.lblStockItemDisplay.TabIndex = 0;
            this.lblStockItemDisplay.Text = "Stock Item:";
            // 
            // txtStockItemDisplay
            // 
            this.txtStockItemDisplay.Location = new System.Drawing.Point(130, 20);
            this.txtStockItemDisplay.Name = "txtStockItemDisplay";
            this.txtStockItemDisplay.ReadOnly = true;
            this.txtStockItemDisplay.Size = new System.Drawing.Size(280, 20);
            this.txtStockItemDisplay.TabIndex = 0; // TabStop = false in code
            this.txtStockItemDisplay.TabStop = false;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(20, 53);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(93, 13);
            this.lblTransactionType.TabIndex = 2;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "IN",
            "OUT",
            "ADJUSTMENT"});
            this.cmbTransactionType.Location = new System.Drawing.Point(130, 50);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(150, 21);
            this.cmbTransactionType.TabIndex = 1;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 83);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(130, 80);
            this.numQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(150, 20);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Location = new System.Drawing.Point(20, 113);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(92, 13);
            this.lblTransactionDate.TabIndex = 6;
            this.lblTransactionDate.Text = "Transaction Date:";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(130, 110);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(150, 20);
            this.dtpTransactionDate.TabIndex = 3;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(20, 143);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(47, 13);
            this.lblReason.TabIndex = 8;
            this.lblReason.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(130, 140);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(280, 60);
            this.txtReason.TabIndex = 4;
            // 
            // lblDistributedTo
            // 
            this.lblDistributedTo.AutoSize = true;
            this.lblDistributedTo.Location = new System.Drawing.Point(20, 213);
            this.lblDistributedTo.Name = "lblDistributedTo";
            this.lblDistributedTo.Size = new System.Drawing.Size(107, 13);
            this.lblDistributedTo.TabIndex = 10;
            this.lblDistributedTo.Text = "Source/Distributed to:";
            // 
            // txtDistributedTo
            // 
            this.txtDistributedTo.Location = new System.Drawing.Point(130, 210);
            this.txtDistributedTo.Multiline = true;
            this.txtDistributedTo.Name = "txtDistributedTo";
            this.txtDistributedTo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDistributedTo.Size = new System.Drawing.Size(280, 60);
            this.txtDistributedTo.TabIndex = 5;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 283);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(130, 280);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(280, 60);
            this.txtNotes.TabIndex = 6;
            // 
            // btnSaveTransaction
            // 
            this.btnSaveTransaction.Location = new System.Drawing.Point(130, 355);
            this.btnSaveTransaction.Name = "btnSaveTransaction";
            this.btnSaveTransaction.Size = new System.Drawing.Size(100, 23);
            this.btnSaveTransaction.TabIndex = 7;
            this.btnSaveTransaction.Text = "Save";
            this.btnSaveTransaction.UseVisualStyleBackColor = true;
            this.btnSaveTransaction.Click += new System.EventHandler(this.btnSaveTransaction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(240, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // StockTransactionCreateForm
            // 
            this.AcceptButton = this.btnSaveTransaction;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 396);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveTransaction);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtDistributedTo);
            this.Controls.Add(this.lblDistributedTo);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.dtpTransactionDate);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbTransactionType);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.txtStockItemDisplay);
            this.Controls.Add(this.lblStockItemDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockTransactionCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Stock Transaction";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockItemDisplay;
        private System.Windows.Forms.TextBox txtStockItemDisplay;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblDistributedTo;
        private System.Windows.Forms.TextBox txtDistributedTo;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSaveTransaction;
        private System.Windows.Forms.Button btnCancel;
    }
}
