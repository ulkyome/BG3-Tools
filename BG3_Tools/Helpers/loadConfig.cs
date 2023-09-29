using BG3_Tools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BG3_Tools.Helpers
{
    public class loadConfig
    {
        public static configModel cfgApp = new configModel();
        public static void read()
        {
            cfgApp.ver = "0.12";

            ConfigPath Cp = new ConfigPath();
            temp pathTemp = new temp();

            pathTemp.root = string.Format(@"{0}\temp\", Environment.CurrentDirectory);
            pathTemp.xml = $@"{pathTemp.root}xml\";
            pathTemp.json = $@"{pathTemp.root}json\";
            pathTemp.update = $@"{pathTemp.root}update\";
            Cp.temp = pathTemp;
            cfgApp.ConfigPath = Cp;


        }

        public static void save()
        {
            //
        }
    
    }
}
