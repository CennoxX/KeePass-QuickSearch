using KeePass;
using KeePass.App.Configuration;
using KeePass.Resources;
using KeePass.UI;
using KeePassLib;
using KeePassLib.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuickSearch
{
    class SearchController
    {
        static object listViewLock = new object();
        List<Search> previousSearches = new List<Search>();
        QuickSearchControl quickSearchControl;
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        PwDatabase database;
        EventHandler textUpdateHandler;
        ListView listview;
        delegate void QsUpdateMethod(SearchStatus status, bool cancellationPending);
        QsUpdateMethod qsUpdateMethod;
        bool secondEscape = false;

        public EventHandler TextUpdateHandler
        {
            get { return textUpdateHandler; }
        }

        public SearchController(QuickSearchControl qsControl, PwDatabase database, ListView listview)
        {
            this.database = database;
            this.listview = listview;
            qsUpdateMethod = QsUpdate;
            quickSearchControl = qsControl;
            textUpdateHandler = new EventHandler(Control_TextUpdate);
            Debug.Assert(listview != null);
            backgroundWorker.WorkerSupportsCancellation = true;
            quickSearchControl.PreviewKeyDown += new PreviewKeyDownEventHandler(QuickSearchControl_PreviewKeyDown);
        }

        private void QuickSearchControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listview.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (!secondEscape && quickSearchControl.Text == string.Empty)
                    return;

                secondEscape = !secondEscape;
                quickSearchControl.Text = string.Empty;
                e.IsInputKey = true;
                if (secondEscape)
                    return;
                var entries = database.RootGroup.Entries.AsEnumerable();
                entries = entries.Concat(database.RootGroup.Groups.SelectMany(i => i.Entries));
                listview.BeginUpdate();
                listview.Items.Clear();
                listview.Items.AddRange(entries.Select(pe => AddEntryToList(pe)).ToArray());
                listview.EndUpdate();
            }
        }
        public void ClearPreviousSearches()
        {
            previousSearches.Clear();
        }

        private void Control_TextUpdate(object sender, EventArgs e)
        {
            Debug.WriteLine("Text changed to: " + quickSearchControl.Text);
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            String userText = quickSearchControl.Text.Trim();
            // if there is no text, don't search
            if (userText.Equals(String.Empty))
            {
                quickSearchControl.UpdateSearchStatus(SearchStatus.Normal);
                return;
            }
            else
            {
                quickSearchControl.UpdateSearchStatus(SearchStatus.Pending);
            }
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);

            backgroundWorker.RunWorkerAsync(userText);
        }

        /// <summary>
        /// This method is called by the UI thread. The ListView usually can only be updated from this thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ListViewItem[] items = e.Result as ListViewItem[];
            if (items != null)
            {
                /* don't make this. text will be overriden when selection index in listview changes
                string itemsFound = items.Length.ToString() + " " +
                KPRes.SearchItemsFoundSmall;
                Program.MainForm.SetStatusEx(itemsFound);
                */
                Stopwatch sw = Stopwatch.StartNew();
                listview.BeginUpdate();

                listview.Items.Clear();
                listview.Items.AddRange(items);
                listview.Items[0].Selected = true;
                listview.EndUpdate();
                Debug.WriteLine("ListView updated in elapsed Ticks: " + sw.ElapsedTicks.ToString() + ", elapsed ms: " + sw.ElapsedMilliseconds);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            String userText = (string)e.Argument;
            Search newSearch = new Search(userText);

            bool previousSearchFound = false;
            lock (this)
            {
                for (int i = previousSearches.Count - 1; i >= 0; i--)
                {
                    if (previousSearches[i].ParamEquals(newSearch))
                    {
                        previousSearchFound = true;
                        newSearch = previousSearches[i];
                        Debug.WriteLine("found exact match in previousSearches");
                        break;
                    }
                }
                if (previousSearchFound == false)
                {
                    for (int i = previousSearches.Count - 1; i >= 0; i--)
                    {
                        if (previousSearches[i].IsRefinedSearch(newSearch))
                        {
                            previousSearchFound = true;
                            newSearch.PerformSearch(previousSearches[i].resultEntries, worker);
                            Debug.WriteLine("Search is refined search");
                            break;
                        }
                    }
                }
            }

            if (previousSearchFound == false)
            {
                newSearch.PerformSearch(database.RootGroup, worker);
            }

            lock (this)
            {

                previousSearches.Add(newSearch);
                if (!worker.CancellationPending)
                {
                    SearchStatus status;
                    if (newSearch.resultEntries.Count == 0)
                    {
                        status = SearchStatus.Error;
                    }
                    else
                    {
                        status = SearchStatus.Success;
                    }
                    quickSearchControl.Invoke(qsUpdateMethod, status, worker.CancellationPending);
                }
            }

            // for testing
            // only update the ListView if there are results
            if (newSearch.resultEntries.Count != 0)
            {
                // using the ListView itself for locking caused problems
                if (!worker.CancellationPending)
                {
                    ListViewItem[] items = new ListViewItem[newSearch.resultEntries.Count];
                    int i = 0;
                    foreach (PwEntry entry in newSearch.resultEntries)
                    {
                        if (worker.CancellationPending)
                        {
                            return;
                        }
                        items[i] = AddEntryToList(entry);
                        i++;
                    }
                    lock (listViewLock)
                    {
                        if (!worker.CancellationPending)
                        {
                            e.Result = items;
                        }
                    }
                }
            }
        }

        private ListViewItem AddEntryToList(PwEntry pe)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = new PwListItem(pe);

            if (pe.Expires && DateTime.UtcNow > pe.ExpiryTime)
            {
                lvi.ImageIndex = (int)PwIcon.Expired;
                lvi.Font = FontUtil.CreateFont(lvi.Font, lvi.Font.Style | FontStyle.Strikeout);
            }
            else if (pe.CustomIconUuid.Equals(PwUuid.Zero))
            {
                lvi.ImageIndex = (int)pe.IconId;
            }
            else
            {
                lvi.ImageIndex = (int)PwIcon.Count + database.GetCustomIconIndex(pe.CustomIconUuid);
            }

            if (!pe.ForegroundColor.IsEmpty)
                lvi.ForeColor = pe.ForegroundColor;

            if (!pe.BackgroundColor.IsEmpty)
                lvi.BackColor = pe.BackgroundColor;

            lvi.Text = GetEntryFieldEx(pe, 0, true);

            for (int iColumn = 1; iColumn < listview.Columns.Count; ++iColumn)
                lvi.SubItems.Add(GetEntryFieldEx(pe, iColumn, true));

            Debug.Assert(lvi != null);
            return lvi;
        }

        private string GetEntryFieldEx(PwEntry pe, int iColumnID, bool bAsterisksIfHidden)
        {
            List<AceColumn> l = Program.Config.MainWindow.EntryListColumns;
            if ((iColumnID < 0) || (iColumnID >= l.Count)) { Debug.Assert(false); return string.Empty; }

            AceColumn col = l[iColumnID];
            if (bAsterisksIfHidden && col.HideWithAsterisks) return PwDefs.HiddenPassword;

            string str = string.Empty;
            switch (col.Type)
            {
                case AceColumnType.Title: str = pe.Strings.ReadSafe(PwDefs.TitleField); break;
                case AceColumnType.UserName: str = pe.Strings.ReadSafe(PwDefs.UserNameField); break;
                case AceColumnType.Password: str = pe.Strings.ReadSafe(PwDefs.PasswordField); break;
                case AceColumnType.Url: str = pe.Strings.ReadSafe(PwDefs.UrlField); break;
                case AceColumnType.Notes: str = pe.Strings.ReadSafe(PwDefs.NotesField); break;
                case AceColumnType.CreationTime: str = TimeUtil.ToDisplayString(pe.CreationTime); break;
                case AceColumnType.LastAccessTime: str = TimeUtil.ToDisplayString(pe.LastAccessTime); break;
                case AceColumnType.LastModificationTime: str = TimeUtil.ToDisplayString(pe.LastModificationTime); break;
                case AceColumnType.ExpiryTime:
                    if (pe.Expires) str = TimeUtil.ToDisplayString(pe.ExpiryTime);
                    else str = KPRes.NeverExpires;
                    break;
                case AceColumnType.Uuid: str = pe.Uuid.ToHexString(); break;
                case AceColumnType.Attachment: str = pe.Binaries.KeysToString(); break;
                case AceColumnType.CustomString:
                    str = pe.Strings.ReadSafe(col.CustomName);
                    break;
                case AceColumnType.PluginExt:
                    str = Program.ColumnProviderPool.GetCellData(col.CustomName, pe);
                    break;
                case AceColumnType.OverrideUrl: str = pe.OverrideUrl; break;
                case AceColumnType.Tags:
                    str = StrUtil.TagsToString(pe.Tags, true);
                    break;
                case AceColumnType.ExpiryTimeDateOnly:
                    if (pe.Expires) str = TimeUtil.ToDisplayStringDateOnly(pe.ExpiryTime);
                    else str = KPRes.NeverExpires;
                    break;
                case AceColumnType.Size:
                    str = StrUtil.FormatDataSizeKB(pe.GetSize());
                    break;
                case AceColumnType.HistoryCount:
                    str = pe.History.UCount.ToString();
                    break;
                default: Debug.Assert(false); break;
            }

            return str;
        }

        private void QsUpdate(SearchStatus status, bool cancellationPending)
        {
            if (!cancellationPending)
            {
                quickSearchControl.UpdateSearchStatus(status);
            }
        }
    }
}
