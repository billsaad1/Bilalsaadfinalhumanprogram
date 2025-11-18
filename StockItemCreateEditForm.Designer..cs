namespace HumanitarianProjectManagement.Forms
{
    partial class StockItemCreateEditForm
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUnitOfMeasure = new System.Windows.Forms.Label();
            this.txtUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.lblCurrentQuantity = new System.Windows.Forms.Label();
            this.numCurrentQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentQuantityDisplay = new System.Windows.Forms.Label();
            this.txtCurrentQuantityDisplay = new System.Windows.Forms.TextBox();
            this.lblMinStockLevel = new System.Windows.Forms.Label();
            this.numMinStockLevel = new System.Windows.Forms.NumericUpDown();
            this.lblMaxStockLevel = new System.Windows.Forms.Label();
            this.numMaxStockLevel = new System.Windows.Forms.NumericUpDown();
            this.chkSpecifyMaxStockLevel = new System.Windows.Forms.CheckBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblLastStockUpdateDisplay = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStockLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStockLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(20, 23);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 13);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Item Name:";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(130, 20);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(280, 20);
            this.txtItemName.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 53);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 50);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(280, 60);
            this.txtDescription.TabIndex = 1;
            // 
            // lblUnitOfMeasure
            // 
            this.lblUnitOfMeasure.AutoSize = true;
            this.lblUnitOfMeasure.Location = new System.Drawing.Point(20, 123);
            this.lblUnitOfMeasure.Name = "lblUnitOfMeasure";
            this.lblUnitOfMeasure.Size = new System.Drawing.Size(85, 13);
            this.lblUnitOfMeasure.TabIndex = 4;
            this.lblUnitOfMeasure.Text = "Unit of Measure:";
            // 
            // txtUnitOfMeasure
            // 
            this.txtUnitOfMeasure.Location = new System.Drawing.Point(130, 120);
            this.txtUnitOfMeasure.Name = "txtUnitOfMeasure";
            this.txtUnitOfMeasure.Size = new System.Drawing.Size(150, 20);
            this.txtUnitOfMeasure.TabIndex = 2;
            // 
            // lblCurrentQuantity
            // 
            this.lblCurrentQuantity.AutoSize = true;
            this.lblCurrentQuantity.Location = new System.Drawing.Point(20, 153);
            this.lblCurrentQuantity.Name = "lblCurrentQuantity";
            this.lblCurrentQuantity.Size = new System.Drawing.Size(89, 13);
            this.lblCurrentQuantity.TabIndex = 6;
            this.lblCurrentQuantity.Text = "Current Quantity:";
            // 
            // numCurrentQuantity
            // 
            this.numCurrentQuantity.Location = new System.Drawing.Point(130, 150);
            this.numCurrentQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCurrentQuantity.Name = "numCurrentQuantity";
            this.numCurrentQuantity.Size = new System.Drawing.Size(150, 20);
            this.numCurrentQuantity.TabIndex = 3;
            // 
            // lblCurrentQuantityDisplay
            // 
            this.lblCurrentQuantityDisplay.AutoSize = true;
            this.lblCurrentQuantityDisplay.Location = new System.Drawing.Point(20, 153); // Same position as num version label
            this.lblCurrentQuantityDisplay.Name = "lblCurrentQuantityDisplay";
            this.lblCurrentQuantityDisplay.Size = new System.Drawing.Size(89, 13);
            this.lblCurrentQuantityDisplay.TabIndex = 20; // Higher TabIndex so it doesn't interfere initially
            this.lblCurrentQuantityDisplay.Text = "Current Quantity:";
            this.lblCurrentQuantityDisplay.Visible = false;
            // 
            // txtCurrentQuantityDisplay
            // 
            this.txtCurrentQuantityDisplay.Location = new System.Drawing.Point(130, 150); // Same position as num version
            this.txtCurrentQuantityDisplay.Name = "txtCurrentQuantityDisplay";
            this.txtCurrentQuantityDisplay.ReadOnly = true;
            this.txtCurrentQuantityDisplay.Size = new System.Drawing.Size(150, 20);
            this.txtCurrentQuantityDisplay.TabIndex = 21; // Higher TabIndex
            this.txtCurrentQuantityDisplay.TabStop = false;
            this.txtCurrentQuantityDisplay.Visible = false;
            // 
            // lblMinStockLevel
            // 
            this.lblMinStockLevel.AutoSize = true;
            this.lblMinStockLevel.Location = new System.Drawing.Point(20, 183);
            this.lblMinStockLevel.Name = "lblMinStockLevel";
            this.lblMinStockLevel.Size = new System.Drawing.Size(86, 13);
            this.lblMinStockLevel.TabIndex = 8;
            this.lblMinStockLevel.Text = "Min Stock Level:";
            // 
            // numMinStockLevel
            // 
            this.numMinStockLevel.Location = new System.Drawing.Point(130, 180);
            this.numMinStockLevel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMinStockLevel.Name = "numMinStockLevel";
            this.numMinStockLevel.Size = new System.Drawing.Size(150, 20);
            this.numMinStockLevel.TabIndex = 4;
            // 
            // lblMaxStockLevel
            // 
            this.lblMaxStockLevel.AutoSize = true;
            this.lblMaxStockLevel.Location = new System.Drawing.Point(20, 213);
            this.lblMaxStockLevel.Name = "lblMaxStockLevel";
            this.lblMaxStockLevel.Size = new System.Drawing.Size(89, 13);
            this.lblMaxStockLevel.TabIndex = 10;
            this.lblMaxStockLevel.Text = "Max Stock Level:";
            // 
            // numMaxStockLevel
            // 
            this.numMaxStockLevel.Enabled = false;
            this.numMaxStockLevel.Location = new System.Drawing.Point(130, 210);
            this.numMaxStockLevel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxStockLevel.Name = "numMaxStockLevel";
            this.numMaxStockLevel.Size = new System.Drawing.Size(150, 20);
            this.numMaxStockLevel.TabIndex = 6; // After checkbox
            // 
            // chkSpecifyMaxStockLevel
            // 
            this.chkSpecifyMaxStockLevel.AutoSize = true;
            this.chkSpecifyMaxStockLevel.Location = new System.Drawing.Point(290, 212);
            this.chkSpecifyMaxStockLevel.Name = "chkSpecifyMaxStockLevel";
            this.chkSpecifyMaxStockLevel.Size = new System.Drawing.Size(111, 17);
            this.chkSpecifyMaxStockLevel.TabIndex = 5; // Before NumericUpDown
            this.chkSpecifyMaxStockLevel.Text = "Specify Max Level";
            this.chkSpecifyMaxStockLevel.UseVisualStyleBackColor = true;
            this.chkSpecifyMaxStockLevel.CheckedChanged += new System.EventHandler(this.chkSpecifyMaxStockLevel_CheckedChanged);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 243);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 13;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(130, 240);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(280, 60);
            this.txtNotes.TabIndex = 7;
            // 
            // lblLastStockUpdateDisplay
            // 
            this.lblLastStockUpdateDisplay.AutoSize = true;
            this.lblLastStockUpdateDisplay.Location = new System.Drawing.Point(20, 313);
            this.lblLastStockUpdateDisplay.Name = "lblLastStockUpdateDisplay";
            this.lblLastStockUpdateDisplay.Size = new System.Drawing.Size(99, 13);
            this.lblLastStockUpdateDisplay.TabIndex = 15;
            this.lblLastStockUpdateDisplay.Text = "Last Update: [Date]";
            this.lblLastStockUpdateDisplay.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(240, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // StockItemCreateEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 381);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLastStockUpdateDisplay);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.chkSpecifyMaxStockLevel);
            this.Controls.Add(this.numMaxStockLevel);
            this.Controls.Add(this.lblMaxStockLevel);
            this.Controls.Add(this.numMinStockLevel);
            this.Controls.Add(this.lblMinStockLevel);
            this.Controls.Add(this.txtCurrentQuantityDisplay);
            this.Controls.Add(this.lblCurrentQuantityDisplay);
            this.Controls.Add(this.numCurrentQuantity);
            this.Controls.Add(this.lblCurrentQuantity);
            this.Controls.Add(this.txtUnitOfMeasure);
            this.Controls.Add(this.lblUnitOfMeasure);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockItemCreateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Item Details";
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStockLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStockLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblUnitOfMeasure;
        private System.Windows.Forms.TextBox txtUnitOfMeasure;
        private System.Windows.Forms.Label lblCurrentQuantity;
        private System.Windows.Forms.NumericUpDown numCurrentQuantity;
        private System.Windows.Forms.Label lblMinStockLevel;
        private System.Windows.Forms.NumericUpDown numMinStockLevel;
        private System.Windows.Forms.Label lblMaxStockLevel;
        private System.Windows.Forms.NumericUpDown numMaxStockLevel;
        private System.Windows.Forms.CheckBox chkSpecifyMaxStockLevel;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblLastStockUpdateDisplay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCurrentQuantityDisplay;
        private System.Windows.Forms.TextBox txtCurrentQuantityDisplay;
    }
}
