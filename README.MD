# ![](Resources/repo.png)


[![GitHub last commit](https://img.shields.io/github/last-commit/aphadeon/BotM.svg?style=for-the-badge)](https://github.com/aphadeon/BotM/commits/master) [![Github All Releases](https://img.shields.io/github/downloads/atom/aphadeon/BotM/total.svg?style=for-the-badge)](https://github.com/aphadeon/BotM/releases) [![GitHub](https://img.shields.io/badge/license-MIT-brightgreen.svg?longCache=true&style=for-the-badge)](https://github.com/aphadeon/BotM/blob/master/LICENSE.MD) [![GitHub issues](https://img.shields.io/github/issues-raw/aphadeon/BotM.svg?style=for-the-badge)](https://github.com/aphadeon/BotM/issues)

### BotM: A BotW Mod Manager

***Important: This program currently only supports BotW 1.5.0 with all DLC for WiiU.***  
*Once goals are realized with that version, we will look to expand.*

### Version History

- Prerelease: Getting basic launcher and mod file support ready. **Not recommended for use yet, aside from testing.**

### Mod File Format (*.botm.zip)

This mod manager standardizes the distributable mod format to be consistent and manageable, as well as (eventually) 
enabling a lot of new features that would otherwise be very difficult to use.  The mod is packed into a zip file, 
which needs to end with ".botm.zip" so that both BotM and your zip application of choice can recognize the file.

#### mod.json

Inside of the zip file, you need a mod.json file which will tell BotM a bit about your modifications.  
*The spec for this file will continue to be expanded, we will try to keep this example up to date:*
```json
{
  "ModName": "MyMod",
  "ModAuthor": "MyName"
  "InstallActions": [
    {
      "Action": "Overwrite",
      "Parameters": [
        "files\\AirWall.sbactorpack",
        "update\\content\\actor\\pack\\AirWall.sbactorpack"
      ]
    }
  ]
}
```

Your mod file may contain an 64x64 png in its root directory, called *mod.png*, which BotM will treat as an icon for the mod.  
Your mod file may contain an optional *readme.txt*, which BotM will display in the mod window when your mod is selected.

#### InstallActions

InstallActions will control the installation procedure for your mod.  
Implemented *Action* types:

- Overwrite

Overwrite is pretty straightforward - and the least compatible way to implement your mod.  It simply overwrites a file in
either the game or update directory.  It takes two parameters - the first is the relative path to the source file in your mod
zip file; the second parameter is the path to the destination.  Notably, there are two shortcuts for the destination path:  
Starting your path with *update* is the same as (for example) *mlc01\usr\title\00050000\101C9400*.  
Starting your path with *game* is the same as the root game directory (the one that contains *code*, *content*, and *meta*).

