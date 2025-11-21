using System;
using System.Drawing;
using System.Windows.Forms;
using HumanitarianProjectManagement.UI;
using HumanitarianProjectManagement.Forms;
using HumanitarianProjectManagement.Models;
using System.Collections.Generic;
using HumanitarianProjectManagement.DataAccessLayer;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace HumanitarianProjectManagement.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly SectionService _sectionService;
        private readonly ProjectService _projectService;
        private bool _sidebarCollapsed = false;
        private int _originalSidebarWidth = 280;

        public DashboardForm()
        {
            InitializeComponent();
            InitializeModernTheme();

            _sectionService = new SectionService();
            _projectService = new ProjectService();

            // Wire up event handlers
            this.Load += DashboardForm_Load;

            // Set up hover effects for buttons
            SetupButtonHoverEffects();

            // Initialize dashboard data
            InitializeDashboardData();

            // Accessibility Enhancements
            SetupAccessibility();
        }

        private void InitializeModernTheme()
        {
            // Apply modern theme colors
            this.BackColor = Color.FromArgb(249, 250, 251);

            // Apply theme to sidebar
            pnlSidebar.BackColor = Color.FromArgb(31, 41, 55);
            pnlSidebarHeader.BackColor = Color.FromArgb(17, 24, 39);

            // Apply theme to main content
            pnlMainContent.BackColor = Color.FromArgb(249, 250, 251);

            // Apply theme to cards
            ApplyCardStyling();

            // Apply modern font
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        private void ApplyCardStyling()
        {
            // Style welcome section
            pnlWelcomeSection.BackColor = Color.White;
            AddCardShadow(pnlWelcomeSection);

            // Style quick stats section
            pnlQuickStats.BackColor = Color.White;
            AddCardShadow(pnlQuickStats);

            // Style quick actions section
            pnlQuickActions.BackColor = Color.White;
            AddCardShadow(pnlQuickActions);

            // Style stat cards with rounded corners effect
            StyleStatCard(pnlProjectsCard, Color.FromArgb(37, 99, 235));
            StyleStatCard(pnlBeneficiariesCard, Color.FromArgb(16, 185, 129));
            StyleStatCard(pnlBudgetCard, Color.FromArgb(245, 158, 11));
        }

        private void AddCardShadow(Panel panel)
        {
            // Simulate shadow effect with border
            panel.Paint += (sender, e) =>
            {
                var rect = panel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                using (var pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };
        }

        private void StyleStatCard(Panel card, Color backgroundColor)
        {
            card.BackColor = backgroundColor;
            card.Paint += (sender, e) =>
            {
                // Add subtle rounded corner effect
                var rect = card.ClientRectangle;
                using (var brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };
        }

        private void SetupButtonHoverEffects()
        {
            // Setup hover effects for action buttons
            SetupButtonHover(btnNewProject, Color.FromArgb(37, 99, 235), Color.FromArgb(29, 78, 216));
            SetupButtonHover(btnViewReports, Color.FromArgb(16, 185, 129), Color.FromArgb(5, 150, 105));
            SetupButtonHover(btnManageBeneficiaries, Color.FromArgb(245, 158, 11), Color.FromArgb(217, 119, 6));
            SetupButtonHover(btnAddSection, Color.FromArgb(37, 99, 235), Color.FromArgb(29, 78, 216));
            SetupButtonHover(btnToggleSidebar, Color.Transparent, Color.FromArgb(55, 65, 81));
        }

        private void SetupButtonHover(Button button, Color normalColor, Color hoverColor)
        {
            button.MouseEnter += (sender, e) =>
            {
                button.BackColor = hoverColor;
                button.Cursor = Cursors.Hand;
            };

            button.MouseLeave += (sender, e) =>
            {
                button.BackColor = normalColor;
                button.Cursor = Cursors.Default;
            };
        }

        private void InitializeDashboardData()
        {
            // Set welcome message with current user
            lblWelcomeTitle.Text = $"Welcome, {Environment.UserName}!";

            // Initialize status
            statusLabel.Text = "Dashboard loaded successfully";
        }

        private void SetupAccessibility()
        {
            // Main menu accessibility
            mainMenuStrip.AccessibleName = "Main application menu";
            fileToolStripMenuItem.AccessibleName = "File Menu";
            settingsToolStripMenuItem.AccessibleName = "Application Settings";
            exitToolStripMenuItem.AccessibleName = "Exit Application";
            helpToolStripMenuItem.AccessibleName = "Help Menu";
            aboutToolStripMenuItem.AccessibleName = "About Application";

            // Dashboard elements accessibility
            lblWelcomeTitle.AccessibleName = "Welcome message";
            pnlQuickStats.AccessibleName = "Quick statistics panel";
            pnlQuickActions.AccessibleName = "Quick actions panel";

            // Sidebar accessibility
            pnlSidebar.AccessibleName = "Navigation sidebar";
            tvwSections.AccessibleName = "Sections tree view";
            flpModuleButtons.AccessibleName = "Module buttons panel";
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadSectionsTreeViewAsync();
                AddOtherModuleButtons();
                await LoadDashboardStatsAsync();
                statusLabel.Text = "Dashboard ready";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Error loading dashboard";
            }
        }

        private async Task LoadSectionsTreeViewAsync()
        {
            tvwSections.Nodes.Clear();
            TreeNode sectionsRootNode = new TreeNode("📁 Sections")
            {
                ForeColor = Color.White // Removed Font property
            };
            tvwSections.Nodes.Add(sectionsRootNode);

            try
            {
                var sections = await _sectionService.GetSectionsAsync();
                if (sections != null)
                {
                    foreach (var section in sections)
                    {
                        TreeNode sectionNode = new TreeNode($"📂 {section.SectionName}")
                        {
                            Tag = section.SectionID,
                            ForeColor = Color.FromArgb(209, 213, 219) // Removed Font property
                        };
                        sectionsRootNode.Nodes.Add(sectionNode);
                    }
                }
                sectionsRootNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sections: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDashboardStatsAsync()
        {
            try
            {
                // Load project count
                var projects = await _projectService.GetAllProjectsAsync(); // Updated method name
                lblProjectsCount.Text = projects?.Count.ToString() ?? "0";

                // Load beneficiaries count (placeholder)
                lblBeneficiariesCount.Text = "0"; // TODO: Implement beneficiaries service

                // Load budget total (placeholder)
                lblBudgetAmount.Text = "$0"; // TODO: Implement budget calculation

                statusLabel.Text = "Statistics updated";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddOtherModuleButtons()
        {
            flpModuleButtons.Controls.Clear();

            var moduleButtonProperties = new[]
            {
                new { Text = "📊 Projects (All)", Icon = "📊", FormType = typeof(ProjectListForm) },
                new { Text = "📈 Monitoring & Evaluation", Icon = "📈", FormType = typeof(ProjectListForm) },
                //new { Text = "🛒 Purchasing", Icon = "🛒", FormType = typeof(PurchaseOrderListForm) },
                new { Text = "👥 Beneficiaries", Icon = "👥", FormType = typeof(BeneficiaryListManagementForm) },
                //new { Text = "📦 Stock Management", Icon = "📦", FormType = typeof(StockItemListForm) }
            };

            foreach (var props in moduleButtonProperties)
            {
                Button btnModule = CreateModuleButton(props.Text, props.FormType);
                flpModuleButtons.Controls.Add(btnModule);
            }
        }

        private Button CreateModuleButton(string text, Type formType)
        {
            Button btnModule = new Button
            {
                Text = text,
                Height = 45,
                Width = flpModuleButtons.ClientSize.Width - 20,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = Color.FromArgb(55, 65, 81),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btnModule.FlatAppearance.BorderSize = 0;

            // Add hover effect
            btnModule.MouseEnter += (sender, e) =>
            {
                btnModule.BackColor = Color.FromArgb(75, 85, 99);
            };

            btnModule.MouseLeave += (sender, e) =>
            {
                btnModule.BackColor = Color.FromArgb(55, 65, 81);
            };

            btnModule.Click += (sender, e) =>
            {
                try
                {
                    Form formToOpen = (Form)Activator.CreateInstance(formType);
                    OpenFormInPanel(formToOpen);
                    statusLabel.Text = $"Opened {text}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening {text}: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            return btnModule;
        }

        private void OpenFormInPanel(Form formToOpen)
        {
            // Clear existing content
            foreach (Control ctrl in pnlMainContent.Controls)
            {
                if (ctrl is Form currentForm)
                {
                    currentForm.Close();
                }
            }
            pnlMainContent.Controls.Clear();

            // Add new form
            formToOpen.TopLevel = false;
            formToOpen.FormBorderStyle = FormBorderStyle.None;
            formToOpen.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(formToOpen);
            formToOpen.Tag = "DynamicForm";
            formToOpen.Show();
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _sidebarCollapsed = !_sidebarCollapsed;

            if (_sidebarCollapsed)
            {
                pnlSidebar.Width = 60;
                lblAppTitle.Visible = false;
                lblSectionsTitle.Visible = false;
                lblModulesTitle.Visible = false;
                tvwSections.Visible = false;
                btnAddSection.Visible = false;

                // Hide module button text
                foreach (Button btn in flpModuleButtons.Controls)
                {
                    btn.Width = 40;
                    btn.Text = btn.Text.Split(' ')[0]; // Show only icon
                }
            }
            else
            {
                pnlSidebar.Width = _originalSidebarWidth;
                lblAppTitle.Visible = true;
                lblSectionsTitle.Visible = true;
                lblModulesTitle.Visible = true;
                tvwSections.Visible = true;
                btnAddSection.Visible = true;

                // Restore module button text
                AddOtherModuleButtons();
            }
        }

        private async void btnAddSection_Click(object sender, EventArgs e)
        {
            string sectionName = Interaction.InputBox(
                "Enter the name for the new section:",
                "Add New Section",
                "");

            if (!string.IsNullOrWhiteSpace(sectionName))
            {
                string sectionDescription = Interaction.InputBox(
                    "Enter the description for the new section (optional):",
                    "Add Section Description",
                    "");

                Section newSection = new Section
                {
                    SectionName = sectionName,
                    Description = sectionDescription
                };

                try
                {
                    int newSectionId = await _sectionService.AddSectionAsync(newSection);
                    if (newSectionId > 0)
                    {
                        MessageBox.Show("Section added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadSectionsTreeViewAsync();
                        statusLabel.Text = "New section added";
                    }
                    else
                    {
                        MessageBox.Show("Failed to add section.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding section: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tvwSections_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null && e.Node.Parent == tvwSections.Nodes[0])
            {
                if (int.TryParse(e.Node.Tag.ToString(), out int sectionId))
                {
                    ProjectListForm projectListForm = new ProjectListForm(sectionId);
                    OpenFormInPanel(projectListForm);
                    statusLabel.Text = $"Viewing projects for {e.Node.Text}";
                }
            }
        }

        // Quick Action Button Events
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the constructor explicitly to resolve ambiguity
                ProjectCreateEditForm newProjectForm = new ProjectCreateEditForm(null, null);
                OpenFormInPanel(newProjectForm);
                statusLabel.Text = "Creating new project";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening new project form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports functionality will be implemented soon.", "Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            statusLabel.Text = "Reports feature coming soon";
        }

        private void btnManageBeneficiaries_Click(object sender, EventArgs e)
        {
            try
            {
                BeneficiaryListManagementForm beneficiariesForm = new BeneficiaryListManagementForm();
                OpenFormInPanel(beneficiariesForm);
                statusLabel.Text = "Managing beneficiaries";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening beneficiaries form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Event Handlers
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Humanitarian Project Management System\n" +
                "Version 2.0 - Modern Edition\n\n" +
                "Enhanced with modern UI design\n" +
                "Developed for humanitarian organizations",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Ensure all MDI children are closed
                if (this.IsMdiContainer)
                {
                    foreach (Form mdiChild in this.MdiChildren)
                    {
                        mdiChild.Close();
                    }
                }
                Application.Exit();
            }
        }

        // Method to refresh dashboard data
        public async void RefreshDashboard()
        {
            try
            {
                await LoadSectionsTreeViewAsync();
                await LoadDashboardStatsAsync();
                statusLabel.Text = "Dashboard refreshed";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
