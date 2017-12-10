```C#
public async void CheckUpdate(bool ManuallyInvoked)
{

    /***
     * 
     * Add this function to your form, and run it when the form loads.
     *
     * If you want to automatically check for updates, run CheckUpdate(false);. If the user pressed a button to check for updates, run CheckUpdate(true);.
     *
     * Configure the settings below.
     * 
     ***/

    string url = "https://github.com/FaZeIlLuMiNaTi/GTAO-PublicSessionBlocker/releases/"; // URL to GitHub releases page - (make sure you've got the ending "/" - IMPORTANT.
    string exename = "GTAO-PublicSessionBlocker.exe"; // Name of EXE file

    int NumberOfRetries = 3;
    int DelayOnRetry = 1000;

    /***
     * 
     * You shouldn't touch anything below here.
     * 
     ***/

    HtmlWeb web = new HtmlWeb();
    HtmlAgilityPack.HtmlDocument doc; // Make a timeout of 10 seconds? (not sure if this is even neccesary now)

    Assembly assembly = Assembly.GetExecutingAssembly();
    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
    Version currentVersion = new Version(fileVersionInfo.ProductVersion);


    for (int i = 0; i <= NumberOfRetries; i++)
    {
        try
        {
            doc = web.Load(url + "latest");

            Version newVersion = new Version(doc.DocumentNode.SelectNodes("//*[@id=\"js-repo-pjax-container\"]/div[2]/div[1]/div[2]/div/div[1]/ul/li[1]/a/span")[0].InnerText);
            if (currentVersion < newVersion) // Compare versions
            {
                DialogResult dialogResult = MessageBox.Show("Update available!\nCurrent version: " + currentVersion + "\nNew version: " + newVersion + "\nWould you like to update?", "Update available", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Extract and launch the updater
                    string updaterpath = Path.Combine(Path.GetTempPath(), "GitHubAppUpdater.exe");
                    File.WriteAllBytes(updaterpath, Resources.GitHubAppUpdater);


                    string arguments = url + " " + exename;
                    ProcessStartInfo ProcStartInfo = new ProcessStartInfo(updaterpath, arguments);
                    Process.Start(ProcStartInfo);
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Nothing
                }
            }
            else
            {
                // Application is up to date, no action needed
                if (ManuallyInvoked)
                {
                    MessageBox.Show("No updates available.");
                }
            }

            SetVisibleCore(true); // Show GUI

            break; // Break from for loop
        }
        catch (Exception)
        {
            if (i < NumberOfRetries)
            {
                await Task.Delay(DelayOnRetry); // Error contacting page, retry.
            }
            else
            {
                MessageBox.Show("GitHub project page not available.\nCheck your internet connection.");
                SetVisibleCore(true);
                break;
            }

        }
    }
}
```