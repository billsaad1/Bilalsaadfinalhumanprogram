namespace HumanitarianProjectManagement.Forms
{
    partial class PurchaseOrderCreateEditForm
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
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.chkSpecifyExpectedDeliveryDate = new System.Windows.Forms.CheckBox();
            this.dtpExpectedDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.chkSpecifyActualDeliveryDate = new System.Windows.Forms.CheckBox();
            this.dtpActualDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.numTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.lblBillingAddress = new System.Windows.Forms.Label();
            this.txtBillingAddress = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblCreatedByDisplay = new System.Windows.Forms.Label();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.cmbApprovedBy = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(20, 23);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project:";
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(130, 20);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(300, 21);
            this.cmbProject.TabIndex = 0;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(20, 53);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(79, 13);
            this.lblSupplierName.TabIndex = 2;
            this.lblSupplierName.Text = "Supplier Name:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(130, 50);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(300, 20);
            this.txtSupplierName.TabIndex = 1;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(20, 83);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(130, 80);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(150, 20);
            this.dtpOrderDate.TabIndex = 2;
            // 
            // chkSpecifyExpectedDeliveryDate
            // 
            this.chkSpecifyExpectedDeliveryDate.AutoSize = true;
            this.chkSpecifyExpectedDeliveryDate.Location = new System.Drawing.Point(23, 112);
            this.chkSpecifyExpectedDeliveryDate.Name = "chkSpecifyExpectedDeliveryDate";
            this.chkSpecifyExpectedDeliveryDate.Size = new System.Drawing.Size(109, 17);
            this.chkSpecifyExpectedDeliveryDate.TabIndex = 3;
            this.chkSpecifyExpectedDeliveryDate.Text = "Expected Delivery:";
            this.chkSpecifyExpectedDeliveryDate.UseVisualStyleBackColor = true;
            this.chkSpecifyExpectedDeliveryDate.CheckedChanged += new System.EventHandler(this.chkSpecifyExpectedDeliveryDate_CheckedChanged);
            // 
            // dtpExpectedDeliveryDate
            // 
            this.dtpExpectedDeliveryDate.Enabled = false;
            this.dtpExpectedDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedDeliveryDate.Location = new System.Drawing.Point(130, 110);
            this.dtpExpectedDeliveryDate.Name = "dtpExpectedDeliveryDate";
            this.dtpExpectedDeliveryDate.Size = new System.Drawing.Size(150, 20);
            this.dtpExpectedDeliveryDate.TabIndex = 4;
            // 
            // chkSpecifyActualDeliveryDate
            // 
            this.chkSpecifyActualDeliveryDate.AutoSize = true;
            this.chkSpecifyActualDeliveryDate.Location = new System.Drawing.Point(23, 142);
            this.chkSpecifyActualDeliveryDate.Name = "chkSpecifyActualDeliveryDate";
            this.chkSpecifyActualDeliveryDate.Size = new System.Drawing.Size(99, 17);
            this.chkSpecifyActualDeliveryDate.TabIndex = 5;
            this.chkSpecifyActualDeliveryDate.Text = "Actual Delivery:";
            this.chkSpecifyActualDeliveryDate.UseVisualStyleBackColor = true;
            this.chkSpecifyActualDeliveryDate.CheckedChanged += new System.EventHandler(this.chkSpecifyActualDeliveryDate_CheckedChanged);
            // 
            // dtpActualDeliveryDate
            // 
            this.dtpActualDeliveryDate.Enabled = false;
            this.dtpActualDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActualDeliveryDate.Location = new System.Drawing.Point(130, 140);
            this.dtpActualDeliveryDate.Name = "dtpActualDeliveryDate";
            this.dtpActualDeliveryDate.Size = new System.Drawing.Size(150, 20);
            this.dtpActualDeliveryDate.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 173);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 13);
            this.lblTotalAmount.TabIndex = 10;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // numTotalAmount
            // 
            this.numTotalAmount.DecimalPlaces = 2;
            this.numTotalAmount.Location = new System.Drawing.Point(130, 170);
            this.numTotalAmount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numTotalAmount.Name = "numTotalAmount";
            this.numTotalAmount.Size = new System.Drawing.Size(150, 20);
            this.numTotalAmount.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 203);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(130, 200);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 8;
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Location = new System.Drawing.Point(20, 233);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(92, 13);
            this.lblShippingAddress.TabIndex = 14;
            this.lblShippingAddress.Text = "Shipping Address:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(130, 230);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShippingAddress.Size = new System.Drawing.Size(300, 60);
            this.txtShippingAddress.TabIndex = 9;
            // 
            // lblBillingAddress
            // 
            this.lblBillingAddress.AutoSize = true;
            this.lblBillingAddress.Location = new System.Drawing.Point(20, 303);
            this.lblBillingAddress.Name = "lblBillingAddress";
            this.lblBillingAddress.Size = new System.Drawing.Size(78, 13);
            this.lblBillingAddress.TabIndex = 16;
            this.lblBillingAddress.Text = "Billing Address:";
            // 
            // txtBillingAddress
            // 
            this.txtBillingAddress.Location = new System.Drawing.Point(130, 300);
            this.txtBillingAddress.Multiline = true;
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBillingAddress.Size = new System.Drawing.Size(300, 60);
            this.txtBillingAddress.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 373);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 18;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(130, 370);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(300, 60);
            this.txtNotes.TabIndex = 11;
            // 
            // lblCreatedByDisplay
            // 
            this.lblCreatedByDisplay.AutoSize = true;
            this.lblCreatedByDisplay.Location = new System.Drawing.Point(20, 443);
            this.lblCreatedByDisplay.Name = "lblCreatedByDisplay";
            this.lblCreatedByDisplay.Size = new System.Drawing.Size(110, 13);
            this.lblCreatedByDisplay.TabIndex = 20;
            this.lblCreatedByDisplay.Text = "Created by: [User] on [Date]";
            this.lblCreatedByDisplay.Visible = false;
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(20, 463);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(70, 13);
            this.lblApprovedBy.TabIndex = 21;
            this.lblApprovedBy.Text = "Approved By:";
            // 
            // cmbApprovedBy
            // 
            this.cmbApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprovedBy.FormattingEnabled = true;
            this.cmbApprovedBy.Location = new System.Drawing.Point(130, 460);
            this.cmbApprovedBy.Name = "cmbApprovedBy";
            this.cmbApprovedBy.Size = new System.Drawing.Size(300, 21);
            this.cmbApprovedBy.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(240, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PurchaseOrderCreateEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(454, 536);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbApprovedBy);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.lblCreatedByDisplay);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtBillingAddress);
            this.Controls.Add(this.lblBillingAddress);
            this.Controls.Add(this.txtShippingAddress);
            this.Controls.Add(this.lblShippingAddress);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.numTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.dtpActualDeliveryDate);
            this.Controls.Add(this.chkSpecifyActualDeliveryDate);
            this.Controls.Add(this.dtpExpectedDeliveryDate);
            this.Controls.Add(this.chkSpecifyExpectedDeliveryDate);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseOrderCreateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Order Details";
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.CheckBox chkSpecifyExpectedDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedDeliveryDate;
        private System.Windows.Forms.CheckBox chkSpecifyActualDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpActualDeliveryDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.NumericUpDown numTotalAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private System.Windows.Forms.Label lblBillingAddress;
        private System.Windows.Forms.TextBox txtBillingAddress;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblCreatedByDisplay;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.ComboBox cmbApprovedBy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
