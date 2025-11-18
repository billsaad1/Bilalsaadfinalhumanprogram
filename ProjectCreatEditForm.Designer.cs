namespace HumanitarianProjectManagement.Forms
{
    partial class ProjectCreateEditForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControlProjectDetails = new System.Windows.Forms.TabControl();
            this.tabPageGeneralInfo = new System.Windows.Forms.TabPage();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectCode = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblOverallObjective = new System.Windows.Forms.Label();
            this.txtOverallObjective = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblDonor = new System.Windows.Forms.Label();
            this.txtDonor = new System.Windows.Forms.TextBox();
            this.lblTotalBudget = new System.Windows.Forms.Label();
            this.nudTotalBudget = new System.Windows.Forms.NumericUpDown();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();

            this.tabPageLogFrame = new System.Windows.Forms.TabPage();
            this.pnlLogFrameMain = new System.Windows.Forms.Panel();
            this.btnAddOutcome = new System.Windows.Forms.Button();
            this.pnlOutcome1 = new System.Windows.Forms.Panel();
            this.lblOutcome1 = new System.Windows.Forms.Label();
            this.txtOutcome1Description = new System.Windows.Forms.TextBox();
            this.btnAddOutputToOutcome1 = new System.Windows.Forms.Button();
            this.btnAddIndicatorToOutcome1_placeholder = new System.Windows.Forms.Button();
            this.btnAddActivityViaOutcome1_placeholder = new System.Windows.Forms.Button();

            // tabPageDetailedBudget and flpBudgetCategories related initializations are removed here

            this.tabPageActivityPlan = new System.Windows.Forms.TabPage();
            this.dgvActivityPlan = new System.Windows.Forms.DataGridView();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.tabControlProjectDetails.SuspendLayout();
            this.tabPageGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalBudget)).BeginInit();
            this.tabPageLogFrame.SuspendLayout();
            this.pnlLogFrameMain.SuspendLayout();
            this.pnlOutcome1.SuspendLayout();
            // this.tabPageDetailedBudget.SuspendLayout(); // Removed
            this.tabPageActivityPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityPlan)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlProjectDetails
            //
            this.tabControlProjectDetails.Controls.Add(this.tabPageGeneralInfo);
            this.tabControlProjectDetails.Controls.Add(this.tabPageLogFrame);
            // this.tabControlProjectDetails.Controls.Add(this.tabPageDetailedBudget); // Removed
            this.tabControlProjectDetails.Controls.Add(this.tabPageActivityPlan);
            this.tabControlProjectDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlProjectDetails.Location = new System.Drawing.Point(0, 0);
            this.tabControlProjectDetails.Name = "tabControlProjectDetails";
            this.tabControlProjectDetails.SelectedIndex = 0;
            this.tabControlProjectDetails.Size = new System.Drawing.Size(434, 451);
            this.tabControlProjectDetails.TabIndex = 0;
            //
            // tabPageGeneralInfo
            //
            this.tabPageGeneralInfo.Controls.Add(this.lblProjectName);
            this.tabPageGeneralInfo.Controls.Add(this.txtProjectName);
            this.tabPageGeneralInfo.Controls.Add(this.lblProjectCode);
            this.tabPageGeneralInfo.Controls.Add(this.txtProjectCode);
            this.tabPageGeneralInfo.Controls.Add(this.lblStartDate);
            this.tabPageGeneralInfo.Controls.Add(this.dtpStartDate);
            this.tabPageGeneralInfo.Controls.Add(this.lblEndDate);
            this.tabPageGeneralInfo.Controls.Add(this.dtpEndDate);
            this.tabPageGeneralInfo.Controls.Add(this.lblLocation);
            this.tabPageGeneralInfo.Controls.Add(this.txtLocation);
            this.tabPageGeneralInfo.Controls.Add(this.lblOverallObjective);
            this.tabPageGeneralInfo.Controls.Add(this.txtOverallObjective);
            this.tabPageGeneralInfo.Controls.Add(this.lblStatus);
            this.tabPageGeneralInfo.Controls.Add(this.txtStatus);
            this.tabPageGeneralInfo.Controls.Add(this.lblDonor);
            this.tabPageGeneralInfo.Controls.Add(this.txtDonor);
            this.tabPageGeneralInfo.Controls.Add(this.lblTotalBudget);
            this.tabPageGeneralInfo.Controls.Add(this.nudTotalBudget);
            this.tabPageGeneralInfo.Controls.Add(this.lblSection);
            this.tabPageGeneralInfo.Controls.Add(this.cmbSection);
            this.tabPageGeneralInfo.Controls.Add(this.lblManager);
            this.tabPageGeneralInfo.Controls.Add(this.cmbManager);
            this.tabPageGeneralInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneralInfo.Name = "tabPageGeneralInfo";
            this.tabPageGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralInfo.Size = new System.Drawing.Size(426, 425);
            this.tabPageGeneralInfo.TabIndex = 0;
            this.tabPageGeneralInfo.Text = "General Info";
            this.tabPageGeneralInfo.UseVisualStyleBackColor = true;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(15, 18);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(74, 13);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(120, 15);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(280, 20);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblProjectCode
            // 
            this.lblProjectCode.AutoSize = true;
            this.lblProjectCode.Location = new System.Drawing.Point(15, 48);
            this.lblProjectCode.Name = "lblProjectCode";
            this.lblProjectCode.Size = new System.Drawing.Size(71, 13);
            this.lblProjectCode.TabIndex = 2;
            this.lblProjectCode.Text = "Project Code:";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(120, 45);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(280, 20);
            this.txtProjectCode.TabIndex = 2;
            //
            // dtpStartDate, dtpEndDate, txtLocation etc. (rest of General Info controls)
            // ... (assuming these are unchanged and correctly placed as per original)
            //
            int currentY = 75;
            int labelX = 15;
            int controlX = 120;
            int tabIdx = 3;

            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Text = "Start Date:";
            this.dtpStartDate.Location = new System.Drawing.Point(controlX, currentY);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Size = new System.Drawing.Size(130, 20);
            this.dtpStartDate.TabIndex = tabIdx++;
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Checked = false;
            currentY += 30;

            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Text = "End Date:";
            this.dtpEndDate.Location = new System.Drawing.Point(controlX, currentY);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Size = new System.Drawing.Size(130, 20);
            this.dtpEndDate.TabIndex = tabIdx++;
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Checked = false;
            currentY += 30;

            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Text = "Location:";
            this.txtLocation.Location = new System.Drawing.Point(controlX, currentY);
            this.txtLocation.Multiline = true;
            this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLocation.Size = new System.Drawing.Size(280, 40);
            this.txtLocation.TabIndex = tabIdx++;
            currentY += 50;

            this.lblOverallObjective.AutoSize = true;
            this.lblOverallObjective.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblOverallObjective.Name = "lblOverallObjective";
            this.lblOverallObjective.Text = "Overall Objective:";
            this.txtOverallObjective.Location = new System.Drawing.Point(controlX, currentY);
            this.txtOverallObjective.Multiline = true;
            this.txtOverallObjective.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOverallObjective.Size = new System.Drawing.Size(280, 40);
            this.txtOverallObjective.TabIndex = tabIdx++;
            currentY += 50;

            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status:";
            this.txtStatus.Location = new System.Drawing.Point(controlX, currentY);
            this.txtStatus.Size = new System.Drawing.Size(280, 20);
            this.txtStatus.TabIndex = tabIdx++;
            currentY += 30;

            this.lblDonor.AutoSize = true;
            this.lblDonor.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblDonor.Name = "lblDonor";
            this.lblDonor.Text = "Donor:";
            this.txtDonor.Location = new System.Drawing.Point(controlX, currentY);
            this.txtDonor.Size = new System.Drawing.Size(280, 20);
            this.txtDonor.TabIndex = tabIdx++;
            currentY += 30;

            this.lblTotalBudget.AutoSize = true;
            this.lblTotalBudget.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblTotalBudget.Name = "lblTotalBudget";
            this.lblTotalBudget.Text = "Total Budget:";
            this.nudTotalBudget.Location = new System.Drawing.Point(controlX, currentY);
            this.nudTotalBudget.DecimalPlaces = 2;
            this.nudTotalBudget.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudTotalBudget.Size = new System.Drawing.Size(150, 20);
            this.nudTotalBudget.TabIndex = tabIdx++;
            currentY += 30;

            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblSection.Name = "lblSection";
            this.lblSection.Text = "Section:";
            this.cmbSection.Location = new System.Drawing.Point(controlX, currentY);
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Size = new System.Drawing.Size(280, 21);
            this.cmbSection.TabIndex = tabIdx++;
            currentY += 30;

            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(labelX, currentY + 3);
            this.lblManager.Name = "lblManager";
            this.lblManager.Text = "Manager:";
            this.cmbManager.Location = new System.Drawing.Point(controlX, currentY);
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.Size = new System.Drawing.Size(280, 21);
            this.cmbManager.TabIndex = tabIdx++;
            // 
            // tabPageLogFrame
            // 
            this.tabPageLogFrame.Controls.Add(this.pnlLogFrameMain);
            this.tabPageLogFrame.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogFrame.Name = "tabPageLogFrame";
            this.tabPageLogFrame.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogFrame.Size = new System.Drawing.Size(426, 425);
            this.tabPageLogFrame.TabIndex = 1;
            this.tabPageLogFrame.Text = "Logical Framework";
            this.tabPageLogFrame.UseVisualStyleBackColor = true;
            // 
            // pnlLogFrameMain
            // 
            this.pnlLogFrameMain.AutoScroll = true;
            this.pnlLogFrameMain.Controls.Add(this.btnAddOutcome);
            this.pnlLogFrameMain.Controls.Add(this.pnlOutcome1);
            this.pnlLogFrameMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogFrameMain.Location = new System.Drawing.Point(3, 3);
            this.pnlLogFrameMain.Name = "pnlLogFrameMain";
            this.pnlLogFrameMain.Size = new System.Drawing.Size(420, 419);
            this.pnlLogFrameMain.TabIndex = 0;
            // 
            // btnAddOutcome
            // 
            this.btnAddOutcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddOutcome.Location = new System.Drawing.Point(0, 0);
            this.btnAddOutcome.Name = "btnAddOutcome";
            this.btnAddOutcome.Size = new System.Drawing.Size(420, 23);
            this.btnAddOutcome.TabIndex = 0;
            this.btnAddOutcome.Text = "Add Outcome";
            this.btnAddOutcome.UseVisualStyleBackColor = true;
            // 
            // pnlOutcome1
            // 
            this.pnlOutcome1.AutoSize = true;
            this.pnlOutcome1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOutputsContainer = new System.Windows.Forms.Panel();
            this.pnlOutcome1.Controls.Add(this.pnlOutputsContainer);
            this.pnlOutcome1.Controls.Add(this.lblOutcome1);
            this.pnlOutcome1.Controls.Add(this.txtOutcome1Description);
            this.pnlOutcome1.Controls.Add(this.btnAddOutputToOutcome1);
            this.pnlOutcome1.Controls.Add(this.btnAddIndicatorToOutcome1_placeholder);
            this.pnlOutcome1.Controls.Add(this.btnAddActivityViaOutcome1_placeholder);
            this.pnlOutcome1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutcome1.Location = new System.Drawing.Point(0, 23);
            this.pnlOutcome1.Padding = new System.Windows.Forms.Padding(5);
            this.pnlOutcome1.Name = "pnlOutcome1";
            this.pnlOutcome1.Size = new System.Drawing.Size(420, 100);
            this.pnlOutcome1.TabIndex = 1;
            // 
            // lblOutcome1
            // 
            this.lblOutcome1.AutoSize = true;
            this.lblOutcome1.Location = new System.Drawing.Point(5, 5);
            this.lblOutcome1.Name = "lblOutcome1";
            this.lblOutcome1.Text = "Outcome 1:";
            // 
            // txtOutcome1Description
            // 
            this.txtOutcome1Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutcome1Description.Location = new System.Drawing.Point(5, 25);
            this.txtOutcome1Description.Multiline = true;
            this.txtOutcome1Description.Name = "txtOutcome1Description";
            this.txtOutcome1Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutcome1Description.Size = new System.Drawing.Size(408, 40);
            this.txtOutcome1Description.TabIndex = 0;
            // 
            // pnlOutputsContainer
            // 
            this.pnlOutputsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOutputsContainer.AutoScroll = true;
            this.pnlOutputsContainer.Location = new System.Drawing.Point(5, 70);
            this.pnlOutputsContainer.Name = "pnlOutputsContainer";
            this.pnlOutputsContainer.Size = new System.Drawing.Size(408, 0);
            this.pnlOutputsContainer.AutoSize = true;
            this.pnlOutputsContainer.MinimumSize = new System.Drawing.Size(0, 50);
            this.pnlOutputsContainer.TabIndex = 1;
            // 
            // btnAddOutputToOutcome1
            // 
            this.btnAddOutputToOutcome1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOutputToOutcome1.Location = new System.Drawing.Point(5, 65);
            this.btnAddOutputToOutcome1.Name = "btnAddOutputToOutcome1";
            this.btnAddOutputToOutcome1.Size = new System.Drawing.Size(100, 23);
            this.btnAddOutputToOutcome1.TabIndex = 1;
            this.btnAddOutputToOutcome1.Text = "Add Output";
            // 
            // btnAddIndicatorToOutcome1_placeholder
            // 
            this.btnAddIndicatorToOutcome1_placeholder.Location = new System.Drawing.Point(110, 70);
            this.btnAddIndicatorToOutcome1_placeholder.Name = "btnAddIndicatorToOutcome1_placeholder";
            this.btnAddIndicatorToOutcome1_placeholder.Size = new System.Drawing.Size(100, 23);
            this.btnAddIndicatorToOutcome1_placeholder.TabIndex = 2;
            this.btnAddIndicatorToOutcome1_placeholder.Text = "Add Indicator";
            // 
            // btnAddActivityViaOutcome1_placeholder
            // 
            this.btnAddActivityViaOutcome1_placeholder.Location = new System.Drawing.Point(215, 70);
            this.btnAddActivityViaOutcome1_placeholder.Name = "btnAddActivityViaOutcome1_placeholder";
            this.btnAddActivityViaOutcome1_placeholder.Size = new System.Drawing.Size(100, 23);
            this.btnAddActivityViaOutcome1_placeholder.TabIndex = 3;
            this.btnAddActivityViaOutcome1_placeholder.Text = "Add Activity";
            //
            // tabPageActivityPlan
            //
            this.tabPageActivityPlan.Controls.Add(this.dgvActivityPlan);
            this.tabPageActivityPlan.Location = new System.Drawing.Point(4, 22);
            this.tabPageActivityPlan.Name = "tabPageActivityPlan";
            this.tabPageActivityPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivityPlan.Size = new System.Drawing.Size(426, 425);
            this.tabPageActivityPlan.TabIndex = 3; // TabIndex might need adjustment if tabPageDetailedBudget was index 2
            this.tabPageActivityPlan.Text = "Activity Plan";
            this.tabPageActivityPlan.UseVisualStyleBackColor = true;
            // 
            // dgvActivityPlan
            // 
            this.dgvActivityPlan.AllowUserToAddRows = false;
            this.dgvActivityPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivityPlan.Location = new System.Drawing.Point(3, 3);
            this.dgvActivityPlan.Name = "dgvActivityPlan";
            this.dgvActivityPlan.Size = new System.Drawing.Size(420, 419);
            this.dgvActivityPlan.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 451);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(434, 40);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(228, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(329, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProjectCreateEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 491);
            this.Controls.Add(this.tabControlProjectDetails);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectCreateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Details";

            this.tabControlProjectDetails.ResumeLayout(false);
            this.tabPageGeneralInfo.ResumeLayout(false);
            this.tabPageGeneralInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalBudget)).EndInit();
            this.tabPageLogFrame.ResumeLayout(false);
            this.pnlLogFrameMain.ResumeLayout(false);
            this.pnlLogFrameMain.PerformLayout();
            this.pnlOutcome1.ResumeLayout(false);
            this.pnlOutcome1.PerformLayout();
            // this.tabPageDetailedBudget.ResumeLayout(false); // Removed
            this.tabPageActivityPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityPlan)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlProjectDetails;
        private System.Windows.Forms.TabPage tabPageGeneralInfo;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectCode;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblOverallObjective;
        private System.Windows.Forms.TextBox txtOverallObjective;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblDonor;
        private System.Windows.Forms.TextBox txtDonor;
        private System.Windows.Forms.Label lblTotalBudget;
        private System.Windows.Forms.NumericUpDown nudTotalBudget;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.TabPage tabPageLogFrame;
        private System.Windows.Forms.Panel pnlLogFrameMain;
        private System.Windows.Forms.Button btnAddOutcome;
        private System.Windows.Forms.Panel pnlOutcome1;
        private System.Windows.Forms.Label lblOutcome1;
        private System.Windows.Forms.TextBox txtOutcome1Description;
        private System.Windows.Forms.Panel pnlOutputsContainer;
        private System.Windows.Forms.Button btnAddOutputToOutcome1;
        private System.Windows.Forms.Button btnAddIndicatorToOutcome1_placeholder;
        private System.Windows.Forms.Button btnAddActivityViaOutcome1_placeholder;
        private HumanitarianProjectManagement.LogFrameTabUserControl logFrameTabUserControlInstance; // Added
        // Removed: private System.Windows.Forms.TabPage tabPageDetailedBudget;
        // Removed: private System.Windows.Forms.FlowLayoutPanel flpBudgetCategories;
        private System.Windows.Forms.TabPage tabPageActivityPlan;
        private System.Windows.Forms.DataGridView dgvActivityPlan;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlButtons;
    }
}
