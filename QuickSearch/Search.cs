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
        string userSearchString;

        /// <summary>
        /// the splitted user input text
        /// </summary>
        string[] searchStrings;

        /// <summary>
        /// names of the standard fields that will be searched in a Password entry. 
        /// </summary>
        List<string> searchFields;

        StringComparison searchStringComparison;

        bool SearchInTitle;
        bool SearchInUrl;
        bool SearchInUserName;
        bool SearchInNotes;
        bool SearchInPassword;
        bool searchInOther;
        bool SearchExcludeExpired;

        public List<PwEntry> resultEntries;

        Properties.Settings searchSettings = Properties.Settings.Default;

        PwGroup rootGroup;

        public Search(string userSearchText)
        {
            SearchInTitle = Settings.Default.SearchInTitle;
            SearchInUrl = Settings.Default.SearchInUrl;
            SearchInUserName = Settings.Default.SearchInUserName;
            SearchInNotes = Settings.Default.SearchInNotes;
            SearchInPassword = KeePass.Program.Config.MainWindow.QuickFindSearchInPasswords;
            searchInOther = Settings.Default.SearchInOther;
            SearchExcludeExpired = KeePass.Program.Config.MainWindow.QuickFindExcludeExpired;
            if (Settings.Default.SearchCaseSensitive)
            {
                searchStringComparison = StringComparison.Ordinal;
            }
            else
            {
                searchStringComparison = StringComparison.OrdinalIgnoreCase;
            }
            userSearchString = userSearchText;
            searchStrings = userSearchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            resultEntries = new List<PwEntry>();
        }

        public Search(PwGroup rootGroup)
        {
            this.rootGroup = rootGroup;

            SearchInTitle = Settings.Default.SearchInTitle;
            SearchInUrl = Settings.Default.SearchInUrl;
            SearchInUserName = Settings.Default.SearchInUserName;
            SearchInNotes = Settings.Default.SearchInNotes;
            SearchInPassword = KeePass.Program.Config.MainWindow.QuickFindSearchInPasswords;
            searchInOther = Settings.Default.SearchInOther;
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
                foreach (PwGroup group in pwGroup.Groups)
                {
                    PerformSearch(group, worker);
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
                {
                    return;
                }

                if (SearchExcludeExpired && entry.Expires && DateTime.UtcNow > entry.ExpiryTime)
                {
                    break;
                }

                foreach (KeyValuePair<string, ProtectedString> pair in entry.Strings)
                {
                    // check if cancellation was requested. In this case don't continue with the search
                    if (worker.CancellationPending)
                    {
                        return;
                    }

                    if (
                           (SearchInTitle && pair.Key.Equals(PwDefs.TitleField))
                        || (SearchInUrl && pair.Key.Equals(PwDefs.UrlField))
                        || (SearchInUserName && pair.Key.Equals(PwDefs.UserNameField))
                        || (SearchInNotes && pair.Key.Equals(PwDefs.NotesField))
                        || (SearchInPassword && pair.Key.Equals(PwDefs.PasswordField))
                        || (searchInOther && !PwDefs.IsStandardField(pair.Key))
                        )
                    {
                        bool allSearchStringsMatched = true;
                        foreach (string searchString in searchStrings)
                        {
                            // check if cancellation was requested. In this case don't continue with the search
                            if (worker.CancellationPending)
                            {
                                return;
                            }
                            if (pair.Value.ReadString().IndexOf(searchString, searchStringComparison) < 0)
                            {
                                // no match in this field
                                // continue with next field
                                allSearchStringsMatched = false;
                                break;
                            }
                            // if no break occured all words have been found. This entry is a match

                        }
                        if (allSearchStringsMatched)
                        {
                            resultEntries.Add(entry);
                            // this entry was a match. The other fields can be skipped
                            // continue with the next entry
                            break;
                        }
                    }
                }
            }
        }

        public bool SettingsEquals(Search search)
        {
            return SearchInTitle == search.SearchInTitle &&
            SearchInUrl == search.SearchInUrl &&
            SearchInUserName == search.SearchInUserName &&
            SearchInNotes == search.SearchInNotes &&
            SearchInPassword == search.SearchInPassword &&
            searchInOther == search.searchInOther &&
            SearchExcludeExpired == search.SearchExcludeExpired &&
            searchStringComparison == search.searchStringComparison;
        }

        /// <summary>
        /// checks if the search specific settings are equal and if the search text is more specific
        /// </summary>
        /// <param name="search"></param>
        /// <returns>true if search is a refinement of this</returns>
        public bool IsRefinedSearch(Search search)
        {
            return SettingsEquals(search) && search.userSearchString.Contains(userSearchString);
        }

        public bool ParamEquals(Search search)
        {
            return userSearchString.Equals(search.userSearchString) && SettingsEquals(search);
        }
    }
}
