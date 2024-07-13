using QuickSearch.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuickSearch
{
    public partial class QuickSearchControl : UserControl
    {
        public new string Text
        {
            get { return comboBoxSearch.Text; }
            set
            {
                comboBoxSearch.Text = value;
            }
        }

        public new event EventHandler TextChanged
        {
            add
            {
                comboBoxSearch.TextChanged += value;
            }
            remove
            {
                comboBoxSearch.TextChanged -= value;
            }
        }


        }
        public QuickSearchControl()
        {
            InitializeComponent();
            UpdateWidth();
            comboBoxSearch.GotFocus += new EventHandler(ComboBoxSearch_GotFocus);
            comboBoxSearch.LostFocus += new EventHandler(ComboBoxSearch_LostFocus);

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
        }

        void ComboBoxSearch_LostFocus(object sender, EventArgs e)
        {
            Debug.WriteLine("Focus Lost");
            SetBackColorNormal();
            OnLostFocus(e);
        }

        void ComboBoxSearch_GotFocus(object sender, EventArgs e)
        {
            Debug.WriteLine("Got Focus");
            SetBackColorNormal();
        }

        // this event has to be consumed by all checkboxes and the DropDown. 
        // The TableLayoutPanels and GroupBoxes don't seem to raise this event
        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                    SetBackColorSuccess();
                    break;
                case SearchStatus.Error:
                    SetBackColorError();
                    break;
                case SearchStatus.Pending:
                    SetBackColorSearching();
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
            if (toolStripDropDownSettings.Visible == false)
            {
                ButtonDropdownSettings.ImageIndex = 0;
            }
        }

        private void ButtonDropdownSettings_Click(object sender, EventArgs e)
        {
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
            if (!ButtonDropdownSettings.ClientRectangle.IntersectsWith(new Rectangle(mousePosition, System.Drawing.Size.Empty)))
            {
                ButtonDropdownSettings.ImageIndex = 0;
            }
            ButtonDropdownSettings.Enabled = true;
        }

        void SetBackColor(Color color)
        {
            comboBoxSearch.BackColor = color;
            ButtonDropdownSettings.BackColor = color;
            ButtonDropdownSettings.FlatAppearance.MouseDownBackColor = color;
            ButtonDropdownSettings.FlatAppearance.MouseOverBackColor = color;
        }

        void SetBackColorError()
        {
            SetBackColor(Settings.Default.BackColorOnError);
        }

        void SetBackColorSearching()
        {
            SetBackColor(Settings.Default.BackColorSearching);
        }

        void SetBackColorSuccess()
        {
            SetBackColor(Settings.Default.BackColorSuccess);
        }

        void SetBackColorNormal()
        {
            SetBackColor(comboBoxSearch.Focused ? Settings.Default.BackColorNormalFocused : Settings.Default.BackColorNormalUnFocused);
        }

        public void UpdateWidth()
        {
            Width = Settings.Default.ControlWidth;
            comboBoxSearch.Invalidate();
        }
    }
}
