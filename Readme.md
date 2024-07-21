# QuickSearch

QuickSearch is a search plugin for KeePass Password Safe 2 [KeePass.info](http://www.KeePass.info) that provides instant results. It can be used as a replacement for the built-in QuickFind toolbar control.

Original version: [profon.wordpress.com](http://profon.wordpress.com/quicksearch/)

## Installation

Place __QuickSearch.plgx__ in your KeePass Plugins folder.

## Uninstallation

Delete __QuickSearch.plgx__ from your KeePass Plugins folder.

## Changelog
v2.32
* Fixed: shortcut to activate search bar, now CTRL+SHIFT+X
* Added: focus password list on ENTER
* Added: clear search bar on ESCAPE, hide on ESCAPE if configured on empty search bar
* Added: focus search bar on restoring from tray
* Added: strike out expired entries

v2.31
* Fixed: search not working after sync
* Added: CTRL+Backspace deletes last word

v2.30
* Changes in build configuration

v2.29
* Fixed: compatibility issue

v2.28
* Fixed: automatic check for updates

v2.27
* Added: automatic check for updates

v2.26
* Added: CTRL+SHIFT+F activates search textbox
* Knownig issue: doesn't work at Linux

v2.17
* Fixed: support KeePass 2.17

v2.13 b0.0.0.2
* Fixed: QuickSearch.config will now be saved in application directory if PreferUserConfiguration==false.
* Added: different mouse cursor for ColorSelectButton

v0.3
* Settings system changed: QuickSearch.config is no longer used and settings are now stored in the KeePass config file
* Changed redistributable to plgx instead of dll
* Compatible with KeePass 2.28 (and probably earlier versions, but untested)
