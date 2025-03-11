using KeePass;
using KeePass.Resources;
using QuickSearch.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickSearch
{
    public partial class QuickSearchControl : UserControl
    {
        public new string Text
        {
            get { return comboBoxSearch.Text; }
            set { comboBoxSearch.Text = value; }
        }

        public new event EventHandler TextChanged
        {
            add { comboBoxSearch.TextChanged += value; }
            remove { comboBoxSearch.TextChanged -= value; }
        }

        public new event PreviewKeyDownEventHandler PreviewKeyDown
        {
            add { comboBoxSearch.PreviewKeyDown += value; }
            remove { comboBoxSearch.PreviewKeyDown -= value; }
        }

        public QuickSearchControl()
        {
            InitializeComponent();
            UpdateWidth();
            comboBoxSearch.GotFocus += ComboBoxSearch_GotFocus;
            comboBoxSearch.LostFocus += ComboBoxSearch_LostFocus;
            comboBoxSearch.DropDown += ComboBoxSearch_DropDown;
            checkBoxGroupPath.CheckedChanged += CheckBoxGroupPath_CheckedChanged;

            if (comboBoxSearch.IsHandleCreated)
                ComboBoxSearch_HandleCreated();
            else
                comboBoxSearch.HandleCreated += ComboBoxSearch_HandleCreated; 

            Controls.Remove(tableLayoutPanelMain);

            // The Dropdown has no parent form so it has no BindingContext.
            // Binding won't work for it's hosted controls
            // create a new BindingContext to solve this bug
            toolStripDropDownSettings.BindingContext = new BindingContext();

            // Create a host for the tableLayoutPanelMain
            // Only a ToolStripControlHost can be added to a ToolStripDropDown
            // set tableLayoutPanelMain as it's control
            ToolStripControlHost settingsPanelHost = new ToolStripControlHost(tableLayoutPanelMain);

            // set the Margin to zero so we don't see white lines between the border of the ControlHost and the DropDown
            settingsPanelHost.Margin = Padding.Empty;

            // set the position of the Panel
            tableLayoutPanelMain.Location = Point.Empty;
            // add the ToolStripControlHost to the DropDown
            toolStripDropDownSettings.Items.Add(settingsPanelHost);

            var isDarkThemeEnabled = Program.Config.CustomConfig.GetString("KeeTheme.Enabled");
            if (isDarkThemeEnabled != null && isDarkThemeEnabled.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                groupBoxSearchIn.ForeColor = Color.LightGray;
                groupBoxOptions.ForeColor = Color.LightGray;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private void ComboBoxSearch_HandleCreated(object sender = null, EventArgs e = null)
        {
            const int CB_SETCUEBANNER = 0x1703;
            SendMessage(comboBoxSearch.Handle, CB_SETCUEBANNER, 0, KPRes.Search);
        }

        private void ComboBoxSearch_DropDown(object sender, EventArgs e)
        {
            SetBackColor(Settings.Default.BackColorNormalUnFocused);
        }

        private void ComboBoxSearch_LostFocus(object sender, EventArgs e)
        {
            Debug.WriteLine("Focus Lost");
            SetBackColorNormal();
            SaveEnteredSearch();
            OnLostFocus(e);
        }

        private void SaveEnteredSearch()
        {
            if (!string.IsNullOrEmpty(this.Text) && !comboBoxSearch.Items.Cast<string>().Any(i => i.StartsWith(this.Text)))
                comboBoxSearch.Items.Add(this.Text);
            
            if (comboBoxSearch.Items.Count > 8)
                comboBoxSearch.Items.RemoveAt(0);
        }

        private void ComboBoxSearch_GotFocus(object sender, EventArgs e)
        {
            Debug.WriteLine("Got Focus");
            SetBackColorNormal();
        }

        // this event has to be consumed by all checkboxes and the DropDown. 
        // The TableLayoutPanels and GroupBoxes don't seem to raise this event
        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Space)
            {
                toolStripDropDownSettings.Hide();
                comboBoxSearch.Focus();
            }
            Debug.WriteLine("in preview");
        }

        public void UpdateSearchStatus(SearchStatus status)
        {
            switch (status)
            {
                case SearchStatus.Success:
                    SetBackColor(Settings.Default.BackColorSuccess);
                    break;
                case SearchStatus.Error:
                    SetBackColor(Settings.Default.BackColorOnError);
                    break;
                case SearchStatus.Pending:
                    SetBackColor(Settings.Default.BackColorSearching);
                    break;
                case SearchStatus.Normal:
                    SetBackColorNormal();
                    break;
                default:
                    break;
            }
        }

        private void ButtonConfig_MouseEnter(object sender, EventArgs e)
        {
            ButtonDropdownSettings.ImageIndex = 1;
        }

        private void ButtonConfig_MouseLeave(object sender, EventArgs e)
        {
            if (!toolStripDropDownSettings.Visible)
            {
                ButtonDropdownSettings.ImageIndex = 0;
            }
        }

        private void ButtonDropdownSettings_Click(object sender, EventArgs e)
        {
            // load KeePass settings
            checkBoxExclude.Checked = Program.Config.MainWindow.QuickFindExcludeExpired;
            checkBoxPassword.Checked = Program.Config.MainWindow.QuickFindSearchInPasswords;

            // show the DropDown
            toolStripDropDownSettings.Show(ButtonDropdownSettings, 0, ButtonDropdownSettings.Bottom);

            // disable the button so that clicking again will close the DropDown but not raise this event again
            ButtonDropdownSettings.Enabled = false;
        }

        private void ToolStripDropDownSettings_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            ButtonDropdownSettings.Enabled = true;
            // we need to check if mouse is over config button. Otherwise icon would be resetted although mouse is over config button.
            // get a mouse position relative to the Button
            Point mousePosition = ButtonDropdownSettings.PointToClient(Control.MousePosition);
            if (!ButtonDropdownSettings.ClientRectangle.IntersectsWith(new Rectangle(mousePosition, Size.Empty)))
            {
                ButtonDropdownSettings.ImageIndex = 0;
            }
            ButtonDropdownSettings.Enabled = true;
        }

        private void SetBackColor(Color color)
        {
            comboBoxSearch.BackColor = color;
            ButtonDropdownSettings.BackColor = color;
            ButtonDropdownSettings.FlatAppearance.MouseDownBackColor = color;
            ButtonDropdownSettings.FlatAppearance.MouseOverBackColor = color;
        }

        private void SetBackColorNormal()
        {
            SetBackColor(comboBoxSearch.Focused ? Settings.Default.BackColorNormalFocused : Settings.Default.BackColorNormalUnFocused);
        }

        public void UpdateWidth()
        {
            Width = Settings.Default.ControlWidth;
            comboBoxSearch.Invalidate();
        }

        private void CheckBoxGroupPath_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGroupPath.Checked)
            {
                Settings.Default.SearchInGroupPath = true;
                Settings.Default.SearchInGroupName = true;
                checkBoxGroupName.Enabled = false;
                checkBoxGroupName.Checked = true;
            }
            else
            {
                Settings.Default.SearchInGroupPath = false;
                checkBoxGroupName.Enabled = true;
            }
        }
    }
}
