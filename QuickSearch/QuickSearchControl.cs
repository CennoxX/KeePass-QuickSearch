using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KeePass;
using KeePass.Resources;
using QuickSearch.Properties;

namespace QuickSearch
{
    public partial class QuickSearchControl : UserControl
    {
        private readonly Settings _lightModeSettings = new Settings();
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
            imageListSearchButton.Images.Add(QuickSearchExt.SearchImage);
            imageListSearchButton.Images.Add(QuickSearchExt.OptionsImage);

            checkBoxPassword.Checked = Program.Config.MainWindow.QuickFindSearchInPasswords;
            checkBoxPassword.DataBindings.Add(new Binding("Checked", Program.Config.MainWindow, "QuickFindSearchInPasswords", true, DataSourceUpdateMode.OnPropertyChanged));

            checkBoxExclude.Checked = Program.Config.MainWindow.QuickFindExcludeExpired;
            checkBoxExclude.DataBindings.Add(new Binding("Checked", Program.Config.MainWindow, "QuickFindExcludeExpired", true, DataSourceUpdateMode.OnPropertyChanged));

            groupBoxSearchIn.Text = LocalizedStrings.m_grpSearchIn;
            checkBoxTitle.Text = LocalizedStrings.m_cbTitle;
            checkBoxUserName.Text = LocalizedStrings.m_cbUserName;
            checkBoxNotes.Text = LocalizedStrings.m_cbNotes;
            checkBoxGroupName.Text = LocalizedStrings.m_cbGroupName;
            checkBoxGroupPath.Text = LocalizedStrings.m_cbGroupPath;
            checkBoxOther.Text = LocalizedStrings.m_cbStringsOther;
            checkBoxPassword.Text = LocalizedStrings.m_cbPassword;
            checkBoxUrl.Text = LocalizedStrings.m_cbUrl;
            groupBoxOptions.Text = LocalizedStrings.m_grpOptions;
            checkBoxCase.Text = LocalizedStrings.m_cbCaseSensitive;
            checkBoxExclude.Text = LocalizedStrings.m_cbExcludeExpired;
            checkBoxGroupSettings.Text = LocalizedStrings.m_cbIgnoreGroupSettings;
            checkBoxTags.Text = LocalizedStrings.m_cbTags;

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

            var isDarkThemeEnabled = string.Equals(Program.Config.CustomConfig.GetString("KeeTheme.Enabled"), "true", StringComparison.OrdinalIgnoreCase);
            ApplyThemeColors(isDarkThemeEnabled);
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
            }
        }

        public void UpdateWidth()
        {
            Width = Settings.Default.ControlWidth;
            comboBoxSearch.Invalidate();
        }

        public void ClearSelection()
        {
            BeginInvoke(new Action(() =>
            {
                comboBoxSearch.SelectionStart = comboBoxSearch.Text.Length;
                comboBoxSearch.SelectionLength = 0;
            }));
        }

        private void ApplyThemeColors(bool enableDarkMode)
        {
            var darkColors = new Dictionary<string, Color>
            {
                { "BackColorSuccess", Color.FromArgb(17, 54, 31) },
                { "BackColorSearching", Color.FromArgb(61, 52, 0) },
                { "BackColorOnError", Color.FromArgb(89, 0, 0) },
                { "BackColorNormalUnFocused", Color.FromArgb(57, 60, 62) },
                { "BackColorNormalFocused", Color.FromArgb(72, 76, 78) }
            };

            if (enableDarkMode)
            {
                groupBoxSearchIn.ForeColor = Color.LightGray;
                groupBoxOptions.ForeColor = Color.LightGray;
                bool isUsingLightDefaults = true;
                foreach (var kvp in darkColors)
                {
                    var currentValue = (Color)typeof(Settings).GetProperty(kvp.Key).GetValue(Settings.Default, null);
                    var defaultValue = (Color)typeof(Settings).GetProperty(kvp.Key).GetValue(_lightModeSettings, null);
                    if (currentValue.ToArgb() != defaultValue.ToArgb())
                    {
                        isUsingLightDefaults = false;
                        break;
                    }
                }

                if (isUsingLightDefaults)
                {
                    foreach (var kvp in darkColors)
                    {
                        typeof(Settings).GetProperty(kvp.Key).SetValue(Settings.Default, kvp.Value, null);
                    }
                }
            }
            else
            {
                bool isUsingDarkDefaults = true;
                foreach (var kvp in darkColors)
                {
                    var currentValue = (Color)typeof(Settings).GetProperty(kvp.Key).GetValue(Settings.Default, null);
                    if (currentValue.ToArgb() != kvp.Value.ToArgb())
                    {
                        isUsingDarkDefaults = false;
                        break;
                    }
                }

                if (isUsingDarkDefaults)
                {
                    foreach (var prop in typeof(Settings).GetProperties())
                    {
                        if (prop.PropertyType == typeof(Color))
                        {
                            prop.SetValue(Settings.Default, prop.GetValue(_lightModeSettings, null), null);
                        }
                    }
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

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
            ClearSelection();
        }

        private void SaveEnteredSearch()
        {
            if (!string.IsNullOrEmpty(Text) && !comboBoxSearch.Items.Cast<string>().Any(i => i.StartsWith(Text)))
                comboBoxSearch.Items.Add(Text);

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

        private void ButtonConfig_MouseEnter(object sender, EventArgs e)
        {
            buttonDropdownSettings.ImageIndex = 1;
        }

        private void ButtonConfig_MouseLeave(object sender, EventArgs e)
        {
            if (!toolStripDropDownSettings.Visible)
            {
                buttonDropdownSettings.ImageIndex = 0;
            }
        }

        private void ButtonDropdownSettings_Click(object sender, EventArgs e)
        {
            // load KeePass settings
            checkBoxExclude.Checked = Program.Config.MainWindow.QuickFindExcludeExpired;
            checkBoxPassword.Checked = Program.Config.MainWindow.QuickFindSearchInPasswords;

            // show the DropDown
            toolStripDropDownSettings.Show(buttonDropdownSettings, 0, buttonDropdownSettings.Bottom);

            // disable the button so that clicking again will close the DropDown but not raise this event again
            buttonDropdownSettings.Enabled = false;
        }

        private void ToolStripDropDownSettings_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            buttonDropdownSettings.Enabled = true;
            // we need to check if mouse is over config button. Otherwise icon would be resetted although mouse is over config button.
            // get a mouse position relative to the Button
            Point mousePosition = buttonDropdownSettings.PointToClient(Control.MousePosition);
            if (!buttonDropdownSettings.ClientRectangle.IntersectsWith(new Rectangle(mousePosition, Size.Empty)))
            {
                buttonDropdownSettings.ImageIndex = 0;
            }
            buttonDropdownSettings.Enabled = true;
        }

        private void SetBackColor(Color color)
        {
            comboBoxSearch.BackColor = color;
            buttonDropdownSettings.BackColor = color;
            buttonDropdownSettings.FlatAppearance.MouseDownBackColor = color;
            buttonDropdownSettings.FlatAppearance.MouseOverBackColor = color;
        }

        private void SetBackColorNormal()
        {
            SetBackColor(comboBoxSearch.Focused ? Settings.Default.BackColorNormalFocused : Settings.Default.BackColorNormalUnFocused);
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
