using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3_Tools.Models
{
    public class configModel
    {
        public ConfigPath ConfigPath { get; set; }
        public string ver { get; set; }
    }

    public class ConfigPath
    {
        public temp temp { get; set; }
        public string root { get; set; }
    }

    public class temp
    {
        public string root { get; set; }
        public string json { get; set; }
        public string xml { get; set; }
        public string update { get; set; }
    }
}
