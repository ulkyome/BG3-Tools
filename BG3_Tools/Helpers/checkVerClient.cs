using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BG3_Tools.Helpers
{
    internal class checkVerCl
    {
        public static string ver { get; set; }
        public static string url { get; set; }

        public static void cV()
        {
            var client = new GitHubClient(new ProductHeaderValue("BG3-Tools"));
            var latest = client.Repository.Release.GetAll("ulkyome", "BG3-Tools").Result[0];

            ver = latest.TagName;
            url = latest.Assets[0].BrowserDownloadUrl;
        }
    }
}
