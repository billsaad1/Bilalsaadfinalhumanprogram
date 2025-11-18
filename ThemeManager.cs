using System.Drawing;
using System.Windows.Forms;

namespace HumanitarianProjectManagement.UI
{
    public static class ThemeManager
    {
        // Theme Properties
        public static Color FormBackgroundColor { get; set; }
        public static Color PanelBackgroundColor { get; set; }
        public static Color TextColor { get; set; } // For general text like labels
        public static Color InputFieldForegroundColor { get; set; } // For text typed into input fields
        public static Color ButtonBackgroundColor { get; set; }
        public static Color ButtonForegroundColor { get; set; }
        public static Color TextBoxBackgroundColor { get; set; }
        public static Color DataGridViewBackgroundColor { get; set; }
        public static Color DataGridViewHeaderBackgroundColor { get; set; }
        public static Color DataGridViewHeaderForegroundColor { get; set; }
        public static Color MenuStripBackendColor { get; set; } // For MenuStrip itself
        public static Color MenuItemBackgroundColor { get; set; } // For ToolStripMenuItems
        public static Color MenuItemForegroundColor { get; set; }

        public static Font GlobalFont { get; set; }
        public static Font HeaderFont { get; set; }
        public static Font MenuFont { get; set; }


        // Static Constructor
        static ThemeManager()
        {
            // Blue Theme Palette
            Color primaryBlue = Color.FromArgb(22, 100, 199); // A medium, rich blue
            Color lighterBlue = Color.FromArgb(173, 216, 230); // Light blue, sky blue
            Color accentBlue = Color.FromArgb(0, 71, 171);     // A deeper blue for accents
            Color lightText = Color.FromArgb(240, 240, 240); // Very light gray / Off-white

            // Initialize with Blue Theme
            FormBackgroundColor = primaryBlue;
            PanelBackgroundColor = lighterBlue;
            TextColor = lightText;
            ButtonBackgroundColor = accentBlue;
            ButtonForegroundColor = lightText;
            TextBoxBackgroundColor = Color.White; // Keep text boxes white for readability
            DataGridViewBackgroundColor = Color.White; // Keep grids white
            DataGridViewHeaderBackgroundColor = accentBlue;
            DataGridViewHeaderForegroundColor = lightText;
            MenuStripBackendColor = accentBlue;
            MenuItemBackgroundColor = accentBlue; // Or a slightly lighter/darker shade of accentBlue
            MenuItemForegroundColor = lightText;
            InputFieldForegroundColor = Color.Black; // Text in input fields should be black


            GlobalFont = new Font("Segoe UI", 9f, FontStyle.Regular);
            HeaderFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            MenuFont = new Font("Segoe UI", 9f, FontStyle.Regular);
        }

        // Apply theme to a single control (can be expanded)
        private static void ApplyThemeToControl(Control control)
        {
            control.Font = GlobalFont; // Apply global font to all

            if (control is Form form) // Should be handled by ApplyThemeToForm directly for the form itself
            {
                form.BackColor = FormBackgroundColor;
            }
            else if (control is Panel panel)
            {
                panel.BackColor = PanelBackgroundColor;
            }
            else if (control is Label label)
            {
                label.ForeColor = TextColor;
                // Example: Differentiate header labels by Tag or Name
                if (label.Tag?.ToString() == "HeaderLabel" || label.Font.Bold) // Simple heuristic
                {
                    label.Font = HeaderFont;
                }
            }
            else if (control is Button button)
            {
                button.BackColor = ButtonBackgroundColor;
                button.ForeColor = ButtonForegroundColor;
                button.FlatStyle = FlatStyle.System; // Or FlatStyle.Flat for more custom look
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = TextBoxBackgroundColor;
                textBox.ForeColor = InputFieldForegroundColor;
            }
            else if (control is RichTextBox richTextBox) // Added RichTextBox
            {
                richTextBox.BackColor = TextBoxBackgroundColor;
                richTextBox.ForeColor = InputFieldForegroundColor;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = TextBoxBackgroundColor;
                comboBox.ForeColor = InputFieldForegroundColor; // Ensure typed text is black, dropdown list items might need custom drawing for full theme.
                comboBox.FlatStyle = FlatStyle.System;
            }
            else if (control is DateTimePicker dateTimePicker)
            {
                dateTimePicker.CalendarForeColor = InputFieldForegroundColor; // For text in the calendar dropdown
                dateTimePicker.CalendarMonthBackground = TextBoxBackgroundColor;
                dateTimePicker.ForeColor = InputFieldForegroundColor; // For the text displayed in the control
            }
            else if (control is NumericUpDown numericUpDown)
            {
                numericUpDown.BackColor = TextBoxBackgroundColor;
                numericUpDown.ForeColor = InputFieldForegroundColor;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = DataGridViewBackgroundColor;
                dgv.GridColor = PanelBackgroundColor; // Grid lines
                dgv.DefaultCellStyle.BackColor = DataGridViewBackgroundColor;
                dgv.DefaultCellStyle.ForeColor = TextColor;
                dgv.DefaultCellStyle.Font = GlobalFont;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = DataGridViewHeaderBackgroundColor;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = DataGridViewHeaderForegroundColor;
                dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont; // Use HeaderFont for DGV headers
                dgv.EnableHeadersVisualStyles = false; // Important for custom header colors to apply
            }
            else if (control is MenuStrip menuStrip)
            {
                menuStrip.BackColor = MenuStripBackendColor;
                menuStrip.Font = MenuFont;
                foreach (ToolStripItem item in menuStrip.Items)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        menuItem.ForeColor = MenuItemForegroundColor;
                        // menuItem.BackColor = MenuItemBackgroundColor; // Usually inherited or transparent
                        ApplyThemeToToolStripMenuItemRecursive(menuItem);
                    }
                }
            }
            // Add more control types as needed (e.g., GroupBox, TabControl)
        }

        private static void ApplyThemeToToolStripMenuItemRecursive(ToolStripMenuItem menuItem)
        {
            menuItem.Font = MenuFont;
            menuItem.ForeColor = MenuItemForegroundColor;
            // menuItem.BackColor = MenuItemBackgroundColor; // Careful with this, can look odd

            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem subMenuItem)
                {
                    ApplyThemeToToolStripMenuItemRecursive(subMenuItem);
                }
                else if (item is ToolStripSeparator separator)
                {
                    // separator.Paint += (sender, e) => { e.Graphics.DrawLine(new Pen(PanelBackgroundColor), 0, separator.Height / 2, separator.Width, separator.Height / 2); }; // Example custom separator
                }
            }
        }


        // Apply theme to a form and all its child controls recursively
        public static void ApplyThemeToForm(Form formToTheme)
        {
            formToTheme.BackColor = FormBackgroundColor;
            formToTheme.Font = GlobalFont; // Set base font for the form

            foreach (Control control in formToTheme.Controls)
            {
                ApplyThemeToControlRecursive(control);
            }
        }

        private static void ApplyThemeToControlRecursive(Control control)
        {
            ApplyThemeToControl(control);
            foreach (Control childControl in control.Controls)
            {
                // Special handling for MenuStrip items as they are not in Controls collection directly for styling
                if (!(control is MenuStrip))
                {
                    ApplyThemeToControlRecursive(childControl);
                }
            }
        }
    }
}
