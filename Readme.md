# QuickSearch

QuickSearch is a search plugin for [KeePass 2](http://www.KeePass.info), designed to provide instant search results. It serves as replacement to the built-in QuickFind toolbar control, offering an enhanced user experience.

Original version: [profon.wordpress.com](http://profon.wordpress.com/quicksearch/)

## Table of Contents

- [Installation and Uninstallation](#installation-and-uninstallation)
- [Usage](#usage)
- [Development](#development)
- [Changelog](#changelog)
- [Contact](#contact)

## Installation and Uninstallation

### Installation

1. Download `QuickSearch.plgx` from the [latest Release](https://github.com/CennoxX/keepass-quicksearch/releases/latest).
2. Move `QuickSearch.plgx` into your KeePass Plugins folder (`Tools` > `Plugins…` > `Open Folder`).
3. Provide administrator permission to copy to the folder.
4. Restart KeePass to complete the installation.

### Uninstallation

1. Remove `QuickSearch.plgx` from your KeePass Plugins folder.
2. Provide administrator permission to remove the file.
3. Restart KeePass to complete the uninstallation.

## Usage

QuickSearch enhances KeePass’s search functionality, delivering instant results as you type. If you need to make a more complex search, you can still use `CTRL+F` to open the search from KeePass.

### Shortcuts

- **Activate Search Box**: `CTRL+SHIFT+X`
- **Focus Password List**: `ENTER`
- **Clear Search Box**: `ESCAPE` (if the search box is empty, the `ESCAPE` action configured in KeePass is executed)

### Additional Features

- **Dynamic Search Box Color**: Changes based on search results and focus (adjust in `Tools` > `Options…` > `Quick Search`).
- **Quick Access Panel**: Customize search settings easily by clicking the magnifying glass icon next to the search box.
- **KeePass Integration**: Respects KeePass settings for focusing the search box when restoring from tray or minimized state.

## Development
1. **Clone the repository**
2. **Install dependencies**:
   - Ensure you have the "Microsoft .NET Framework 4.6.2 Developer Pack" installed. You can download it from the [official Microsoft website](https://dotnet.microsoft.com/download/dotnet-framework).
3. **Build the project**:
   - After making changes, rebuild the QuickSearch project in the solution
4. **Ensure KeePass is not running**:
   - Before starting the debug process, make sure there are no running instances of KeePass.
5. **Start debugging**:
   - Start the debug process to test your changes.
   
## Changelog

### v2.35
- **Added**: Show passwords in groups
- **Added**: Search in group names

<details>
<summary>Full Changelog</summary>

### v2.34
- **Added**: Sync KeePass search settings
- **Added**: Consistent use of KeePass settings for focus
- **Added**: Reset search on empty search box
- **Added**: Always hide KeePass QuickFind
- **Changed**: Revised PlgX creation
- **Fixed**: Option exclude expired entries
- **Fixed**: Display of entries on reset
- **Fixed**: Text formatting of expired entries

### v2.33
- **Added**: Respect KeePass settings when focusing the search box on restoring from tray or minimized.
- **Added**: KeePass 2.x as a submodule.

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

## Contact
For questions, issues, or discussions, visit the [GitHub Issues page](https://github.com/CennoxX/keepass-quicksearch/issues) or check out the [GitHub Discussions page](https://github.com/CennoxX/keepass-quicksearch/discussions).
