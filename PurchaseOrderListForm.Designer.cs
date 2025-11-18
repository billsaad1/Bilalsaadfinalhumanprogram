namespace HumanitarianProjectManagement.Forms
{
    partial class PurchaseOrderListForm
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
            this.pnlFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilterProject = new System.Windows.Forms.Label();
            this.cmbFilterProject = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.chkFilterFromDate = new System.Windows.Forms.CheckBox();
            this.dtpFilterFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkFilterToDate = new System.Windows.Forms.CheckBox();
            this.dtpFilterToDate = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.dgvPurchaseOrders = new System.Windows.Forms.DataGridView();
            this.pnlActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreatePO = new System.Windows.Forms.Button();
            this.btnViewEditPO = new System.Windows.Forms.Button();
            this.btnCancelDeletePO = new System.Windows.Forms.Button();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.lblFilterProject);
            this.pnlFilters.Controls.Add(this.cmbFilterProject);
            this.pnlFilters.Controls.Add(this.lblFilterStatus);
            this.pnlFilters.Controls.Add(this.cmbFilterStatus);
            this.pnlFilters.Controls.Add(this.chkFilterFromDate);
            this.pnlFilters.Controls.Add(this.dtpFilterFromDate);
            this.pnlFilters.Controls.Add(this.chkFilterToDate);
            this.pnlFilters.Controls.Add(this.dtpFilterToDate);
            this.pnlFilters.Controls.Add(this.btnApplyFilters);
            this.pnlFilters.Controls.Add(this.btnClearFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFilters.Size = new System.Drawing.Size(784, 65);
            this.pnlFilters.TabIndex = 0;
            // 
            // lblFilterProject
            // 
            this.lblFilterProject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilterProject.AutoSize = true;
            this.lblFilterProject.Location = new System.Drawing.Point(8, 13);
            this.lblFilterProject.Name = "lblFilterProject";
            this.lblFilterProject.Size = new System.Drawing.Size(43, 13);
            this.lblFilterProject.TabIndex = 0;
            this.lblFilterProject.Text = "Project:";
            // 
            // cmbFilterProject
            // 
            this.cmbFilterProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterProject.FormattingEnabled = true;
            this.cmbFilterProject.Location = new System.Drawing.Point(57, 8);
            this.cmbFilterProject.Name = "cmbFilterProject";
            this.cmbFilterProject.Size = new System.Drawing.Size(200, 21);
            this.cmbFilterProject.TabIndex = 1;
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Location = new System.Drawing.Point(263, 13);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(40, 13);
            this.lblFilterStatus.TabIndex = 2;
            this.lblFilterStatus.Text = "Status:";
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(309, 8);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterStatus.TabIndex = 3;
            // 
            // chkFilterFromDate
            // 
            this.chkFilterFromDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFilterFromDate.AutoSize = true;
            this.chkFilterFromDate.Location = new System.Drawing.Point(436, 12);
            this.chkFilterFromDate.Name = "chkFilterFromDate";
            this.chkFilterFromDate.Size = new System.Drawing.Size(52, 17);
            this.chkFilterFromDate.TabIndex = 4;
            this.chkFilterFromDate.Text = "From:";
            this.chkFilterFromDate.UseVisualStyleBackColor = true;
            this.chkFilterFromDate.CheckedChanged += new System.EventHandler(this.chkFilterFromDate_CheckedChanged);
            // 
            // dtpFilterFromDate
            // 
            this.dtpFilterFromDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFilterFromDate.Enabled = false;
            this.dtpFilterFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterFromDate.Location = new System.Drawing.Point(494, 10);
            this.dtpFilterFromDate.Name = "dtpFilterFromDate";
            this.dtpFilterFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFilterFromDate.TabIndex = 5;
            // 
            // chkFilterToDate
            // 
            this.chkFilterToDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFilterToDate.AutoSize = true;
            this.chkFilterToDate.Location = new System.Drawing.Point(8, 39); // New row
            this.chkFilterToDate.Name = "chkFilterToDate";
            this.chkFilterToDate.Size = new System.Drawing.Size(42, 17);
            this.chkFilterToDate.TabIndex = 6;
            this.chkFilterToDate.Text = "To:";
            this.chkFilterToDate.UseVisualStyleBackColor = true;
            this.chkFilterToDate.CheckedChanged += new System.EventHandler(this.chkFilterToDate_CheckedChanged);
            // 
            // dtpFilterToDate
            // 
            this.dtpFilterToDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFilterToDate.Enabled = false;
            this.dtpFilterToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterToDate.Location = new System.Drawing.Point(56, 37); // New row
            this.dtpFilterToDate.Name = "dtpFilterToDate";
            this.dtpFilterToDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFilterToDate.TabIndex = 7;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApplyFilters.Location = new System.Drawing.Point(162, 35); // New row
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFilters.TabIndex = 8;
            this.btnApplyFilters.Text = "Apply";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearFilters.Location = new System.Drawing.Point(243, 35); // New row
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 23);
            this.btnClearFilters.TabIndex = 9;
            this.btnClearFilters.Text = "Clear/Refresh";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // dgvPurchaseOrders
            // 
            this.dgvPurchaseOrders.AllowUserToAddRows = false;
            this.dgvPurchaseOrders.AllowUserToDeleteRows = false;
            this.dgvPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseOrders.Location = new System.Drawing.Point(0, 65);
            this.dgvPurchaseOrders.Name = "dgvPurchaseOrders";
            this.dgvPurchaseOrders.ReadOnly = true;
            this.dgvPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseOrders.Size = new System.Drawing.Size(784, 451);
            this.dgvPurchaseOrders.TabIndex = 1;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnCreatePO);
            this.pnlActions.Controls.Add(this.btnViewEditPO);
            this.pnlActions.Controls.Add(this.btnCancelDeletePO);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlActions.Location = new System.Drawing.Point(0, 516);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlActions.Size = new System.Drawing.Size(784, 45);
            this.pnlActions.TabIndex = 2;
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Location = new System.Drawing.Point(8, 8);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(100, 23);
            this.btnCreatePO.TabIndex = 0;
            this.btnCreatePO.Text = "Create New PO";
            this.btnCreatePO.UseVisualStyleBackColor = true;
            this.btnCreatePO.Click += new System.EventHandler(this.btnCreatePO_Click);
            // 
            // btnViewEditPO
            // 
            this.btnViewEditPO.Location = new System.Drawing.Point(114, 8);
            this.btnViewEditPO.Name = "btnViewEditPO";
            this.btnViewEditPO.Size = new System.Drawing.Size(100, 23);
            this.btnViewEditPO.TabIndex = 1;
            this.btnViewEditPO.Text = "View/Edit PO";
            this.btnViewEditPO.UseVisualStyleBackColor = true;
            this.btnViewEditPO.Click += new System.EventHandler(this.btnViewEditPO_Click);
            // 
            // btnCancelDeletePO
            // 
            this.btnCancelDeletePO.Location = new System.Drawing.Point(220, 8);
            this.btnCancelDeletePO.Name = "btnCancelDeletePO";
            this.btnCancelDeletePO.Size = new System.Drawing.Size(110, 23);
            this.btnCancelDeletePO.TabIndex = 2;
            this.btnCancelDeletePO.Text = "Cancel/Delete PO";
            this.btnCancelDeletePO.UseVisualStyleBackColor = true;
            this.btnCancelDeletePO.Click += new System.EventHandler(this.btnCancelDeletePO_Click);
            // 
            // PurchaseOrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvPurchaseOrders);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilters);
            this.Name = "PurchaseOrderListForm";
            this.Text = "Purchase Order Management";
            this.Load += new System.EventHandler(this.PurchaseOrderListForm_Load);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlFilters;
        private System.Windows.Forms.Label lblFilterProject;
        private System.Windows.Forms.ComboBox cmbFilterProject;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.CheckBox chkFilterFromDate;
        private System.Windows.Forms.DateTimePicker dtpFilterFromDate;
        private System.Windows.Forms.CheckBox chkFilterToDate;
        private System.Windows.Forms.DateTimePicker dtpFilterToDate;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.DataGridView dgvPurchaseOrders;
        private System.Windows.Forms.FlowLayoutPanel pnlActions;
        private System.Windows.Forms.Button btnCreatePO;
        private System.Windows.Forms.Button btnViewEditPO;
        private System.Windows.Forms.Button btnCancelDeletePO;
    }
}
