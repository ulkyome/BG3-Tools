using BG3_Tools.Forms;
using BG3_Tools.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BG3_Tools.Helpers
{
    public class loadConfig
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static configModel cfgApp = new configModel();
        public static string ConfigFileD = $@"{Environment.CurrentDirectory}\config.cfg";
        public static void read()
        {
            try
            {
                bool fileExist = File.Exists(ConfigFileD);
                if (fileExist)
                {
                    logger.Info("Open config json file");
                    cfgApp = JsonConvert.DeserializeObject<configModel>(File.ReadAllText(ConfigFileD));
                }
                else
                {
                    logger.Error("Config file does not exist.");
                    readDefalut();
                }

                Directory.CreateDirectory(cfgApp.ConfigPath.temp.json);
                Directory.CreateDirectory(cfgApp.ConfigPath.temp.xml);
                Directory.CreateDirectory(cfgApp.ConfigPath.temp.update);
                logger.Info("Create dir temp");
            }
            catch (Exception e)
            {
                ErrorForm.openForm("ERROR OPEN JSON", $"(Markup error or invalid format) {e.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
            }
        }

        public static void readDefalut()
        {
            cfgApp.ver = "0.11";

            ConfigPath Cp = new ConfigPath();
            Cp.root = $@"{Environment.CurrentDirectory}\";
            temp pathTemp = new temp();

            pathTemp.root = $@"{Cp.root}temp\";
            pathTemp.xml = $@"{pathTemp.root}xml\";
            pathTemp.json = $@"{pathTemp.root}json\";
            pathTemp.update = $@"{pathTemp.root}update\";
            Cp.temp = pathTemp;

            cfgApp.ConfigPath = Cp;
            save();
        }

        public static void save()
        {
            try
            {
                File.WriteAllText($@"{cfgApp.ConfigPath.root}config.cfg", JsonConvert.SerializeObject(cfgApp, Formatting.Indented));
                logger.Info("save config file");
            }
            catch(Exception e)
            {
                ErrorForm.openForm("ERROR SAVE JSON", $"{e.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
            }
        }
    }
}
