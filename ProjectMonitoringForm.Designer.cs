namespace HumanitarianProjectManagement.Forms
{
    partial class ProjectMonitoringForm
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
            this.lblProjectNameDisplay = new System.Windows.Forms.Label();
            this.dgvProjectIndicators = new System.Windows.Forms.DataGridView();
            this.pnlIndicatorActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddIndicator = new System.Windows.Forms.Button();
            this.btnEditIndicator = new System.Windows.Forms.Button();
            this.btnDeleteIndicator = new System.Windows.Forms.Button();
            this.btnRefreshIndicators = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectIndicators)).BeginInit();
            this.pnlIndicatorActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjectNameDisplay
            // 
            this.lblProjectNameDisplay.AutoSize = true;
            this.lblProjectNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectNameDisplay.Location = new System.Drawing.Point(12, 9);
            this.lblProjectNameDisplay.Name = "lblProjectNameDisplay";
            this.lblProjectNameDisplay.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5); // Add padding to bottom
            this.lblProjectNameDisplay.Size = new System.Drawing.Size(200, 22);
            this.lblProjectNameDisplay.TabIndex = 0;
            this.lblProjectNameDisplay.Text = "Indicators for Project: [Name]";
            // 
            // dgvProjectIndicators
            // 
            this.dgvProjectIndicators.AllowUserToAddRows = false;
            this.dgvProjectIndicators.AllowUserToDeleteRows = false;
            this.dgvProjectIndicators.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProjectIndicators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectIndicators.Location = new System.Drawing.Point(0, 35); // Position below label and actions panel
            this.dgvProjectIndicators.Name = "dgvProjectIndicators";
            this.dgvProjectIndicators.ReadOnly = true;
            this.dgvProjectIndicators.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjectIndicators.Size = new System.Drawing.Size(784, 476);
            this.dgvProjectIndicators.TabIndex = 2; // After lblProjectNameDisplay and pnlIndicatorActions
            // 
            // pnlIndicatorActions
            // 
            this.pnlIndicatorActions.Controls.Add(this.btnAddIndicator);
            this.pnlIndicatorActions.Controls.Add(this.btnEditIndicator);
            this.pnlIndicatorActions.Controls.Add(this.btnDeleteIndicator);
            this.pnlIndicatorActions.Controls.Add(this.btnRefreshIndicators);
            this.pnlIndicatorActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlIndicatorActions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlIndicatorActions.Location = new System.Drawing.Point(0, 516);
            this.pnlIndicatorActions.Name = "pnlIndicatorActions";
            this.pnlIndicatorActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlIndicatorActions.Size = new System.Drawing.Size(784, 45);
            this.pnlIndicatorActions.TabIndex = 1; // Before dgvProjectIndicators
            // 
            // btnAddIndicator
            // 
            this.btnAddIndicator.Location = new System.Drawing.Point(8, 8);
            this.btnAddIndicator.Name = "btnAddIndicator";
            this.btnAddIndicator.Size = new System.Drawing.Size(100, 23);
            this.btnAddIndicator.TabIndex = 0;
            this.btnAddIndicator.Text = "Add Indicator";
            this.btnAddIndicator.UseVisualStyleBackColor = true;
            this.btnAddIndicator.Click += new System.EventHandler(this.btnAddIndicator_Click);
            // 
            // btnEditIndicator
            // 
            this.btnEditIndicator.Location = new System.Drawing.Point(114, 8);
            this.btnEditIndicator.Name = "btnEditIndicator";
            this.btnEditIndicator.Size = new System.Drawing.Size(120, 23);
            this.btnEditIndicator.TabIndex = 1;
            this.btnEditIndicator.Text = "Edit/Update Indicator";
            this.btnEditIndicator.UseVisualStyleBackColor = true;
            this.btnEditIndicator.Click += new System.EventHandler(this.btnEditIndicator_Click);
            // 
            // btnDeleteIndicator
            // 
            this.btnDeleteIndicator.Location = new System.Drawing.Point(240, 8);
            this.btnDeleteIndicator.Name = "btnDeleteIndicator";
            this.btnDeleteIndicator.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteIndicator.TabIndex = 2;
            this.btnDeleteIndicator.Text = "Delete Indicator";
            this.btnDeleteIndicator.UseVisualStyleBackColor = true;
            this.btnDeleteIndicator.Click += new System.EventHandler(this.btnDeleteIndicator_Click);
            // 
            // btnRefreshIndicators
            // 
            this.btnRefreshIndicators.Location = new System.Drawing.Point(346, 8);
            this.btnRefreshIndicators.Name = "btnRefreshIndicators";
            this.btnRefreshIndicators.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshIndicators.TabIndex = 3;
            this.btnRefreshIndicators.Text = "Refresh";
            this.btnRefreshIndicators.UseVisualStyleBackColor = true;
            this.btnRefreshIndicators.Click += new System.EventHandler(this.btnRefreshIndicators_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(697, 10); // Part of pnlIndicatorActions
            this.pnlIndicatorActions.Controls.Add(this.btnClose); // Add to panel
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4; // Last in panel
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProjectMonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvProjectIndicators);
            this.Controls.Add(this.pnlIndicatorActions);
            this.Controls.Add(this.lblProjectNameDisplay);
            this.Name = "ProjectMonitoringForm";
            this.Text = "Project Monitoring"; // Base title
            this.Load += new System.EventHandler(this.ProjectMonitoringForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectIndicators)).EndInit();
            this.pnlIndicatorActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectNameDisplay;
        private System.Windows.Forms.DataGridView dgvProjectIndicators;
        private System.Windows.Forms.FlowLayoutPanel pnlIndicatorActions;
        private System.Windows.Forms.Button btnAddIndicator;
        private System.Windows.Forms.Button btnEditIndicator;
        private System.Windows.Forms.Button btnDeleteIndicator;
        private System.Windows.Forms.Button btnRefreshIndicators;
        private System.Windows.Forms.Button btnClose;
    }
}
