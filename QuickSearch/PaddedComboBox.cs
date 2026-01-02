using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickSearch
{
    public class PaddedComboBox : ComboBox
    {
        const int EM_SETMARGINS = 0xD3, EC_LEFTMARGIN = 0x1, EC_RIGHTMARGIN = 0x2;
        public int LeftPadding = 23;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr windowHandle, int message, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool GetComboBoxInfo(IntPtr comboBoxHandle, ref ComboBoxInformation comboBoxInformation);

        struct ComboBoxInformation
        {
            public int StructureSize;
            public RectangleCoordinates ItemRectangle, ButtonRectangle;
            public int ButtonState;
            public IntPtr ComboBoxHandle, EditControlHandle, ListControlHandle;
        }

        struct RectangleCoordinates
        {
            public int Left, Top, Right, Bottom;
        }

        protected override void OnHandleCreated(EventArgs eventArgs)
        {
            base.OnHandleCreated(eventArgs);
            var comboBoxInformation = new ComboBoxInformation
            {
                StructureSize = Marshal.SizeOf(typeof(ComboBoxInformation))
            };
            if (GetComboBoxInfo(Handle, ref comboBoxInformation) && comboBoxInformation.EditControlHandle != IntPtr.Zero)
            {
                SendMessage(comboBoxInformation.EditControlHandle, EM_SETMARGINS, (IntPtr)(EC_LEFTMARGIN | EC_RIGHTMARGIN), (IntPtr)(LeftPadding | (4 << 16)));
            }
        }
    }
}