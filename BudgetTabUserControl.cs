using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HumanitarianProjectManagement.Models;

namespace HumanitarianProjectManagement
{
    public partial class BudgetTabUserControl : UserControl
    {
        private Project _currentProject;
        private BudgetCategoriesEnum? _selectedMainCategory;

        public BudgetTabUserControl()
        {
            InitializeComponent();

            // Ensure pnlMainBudgetContentArea is a FlowLayoutPanel for vertical stacking
            if (!(this.pnlMainBudgetContentArea is FlowLayoutPanel))
            {
                var flp = new FlowLayoutPanel
                {
                    Name = "pnlMainBudgetContentArea",
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(5),
                    Margin = new Padding(0),
                    BackColor = Color.White
                };
                this.splitVerticalContent.Panel2.Controls.Remove(this.pnlMainBudgetContentArea);
                this.splitVerticalContent.Panel2.Controls.Add(flp);
                this.pnlMainBudgetContentArea = flp;
            }
        }

        public void LoadProject(Project project)
        {
            _currentProject = project;
            if (_currentProject == null)
            {
                ClearAndHideAll();
                InitializeMainCategoryButtons();
                return;
            }
            _currentProject.DetailedBudgetLines = _currentProject.DetailedBudgetLines ?? new BindingList<DetailedBudgetLine>();
            InitializeMainCategoryButtons();
            if (tlpCategoryButtons.Controls.Count > 0 && tlpCategoryButtons.Controls[0] is Button firstCatButton)
            {
                firstCatButton.PerformClick();
            }
            else { ClearAndHideAllContentArea(); }
        }

        private void InitializeMainCategoryButtons()
        {
            if (this.tlpCategoryButtons == null) return;
            this.tlpCategoryButtons.SuspendLayout();
            this.tlpCategoryButtons.Controls.Clear();
            this.tlpCategoryButtons.RowStyles.Clear();

            int currentRow = 0;
            var colors = new List<Color>
            {
                Color.FromArgb(255, 182, 193), // Light Pink
                Color.FromArgb(173, 216, 230), // Light Blue
                Color.FromArgb(144, 238, 144), // Light Green
                Color.FromArgb(255, 255, 224), // Light Yellow
                Color.FromArgb(221, 160, 221), // Plum
                Color.FromArgb(240, 230, 140), // Khaki
                Color.FromArgb(176, 224, 230), // Powder Blue
                Color.FromArgb(255, 228, 196)  // Moccasin
            };

            int colorIndex = 0;
            foreach (BudgetCategoriesEnum catEnum in Enum.GetValues(typeof(BudgetCategoriesEnum)))
            {
                this.tlpCategoryButtons.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                Button btnCategory = new Button
                {
                    Text = GetCategoryDisplayName(catEnum),
                    Tag = catEnum,
                    Dock = DockStyle.Top,
                    Height = 45,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(15, 0, 0, 0),
                    Margin = new Padding(5, 3, 5, 3),
                    BackColor = colors[colorIndex % colors.Count],
                    ForeColor = Color.Black,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular)
                };
                btnCategory.FlatAppearance.BorderSize = 1;
                btnCategory.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                btnCategory.Click += btnBudgetCategory_Internal_Click;
                this.tlpCategoryButtons.Controls.Add(btnCategory, 0, currentRow++);
                colorIndex++;
            }
            this.tlpCategoryButtons.RowCount = currentRow;
            this.tlpCategoryButtons.ResumeLayout(true);
        }

        private string GetCategoryDisplayName(BudgetCategoriesEnum? category)
        {
            if (!category.HasValue) return "No Category Selected";
            string name = category.Value.ToString();
            name = name.Replace("_", ". ");
            if (name.StartsWith("C.")) name = "C. Equipment";
            if (name.StartsWith("D.")) name = "D. Contractual Services";
            if (name.StartsWith("F.")) name = "F. Other Direct Costs";
            return name;
        }

        private string GetCategoryPrefix(BudgetCategoriesEnum? category)
        {
            if (!category.HasValue) return "N/A";
            string name = category.Value.ToString();
            if (name.Contains("_")) return name.Split('_')[0];
            if (string.IsNullOrEmpty(name)) return "ERR";
            return name.Substring(0, 1);
        }

        private void btnBudgetCategory_Internal_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || !(clickedButton.Tag is BudgetCategoriesEnum)) return;
            _selectedMainCategory = (BudgetCategoriesEnum?)clickedButton.Tag;

            clickedButton.BackColor = Color.FromArgb(0, 122, 204);
            clickedButton.ForeColor = Color.White;

            RefreshMainDisplay();
        }

        private void RefreshMainDisplay()
        {
            var flp = this.pnlMainBudgetContentArea as FlowLayoutPanel;
            if (flp == null) return;

            flp.SuspendLayout();
            flp.Controls.Clear();

            // 1. Category title at the very top
            Label lblCategoryHeader = new Label
            {
                Text = _selectedMainCategory.HasValue ? "Budget for: " + GetCategoryDisplayName(_selectedMainCategory) : "Budget Entry - Select Category",
                Font = new Font(this.Font.FontFamily, 14F, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(10, 15, 10, 15),
                Margin = new Padding(0, 10, 0, 10),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 122, 204),
                BorderStyle = BorderStyle.FixedSingle,
                Width = flp.Width - 20
            };
            flp.Controls.Add(lblCategoryHeader);

            // 2. Input row for adding top-level direct lines
            flp.Controls.Add(CreateInputRowForLine(null));

            // 3. Column headers for Excel-like appearance
            TableLayoutPanel headerRow = CreateHeaderRow();
            flp.Controls.Add(headerRow);

            // 4. Render ALL budget lines from ALL categories
            if (_currentProject != null)
            {
                var allLines = _currentProject.DetailedBudgetLines
                    .Where(l => l.ParentDetailedBudgetLineID == null)
                    .OrderBy(l => l.Category)
                    .ThenBy(l => l.Code)
                    .ToList();

                foreach (var line in allLines)
                {
                    RenderBudgetLineWithChildren(line, 0, flp);
                }
            }

            flp.ResumeLayout(true);
            flp.PerformLayout();
        }

        private TableLayoutPanel CreateHeaderRow()
        {
            TableLayoutPanel headerRow = new TableLayoutPanel
            {
                ColumnCount = 10,
                RowCount = 1,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 5, 0, 0),
                BackColor = Color.FromArgb(233, 236, 239),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BorderStyle = BorderStyle.FixedSingle,
                Height = 35
            };

            // Set column widths to match input row
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Code
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));    // Item
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Description
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Unit
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // Quantity
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));  // Unit Cost
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Duration
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // % CBPF
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));  // Total
            headerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));    // Actions

            string[] headers = { "Code", "Item/Activity", "Description", "Unit", "Quantity", "Unit Cost", "Duration", "% CBPF", "Total", "Actions" };
            for (int i = 0; i < headers.Length; i++)
            {
                headerRow.Controls.Add(new Label
                {
                    Text = headers[i],
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Padding = new Padding(3),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent
                }, i, 0);
            }
            return headerRow;
        }

        private TableLayoutPanel CreateInputRowForLine(DetailedBudgetLine parentLine)
        {
            TableLayoutPanel inputRow = new TableLayoutPanel
            {
                ColumnCount = 8,
                RowCount = 2,
                AutoSize = true,
                Dock = DockStyle.Top,
                Padding = new Padding(5, 10, 5, 10),
                Margin = new Padding(parentLine == null ? 0 : 20, 10, 0, 10),
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Set column widths to match header
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));    // Item
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Description
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Unit
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // Quantity
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));  // Unit Cost
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Duration
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // % CBPF
            inputRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));    // Action

            string[] directLabels = { "Item/Activity:", "Description:", "Unit:", "Quantity:", "Unit Cost:", "Duration:", "% CBPF:" };

            TextBox txtItem = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };
            TextBox txtDescription = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };
            TextBox txtUnit = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };
            NumericUpDown numQuantity = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 2, Minimum = 0, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };
            NumericUpDown numUnitCost = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 2, Minimum = 0, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };
            NumericUpDown numDuration = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 1, Minimum = 0, Value = 1, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };
            NumericUpDown numPercentageCBPF = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 0, Minimum = 0, Maximum = 100, Value = 100, Font = new Font("Segoe UI", 9F), Margin = new Padding(3), BorderStyle = BorderStyle.FixedSingle };

            Control[] directInputs = { txtItem, txtDescription, txtUnit, numQuantity, numUnitCost, numDuration, numPercentageCBPF };

            for (int i = 0; i < directLabels.Length; i++)
            {
                inputRow.Controls.Add(new Label { Text = directLabels[i], AutoSize = true, Anchor = AnchorStyles.Left, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Margin = new Padding(3), ForeColor = Color.FromArgb(0, 122, 204) }, i, 0);
                inputRow.Controls.Add(directInputs[i], i, 1);
            }

            Button btnAddLine = new Button
            {
                Text = "Add Entry",
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                Height = 35,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(3),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnAddLine.FlatAppearance.BorderSize = 0;

            btnAddLine.Click += (s, e) =>
            {
                if (_currentProject == null || !_selectedMainCategory.HasValue)
                {
                    MessageBox.Show("Please select a category first.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtItem.Text))
                {
                    MessageBox.Show("Item name is required.");
                    txtItem.Focus();
                    return;
                }
                if (numQuantity.Value <= 0)
                {
                    MessageBox.Show("Quantity must be greater than 0.");
                    numQuantity.Focus();
                    return;
                }

                DetailedBudgetLine newLine = new DetailedBudgetLine
                {
                    DetailedBudgetLineID = Guid.NewGuid(),
                    ProjectId = _currentProject.ProjectID,
                    Category = _selectedMainCategory.Value,
                    ItemName = txtItem.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Unit = txtUnit.Text.Trim(),
                    Quantity = numQuantity.Value,
                    UnitCost = numUnitCost.Value,
                    Duration = numDuration.Value,
                    PercentageChargedToCBPF = numPercentageCBPF.Value,
                    Code = parentLine == null ? GenerateDirectLineCode(_selectedMainCategory.Value) : GenerateChildLineCode(parentLine),
                    ParentDetailedBudgetLineID = parentLine?.DetailedBudgetLineID
                };
                RecalculateItemTotal(newLine);
                _currentProject.DetailedBudgetLines.Add(newLine);

                // Clear inputs
                txtItem.Clear();
                txtDescription.Clear();
                txtUnit.Clear();
                numQuantity.Value = 0;
                numUnitCost.Value = 0;
                numDuration.Value = 1;
                numPercentageCBPF.Value = 100;

                // Refresh the display
                RefreshMainDisplay();
            };

            inputRow.Controls.Add(btnAddLine, 7, 1);
            return inputRow;
        }

        private void RenderBudgetLineWithChildren(DetailedBudgetLine line, int indentLevel, FlowLayoutPanel flp)
        {
            TableLayoutPanel row = new TableLayoutPanel
            {
                ColumnCount = 10,
                RowCount = 1,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(indentLevel * 20, 1, 0, 1),
                BackColor = indentLevel % 2 == 0 ? Color.White : Color.FromArgb(248, 249, 250),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BorderStyle = BorderStyle.FixedSingle,
                Width = flp.Width - (indentLevel * 20) - 25
            };

            // Set column widths to match header
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Code
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));    // Item
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Description
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Unit
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // Quantity
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));  // Unit Cost
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // Duration
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));   // % CBPF
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));  // Total
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));    // Actions

            row.Controls.Add(new Label { Text = line.Code, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 0, 0);
            row.Controls.Add(new Label { Text = line.ItemName, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 1, 0);
            row.Controls.Add(new Label { Text = line.Description, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 2, 0);
            row.Controls.Add(new Label { Text = line.Unit, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 3, 0);
            row.Controls.Add(new Label { Text = line.Quantity.ToString("N2"), AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 4, 0);
            row.Controls.Add(new Label { Text = line.UnitCost.ToString("C2"), AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 5, 0);
            row.Controls.Add(new Label { Text = line.Duration.ToString("N1"), AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 6, 0);
            row.Controls.Add(new Label { Text = line.PercentageChargedToCBPF.ToString("N0") + "%", AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F), Padding = new Padding(3), ForeColor = Color.Black }, 7, 0);
            row.Controls.Add(new Label { Text = line.TotalCost.ToString("C2"), AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(3), ForeColor = Color.FromArgb(40, 167, 69) }, 8, 0);

            // Actions
            FlowLayoutPanel actionsPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill,
                Padding = new Padding(3),
                BackColor = Color.Transparent
            };

            Button btnEdit = new Button
            {
                Text = "Edit",
                Tag = line,
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Margin = new Padding(2)
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += (s, e) => EditBudgetLine(line);

            Button btnDelete = new Button
            {
                Text = "Del",
                Tag = line,
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Margin = new Padding(2)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) => DeleteBudgetLine(line);

            Button btnAddSubLine = new Button { Text = "+ Sub", Tag = line, AutoSize = true, Font = new Font("Segoe UI", 10F) };
            btnAddSubLine.Click += (s, e) =>
            {
                var inputRow = CreateInputRowForLine(line);
                flp.Controls.Add(inputRow);
                flp.Controls.SetChildIndex(inputRow, flp.Controls.GetChildIndex(row) + 1);
            };
            actionsPanel.Controls.Add(btnAddSubLine);
            actionsPanel.Controls.Add(btnEdit);
            actionsPanel.Controls.Add(btnDelete);
            row.Controls.Add(actionsPanel, 9, 0);

            flp.Controls.Add(row);

            // Recursively add children, if any
            var childLines = _currentProject.DetailedBudgetLines
                .Where(l => l.ParentDetailedBudgetLineID == line.DetailedBudgetLineID)
                .OrderBy(l => l.Code)
                .ToList();

            foreach (var child in childLines)
                RenderBudgetLineWithChildren(child, indentLevel + 1, flp);
        }

        private void EditBudgetLine(DetailedBudgetLine line)
        {
            MessageBox.Show($"Edit functionality for: {line.ItemName}\nCode: {line.Code}");
        }

        private void DeleteBudgetLine(DetailedBudgetLine line)
        {
            if (MessageBox.Show($"Are you sure you want to delete '{line.ItemName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _currentProject.DetailedBudgetLines.Remove(line);
                RefreshMainDisplay();
            }
        }

        private string GenerateDirectLineCode(BudgetCategoriesEnum mainCategory)
        {
            if (_currentProject == null) return GetCategoryPrefix(mainCategory) + ".ERR";
            string prefix = GetCategoryPrefix(mainCategory) + ".";
            int maxSuffix = _currentProject.DetailedBudgetLines
                .Where(line => line.Category == mainCategory && line.ParentDetailedBudgetLineID == null)
                .Select(line => {
                    if (line.Code != null && line.Code.StartsWith(prefix) && !line.Code.Substring(prefix.Length).Contains("."))
                    {
                        string s = line.Code.Substring(prefix.Length);
                        return int.TryParse(s, out int n) ? n : 0;
                    }
                    return 0;
                })
                .DefaultIfEmpty(0).Max();
            return prefix + (maxSuffix + 1).ToString();
        }

        private string GenerateChildLineCode(DetailedBudgetLine parentLine)
        {
            if (_currentProject == null || parentLine == null) return "ERR.CODE";
            string basePrefix = parentLine.Code + ".";
            int maxSuffix = _currentProject.DetailedBudgetLines
                .Where(line => line.ParentDetailedBudgetLineID == parentLine.DetailedBudgetLineID && line.Code != null && line.Code.StartsWith(basePrefix))
                .Select(line => {
                    string suffixPart = line.Code.Substring(basePrefix.Length);
                    return int.TryParse(suffixPart, out int num) ? num : 0;
                })
                .DefaultIfEmpty(0).Max();
            return basePrefix + (maxSuffix + 1).ToString();
        }

        private void RecalculateItemTotal(DetailedBudgetLine item)
        {
            if (item == null) return;
            decimal pf = item.PercentageChargedToCBPF > 0 ? item.PercentageChargedToCBPF / 100M : 1M;
            item.TotalCost = item.Quantity * item.UnitCost * item.Duration * pf;
        }

        private void ClearAndHideAll()
        {
            ClearAndHideAllContentArea();
            if (this.tlpCategoryButtons != null)
                foreach (Control c in this.tlpCategoryButtons.Controls)
                    if (c is Button btn) { btn.BackColor = Color.FromArgb(245, 245, 245); btn.ForeColor = Color.Black; }
        }

        private void ClearAndHideAllContentArea()
        {
            if (this.pnlMainBudgetContentArea != null) this.pnlMainBudgetContentArea.Controls.Clear();
            _selectedMainCategory = null;
        }
    }
}
