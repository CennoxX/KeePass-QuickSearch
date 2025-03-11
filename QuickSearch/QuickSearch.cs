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
        private static IPluginHost _host;

        private static Search _search;
        
        private QuickSearchControl _qsControl;
        
        private KeyboardHook _keyboardHook;

        private FormWindowState _wsLast;
        
        private bool _tsLast;

        public override string UpdateUrl
        {
            get { return @"https://raw.githubusercontent.com/CennoxX/KeePass-QuickSearch/master/QuickSearchVersion.txt"; }
        }

        public override bool Initialize(IPluginHost host)
        {
            _host = host;

            Settings.Default.Load(host);

            HideQuickFindControl();
            LocalizeSettingsPanel();
            _qsControl = AddQuickSearchControl(host);
            new ActiveControllerManager(host, _qsControl);

            GlobalWindowManager.WindowAdded += GlobalWindowManager_WindowAdded;

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
                    _qsControl.UpdateWidth();
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
            _keyboardHook = new KeyboardHook(host);
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
                if (mainForm.WindowState != FormWindowState.Minimized && _wsLast == FormWindowState.Minimized)
                {
                    if (Program.Config.MainWindow.FocusQuickFindOnRestore && !_tsLast
                        || Program.Config.MainWindow.FocusQuickFindOnUntray && _tsLast)
                        _qsControl.comboBoxSearch.Select();
                }
                _wsLast = mainForm.WindowState;
                _tsLast = mainForm.IsTrayed();
            }
        }

        /// <summary>
        /// Removes the builtin "QuickFind" ComboBox
        /// </summary>
        private void HideQuickFindControl()
        {
            Control.ControlCollection mainWindowControls = _host.MainWindow.Controls;
            CustomToolStripEx toolStrip = (CustomToolStripEx)mainWindowControls["m_toolMain"];
            ToolStripItem comboBox = toolStrip.Items["m_tbQuickFind"];
            ((ToolStripComboBox)comboBox).ComboBox.Visible = false;
        }
        public static Image SearchImage
		{
			get
			{
				return _host.Resources.GetObject("B16x16_XMag") as Image;
			}
		}
        public static Image OptionsImage
		{
			get
			{
				return _host.Resources.GetObject("B16x16_Misc") as Image;
			}
		}

		public override Image SmallIcon
        {
            get
            {
                return SearchImage;
            }
        }

        public override void Terminate()
        {
            Settings.Default.Save(_host);
            base.Terminate();
        }
    }
}
