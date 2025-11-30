using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace HumanitarianProjectManagement.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private readonly HpmDbContext _context;

        public LoginForm()
        {
            InitializeComponent();
            _context = new HpmDbContext();
            _userService = new UserService(_context);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Subscribe to the language changed event
            ApplicationStyleManager.LanguageChanged += (s, e) => ApplyLocalization();

            ApplyLocalization();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = await _userService.AuthenticateUser(username, password);

            if (user != null)
            {
                ApplicationState.CurrentUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ApplyLocalization()
        {
            // Set Right-to-Left layout if the language is Arabic
            if (Thread.CurrentThread.CurrentUICulture.Name == "ar")
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
            }

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Text = resources.GetString("$this.Text");
            this.lblUsername.Text = resources.GetString("lblUsername.Text");
            this.lblPassword.Text = resources.GetString("lblPassword.Text");
            this.btnLogin.Text = resources.GetString("btnLogin.Text");
            this.btnCancel.Text = resources.GetString("btnCancel.Text");
        }
    }
}
