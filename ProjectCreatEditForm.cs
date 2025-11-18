// Using statements from the original file - confirmed to be sufficient
using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
// Using Models.Activity directly to avoid ambiguity
// using ProjectActivity = HumanitarianProjectManagement.Models.Activity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using HumanitarianProjectManagement.UI;
using System.Globalization;
using HumanitarianProjectManagement; // Added for ApplicationState if not implicitly available
using System.Diagnostics; // Added for Debug.WriteLine

// Provided by user in feedback 2024-05-16
namespace HumanitarianProjectManagement.Forms
{
    public partial class ProjectCreateEditForm : Form
    {
        private readonly ProjectService _projectService;
        private readonly SectionService _sectionService;
        private Project _currentProject;
        private readonly bool _isEditMode;
        private int? _initialSectionId;
        private readonly LogFrameService _logFrameService; // Keep for saving, if UserControl doesn't handle all saving
        // private Panel sidebarPanel; // For OLD LogFrame - No longer needed for new UserControl
        // private Panel pnlLogFrameMain; // For OLD LogFrame - No longer needed for new UserControl


        private BudgetTabUserControl _budgetTabControlInstance; // Instance of the new UserControl
        // logFrameTabUserControlInstance is declared in Designer.cs

        private class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }

        public ProjectCreateEditForm(Project projectToEdit = null)
            : this(projectToEdit, null)
        {
        }

        public ProjectCreateEditForm(Project projectToEdit = null, int? initialSectionId = null)
        {
            InitializeComponent();
            ThemeManager.ApplyThemeToForm(this);
            _projectService = new ProjectService();
            _sectionService = new SectionService();
            _logFrameService = new LogFrameService(); // May still be needed for saving the overall project
            _initialSectionId = initialSectionId;

            _isEditMode = (projectToEdit != null);
            this.WindowState = FormWindowState.Maximized;

            if (_isEditMode)
            {
                _currentProject = projectToEdit;
                this.Text = $"Edit Project - {_currentProject.ProjectName}";
                // Ensure Outcomes list is initialized for the UserControl, even if empty
                if (_currentProject.Outcomes == null) _currentProject.Outcomes = new List<Outcome>();
                PopulateControls();
            }
            else
            {
                _currentProject = new Project();
                this.Text = "Add New Project";
                // Ensure Outcomes list is initialized for the UserControl
                _currentProject.Outcomes = new List<Outcome>();
                dtpStartDate.Value = DateTime.Now;
                dtpStartDate.Checked = false;
                dtpEndDate.Checked = false;
            }

            this.Load += new System.EventHandler(this.ProjectCreateEditForm_Load);
        }

        private void InitializeBudgetUITab()
        {
            System.Diagnostics.Debug.WriteLine("InitializeBudgetUITab: Started.");
            try
            {
                if (this.tabControlProjectDetails == null)
                {
                    System.Diagnostics.Debug.WriteLine("InitializeBudgetUITab: tabControlProjectDetails is null. Cannot initialize Budget tab.");
                    return;
                }

                _budgetTabControlInstance = new BudgetTabUserControl();
                _budgetTabControlInstance.Dock = DockStyle.Fill;

                TabPage tabPageBudget = new TabPage();
                tabPageBudget.Name = "tabPageBudget";
                tabPageBudget.Text = "Budget";
                tabPageBudget.Controls.Add(_budgetTabControlInstance);

                if (this.tabControlProjectDetails.TabPages.ContainsKey("tabPageBudget"))
                {
                    System.Diagnostics.Debug.WriteLine("InitializeBudgetUITab: tabPageBudget already exists, removing to avoid duplication.");
                    this.tabControlProjectDetails.TabPages.RemoveByKey("tabPageBudget");
                }
                this.tabControlProjectDetails.TabPages.Add(tabPageBudget);
                System.Diagnostics.Debug.WriteLine($"InitializeBudgetUITab: tabPageBudget {(tabControlProjectDetails.TabPages.Contains(tabPageBudget) ? "successfully added" : "NOT found after adding")}. Name: {tabPageBudget.Name}");

                System.Diagnostics.Debug.WriteLine($"InitializeBudgetUITab: _currentProject is {(_currentProject == null ? "null" : "not null, ProjectID: " + _currentProject.ProjectID)}");
                if (_budgetTabControlInstance != null && _currentProject != null)
                {
                    _budgetTabControlInstance.LoadProject(_currentProject);
                }
                else if (_budgetTabControlInstance == null)
                {
                    System.Diagnostics.Debug.WriteLine("InitializeBudgetUITab: _budgetTabControlInstance is null. Cannot load project data.");
                }
                else if (_currentProject == null)
                {
                    System.Diagnostics.Debug.WriteLine("InitializeBudgetUITab: _currentProject is null. Budget tab will be initialized without project data.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InitializeBudgetUITab: EXCEPTION: {ex.ToString()}");
            }
        }

        private async void ProjectCreateEditForm_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: Started.");
            System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: tabControlProjectDetails is {(this.tabControlProjectDetails == null ? "null" : "found")}");

            try { await LoadComboBoxesAsync(); }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: EXCEPTION during LoadComboBoxesAsync: {ex.ToString()}");
                MessageBox.Show("Error loading sections/managers: " + ex.ToString(), "Load Data Exception");
                return;
            }

            // InitializeLogFrameUI(); // Old UI initialization commented out
            InitializeNewLogFrameTab(); // New UI initialization
            InitializeActivityPlanTab();
            InitializeBudgetUITab();

            System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: Attempting to apply role-based visibility for budget tab.");
            TabPage tabPageBudget = null; // Initialize to null

            // Load project into the new LogFrameTabUserControl after it has been initialized
            if (this.logFrameTabUserControlInstance != null && _currentProject != null)
            {
                await this.logFrameTabUserControlInstance.LoadProjectAsync(_currentProject);
                System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: Called LoadProjectAsync on logFrameTabUserControlInstance.");
            }
            else if (this.logFrameTabUserControlInstance == null)
            {
                System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: logFrameTabUserControlInstance is null. Cannot load project data into it.");
            }
            else if (_currentProject == null)
            {
                System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: _currentProject is null. LogFrame tab will be initialized without project data (handled by UserControl).");
            }

            try
            {
                tabPageBudget = tabControlProjectDetails.TabPages["tabPageBudget"];
                if (tabPageBudget == null)
                {
                    System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: Budget tab ('tabPageBudget') not found after initialization.");
                }
                else
                {
                    User currentUser = ApplicationState.CurrentUser;
                    System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: ApplicationState.CurrentUser is {(currentUser == null ? "null" : currentUser.Username)}");

                    if (currentUser == null)
                    {
                        System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: CurrentUser is null, preparing to hide budget tab.");
                        System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: Condition not met or user lacks permission, attempting to remove tabPageBudget.");
                        tabControlProjectDetails.TabPages.Remove(tabPageBudget);
                    }
                    else
                    {
                        UserService userService = new UserService();
                        List<int> roleIds = await userService.GetRoleIdsForUserAsync(currentUser.UserID);
                        System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: Fetched role IDs for user {currentUser.Username}: {(roleIds == null ? "null" : string.Join(", ", roleIds))}");

                        List<Role> allRoles = await userService.GetAllRolesAsync();
                        System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: Fetched all roles: {(allRoles == null ? "null" : string.Join(", ", allRoles.Select(r => r.RoleName)))}");

                        List<string> userRoleNames = roleIds
                            .Select(id => allRoles.FirstOrDefault(r => r.RoleID == id)?.RoleName)
                            .Where(name => name != null)
                            .ToList();

                        List<string> allowedRoleNames = new List<string> { "Administrator", "Project Manager", "Finance" };
                        System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: Allowed role names for budget tab: {string.Join(", ", allowedRoleNames)}");

                        bool userHasAllowedRole = userRoleNames.Any(userRole => allowedRoleNames.Contains(userRole));
                        System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: User {currentUser.Username} {(userHasAllowedRole ? "HAS" : "DOES NOT HAVE")} an allowed role.");

                        if (!userHasAllowedRole)
                        {
                            System.Diagnostics.Debug.WriteLine("ProjectCreateEditForm_Load: Condition not met or user lacks permission, attempting to remove tabPageBudget.");
                            tabControlProjectDetails.TabPages.Remove(tabPageBudget);
                        }
                    }
                }
                // Final check on tab visibility
                if (tabControlProjectDetails.TabPages.ContainsKey("tabPageBudget"))
                {
                    System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: tabPageBudget is visible/present.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: tabPageBudget is hidden/removed.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: EXCEPTION during role-based visibility: {ex.ToString()}");
                if (tabPageBudget != null && tabControlProjectDetails.TabPages.Contains(tabPageBudget))
                {
                    tabControlProjectDetails.TabPages.Remove(tabPageBudget);
                    System.Diagnostics.Debug.WriteLine($"ProjectCreateEditForm_Load: tabPageBudget removed due to exception in role check.");
                }
                MessageBox.Show("Error determining user permissions for the budget tab. The tab will be hidden as a precaution.", "Permissions Error");
            }

            DataGridView dgvActivityPlan = this.Controls.Find("dgvActivityPlan", true).FirstOrDefault() as DataGridView;
            if (dgvActivityPlan != null)
            {
                dgvActivityPlan.CellValueChanged -= dgvActivityPlan_CellValueChanged;
                dgvActivityPlan.CurrentCellDirtyStateChanged -= dgvActivityPlan_CurrentCellDirtyStateChanged;
                dgvActivityPlan.CellValueChanged += dgvActivityPlan_CellValueChanged;
                dgvActivityPlan.CurrentCellDirtyStateChanged += dgvActivityPlan_CurrentCellDirtyStateChanged;
            }

            if (this.dtpStartDate != null) { this.dtpStartDate.ValueChanged -= ProjectDatesChanged_RefreshActivityPlan; this.dtpStartDate.ValueChanged += ProjectDatesChanged_RefreshActivityPlan; }
            if (this.dtpEndDate != null) { this.dtpEndDate.ValueChanged -= ProjectDatesChanged_RefreshActivityPlan; this.dtpEndDate.ValueChanged += ProjectDatesChanged_RefreshActivityPlan; }
        }

        private void InitializeNewLogFrameTab()
        {
            System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: Started.");
            if (this.tabControlProjectDetails == null)
            {
                System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: tabControlProjectDetails is null. Cannot initialize LogFrame tab.");
                return;
            }

            TabPage logFrameTabPage = this.tabControlProjectDetails.TabPages["tabPageLogFrame"];
            if (logFrameTabPage == null)
            {
                System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: tabPageLogFrame not found by name 'tabPageLogFrame'. Attempting to find by Text or creating new.");
                // Attempt to find by Text property if Name is not set as expected or was changed.
                logFrameTabPage = this.tabControlProjectDetails.TabPages.Cast<TabPage>().FirstOrDefault(tp => tp.Text == "Logical Framework");

                if (logFrameTabPage == null)
                {
                    System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: tabPageLogFrame still not found, creating it.");
                    logFrameTabPage = new TabPage { Name = "tabPageLogFrame", Text = "Logical Framework" };
                    this.tabControlProjectDetails.TabPages.Add(logFrameTabPage);
                }
            }

            logFrameTabPage.Controls.Clear(); // Clear any old controls.

            // Ensure logFrameTabUserControlInstance is initialized (it's declared in Designer.cs)
            if (this.logFrameTabUserControlInstance == null)
            {
                this.logFrameTabUserControlInstance = new LogFrameTabUserControl();
                System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: logFrameTabUserControlInstance was null, created new instance.");
            }

            this.logFrameTabUserControlInstance.Dock = DockStyle.Fill;
            logFrameTabPage.Controls.Add(this.logFrameTabUserControlInstance);
            System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: LogFrameTabUserControl instance configured and added to tabPageLogFrame.");

            // Project data loading is now in ProjectCreateEditForm_Load, after this method and _currentProject are set.
            System.Diagnostics.Debug.WriteLine("InitializeNewLogFrameTab: Finished.");
        }

        // OLD LogFrame UI Methods - Commented out
        // private void InitializeLogFrameUI() { /* ... old code ... */ }
        // private void CreateSidebarButtons() { /* ... old code ... */ }
        // private Button CreateSidebarButton(string text, Color backColor) { /* ... old code ... */ return null; }
        // private void AddElementToLogFrame<TElementType>(object parentElementTag, EventHandler specificAddHandler) where TElementType : class { /* ... old code ... */ }
        // private void RenderAllOutcomes() { /* ... old code ... */ }
        // private void RenderOutputsForOutcome(Outcome outcome, Panel parentOutputPanel, string outcomeNumberString) { /* ... old code ... */ }
        // private Panel CreateIndicatorPanel(Output outputInstance, ProjectIndicator indicator, string baseNumberString, int indicatorIndex) { /* ... old code ... */ return null;  }
        // private Panel CreateActivityPanel(Output outputInstance, ProjectActivity activity, string baseNumberString, int activityIndex) { /* ... old code ... */ return null; }
        // private TableLayoutPanel CreateTargetsPanel(ProjectIndicator indicator) { /* ... old code ... */ return null; }

        // OLD LogFrame UI Event Handlers - Commented out
        // The new LogFrameTabUserControl handles its own internal logic for adding/editing.
        // The main form saves _currentProject, which the UserControl populates.
        // private void btnAddOutcome_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnDeleteOutcome_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnAddOutputToOutcome_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnDeleteOutput_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnAddIndicator_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnDeleteIndicator_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnAddActivity_Click(object sender, EventArgs e) { /* ... old code ... */ }
        // private void BtnDeleteActivity_Click(object sender, EventArgs e) { /* ... old code ... */ }

        private void SetAccessibilityProperties()
        {
            txtProjectName.AccessibleName = "Project Name";
            txtProjectName.AccessibleDescription = "Enter the full official name of the project. This field is required.";
            txtProjectCode.AccessibleName = "Project Code";
            txtProjectCode.AccessibleDescription = "Enter the unique code for the project (optional).";
            dtpStartDate.AccessibleName = "Project Start Date";
            dtpStartDate.AccessibleDescription = "Select the start date of the project. Check the box to enable date selection.";
            dtpEndDate.AccessibleName = "Project End Date";
            dtpEndDate.AccessibleDescription = "Select the end date of the project. Check the box to enable date selection.";
            txtLocation.AccessibleName = "Project Location";
            txtLocation.AccessibleDescription = "Enter the geographical location(s) of the project.";
            txtOverallObjective.AccessibleName = "Overall Objective";
            txtOverallObjective.AccessibleDescription = "Describe the main goal or overall objective of the project.";
            txtStatus.AccessibleName = "Project Status";
            txtStatus.AccessibleDescription = "Enter the current status of the project (e.g., Planning, Active, Completed).";
            txtDonor.AccessibleName = "Project Donor";
            txtDonor.AccessibleDescription = "Enter the name of the donor or funding source for the project.";
            nudTotalBudget.AccessibleName = "Total Project Budget";
            nudTotalBudget.AccessibleDescription = "Enter the total budget amount for the project.";
            cmbSection.AccessibleName = "Organizational Section";
            cmbSection.AccessibleDescription = "Select the organizational section or department responsible for the project.";
            cmbManager.AccessibleName = "Project Manager";
            cmbManager.AccessibleDescription = "Select the user who will manage this project.";
            btnSave.AccessibleName = "Save Project Details";
            btnSave.AccessibleDescription = "Saves the current project information to the database.";
            btnCancel.AccessibleName = "Cancel Editing";
            btnCancel.AccessibleDescription = "Discards any changes and closes the project details form.";
        }

        private async Task LoadComboBoxesAsync()
        {
            cmbSection.DisplayMember = "Text"; cmbSection.ValueMember = "Value";
            cmbSection.Items.Clear(); cmbSection.Items.Add(new ComboboxItem { Text = "(No Section)", Value = 0 });
            try { List<Section> sections = await _sectionService.GetSectionsAsync(); sections.ForEach(s => cmbSection.Items.Add(new ComboboxItem { Text = s.SectionName, Value = s.SectionID })); }
            catch (Exception ex) { MessageBox.Show($"Error loading sections: {ex.Message}", "Error"); }

            if (_isEditMode && _currentProject.SectionID.HasValue) { foreach (ComboboxItem item in cmbSection.Items) if (item.Value == _currentProject.SectionID.Value) { cmbSection.SelectedItem = item; break; } if (cmbSection.SelectedItem == null) cmbSection.SelectedIndex = 0; }
            else if (!_isEditMode && _initialSectionId.HasValue) { bool found = false; foreach (ComboboxItem item in cmbSection.Items) if (item.Value == _initialSectionId.Value) { cmbSection.SelectedItem = item; found = true; break; } if (!found) cmbSection.SelectedIndex = 0; }
            else { cmbSection.SelectedIndex = 0; }

            cmbManager.DisplayMember = "Text"; cmbManager.ValueMember = "Value";
            cmbManager.Items.Add(new ComboboxItem { Text = "(No Manager)", Value = 0 });
            cmbManager.Items.Add(new ComboboxItem { Text = "Default Manager 1 (User ID 1)", Value = 1 });
            cmbManager.Items.Add(new ComboboxItem { Text = "Default Manager 2 (User ID 2)", Value = 2 });
            if (_isEditMode && _currentProject.ManagerUserID.HasValue) { foreach (ComboboxItem item in cmbManager.Items) if (item.Value == _currentProject.ManagerUserID.Value) { cmbManager.SelectedItem = item; break; } }
            else { cmbManager.SelectedIndex = 0; }
        }

        private void PopulateControls()
        {
            if (_currentProject == null) return;
            txtProjectName.Text = _currentProject.ProjectName;
            txtProjectCode.Text = _currentProject.ProjectCode;
            if (_currentProject.StartDate.HasValue) { dtpStartDate.Value = _currentProject.StartDate.Value; dtpStartDate.Checked = true; } else { dtpStartDate.Value = DateTime.Now; dtpStartDate.Checked = false; }
            if (_currentProject.EndDate.HasValue) { dtpEndDate.Value = _currentProject.EndDate.Value; dtpEndDate.Checked = true; } else { dtpEndDate.Value = DateTime.Now; dtpEndDate.Checked = false; }
            txtLocation.Text = _currentProject.Location;
            txtOverallObjective.Text = _currentProject.OverallObjective;
            txtStatus.Text = _currentProject.Status;
            txtDonor.Text = _currentProject.Donor;
            nudTotalBudget.Value = _currentProject.TotalBudget ?? 0;
        }

        private bool CollectAndValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text)) { MessageBox.Show("Project Name is required.", "Validation Error"); txtProjectName.Focus(); return false; }
            _currentProject.ProjectName = txtProjectName.Text.Trim();
            _currentProject.ProjectCode = string.IsNullOrWhiteSpace(txtProjectCode.Text) ? null : txtProjectCode.Text.Trim();
            _currentProject.StartDate = dtpStartDate.Checked ? (DateTime?)dtpStartDate.Value : null;
            _currentProject.EndDate = dtpEndDate.Checked ? (DateTime?)dtpEndDate.Value : null;
            if (_currentProject.StartDate.HasValue && _currentProject.EndDate.HasValue && _currentProject.EndDate.Value < _currentProject.StartDate.Value) { MessageBox.Show("End Date cannot be earlier than Start Date.", "Validation Error"); dtpEndDate.Focus(); return false; }
            _currentProject.Location = string.IsNullOrWhiteSpace(txtLocation.Text) ? null : txtLocation.Text.Trim();
            _currentProject.OverallObjective = string.IsNullOrWhiteSpace(txtOverallObjective.Text) ? null : txtOverallObjective.Text.Trim();
            _currentProject.Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? null : txtStatus.Text.Trim();
            _currentProject.Donor = string.IsNullOrWhiteSpace(txtDonor.Text) ? null : txtDonor.Text.Trim();
            _currentProject.TotalBudget = nudTotalBudget.Value;
            _currentProject.SectionID = (cmbSection.SelectedItem as ComboboxItem)?.Value == 0 ? null : (int?)(cmbSection.SelectedItem as ComboboxItem)?.Value;
            _currentProject.ManagerUserID = (cmbManager.SelectedItem as ComboboxItem)?.Value == 0 ? null : (int?)(cmbManager.SelectedItem as ComboboxItem)?.Value;

            // The _currentProject.Outcomes list is managed by the LogFrameTabUserControl directly.
            // When _projectService.SaveProjectAsync(_currentProject) is called,
            // it should include the outcomes data populated by the user control.
            // No specific collection of Outcome data is needed here if the UserControl updates _currentProject.Outcomes directly.
            // If LogFrameService within the UserControl saves logframe items independently, ensure consistency.
            // For now, assume _currentProject.Outcomes is the source of truth passed to SaveProjectAsync.

            if (!_isEditMode) { _currentProject.CreatedAt = DateTime.UtcNow; }
            _currentProject.UpdatedAt = DateTime.UtcNow;
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!CollectAndValidateData()) { return; }
            btnSave.Enabled = false; btnCancel.Enabled = false; this.UseWaitCursor = true;
            try
            {
                // The _currentProject object, including its Outcomes list (which should be managed by LogFrameTabUserControl),
                // is passed to the service. Ensure LogFrameTabUserControl updates _currentProject.Outcomes.
                bool success = await _projectService.SaveProjectAsync(_currentProject);
                if (success) { MessageBox.Show("Project saved successfully.", "Success"); this.DialogResult = DialogResult.OK; this.Close(); }
                else { MessageBox.Show("Failed to save project.", "Save Error"); }
            }
            catch (Exception ex) { MessageBox.Show($"An error occurred: {ex.Message}", "Error"); }
            finally { btnSave.Enabled = true; btnCancel.Enabled = true; this.UseWaitCursor = false; }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }

        private string GetCategoryDisplayName(BudgetCategoriesEnum category) { string name = category.ToString(); if (name.Length > 2 && name[1] == '_') { name = name[0] + ". " + name.Substring(2); } return System.Text.RegularExpressions.Regex.Replace(name, "([A-Z])", " $1").Trim(); }
        void ClearControlsFromRow(TableLayoutPanel panel, int rowIndex) { for (int i = 0; i < panel.ColumnCount; i++) { Control control = panel.GetControlFromPosition(i, rowIndex); if (control != null) { panel.Controls.Remove(control); control.Dispose(); } } }

        private void InitializeActivityPlanTab()
        {
            DataGridView dgvActivityPlan = this.Controls.Find("dgvActivityPlan", true).FirstOrDefault() as DataGridView;
            if (dgvActivityPlan == null || _currentProject == null) { return; }
            dgvActivityPlan.SuspendLayout(); dgvActivityPlan.Columns.Clear(); dgvActivityPlan.Rows.Clear();
            dgvActivityPlan.Columns.Add(new DataGridViewTextBoxColumn { Name = "ActivityDescription", HeaderText = "Activity", ReadOnly = true, Frozen = true, FillWeight = 30 });
            DateTime startDate = _currentProject.StartDate ?? (_currentProject.CreatedAt != DateTime.MinValue ? _currentProject.CreatedAt : DateTime.Now);
            DateTime endDate = _currentProject.EndDate ?? startDate.AddYears(1);
            if (endDate < startDate) endDate = startDate.AddYears(1);
            DateTime currentMonthIterator = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime endMonthTarget = new DateTime(endDate.Year, endDate.Month, 1);
            while (currentMonthIterator <= endMonthTarget)
            {
                string monthYearKeyStorage = currentMonthIterator.ToString("MMM/yyyy", CultureInfo.InvariantCulture);
                string headerTextDisplay = currentMonthIterator.ToString("MMM/yy", CultureInfo.InvariantCulture);
                string columnName = $"Month_{currentMonthIterator.Year}_{currentMonthIterator.Month:00}";
                dgvActivityPlan.Columns.Add(new DataGridViewCheckBoxColumn { Name = columnName, HeaderText = headerTextDisplay, Tag = monthYearKeyStorage, Width = 70 });
                currentMonthIterator = currentMonthIterator.AddMonths(1);
            }
            if (_currentProject.Outcomes != null)
            {
                foreach (var outcome in _currentProject.Outcomes)
                {
                    if (outcome.Outputs == null) continue;
                    foreach (var output in outcome.Outputs)
                    {
                        if (output.Activities == null) continue;
                        foreach (var activity in output.Activities)
                        {
                            int rowIndex = dgvActivityPlan.Rows.Add(); DataGridViewRow row = dgvActivityPlan.Rows[rowIndex];
                            row.Cells["ActivityDescription"].Value = activity.ActivityDescription; row.Tag = activity;
                            List<string> plannedMonthsList = string.IsNullOrEmpty(activity.PlannedMonths) ? new List<string>() : activity.PlannedMonths.Split(',').ToList();
                            foreach (DataGridViewColumn col in dgvActivityPlan.Columns)
                            {
                                if (col is DataGridViewCheckBoxColumn && col.Name.StartsWith("Month_"))
                                {
                                    string colStorageKey = col.Tag as string;
                                    if (colStorageKey != null && plannedMonthsList.Contains(colStorageKey)) { row.Cells[col.Name].Value = true; } else { row.Cells[col.Name].Value = false; }
                                }
                            }
                        }
                    }
                }
            }
            dgvActivityPlan.ResumeLayout();
        }

        private void dgvActivityPlan_CurrentCellDirtyStateChanged(object sender, EventArgs e) { if (sender is DataGridView dgv && dgv.IsCurrentCellDirty && dgv.CurrentCell is DataGridViewCheckBoxCell) { dgv.CommitEdit(DataGridViewDataErrorContexts.Commit); } }
        private void dgvActivityPlan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv) || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!(dgv.Rows[e.RowIndex].Tag is HumanitarianProjectManagement.Models.Activity activity)) return;
            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];
            if (col is DataGridViewCheckBoxColumn && col.Name.StartsWith("Month_") && col.Tag is string monthYearKey)
            {
                bool isChecked = (bool)(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false);
                List<string> plannedMonthsList = string.IsNullOrEmpty(activity.PlannedMonths) ? new List<string>() : activity.PlannedMonths.Split(',').ToList();
                if (isChecked && !plannedMonthsList.Contains(monthYearKey)) { plannedMonthsList.Add(monthYearKey); }
                else if (!isChecked) { plannedMonthsList.Remove(monthYearKey); }
                activity.PlannedMonths = string.Join(",", plannedMonthsList);
            }
        }
        private void ProjectDatesChanged_RefreshActivityPlan(object sender, EventArgs e) { InitializeActivityPlanTab(); }

        private void ProjectCreateEditForm_Load_1(object sender, EventArgs e)
        {
            // This event handler seems to be a duplicate or leftover.
            // The main Load event is `ProjectCreateEditForm_Load`.
            // If this is not used, it can be removed. For now, leaving it as is.
        }
    }
}
