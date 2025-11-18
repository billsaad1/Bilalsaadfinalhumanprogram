namespace HumanitarianProjectManagement.Forms
{
    partial class ProjectIndicatorCreateEditForm
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
            this.lblProjectDisplay = new System.Windows.Forms.Label();
            this.txtProjectDisplay = new System.Windows.Forms.TextBox();
            this.lblIndicatorName = new System.Windows.Forms.Label();
            this.txtIndicatorName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.txtTargetValue = new System.Windows.Forms.TextBox();
            this.lblActualValue = new System.Windows.Forms.Label();
            this.txtActualValue = new System.Windows.Forms.TextBox();
            this.lblUnitOfMeasure = new System.Windows.Forms.Label();
            this.txtUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.lblBaselineValue = new System.Windows.Forms.Label();
            this.txtBaselineValue = new System.Windows.Forms.TextBox();
            this.chkSpecifyStartDate = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.chkSpecifyEndDate = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsKeyIndicator = new System.Windows.Forms.CheckBox();
            this.lblMeansOfVerification = new System.Windows.Forms.Label();
            this.txtMeansOfVerificationText = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProjectDisplay
            // 
            this.lblProjectDisplay.AutoSize = true;
            this.lblProjectDisplay.Location = new System.Drawing.Point(20, 23);
            this.lblProjectDisplay.Name = "lblProjectDisplay";
            this.lblProjectDisplay.Size = new System.Drawing.Size(43, 13);
            this.lblProjectDisplay.TabIndex = 0;
            this.lblProjectDisplay.Text = "Project:";
            // 
            // txtProjectDisplay
            // 
            this.txtProjectDisplay.Location = new System.Drawing.Point(130, 20);
            this.txtProjectDisplay.Name = "txtProjectDisplay";
            this.txtProjectDisplay.ReadOnly = true;
            this.txtProjectDisplay.Size = new System.Drawing.Size(300, 20);
            this.txtProjectDisplay.TabIndex = 0; // TabStop = false
            this.txtProjectDisplay.TabStop = false;
            // 
            // lblIndicatorName
            // 
            this.lblIndicatorName.AutoSize = true;
            this.lblIndicatorName.Location = new System.Drawing.Point(20, 53);
            this.lblIndicatorName.Name = "lblIndicatorName";
            this.lblIndicatorName.Size = new System.Drawing.Size(81, 13);
            this.lblIndicatorName.TabIndex = 2;
            this.lblIndicatorName.Text = "Indicator Name:";
            // 
            // txtIndicatorName
            // 
            this.txtIndicatorName.Location = new System.Drawing.Point(130, 50);
            this.txtIndicatorName.Multiline = true;
            this.txtIndicatorName.Name = "txtIndicatorName";
            this.txtIndicatorName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIndicatorName.Size = new System.Drawing.Size(300, 40);
            this.txtIndicatorName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 103);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 100);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.TabIndex = 2;
            // 
            // lblTargetValue
            // 
            this.lblTargetValue.AutoSize = true;
            this.lblTargetValue.Location = new System.Drawing.Point(20, 173);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(70, 13);
            this.lblTargetValue.TabIndex = 6;
            this.lblTargetValue.Text = "Target Value:";
            // 
            // txtTargetValue
            // 
            this.txtTargetValue.Location = new System.Drawing.Point(130, 170);
            this.txtTargetValue.Name = "txtTargetValue";
            this.txtTargetValue.Size = new System.Drawing.Size(150, 20);
            this.txtTargetValue.TabIndex = 3;
            // 
            // lblActualValue
            // 
            this.lblActualValue.AutoSize = true;
            this.lblActualValue.Location = new System.Drawing.Point(20, 203);
            this.lblActualValue.Name = "lblActualValue";
            this.lblActualValue.Size = new System.Drawing.Size(69, 13);
            this.lblActualValue.TabIndex = 8;
            this.lblActualValue.Text = "Actual Value:";
            // 
            // txtActualValue
            // 
            this.txtActualValue.Location = new System.Drawing.Point(130, 200);
            this.txtActualValue.Name = "txtActualValue";
            this.txtActualValue.Size = new System.Drawing.Size(150, 20);
            this.txtActualValue.TabIndex = 4;
            // 
            // lblUnitOfMeasure
            // 
            this.lblUnitOfMeasure.AutoSize = true;
            this.lblUnitOfMeasure.Location = new System.Drawing.Point(20, 233);
            this.lblUnitOfMeasure.Name = "lblUnitOfMeasure";
            this.lblUnitOfMeasure.Size = new System.Drawing.Size(85, 13);
            this.lblUnitOfMeasure.TabIndex = 10;
            this.lblUnitOfMeasure.Text = "Unit of Measure:";
            // 
            // txtUnitOfMeasure
            // 
            this.txtUnitOfMeasure.Location = new System.Drawing.Point(130, 230);
            this.txtUnitOfMeasure.Name = "txtUnitOfMeasure";
            this.txtUnitOfMeasure.Size = new System.Drawing.Size(150, 20);
            this.txtUnitOfMeasure.TabIndex = 5;
            // 
            // lblBaselineValue
            // 
            this.lblBaselineValue.AutoSize = true;
            this.lblBaselineValue.Location = new System.Drawing.Point(20, 263);
            this.lblBaselineValue.Name = "lblBaselineValue";
            this.lblBaselineValue.Size = new System.Drawing.Size(80, 13);
            this.lblBaselineValue.TabIndex = 12;
            this.lblBaselineValue.Text = "Baseline Value:";
            // 
            // txtBaselineValue
            // 
            this.txtBaselineValue.Location = new System.Drawing.Point(130, 260);
            this.txtBaselineValue.Name = "txtBaselineValue";
            this.txtBaselineValue.Size = new System.Drawing.Size(150, 20);
            this.txtBaselineValue.TabIndex = 6;
            // 
            // chkSpecifyStartDate
            // 
            this.chkSpecifyStartDate.AutoSize = true;
            this.chkSpecifyStartDate.Location = new System.Drawing.Point(23, 292);
            this.chkSpecifyStartDate.Name = "chkSpecifyStartDate";
            this.chkSpecifyStartDate.Size = new System.Drawing.Size(77, 17);
            this.chkSpecifyStartDate.TabIndex = 7;
            this.chkSpecifyStartDate.Text = "Start Date:";
            this.chkSpecifyStartDate.UseVisualStyleBackColor = true;
            this.chkSpecifyStartDate.CheckedChanged += new System.EventHandler(this.chkSpecifyStartDate_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(130, 290);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 20);
            this.dtpStartDate.TabIndex = 8;
            // 
            // chkSpecifyEndDate
            // 
            this.chkSpecifyEndDate.AutoSize = true;
            this.chkSpecifyEndDate.Location = new System.Drawing.Point(23, 322);
            this.chkSpecifyEndDate.Name = "chkSpecifyEndDate";
            this.chkSpecifyEndDate.Size = new System.Drawing.Size(74, 17);
            this.chkSpecifyEndDate.TabIndex = 9;
            this.chkSpecifyEndDate.Text = "End Date:";
            this.chkSpecifyEndDate.UseVisualStyleBackColor = true;
            this.chkSpecifyEndDate.CheckedChanged += new System.EventHandler(this.chkSpecifyEndDate_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(130, 320);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 20);
            this.dtpEndDate.TabIndex = 10;
            // 
            // chkIsKeyIndicator
            // 
            this.chkIsKeyIndicator.AutoSize = true;
            this.chkIsKeyIndicator.Location = new System.Drawing.Point(130, 350);
            this.chkIsKeyIndicator.Name = "chkIsKeyIndicator";
            this.chkIsKeyIndicator.Size = new System.Drawing.Size(103, 17);
            this.chkIsKeyIndicator.TabIndex = 11;
            this.chkIsKeyIndicator.Text = "Is Key Indicator?";
            this.chkIsKeyIndicator.UseVisualStyleBackColor = true;
            // 
            // lblMeansOfVerification
            // 
            this.lblMeansOfVerification.AutoSize = true;
            this.lblMeansOfVerification.Location = new System.Drawing.Point(20, 383);
            this.lblMeansOfVerification.Name = "lblMeansOfVerification";
            this.lblMeansOfVerification.Size = new System.Drawing.Size(110, 13);
            this.lblMeansOfVerification.TabIndex = 19;
            this.lblMeansOfVerification.Text = "Means of Verification:";
            // 
            // txtMeansOfVerificationText
            // 
            this.txtMeansOfVerificationText.Location = new System.Drawing.Point(130, 380);
            this.txtMeansOfVerificationText.Multiline = true;
            this.txtMeansOfVerificationText.Name = "txtMeansOfVerificationText";
            this.txtMeansOfVerificationText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMeansOfVerificationText.Size = new System.Drawing.Size(300, 60);
            this.txtMeansOfVerificationText.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 455);
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
            this.btnCancel.Location = new System.Drawing.Point(240, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProjectIndicatorCreateEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(454, 496);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMeansOfVerificationText);
            this.Controls.Add(this.lblMeansOfVerification);
            this.Controls.Add(this.chkIsKeyIndicator);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.chkSpecifyEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.chkSpecifyStartDate);
            this.Controls.Add(this.txtBaselineValue);
            this.Controls.Add(this.lblBaselineValue);
            this.Controls.Add(this.txtUnitOfMeasure);
            this.Controls.Add(this.lblUnitOfMeasure);
            this.Controls.Add(this.txtActualValue);
            this.Controls.Add(this.lblActualValue);
            this.Controls.Add(this.txtTargetValue);
            this.Controls.Add(this.lblTargetValue);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtIndicatorName);
            this.Controls.Add(this.lblIndicatorName);
            this.Controls.Add(this.txtProjectDisplay);
            this.Controls.Add(this.lblProjectDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectIndicatorCreateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Indicator Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectDisplay;
        private System.Windows.Forms.TextBox txtProjectDisplay;
        private System.Windows.Forms.Label lblIndicatorName;
        private System.Windows.Forms.TextBox txtIndicatorName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTargetValue;
        private System.Windows.Forms.TextBox txtTargetValue;
        private System.Windows.Forms.Label lblActualValue;
        private System.Windows.Forms.TextBox txtActualValue;
        private System.Windows.Forms.Label lblUnitOfMeasure;
        private System.Windows.Forms.TextBox txtUnitOfMeasure;
        private System.Windows.Forms.Label lblBaselineValue;
        private System.Windows.Forms.TextBox txtBaselineValue;
        private System.Windows.Forms.CheckBox chkSpecifyStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.CheckBox chkSpecifyEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox chkIsKeyIndicator;
        private System.Windows.Forms.Label lblMeansOfVerification;
        private System.Windows.Forms.TextBox txtMeansOfVerificationText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
