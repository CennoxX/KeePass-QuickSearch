echo Deleting existing PlgX folder
rm -rf Plgx/

echo Creating PlgX folder
mkdir Plgx

echo Copying files
rsync -av --exclude-from='PlgxExclude.txt' QuickSearch/ PlgX/

echo Compiling Plgx
KeePass2.x/Build/KeePass/Release/KeePass.exe -plgx-create Plgx

echo Releasing PlgX
mkdir "Release"
mv Plgx.plgx "Release/QuickSearch.plgx"

echo Cleaning up
rm -rf Plgx/
