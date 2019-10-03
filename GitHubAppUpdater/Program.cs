using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace GitHubAppUpdater
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Variables
                string url = args[0];
                string exe = args[1];

                await Task.Delay(200);
             
                var client = new WebClient();
                client.DownloadFile(url, exe);

                ProcessStartInfo procStartInfo = new ProcessStartInfo(exe);
                Process.Start(procStartInfo); // Start the updated application
            }
        }
    }
}
