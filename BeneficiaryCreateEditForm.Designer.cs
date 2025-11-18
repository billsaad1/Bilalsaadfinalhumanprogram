namespace HumanitarianProjectManagement.Forms
{
    partial class BeneficiaryCreateEditForm
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
            this.lblBeneficiaryListDisplay = new System.Windows.Forms.Label();
            this.txtBeneficiaryListDisplay = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblNationalID = new System.Windows.Forms.Label();
            this.txtNationalID = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.chkSpecifyDateOfBirth = new System.Windows.Forms.CheckBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblHouseholdSize = new System.Windows.Forms.Label();
            this.numHouseholdSize = new System.Windows.Forms.NumericUpDown();
            this.chkSpecifyHouseholdSize = new System.Windows.Forms.CheckBox();
            this.lblVulnerabilityCriteria = new System.Windows.Forms.Label();
            this.txtVulnerabilityCriteria = new System.Windows.Forms.TextBox();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHouseholdSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBeneficiaryListDisplay
            // 
            this.lblBeneficiaryListDisplay.AutoSize = true;
            this.lblBeneficiaryListDisplay.Location = new System.Drawing.Point(20, 23);
            this.lblBeneficiaryListDisplay.Name = "lblBeneficiaryListDisplay";
            this.lblBeneficiaryListDisplay.Size = new System.Drawing.Size(83, 13);
            this.lblBeneficiaryListDisplay.TabIndex = 0;
            this.lblBeneficiaryListDisplay.Text = "Beneficiary List:";
            // 
            // txtBeneficiaryListDisplay
            // 
            this.txtBeneficiaryListDisplay.Location = new System.Drawing.Point(130, 20);
            this.txtBeneficiaryListDisplay.Name = "txtBeneficiaryListDisplay";
            this.txtBeneficiaryListDisplay.ReadOnly = true;
            this.txtBeneficiaryListDisplay.Size = new System.Drawing.Size(280, 20);
            this.txtBeneficiaryListDisplay.TabIndex = 0; // Non-interactive
            this.txtBeneficiaryListDisplay.TabStop = false;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 53);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(130, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(280, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 83);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(130, 80);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(280, 20);
            this.txtLastName.TabIndex = 2;
            // 
            // lblNationalID
            // 
            this.lblNationalID.AutoSize = true;
            this.lblNationalID.Location = new System.Drawing.Point(20, 113);
            this.lblNationalID.Name = "lblNationalID";
            this.lblNationalID.Size = new System.Drawing.Size(63, 13);
            this.lblNationalID.TabIndex = 6;
            this.lblNationalID.Text = "National ID:";
            // 
            // txtNationalID
            // 
            this.txtNationalID.Location = new System.Drawing.Point(130, 110);
            this.txtNationalID.Name = "txtNationalID";
            this.txtNationalID.Size = new System.Drawing.Size(280, 20);
            this.txtNationalID.TabIndex = 3;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(20, 143);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 13);
            this.lblDateOfBirth.TabIndex = 8;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Enabled = false;
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(130, 140);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 20);
            this.dtpDateOfBirth.TabIndex = 5; // After checkbox
            // 
            // chkSpecifyDateOfBirth
            // 
            this.chkSpecifyDateOfBirth.AutoSize = true;
            this.chkSpecifyDateOfBirth.Location = new System.Drawing.Point(290, 142);
            this.chkSpecifyDateOfBirth.Name = "chkSpecifyDateOfBirth";
            this.chkSpecifyDateOfBirth.Size = new System.Drawing.Size(89, 17);
            this.chkSpecifyDateOfBirth.TabIndex = 4; // Before DatePicker
            this.chkSpecifyDateOfBirth.Text = "Specify DOB";
            this.chkSpecifyDateOfBirth.UseVisualStyleBackColor = true;
            this.chkSpecifyDateOfBirth.CheckedChanged += new System.EventHandler(this.chkSpecifyDateOfBirth_CheckedChanged);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(20, 173);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 11;
            this.lblGender.Text = "Gender:";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other",
            "Prefer not to say"});
            this.cmbGender.Location = new System.Drawing.Point(130, 170);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(150, 21);
            this.cmbGender.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 203);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(130, 200);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(280, 60);
            this.txtAddress.TabIndex = 7;
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Location = new System.Drawing.Point(20, 273);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(87, 13);
            this.lblContactNumber.TabIndex = 15;
            this.lblContactNumber.Text = "Contact Number:";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(130, 270);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(280, 20);
            this.txtContactNumber.TabIndex = 8;
            // 
            // lblHouseholdSize
            // 
            this.lblHouseholdSize.AutoSize = true;
            this.lblHouseholdSize.Location = new System.Drawing.Point(20, 303);
            this.lblHouseholdSize.Name = "lblHouseholdSize";
            this.lblHouseholdSize.Size = new System.Drawing.Size(84, 13);
            this.lblHouseholdSize.TabIndex = 17;
            this.lblHouseholdSize.Text = "Household Size:";
            // 
            // numHouseholdSize
            // 
            this.numHouseholdSize.Enabled = false;
            this.numHouseholdSize.Location = new System.Drawing.Point(130, 300);
            this.numHouseholdSize.Name = "numHouseholdSize";
            this.numHouseholdSize.Size = new System.Drawing.Size(150, 20);
            this.numHouseholdSize.TabIndex = 10; // After checkbox
            // 
            // chkSpecifyHouseholdSize
            // 
            this.chkSpecifyHouseholdSize.AutoSize = true;
            this.chkSpecifyHouseholdSize.Location = new System.Drawing.Point(290, 302);
            this.chkSpecifyHouseholdSize.Name = "chkSpecifyHouseholdSize";
            this.chkSpecifyHouseholdSize.Size = new System.Drawing.Size(86, 17);
            this.chkSpecifyHouseholdSize.TabIndex = 9; // Before NumericUpDown
            this.chkSpecifyHouseholdSize.Text = "Specify Size";
            this.chkSpecifyHouseholdSize.UseVisualStyleBackColor = true;
            this.chkSpecifyHouseholdSize.CheckedChanged += new System.EventHandler(this.chkSpecifyHouseholdSize_CheckedChanged);
            // 
            // lblVulnerabilityCriteria
            // 
            this.lblVulnerabilityCriteria.AutoSize = true;
            this.lblVulnerabilityCriteria.Location = new System.Drawing.Point(20, 333);
            this.lblVulnerabilityCriteria.Name = "lblVulnerabilityCriteria";
            this.lblVulnerabilityCriteria.Size = new System.Drawing.Size(103, 13);
            this.lblVulnerabilityCriteria.TabIndex = 20;
            this.lblVulnerabilityCriteria.Text = "Vulnerability Criteria:";
            // 
            // txtVulnerabilityCriteria
            // 
            this.txtVulnerabilityCriteria.Location = new System.Drawing.Point(130, 330);
            this.txtVulnerabilityCriteria.Multiline = true;
            this.txtVulnerabilityCriteria.Name = "txtVulnerabilityCriteria";
            this.txtVulnerabilityCriteria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVulnerabilityCriteria.Size = new System.Drawing.Size(280, 60);
            this.txtVulnerabilityCriteria.TabIndex = 11;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Location = new System.Drawing.Point(20, 403);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(93, 13);
            this.lblRegistrationDate.TabIndex = 22;
            this.lblRegistrationDate.Text = "Registration Date:";
            // 
            // dtpRegistrationDate
            // 
            this.dtpRegistrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegistrationDate.Location = new System.Drawing.Point(130, 400);
            this.dtpRegistrationDate.Name = "dtpRegistrationDate";
            this.dtpRegistrationDate.Size = new System.Drawing.Size(150, 20);
            this.dtpRegistrationDate.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 440);
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
            this.btnCancel.Location = new System.Drawing.Point(240, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BeneficiaryCreateEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 481);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpRegistrationDate);
            this.Controls.Add(this.lblRegistrationDate);
            this.Controls.Add(this.txtVulnerabilityCriteria);
            this.Controls.Add(this.lblVulnerabilityCriteria);
            this.Controls.Add(this.chkSpecifyHouseholdSize);
            this.Controls.Add(this.numHouseholdSize);
            this.Controls.Add(this.lblHouseholdSize);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.lblContactNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.chkSpecifyDateOfBirth);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtNationalID);
            this.Controls.Add(this.lblNationalID);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtBeneficiaryListDisplay);
            this.Controls.Add(this.lblBeneficiaryListDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeneficiaryCreateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Beneficiary Details";
            ((System.ComponentModel.ISupportInitialize)(this.numHouseholdSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBeneficiaryListDisplay;
        private System.Windows.Forms.TextBox txtBeneficiaryListDisplay;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblNationalID;
        private System.Windows.Forms.TextBox txtNationalID;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.CheckBox chkSpecifyDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblHouseholdSize;
        private System.Windows.Forms.NumericUpDown numHouseholdSize;
        private System.Windows.Forms.CheckBox chkSpecifyHouseholdSize;
        private System.Windows.Forms.Label lblVulnerabilityCriteria;
        private System.Windows.Forms.TextBox txtVulnerabilityCriteria;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
