namespace HumanitarianProjectManagement.Forms
{
    partial class BeneficiaryListManagementForm
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
            this.lblSelectProject = new System.Windows.Forms.Label();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.lblBeneficiaryLists = new System.Windows.Forms.Label();
            this.dgvBeneficiaryLists = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRefreshLists = new System.Windows.Forms.Button();
            this.btnViewBeneficiaries = new System.Windows.Forms.Button();
            this.btnDeleteList = new System.Windows.Forms.Button();
            this.btnEditList = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficiaryLists)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectProject
            // 
            this.lblSelectProject.AutoSize = true;
            this.lblSelectProject.Location = new System.Drawing.Point(12, 15);
            this.lblSelectProject.Name = "lblSelectProject";
            this.lblSelectProject.Size = new System.Drawing.Size(77, 13);
            this.lblSelectProject.TabIndex = 0;
            this.lblSelectProject.Text = "Select Project:";
            // 
            // cmbProjects
            // 
            this.cmbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(95, 12);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(300, 21);
            this.cmbProjects.TabIndex = 1;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // lblBeneficiaryLists
            // 
            this.lblBeneficiaryLists.AutoSize = true;
            this.lblBeneficiaryLists.Location = new System.Drawing.Point(12, 50);
            this.lblBeneficiaryLists.Name = "lblBeneficiaryLists";
            this.lblBeneficiaryLists.Size = new System.Drawing.Size(135, 13);
            this.lblBeneficiaryLists.TabIndex = 2;
            this.lblBeneficiaryLists.Text = "Beneficiary Lists for Project:";
            // 
            // dgvBeneficiaryLists
            // 
            this.dgvBeneficiaryLists.AllowUserToAddRows = false;
            this.dgvBeneficiaryLists.AllowUserToDeleteRows = false;
            this.dgvBeneficiaryLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBeneficiaryLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeneficiaryLists.Location = new System.Drawing.Point(15, 70);
            this.dgvBeneficiaryLists.Name = "dgvBeneficiaryLists";
            this.dgvBeneficiaryLists.ReadOnly = true;
            this.dgvBeneficiaryLists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBeneficiaryLists.Size = new System.Drawing.Size(757, 440);
            this.dgvBeneficiaryLists.TabIndex = 3;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRefreshLists);
            this.pnlButtons.Controls.Add(this.btnViewBeneficiaries);
            this.pnlButtons.Controls.Add(this.btnDeleteList);
            this.pnlButtons.Controls.Add(this.btnEditList);
            this.pnlButtons.Controls.Add(this.btnAddList);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 516);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(784, 45);
            this.pnlButtons.TabIndex = 4;
            // 
            // btnRefreshLists
            // 
            this.btnRefreshLists.Location = new System.Drawing.Point(448, 10);
            this.btnRefreshLists.Name = "btnRefreshLists";
            this.btnRefreshLists.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshLists.TabIndex = 4;
            this.btnRefreshLists.Text = "Refresh";
            this.btnRefreshLists.UseVisualStyleBackColor = true;
            this.btnRefreshLists.Click += new System.EventHandler(this.btnRefreshLists_Click);
            // 
            // btnViewBeneficiaries
            // 
            this.btnViewBeneficiaries.Location = new System.Drawing.Point(286, 10);
            this.btnViewBeneficiaries.Name = "btnViewBeneficiaries";
            this.btnViewBeneficiaries.Size = new System.Drawing.Size(156, 23);
            this.btnViewBeneficiaries.TabIndex = 3;
            this.btnViewBeneficiaries.Text = "Manage Beneficiaries in List";
            this.btnViewBeneficiaries.UseVisualStyleBackColor = true;
            this.btnViewBeneficiaries.Click += new System.EventHandler(this.btnViewBeneficiaries_Click);
            // 
            // btnDeleteList
            // 
            this.btnDeleteList.Location = new System.Drawing.Point(180, 10);
            this.btnDeleteList.Name = "btnDeleteList";
            this.btnDeleteList.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteList.TabIndex = 2;
            this.btnDeleteList.Text = "Delete List";
            this.btnDeleteList.UseVisualStyleBackColor = true;
            this.btnDeleteList.Click += new System.EventHandler(this.btnDeleteList_Click);
            // 
            // btnEditList
            // 
            this.btnEditList.Location = new System.Drawing.Point(99, 10);
            this.btnEditList.Name = "btnEditList";
            this.btnEditList.Size = new System.Drawing.Size(75, 23);
            this.btnEditList.TabIndex = 1;
            this.btnEditList.Text = "Edit List";
            this.btnEditList.UseVisualStyleBackColor = true;
            this.btnEditList.Click += new System.EventHandler(this.btnEditList_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.Location = new System.Drawing.Point(18, 10);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(75, 23);
            this.btnAddList.TabIndex = 0;
            this.btnAddList.Text = "Add List";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // BeneficiaryListManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.dgvBeneficiaryLists);
            this.Controls.Add(this.lblBeneficiaryLists);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.lblSelectProject);
            this.Name = "BeneficiaryListManagementForm";
            this.Text = "Beneficiary List Management";
            this.Load += new System.EventHandler(this.BeneficiaryListManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficiaryLists)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectProject;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label lblBeneficiaryLists;
        private System.Windows.Forms.DataGridView dgvBeneficiaryLists;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnEditList;
        private System.Windows.Forms.Button btnDeleteList;
        private System.Windows.Forms.Button btnViewBeneficiaries;
        private System.Windows.Forms.Button btnRefreshLists;
    }
}
