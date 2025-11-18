using System;
using System.Windows.Forms;
using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using System.Threading.Tasks;
using HumanitarianProjectManagement.UI; // Added

namespace HumanitarianProjectManagement.Forms
{
    public partial class LoginForm : Form
    {
        private UserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this); // Added
            _userService = new UserService();

            // Accessibility Enhancements
            txtUsername.AccessibleName = "Username";
            txtUsername.AccessibleDescription = "Enter your account username.";
            txtPassword.AccessibleName = "Password";
            txtPassword.AccessibleDescription = "Enter your account password.";
            btnLogin.AccessibleName = "Login button";
            btnCancel.AccessibleName = "Cancel button";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // No trim on password

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnLogin.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            this.UseWaitCursor = true;

            try
            {
                User authenticatedUser = await _userService.AuthenticateUserAsync(username, password);

                if (authenticatedUser != null)
                {
                    // Store authenticated user in ApplicationState
                    ApplicationState.CurrentUser = authenticatedUser;

                    // Successful login - Set DialogResult and Close. Program.cs will handle Dashboard.
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Failed login
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear(); // Clear password field
                    txtUsername.Focus(); // Set focus back to username
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                this.UseWaitCursor = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Password recovery feature is not yet implemented.", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
