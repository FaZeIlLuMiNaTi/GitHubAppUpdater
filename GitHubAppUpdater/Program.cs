using HtmlAgilityPack;
using System;
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
                


                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url + "latest");

                Version newVersion = new Version(doc.DocumentNode.SelectNodes("//*[@id=\"js-repo-pjax-container\"]/div[2]/div[1]/div[2]/div/div[1]/ul/li[1]/a/span")[0].InnerText);

                var client = new WebClient();
                client.DownloadFile(url + "download/" + newVersion + "/" + exe, exe);

                ProcessStartInfo procStartInfo = new ProcessStartInfo(exe);
                Process.Start(procStartInfo); // Start the updated application

            }

           
        }
    }
}
