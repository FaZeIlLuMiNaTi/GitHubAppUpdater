# GitHubAppUpdater
GitHubAppUpdater will download the latest version of your application from the GitHub website.

How to use:
* Download the latest release from the [releases](https://github.com/FaZeIlLuMiNaTi/GitHubAppUpdater/releases/latest) section.
* Bundle the ```GitHubAppUpdater.exe``` file in your main application's resources.
* Add [this function](https://github.com/FaZeIlLuMiNaTi/GitHubAppUpdater/blob/master/UPDATEFUNC.md) to your application (read through it to understand it)
* Make sure you're setting your GitHub release version number to be the same as ```[assembly: AssemblyFileVersion("x.x.x.x")]``` in ```AssemblyInfo.cs```.

### A working implementation of this can be seen at [GTAO-PublicSessionBlocker](https://github.com/FaZeIlLuMiNaTi/GTAO-PublicSessionBlocker).

## Issues
If theres anything I've missed, just create an issue and let me know. I'll help you.