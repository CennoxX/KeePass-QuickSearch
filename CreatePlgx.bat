@echo off

echo Deleting existing PlgX folder
rmdir /s /q PlgX

echo Creating PlgX folder
mkdir PlgX

echo Copying files
xcopy "QuickSearch" PlgX /s /e /exclude:PlgxExclude.txt

echo Compiling PlgX
"KeePass2.x/Build/KeePass/Release/KeePass.exe" /plgx-create "%~dp0PlgX"

echo Releasing PlgX
mkdir Release
move /y PlgX.plgx "Release\QuickSearch.plgx"

echo Cleaning up
rmdir /s /q PlgX
