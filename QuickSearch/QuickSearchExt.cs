using KeePass;
using KeePass.Forms;
using KeePass.Plugins;
using KeePass.UI;
using QuickSearch.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickSearch
{
    public class QuickSearchExt : Plugin
    {
        public static IPluginHost host;

        public static Search search;

        QuickSearchControl qsControl;

        FormWindowState wsLast;

        bool tsLast;

        public override string UpdateUrl
        {
            get { return @"https://raw.githubusercontent.com/CennoxX/KeePass-QuickSearch/master/QuickSearchVersion.txt"; }
        }

        public override bool Initialize(IPluginHost host)
        {
            QuickSearchExt.host = host;

            Settings.Default.Load(host);

            HideQuickFindControl();
            qsControl = AddQuickSearchControl(host);
            new ActiveControllerManager(host, qsControl);

            GlobalWindowManager.WindowAdded += new EventHandler<GwmWindowEventArgs>(GlobalWindowManager_WindowAdded);

            return true;
        }

        private void GlobalWindowManager_WindowAdded(object sender, GwmWindowEventArgs e)
        {
            OptionsForm optionsForm = e.Form as OptionsForm;
            if (optionsForm != null)
            {
                TabPage tp = new TabPage("QuickSearch");
                tp.BackColor = SystemColors.Window;
                tp.AutoScroll = true;
                OptionsControl optionsControl = new OptionsControl();
                tp.Controls.Add(optionsControl);
                TabControl tc = optionsForm.Controls.Find("m_tabMain", false)[0] as TabControl;
                tc.TabPages.Add(tp);
                optionsControl.Dock = DockStyle.Top;
                Button buttonOK = optionsForm.Controls.Find("m_btnOK", false)[0] as Button;
                buttonOK.Click += delegate (object senderr, EventArgs evtarg)
                {
                    optionsControl.OKButtonPressed(senderr, evtarg);
                    qsControl.UpdateWidth();
                };
            }
        }

        private QuickSearchControl AddQuickSearchControl(IPluginHost host)
        {
            QuickSearchControl myControl = new QuickSearchControl();
            ToolStripControlHost myToolStripControlHost = new ToolStripControlHost(myControl);
            myToolStripControlHost.AutoSize = true;

            Control.ControlCollection mainWindowControls = host.MainWindow.Controls;
            CustomToolStripEx toolStrip = (CustomToolStripEx)mainWindowControls["m_toolMain"];
            toolStrip.Items.Add(myToolStripControlHost);

            var mainForm = host.MainWindow;
            mainForm.KeyPreview = true;
            mainForm.KeyDown += (sender, args) =>
            {
                if (args.KeyData == (Keys.Shift | Keys.Control | Keys.X))
                    myControl.comboBoxSearch.Focus();
            };
            mainForm.Resize += MainForm_Resize;
            return myControl;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainForm mainForm = sender as MainForm;
            var test = mainForm.IsTrayed();
            if (mainForm != null)
            {
                if (mainForm.WindowState != FormWindowState.Minimized && wsLast == FormWindowState.Minimized)
                {
                    if (Program.Config.MainWindow.FocusQuickFindOnRestore && !tsLast
                        || Program.Config.MainWindow.FocusQuickFindOnUntray && tsLast)
                        qsControl.comboBoxSearch.Select();
                }
                wsLast = mainForm.WindowState;
                tsLast = mainForm.IsTrayed();
            }
        }

        /// <summary>
        /// Removes the builtin "QuickFind" ComboBox
        /// </summary>
        private void HideQuickFindControl()
        {
            Control.ControlCollection mainWindowControls = host.MainWindow.Controls;
            CustomToolStripEx toolStrip = (CustomToolStripEx)mainWindowControls["m_toolMain"];
            ToolStripItem comboBox = toolStrip.Items["m_tbQuickFind"];
            ((ToolStripComboBox)comboBox).ComboBox.Visible = false;
        }

        public override Image SmallIcon
        {
            get
            {
                return Resources.search_icon_16;
            }
        }

        public override void Terminate()
        {
            Settings.Default.Save(host);
            base.Terminate();
        }
    }
}
