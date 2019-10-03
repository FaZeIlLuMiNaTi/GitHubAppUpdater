using System.Diagnostics;
using System.Net;

namespace GitHubAppUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Variables
                string url = args[0];
                string exe = args[1];
             
                var client = new WebClient();
                client.DownloadFile(url, exe);

                ProcessStartInfo procStartInfo = new ProcessStartInfo(exe);
                Process.Start(procStartInfo); // Start the updated application
            }
        }
    }
}
