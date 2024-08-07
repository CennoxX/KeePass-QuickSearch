using KeePass;
using KeePass.App;
using KeePass.App.Configuration;
using KeePass.Forms;
using KeePass.Plugins;
using KeePass.UI;
using KeePass.Util;
using KeePass.Util.XmlSerialization;
using KeePassLib.Translation;
using QuickSearch.Properties;
using System;
using System.Drawing;
using System.IO;
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

        private KeyboardHook _keyboardHook;

        public override bool Initialize(IPluginHost host)
        {
            QuickSearchExt.host = host;

            Settings.Default.Load(host);

            HideQuickFindControl();
            LocalizeSettingsPanel();
            qsControl = AddQuickSearchControl(host);
            new ActiveControllerManager(host, qsControl);

            GlobalWindowManager.WindowAdded += new EventHandler<GwmWindowEventArgs>(GlobalWindowManager_WindowAdded);

            return true;
        }

        private void LocalizeSettingsPanel()
        {
            string strDir = WinUtil.IsAppX ? AppConfigSerializer.AppDataDirectory : Path.GetDirectoryName(WinUtil.GetExecutable());
            string strPath = Path.Combine(strDir, AppDefs.LanguagesDir, Program.Config.Application.LanguageFile);
            if (string.IsNullOrEmpty(Program.Config.Application.LanguageFile) || !File.Exists(strPath))
                return;
            XmlSerializerEx xs = new XmlSerializerEx(typeof(KPTranslation));
            var kpTranslation = KPTranslation.Load(strPath, xs);
            var searchForm = kpTranslation.Forms.Find(i => i.FullName == "KeePass.Forms.SearchForm");
            if (searchForm == null)
                return;
            foreach (var field in typeof(LocalizedStrings).GetFields())
            {
                var control = searchForm.Controls.Find(i => i.Name == field.Name);
                if (control != null)
                    field.SetValue(null, control.Text.Replace("&", ""));
            }
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
            mainForm.Resize += MainForm_Resize;
            
            mainForm.KeyPreview = true;
            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyDown += (sender, e) =>
            {
                if (e.Control && e.KeyCode == Keys.E)
                    myControl.comboBoxSearch.Focus();
            };
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
