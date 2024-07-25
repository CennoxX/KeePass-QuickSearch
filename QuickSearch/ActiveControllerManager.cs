using KeePass.Plugins;
using KeePassLib;
using QuickSearch.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuickSearch
{
    class ActiveControllerManager
    {
        IPluginHost host;
        Dictionary<PwDatabase, SearchController> dictionary = new Dictionary<PwDatabase, SearchController>();
        QuickSearchControl qsControl;

        public ActiveControllerManager(IPluginHost host, QuickSearchControl qsControl)
        {
            this.host = host;

            this.qsControl = qsControl;
            host.MainWindow.FileOpened += new EventHandler<KeePass.Forms.FileOpenedEventArgs>(MainWindow_FileOpened);
            host.MainWindow.FileClosed += new EventHandler<KeePass.Forms.FileClosedEventArgs>(MainWindow_FileClosed);
            host.MainWindow.DocumentManager.ActiveDocumentSelected += new EventHandler(DocumentManager_ActiveDocumentSelected);
            host.MainWindow.FocusChanging += new EventHandler<KeePass.Forms.FocusEventArgs>(MainWindow_FocusChanging);
            qsControl.LostFocus += new EventHandler(QsControl_LostFocus);
        }

        void QsControl_LostFocus(object sender, EventArgs e)
        {
            Debug.WriteLine("QuickSearch Control lost Focus");
            foreach (SearchController searchController in dictionary.Values)
            {
                searchController.ClearPreviousSearches();
            }
        }

        void MainWindow_FocusChanging(object sender, KeePass.Forms.FocusEventArgs e)
        {
            Debug.WriteLine("MainWindow_FocusChanging");
            // prevent Keepass to set focus to some other control after file has been opened
            e.Cancel = true;
        }

        void DocumentManager_ActiveDocumentSelected(object sender, EventArgs e)
        {
            Debug.WriteLine("DocumentManager_ActiveDocumentSelected event");

            foreach (KeyValuePair<PwDatabase, SearchController> pair in dictionary)
            {
                qsControl.TextChanged -= pair.Value.TextUpdateHandler;
                if (pair.Key == host.Database)
                    qsControl.TextChanged += pair.Value.TextUpdateHandler;
            }
        }

        void MainWindow_FileClosed(object sender, KeePass.Forms.FileClosedEventArgs e)
        {
            Debug.WriteLine("File closed");
            // remove the event listeners of those Search Controllers whose databases have been closed
            PwDatabase[] databases = new PwDatabase[dictionary.Count];
            dictionary.Keys.CopyTo(databases, 0);
            //bool isDatabaseOpen
            bool disableQSControl = true;
            foreach (PwDatabase database in databases)
            {
                if (database.IsOpen == false)
                {
                    SearchController controller;
                    dictionary.TryGetValue(database, out controller);
                    qsControl.TextChanged -= controller.TextUpdateHandler;
                    dictionary.Remove(database);
                }
                else // database is open
                {
                    disableQSControl = false;
                }
            }
            if (disableQSControl)
            {
                qsControl.Text = string.Empty;
            }
            //to be improved once access to closed database is implemented in Keepass
            //dictionary.Clear();
            //foreach (PwDocument document in host.MainWindow.DocumentManager.Documents)
            //{
            //    if (document.Database.IsOpen) 
            //    dictionary.Add(document.Database, new SearchController(this.qsControl, document.Database, GetMainListViewControl()));
            //}
        }

        void MainWindow_FileOpened(object sender, KeePass.Forms.FileOpenedEventArgs e)
        {
            Debug.WriteLine("File opened");
            //add a new Controller for the opened Database

            SearchController searchController = new SearchController(qsControl, e.Database, GetMainListViewControl());
            dictionary.Add(e.Database, searchController);
            //assuming the opened Database is also the active Database we subscribe it's SearchController
            //so user input will be handled by that Controller
            qsControl.TextChanged += searchController.TextUpdateHandler;
            qsControl.Enabled = true;
            // focus doesn't work if the Form is not yet visible. Use Select instead
            qsControl.comboBoxSearch.Select();
        }

        private ListView GetMainListViewControl()
        {
            Control.ControlCollection mainWindowControls = host.MainWindow.Controls;
            return (ListView)mainWindowControls.Find("m_lvEntries", true)[0];
        }
    }
}
