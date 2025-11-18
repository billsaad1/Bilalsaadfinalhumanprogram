namespace HumanitarianProjectManagement.Forms
{
    partial class ProjectListForm
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
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnGoToMonitoring = new System.Windows.Forms.Button(); // Added
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.btnEditProject = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProjects
            // 
            this.dgvProjects.AllowUserToAddRows = false;
            this.dgvProjects.AllowUserToDeleteRows = false;
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProjects.Location = new System.Drawing.Point(0, 40);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.ReadOnly = true;
            this.dgvProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjects.Size = new System.Drawing.Size(784, 521);
            this.dgvProjects.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnGoToMonitoring); // Added
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnDeleteProject);
            this.pnlButtons.Controls.Add(this.btnEditProject);
            this.pnlButtons.Controls.Add(this.btnAddProject);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(784, 40);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnGoToMonitoring
            // 
            this.btnGoToMonitoring.Location = new System.Drawing.Point(336, 8); // Adjusted position
            this.btnGoToMonitoring.Name = "btnGoToMonitoring";
            this.btnGoToMonitoring.Size = new System.Drawing.Size(110, 23);
            this.btnGoToMonitoring.TabIndex = 3; // Adjusted TabIndex
            this.btnGoToMonitoring.Text = "M&E / Progress";
            this.btnGoToMonitoring.UseVisualStyleBackColor = true;
            this.btnGoToMonitoring.Click += new System.EventHandler(this.btnGoToMonitoring_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(452, 8); // Adjusted position
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 4; // Adjusted TabIndex
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(224, 8);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteProject.TabIndex = 2;
            this.btnDeleteProject.Text = "Delete Selected";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // btnEditProject
            // 
            this.btnEditProject.Location = new System.Drawing.Point(112, 8);
            this.btnEditProject.Name = "btnEditProject";
            this.btnEditProject.Size = new System.Drawing.Size(100, 23);
            this.btnEditProject.TabIndex = 1;
            this.btnEditProject.Text = "Edit Selected";
            this.btnEditProject.UseVisualStyleBackColor = true;
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(12, 8);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(90, 23);
            this.btnAddProject.TabIndex = 0;
            this.btnAddProject.Text = "Add New Project";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // ProjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvProjects);
            this.Controls.Add(this.pnlButtons);
            this.Name = "ProjectListForm";
            this.Text = "Projects List - Humanitarian Project Management System";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnEditProject;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGoToMonitoring; // Added
    }
}
