using KeePass;
using KeePassLib;
using KeePassLib.Security;
using QuickSearch.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace QuickSearch
{
    public class Search
    {
        /// <summary>
        /// the text the user put into the search box
        /// </summary>
        private string _userSearchString;

        /// <summary>
        /// the splitted user input text
        /// </summary>
        private string[] _searchStrings;

        /// <summary>
        /// names of the standard fields that will be searched in a Password entry. 
        /// </summary>
        private List<string> _searchFields;

        private StringComparison _searchStringComparison;

        private bool _searchInTitle;
        private bool _searchInUrl;
        private bool _searchInUserName;
        private bool _searchInNotes;
        private bool _searchInPassword;
        private bool _searchInGroupName;
        private bool _searchInTags;
        private bool _searchInOther;
        private bool _searchExcludeExpired;

        public List<PwEntry> resultEntries;

        private Properties.Settings searchSettings = Properties.Settings.Default;

        private PwGroup rootGroup;

        public Search(string userSearchText)
        {
            _searchInTitle = Settings.Default.SearchInTitle;
            _searchInUrl = Settings.Default.SearchInUrl;
            _searchInUserName = Settings.Default.SearchInUserName;
            _searchInNotes = Settings.Default.SearchInNotes;
            _searchInPassword = KeePass.Program.Config.MainWindow.QuickFindSearchInPasswords;
            _searchInOther = Settings.Default.SearchInOther;
            _searchInGroupName = Settings.Default.SearchInGroupName;
            _searchInTags = Settings.Default.SearchInTags;
            _searchExcludeExpired = KeePass.Program.Config.MainWindow.QuickFindExcludeExpired;
            if (Settings.Default.SearchCaseSensitive)
            {
                _searchStringComparison = StringComparison.Ordinal;
            }
            else
            {
                _searchStringComparison = StringComparison.OrdinalIgnoreCase;
            }
            _userSearchString = userSearchText;
            _searchStrings = _userSearchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            resultEntries = new List<PwEntry>();
        }

        public Search(PwGroup rootGroup)
        {
            this.rootGroup = rootGroup;

            _searchInTitle = Settings.Default.SearchInTitle;
            _searchInUrl = Settings.Default.SearchInUrl;
            _searchInUserName = Settings.Default.SearchInUserName;
            _searchInNotes = Settings.Default.SearchInNotes;
            _searchInGroupName = Settings.Default.SearchInGroupName;
            _searchInTags = Settings.Default.SearchInTags;
            _searchInPassword = KeePass.Program.Config.MainWindow.QuickFindSearchInPasswords;
            _searchInOther = Settings.Default.SearchInOther;
        }

        public void PerformSearch(List<PwEntry> entries, BackgroundWorker worker)
        {
            SearchInList(entries, worker);
        }

        public void PerformSearch(PwGroup pwGroup, BackgroundWorker worker)
        {
            Debug.WriteLine("Starting a new Search in Group");
            Stopwatch sw = Stopwatch.StartNew();

            if (pwGroup != null)
            {
                SearchInList(pwGroup.Entries, worker);
                if (Program.Config.MainWindow.ShowEntriesOfSubGroups)
                {
                    foreach (PwGroup group in pwGroup.Groups)
                    {
                        PerformSearch(group, worker);
                    }
                }
            }
            Debug.WriteLine("End of Search in Group. Worker cancelled: " + worker.CancellationPending + ". elapsed Ticks: " + sw.ElapsedTicks.ToString() + " elapsed ms: " + sw.ElapsedMilliseconds);
        }

        private void SearchInList(IEnumerable<PwEntry> pWList, BackgroundWorker worker)
        {
            foreach (PwEntry entry in pWList)
            {
                // check if cancellation was requested. In this case don't continue with the search
                if (worker.CancellationPending)
                    return;

                if (_searchExcludeExpired && entry.Expires && DateTime.UtcNow > entry.ExpiryTime)
                    continue;
                
                if (_searchInGroupName && AddEntryIfMatched(entry.ParentGroup.Name, entry, worker))
                    continue;

                if (_searchInTags)
                {
                    var tagFound = false;
                    foreach (var tag in entry.Tags)
                    {
                        if (AddEntryIfMatched(tag, entry, worker))
                        {
                            tagFound = true;
                            break;
                        }
                    }
                    if (tagFound)
                        continue;
                }

                foreach (KeyValuePair<string, ProtectedString> pair in entry.Strings)
                {
                    // check if cancellation was requested. In this case don't continue with the search
                    if (worker.CancellationPending)
                        return;

                    if (((_searchInTitle && pair.Key.Equals(PwDefs.TitleField))
                        || (_searchInUrl && pair.Key.Equals(PwDefs.UrlField))
                        || (_searchInUserName && pair.Key.Equals(PwDefs.UserNameField))
                        || (_searchInNotes && pair.Key.Equals(PwDefs.NotesField))
                        || (_searchInPassword && pair.Key.Equals(PwDefs.PasswordField))
                        || (_searchInOther && !PwDefs.IsStandardField(pair.Key)))
                        && (AddEntryIfMatched(pair.Value.ReadString(), entry, worker)))
                        break;
                }
            }
        }

        private bool AddEntryIfMatched(string source, PwEntry entry, BackgroundWorker worker)
        {
            foreach (string searchString in _searchStrings)
            {
                if (worker.CancellationPending || source.IndexOf(searchString, _searchStringComparison) < 0)
                    return false;
            }
            resultEntries.Add(entry);
            return true;
        }

        public bool SettingsEquals(Search search)
        {
            return _searchInTitle == search._searchInTitle &&
            _searchInUrl == search._searchInUrl &&
            _searchInUserName == search._searchInUserName &&
            _searchInNotes == search._searchInNotes &&
            _searchInPassword == search._searchInPassword &&
            _searchInOther == search._searchInOther &&
            _searchExcludeExpired == search._searchExcludeExpired &&
            _searchStringComparison == search._searchStringComparison;
        }

        /// <summary>
        /// checks if the search specific settings are equal and if the search text is more specific
        /// </summary>
        /// <param name="search"></param>
        /// <returns>true if search is a refinement of this</returns>
        public bool IsRefinedSearch(Search search)
        {
            return SettingsEquals(search) && search._userSearchString.Contains(_userSearchString);
        }

        public bool ParamEquals(Search search)
        {
            return _userSearchString.Equals(search._userSearchString) && SettingsEquals(search);
        }
    }
}
