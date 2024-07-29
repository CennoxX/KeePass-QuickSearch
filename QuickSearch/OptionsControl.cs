using QuickSearch.Properties;
using System;
using System.Windows.Forms;

namespace QuickSearch
{
    public partial class OptionsControl : UserControl
    {
        public OptionsControl()
        {
            InitializeComponent();
            this.ControlWidth.Value = Settings.Default.ControlWidth;
            this.colorSelectButtonError.SelectedColor = Settings.Default.BackColorOnError;
            this.colorSelectButtonFocused.SelectedColor = Settings.Default.BackColorNormalFocused;
            this.colorSelectButtonPending.SelectedColor = Settings.Default.BackColorSearching;
            this.colorSelectButtonUnfocused.SelectedColor = Settings.Default.BackColorNormalUnFocused;
            this.colorSelectButtonSuccess.SelectedColor = Settings.Default.BackColorSuccess;
        }

        public void OKButtonPressed(Object sender, EventArgs e)
        {
            Settings.Default.ControlWidth = (int)this.ControlWidth.Value;
            Settings.Default.BackColorOnError = this.colorSelectButtonError.SelectedColor;
            Settings.Default.BackColorNormalFocused = this.colorSelectButtonFocused.SelectedColor;
            Settings.Default.BackColorSearching = this.colorSelectButtonPending.SelectedColor;
            Settings.Default.BackColorNormalUnFocused = this.colorSelectButtonUnfocused.SelectedColor;
            Settings.Default.BackColorSuccess = this.colorSelectButtonSuccess.SelectedColor;
        }
    }
}
