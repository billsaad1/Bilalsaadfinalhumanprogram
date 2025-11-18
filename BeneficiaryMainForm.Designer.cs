using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.Forms
{
    partial class BeneficiaryMainForm
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
            this.lblListNameDisplay = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchBeneficiary = new System.Windows.Forms.TextBox();
            this.btnSearchBeneficiary = new System.Windows.Forms.Button();
            this.btnClearSearchBeneficiary = new System.Windows.Forms.Button();
            this.dgvBeneficiaries = new System.Windows.Forms.DataGridView();
            this.pnlBeneficiaryControls = new System.Windows.Forms.Panel();
            this.btnExportBeneficiaries = new System.Windows.Forms.Button();
            this.btnImportBeneficiaries = new System.Windows.Forms.Button();
            this.btnDeleteBeneficiary = new System.Windows.Forms.Button();
            this.btnEditBeneficiary = new System.Windows.Forms.Button();
            this.btnAddBeneficiary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficiaries)).BeginInit();
            this.pnlBeneficiaryControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblListNameDisplay
            // 
            this.lblListNameDisplay.AutoSize = true;
            this.lblListNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListNameDisplay.Location = new System.Drawing.Point(12, 9);
            this.lblListNameDisplay.Name = "lblListNameDisplay";
            this.lblListNameDisplay.Size = new System.Drawing.Size(131, 17);
            this.lblListNameDisplay.TabIndex = 0;
            this.lblListNameDisplay.Text = "List Name: [List]";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 40);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(102, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search (Name/ID):";
            // 
            // txtSearchBeneficiary
            // 
            this.txtSearchBeneficiary.Location = new System.Drawing.Point(120, 37);
            this.txtSearchBeneficiary.Name = "txtSearchBeneficiary";
            this.txtSearchBeneficiary.Size = new System.Drawing.Size(250, 20);
            this.txtSearchBeneficiary.TabIndex = 0;
            // 
            // btnSearchBeneficiary
            // 
            this.btnSearchBeneficiary.Location = new System.Drawing.Point(376, 35);
            this.btnSearchBeneficiary.Name = "btnSearchBeneficiary";
            this.btnSearchBeneficiary.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBeneficiary.TabIndex = 1;
            this.btnSearchBeneficiary.Text = "Search";
            this.btnSearchBeneficiary.UseVisualStyleBackColor = true;
            this.btnSearchBeneficiary.Click += new System.EventHandler(this.btnSearchBeneficiary_Click);
            // 
            // btnClearSearchBeneficiary
            // 
            this.btnClearSearchBeneficiary.Location = new System.Drawing.Point(457, 35);
            this.btnClearSearchBeneficiary.Name = "btnClearSearchBeneficiary";
            this.btnClearSearchBeneficiary.Size = new System.Drawing.Size(75, 23);
            this.btnClearSearchBeneficiary.TabIndex = 2;
            this.btnClearSearchBeneficiary.Text = "Clear";
            this.btnClearSearchBeneficiary.UseVisualStyleBackColor = true;
            this.btnClearSearchBeneficiary.Click += new System.EventHandler(this.btnClearSearchBeneficiary_Click);
            // 
            // dgvBeneficiaries
            // 
            this.dgvBeneficiaries.AllowUserToAddRows = false;
            this.dgvBeneficiaries.AllowUserToDeleteRows = false;
            this.dgvBeneficiaries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBeneficiaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeneficiaries.Location = new System.Drawing.Point(15, 70);
            this.dgvBeneficiaries.Name = "dgvBeneficiaries";
            this.dgvBeneficiaries.ReadOnly = true;
            this.dgvBeneficiaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBeneficiaries.Size = new System.Drawing.Size(757, 440);
            this.dgvBeneficiaries.TabIndex = 3;
            // 
            // pnlBeneficiaryControls
            // 
            this.pnlBeneficiaryControls.Controls.Add(this.btnExportBeneficiaries);
            this.pnlBeneficiaryControls.Controls.Add(this.btnImportBeneficiaries);
            this.pnlBeneficiaryControls.Controls.Add(this.btnDeleteBeneficiary);
            this.pnlBeneficiaryControls.Controls.Add(this.btnEditBeneficiary);
            this.pnlBeneficiaryControls.Controls.Add(this.btnAddBeneficiary);
            this.pnlBeneficiaryControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBeneficiaryControls.Location = new System.Drawing.Point(0, 516);
            this.pnlBeneficiaryControls.Name = "pnlBeneficiaryControls";
            this.pnlBeneficiaryControls.Size = new System.Drawing.Size(784, 45);
            this.pnlBeneficiaryControls.TabIndex = 4;
            // 
            // btnExportBeneficiaries
            // 
            this.btnExportBeneficiaries.Location = new System.Drawing.Point(418, 10);
            this.btnExportBeneficiaries.Name = "btnExportBeneficiaries";
            this.btnExportBeneficiaries.Size = new System.Drawing.Size(75, 23);
            this.btnExportBeneficiaries.TabIndex = 4;
            this.btnExportBeneficiaries.Text = "Export";
            this.btnExportBeneficiaries.UseVisualStyleBackColor = true;
            this.btnExportBeneficiaries.Click += new System.EventHandler(this.btnExportBeneficiaries_Click);
            // 
            // btnImportBeneficiaries
            // 
            this.btnImportBeneficiaries.Location = new System.Drawing.Point(337, 10);
            this.btnImportBeneficiaries.Name = "btnImportBeneficiaries";
            this.btnImportBeneficiaries.Size = new System.Drawing.Size(75, 23);
            this.btnImportBeneficiaries.TabIndex = 3;
            this.btnImportBeneficiaries.Text = "Import";
            this.btnImportBeneficiaries.UseVisualStyleBackColor = true;
            this.btnImportBeneficiaries.Click += new System.EventHandler(this.btnImportBeneficiaries_Click);
            // 
            // btnDeleteBeneficiary
            // 
            this.btnDeleteBeneficiary.Location = new System.Drawing.Point(216, 10);
            this.btnDeleteBeneficiary.Name = "btnDeleteBeneficiary";
            this.btnDeleteBeneficiary.Size = new System.Drawing.Size(115, 23);
            this.btnDeleteBeneficiary.TabIndex = 2;
            this.btnDeleteBeneficiary.Text = "Delete Beneficiary";
            this.btnDeleteBeneficiary.UseVisualStyleBackColor = true;
            this.btnDeleteBeneficiary.Click += new System.EventHandler(this.btnDeleteBeneficiary_Click);
            // 
            // btnEditBeneficiary
            // 
            this.btnEditBeneficiary.Location = new System.Drawing.Point(115, 10);
            this.btnEditBeneficiary.Name = "btnEditBeneficiary";
            this.btnEditBeneficiary.Size = new System.Drawing.Size(95, 23);
            this.btnEditBeneficiary.TabIndex = 1;
            this.btnEditBeneficiary.Text = "Edit Beneficiary";
            this.btnEditBeneficiary.UseVisualStyleBackColor = true;
            this.btnEditBeneficiary.Click += new System.EventHandler(this.btnEditBeneficiary_Click);
            // 
            // btnAddBeneficiary
            // 
            this.btnAddBeneficiary.Location = new System.Drawing.Point(14, 10);
            this.btnAddBeneficiary.Name = "btnAddBeneficiary";
            this.btnAddBeneficiary.Size = new System.Drawing.Size(95, 23);
            this.btnAddBeneficiary.TabIndex = 0;
            this.btnAddBeneficiary.Text = "Add Beneficiary";
            this.btnAddBeneficiary.UseVisualStyleBackColor = true;
            this.btnAddBeneficiary.Click += new System.EventHandler(this.btnAddBeneficiary_Click);
            // 
            // BeneficiaryMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlBeneficiaryControls);
            this.Controls.Add(this.dgvBeneficiaries);
            this.Controls.Add(this.btnClearSearchBeneficiary);
            this.Controls.Add(this.btnSearchBeneficiary);
            this.Controls.Add(this.txtSearchBeneficiary);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblListNameDisplay);
            this.Name = "BeneficiaryMainForm";
            this.Text = "Beneficiaries in List:";
            this.Load += new System.EventHandler(this.BeneficiaryMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficiaries)).EndInit();
            this.pnlBeneficiaryControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListNameDisplay;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchBeneficiary;
        private System.Windows.Forms.Button btnSearchBeneficiary;
        private System.Windows.Forms.Button btnClearSearchBeneficiary;
        private System.Windows.Forms.DataGridView dgvBeneficiaries;
        private System.Windows.Forms.Panel pnlBeneficiaryControls;
        private System.Windows.Forms.Button btnAddBeneficiary;
        private System.Windows.Forms.Button btnEditBeneficiary;
        private System.Windows.Forms.Button btnDeleteBeneficiary;
        private System.Windows.Forms.Button btnImportBeneficiaries;
        private System.Windows.Forms.Button btnExportBeneficiaries;
    }
}
