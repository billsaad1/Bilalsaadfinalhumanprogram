namespace HumanitarianProjectManagement.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblOrganizationName = new System.Windows.Forms.Label();
            this.txtOrganizationName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnBrowseLogo = new System.Windows.Forms.Button();
            this.lblLogoPath = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblOrganizationName
            //
            this.lblOrganizationName.AutoSize = true;
            this.lblOrganizationName.Location = new System.Drawing.Point(12, 15);
            this.lblOrganizationName.Name = "lblOrganizationName";
            this.lblOrganizationName.Size = new System.Drawing.Size(103, 13);
            this.lblOrganizationName.TabIndex = 0;
            this.lblOrganizationName.Text = "Organization Name:";
            //
            // txtOrganizationName
            //
            this.txtOrganizationName.Location = new System.Drawing.Point(121, 12);
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.Size = new System.Drawing.Size(251, 20);
            this.txtOrganizationName.TabIndex = 1;
            //
            // lblAddress
            //
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 41);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address:";
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(121, 38);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(251, 20);
            this.txtAddress.TabIndex = 3;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 67);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(121, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(251, 20);
            this.txtEmail.TabIndex = 5;
            //
            // lblCountry
            //
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(12, 93);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 13);
            this.lblCountry.TabIndex = 6;
            this.lblCountry.Text = "Country:";
            //
            // txtCountry
            //
            this.txtCountry.Location = new System.Drawing.Point(121, 90);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(251, 20);
            this.txtCountry.TabIndex = 7;
            //
            // lblLogo
            //
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(12, 119);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(34, 13);
            this.lblLogo.TabIndex = 8;
            this.lblLogo.Text = "Logo:";
            //
            // btnBrowseLogo
            //
            this.btnBrowseLogo.Location = new System.Drawing.Point(121, 114);
            this.btnBrowseLogo.Name = "btnBrowseLogo";
            this.btnBrowseLogo.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLogo.TabIndex = 9;
            this.btnBrowseLogo.Text = "Browse...";
            this.btnBrowseLogo.UseVisualStyleBackColor = true;
            this.btnBrowseLogo.Click += new System.EventHandler(this.btnBrowseLogo_Click);
            //
            // lblLogoPath
            //
            this.lblLogoPath.AutoSize = true;
            this.lblLogoPath.Location = new System.Drawing.Point(202, 119);
            this.lblLogoPath.Name = "lblLogoPath";
            this.lblLogoPath.Size = new System.Drawing.Size(0, 13);
            this.lblLogoPath.TabIndex = 10;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(216, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(297, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // cmbLanguage
            //
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(121, 143);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 13;
            //
            // lblLanguage
            //
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(12, 146);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 14;
            this.lblLanguage.Text = "Language:";
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 215);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLogoPath);
            this.Controls.Add(this.btnBrowseLogo);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtOrganizationName);
            this.Controls.Add(this.lblOrganizationName);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblOrganizationName;
        private System.Windows.Forms.TextBox txtOrganizationName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnBrowseLogo;
        private System.Windows.Forms.Label lblLogoPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
    }
}
