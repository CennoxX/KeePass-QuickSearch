# QuickSearch
QuickSearch is a search plugin for [KeePass 2](http://www.KeePass.info), designed to provide instant search results. It serves as replacement to the built-in QuickFind toolbar control, offering an enhanced user experience.

## Table of Contents
- [Usage](#usage)
- [Installation and Uninstallation](#installation-and-uninstallation)
- [Development](#development)
- [Changelog](#changelog)
- [Credits](#credits)
- [Contact](#contact)

## Usage
QuickSearch delivers instant results as you type. A password entry is a match if all words separated by whitespace occur within a single one of its fields, regardless of their position in the field.

 If you need to make a more complex search, you can still use `CTRL+F` to open the search from KeePass.

**Warning:** If you search in fields that have in-memory protection, they will be decrypted and remain unencrypted in memory for a while.

<img src="https://github.com/user-attachments/assets/04a44465-8d92-4a78-ba3b-5f0d6fdf890c" height="440" alt="QuickSearch plugin filtering entries" />

### Shortcuts
- **Activate Search Box**: `CTRL+E`
- **Focus Password List**: `ENTER`
- **Clear Search Box**: `ESCAPE` (if the search box is empty, the `ESCAPE` action configured in KeePass is executed)

### Additional Features
- **Dynamic Search Box Color**: Changes based on search results and focus (adjust in `Tools` > `Options…` > `Quick Search`).
- **Quick Settings Panel**: Customize search settings easily by clicking the magnifying glass icon next to the search box.
- **Integrates seamlessly with KeePass**: Respects following KeePass settings
  - Search for passwords in quick searches
  - Exclude expired entries in quick searches
  - Focus quick search box when restoring from taskbar
  - Focus quick search box when restoring from tray
  - Alternating item background color
  - Grouping in Entry List

<img src="https://github.com/user-attachments/assets/e2cd2c2c-bf5a-4ae7-bc94-afee530f05e4" height="300" width="379" align="left" alt="Settings for QuickSearch in KeePass" />
<img src="https://github.com/user-attachments/assets/e1ecf93a-da98-4c3b-8924-9c32c425ff19" height="300" width="406" alt="KeePass with opened Quick Settings Panel" />

## Installation and Uninstallation
### Installation
1. Download `QuickSearch.plgx` from the [latest Release](https://github.com/CennoxX/KeePass-QuickSearch/releases/latest).
2. Move `QuickSearch.plgx` into your KeePass Plugins folder (`Tools` > `Plugins…` > `Open Folder`).
3. Provide administrator permission to copy to the folder.
4. Restart KeePass to complete the installation.

### Uninstallation
1. Remove `QuickSearch.plgx` from your KeePass Plugins folder.
2. Provide administrator permission to remove the file.
3. Remove all `Item`s in `%AppData%\KeePass\KeePass.config.xml` under `/Configuration/Custom` with `Key`s beginning with `QuickSearch`
4. Restart KeePass to complete the uninstallation.

## Development
1. **Clone the repository**
2. **Install dependencies**:
   - Ensure you have the "Microsoft .NET Framework 4.6.2 Developer Pack" installed. You can download it from the [official Microsoft website](https://dotnet.microsoft.com/download/dotnet-framework).
3. **Build the project**:
   - Every time after making changes, rebuild the QuickSearch project in the solution
4. **Ensure KeePass is not running**:
   - Before starting the debug process, make sure there are no running instances of KeePass.
5. **Start debugging**:
   - Start the debug process to test your changes.
6. **Ignore assertion errors**:
   - Ignore potential KeePass assertion errors that may occur when using DPI scaling settings.

You can skip step 3 by adding the following as a pre-build event to the Build Events of the KeePass project: `if "$(BuildingInsideVisualStudio)" == "true" "$(MSBuildBinPath)\msbuild.exe" "$(ProjectDir)..\..\QuickSearch\QuickSearch.csproj" /p:Configuration=$(ConfigurationName)`
   
## Changelog
### v2.41
- **Fixed**: `CTRL+E` was captured globally

<details>
<summary>Full Changelog</summary>
### v2.40
- **Fixed**: Show previously partially cut off text in options.

### v2.39
- **Fixed**: Crash on missing KeeTheme.

### v2.38
- **Added**: Alternating item backgrounds in search.
- **Added**: Add placeholder text to search box.

### v2.37
- **Added**: Localize the quick settings panel using KeePass localization.
- **Added**: Use search combobox items like KeePass search.
- **Added**: Search in tags.
- **Added**: Add tooltip to search box.
- **Fixed**: Group search and exclude expired entries in some cases.
- **Fixed**: Groupbox color with the dark theme from the KeeTheme plugin.

### v2.36
- **Changed**: Shortcut to activate search box now `CTRL+E`.
- **Changed**: Use modern default colors.
- **Changed**: Updated icons to avoid copyright issues.
- **Changed**: Align settings with KeePass aesthetics.
- **Fixed**: Color selection with the dark theme from the KeeTheme plugin.

### v2.35
- **Added**: Show passwords in groups.
- **Added**: Search in group names.

### v2.34
- **Added**: Sync KeePass search settings.
- **Added**: Consistent use of KeePass settings for focus.
- **Added**: Reset search on empty search box.
- **Added**: Always hide KeePass QuickFind.
- **Changed**: Revised PlgX creation.
- **Fixed**: Option exclude expired entries.
- **Fixed**: Display of entries on reset.
- **Fixed**: Text formatting of expired entries.

### v2.33
- **Added**: Respect KeePass settings when focusing the search box on restoring from tray or minimized.
- **Added**: KeePass2.x as a submodule.

### v2.32
- **Fixed**: Shortcut to activate search box, now `CTRL+SHIFT+X`.
- **Added**: Focus password list on `ENTER`.
- **Added**: Clear search box on `ESCAPE`, use the `ESCAPE` action configured in KeePass if the search box is empty.
- **Added**: Focus search box on restoring from tray or minimized state.
- **Added**: Strike out expired entries.

### v2.31
- **Fixed**: Search functionality issue after sync.
- **Added**: `CTRL+Backspace` deletes the last word.

### v2.30
- **Changed**: Updated build configuration.

### v2.29
- **Fixed**: Compatibility issues.

### v2.28
- **Fixed**: Automatic check for updates.

### v2.27
- **Added**: Automatic check for updates.

### v2.26
- **Added**: `CTRL+SHIFT+F` shortcut for activating search textbox.

### v2.17
- **Fixed**: Support KeePass 2.17.

### v2.13 b0.0.0.2
- **Fixed**:  QuickSearch.config will now be saved in the application directory if `PreferUserConfiguration==false`.
- **Added**: Custom mouse cursor for `ColorSelectButton`.

### v0.3
- **Changed**: Configuration system updated; settings now stored in the KeePass config file instead of `QuickSearch.config`.
- **Changed**: Redistributable format updated to `.plgx` from `.dll`.
- **Fixed**: Support KeePass 2.28 and likely earlier versions (untested).

</details>

## Credits
Original version by [Gordon Venem](https://profon.wordpress.com/quicksearch/)<br />
With contributions by [Dominik Reichl](https://sourceforge.net/u/dreichl/profile/), [Alex Vallat](https://sourceforge.net/u/alexvallat/profile/) and [Laurens von Assel](https://github.com/biolauri)<br />
Current development by [CennoxX](https://github.com/CennoxX/)<br />
Icons by David Vignoni, licensed under the [LGPL 2.1](https://www.gnu.org/licenses/old-licenses/lgpl-2.1.html)

## Contact
For questions, issues, or discussions, visit the [GitHub Issues page](https://github.com/CennoxX/keepass-quicksearch/issues) or check out the [GitHub Discussions page](https://github.com/CennoxX/keepass-quicksearch/discussions).
