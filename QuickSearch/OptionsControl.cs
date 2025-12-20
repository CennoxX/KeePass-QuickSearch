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
            ControlWidth.Value = Settings.Default.ControlWidth;
            colorSelectButtonError.SelectedColor = Settings.Default.BackColorOnError;
            colorSelectButtonFocused.SelectedColor = Settings.Default.BackColorNormalFocused;
            colorSelectButtonPending.SelectedColor = Settings.Default.BackColorSearching;
            colorSelectButtonUnfocused.SelectedColor = Settings.Default.BackColorNormalUnFocused;
            colorSelectButtonSuccess.SelectedColor = Settings.Default.BackColorSuccess;
        }

        public void OKButtonPressed(Object sender, EventArgs e)
        {
            Settings.Default.ControlWidth = (int)ControlWidth.Value;
            Settings.Default.BackColorOnError = colorSelectButtonError.SelectedColor;
            Settings.Default.BackColorNormalFocused = colorSelectButtonFocused.SelectedColor;
            Settings.Default.BackColorSearching = colorSelectButtonPending.SelectedColor;
            Settings.Default.BackColorNormalUnFocused = colorSelectButtonUnfocused.SelectedColor;
            Settings.Default.BackColorSuccess = colorSelectButtonSuccess.SelectedColor;
        }
    }
}
