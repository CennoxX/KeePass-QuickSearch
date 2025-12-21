using KeePass.Plugins;
using KeePassLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuickSearch
{
    class ActiveControllerManager
    {
        private readonly IPluginHost _host;
        private readonly Dictionary<PwDatabase, SearchController> _dictionary = new Dictionary<PwDatabase, SearchController>();
        private readonly QuickSearchControl _qsControl;

        public ActiveControllerManager(IPluginHost host, QuickSearchControl qsControl)
        {
            _host = host;

            _qsControl = qsControl;
            host.MainWindow.FileOpened += MainWindow_FileOpened;
            host.MainWindow.FileClosed += MainWindow_FileClosed;
            host.MainWindow.DocumentManager.ActiveDocumentSelected += DocumentManager_ActiveDocumentSelected;
            host.MainWindow.FocusChanging += MainWindow_FocusChanging;
            qsControl.LostFocus += QsControl_LostFocus;
        }

        private void QsControl_LostFocus(object sender, EventArgs e)
        {
            Debug.WriteLine("QuickSearch Control lost Focus");
            foreach (SearchController searchController in _dictionary.Values)
            {
                searchController.ClearPreviousSearches();
            }
        }

        private void MainWindow_FocusChanging(object sender, KeePass.Forms.FocusEventArgs e)
        {
            Debug.WriteLine("MainWindow_FocusChanging");
            // prevent Keepass to set focus to some other control after file has been opened
            e.Cancel = true;
        }

        private void DocumentManager_ActiveDocumentSelected(object sender, EventArgs e)
        {
            Debug.WriteLine("DocumentManager_ActiveDocumentSelected event");

            foreach (KeyValuePair<PwDatabase, SearchController> pair in _dictionary)
            {
                _qsControl.TextChanged -= pair.Value.TextUpdateHandler;
                if (pair.Key == _host.Database)
                    _qsControl.TextChanged += pair.Value.TextUpdateHandler;
            }
        }

        private void MainWindow_FileClosed(object sender, KeePass.Forms.FileClosedEventArgs e)
        {
            Debug.WriteLine("File closed");
            // remove the event listeners of those Search Controllers whose databases have been closed
            PwDatabase[] databases = new PwDatabase[_dictionary.Count];
            _dictionary.Keys.CopyTo(databases, 0);
            //bool isDatabaseOpen
            bool disableQSControl = true;
            foreach (PwDatabase database in databases)
            {
                if (!database.IsOpen)
                {
                    SearchController controller;
                    _dictionary.TryGetValue(database, out controller);
                    _qsControl.TextChanged -= controller.TextUpdateHandler;
                    _dictionary.Remove(database);
                }
                else // database is open
                {
                    disableQSControl = false;
                }
            }
            if (disableQSControl)
            {
                _qsControl.Text = string.Empty;
            }
            //to be improved once access to closed database is implemented in Keepass
            //_dictionary.Clear();
            //foreach (PwDocument document in host.MainWindow.DocumentManager.Documents)
            //{
            //    if (document.Database.IsOpen) 
            //    _dictionary.Add(document.Database, new SearchController(_qsControl, document.Database, GetMainListViewControl()));
            //}
        }

        private void MainWindow_FileOpened(object sender, KeePass.Forms.FileOpenedEventArgs e)
        {
            Debug.WriteLine("File opened");
            //add a new Controller for the opened Database

            SearchController searchController = new SearchController(_qsControl, e.Database, GetMainListViewControl());
            _dictionary.Add(e.Database, searchController);
            //assuming the opened Database is also the active Database we subscribe it's SearchController
            //so user input will be handled by that Controller
            _qsControl.TextChanged += searchController.TextUpdateHandler;
            _qsControl.Enabled = true;
            _qsControl.BeginInvoke((Action)(() => _qsControl.comboBoxSearch.Focus()));
        }

        private ListView GetMainListViewControl()
        {
            Control.ControlCollection mainWindowControls = _host.MainWindow.Controls;
            return (ListView)mainWindowControls.Find("m_lvEntries", true)[0];
        }
    }
}
