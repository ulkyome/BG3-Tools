using BG3_Tools.Forms;
using BG3_Tools.Forms.TranslationEditor;
using BG3_Tools.Helpers;
using BG3_Tools.Models;
using NLog;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace BG3_Tools
{
    public partial class LoadingForm : Form
    {
        public static TranslationForm TranslationF;
        public static MainForm MainF;
        public static genGuIDForm genGuIDF;
        public static editLineTransForm editLineT;
        public static AboutForm aboutF;
        public static PackageForm packageF;
        public static metaEditForm metaEditF;
        public static settingForm settingF;
        public static TranslationLastOpenForm TranslationLastOpenF;
        public static findForm findF;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static System.Version Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public static string dataTimeN = DateTime.Now.ToString("MM/dd/yyyy_HH_mm");

        public LoadingForm()
        {
            loadConfig.read();
            
            InitializeComponent();
            
            checkVerCl.cV();

            logger.Info($"last version github: {checkVerCl.ver}");
            logger.Debug($"last version github url: {checkVerCl.url}");
            logger.Info($"application build version: {Version}");
            verApp.Text = Version.ToString();

            MainF = new MainForm();
        }

        private void Loading_Shown(object sender, EventArgs e)
        {
            if (loadConfig.cfgApp.ver == checkVerCl.ver)
            {
                openApp();
            }
            else
            {
                bool fileExist = File.Exists($@"{loadConfig.cfgApp.ConfigPath.temp.update}{checkVerCl.ver}.zip");
                if (fileExist)
                {
                    loadConfig.cfgApp.ver = checkVerCl.ver;
                    loadConfig.save();
                    startUpdater();
                }
                else
                {
                    activeForm._data = new activeFormModel();
                    activeForm._data.title = "New Version";
                    activeForm._data.description = $"Application update released ver: {checkVerCl.ver}";
                    activeForm._data.titleWin = "Update";
                    activeForm._data.link = checkVerCl.url;
                    activeForm.ErrorF.Show();

                    startDownload();
                }
            }
        }

        public void openApp()
        {
            MainF.Show();
            this.Hide();
        }

        public void openUpdater()
        {
            loadConfig.read();
            if (loadConfig.cfgApp.ver == checkVerCl.ver)
            {
                openApp();
            }
            else
            {
                loadConfig.cfgApp.ver = checkVerCl.ver;
                loadConfig.save();
                startUpdater();
            }
        }

        public void startUpdater()
        {
            try
            {
                Thread.Sleep(2000);
                Process _process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.FileName = "updater.exe";
                startInfo.Arguments = $"{checkVerCl.ver} {loadConfig.cfgApp.ConfigPath.temp.update}";

                _process.StartInfo = startInfo;
                _process.Start();
                Thread.Sleep(2000);
                Application.Exit();
            }
            catch (Exception exc)
            {
                activeForm._data = new activeFormModel();
                activeForm._data.title = "ERROR open updater";
                activeForm._data.description = $"Problems with updater. check if it exists in the root {exc.Message}";
                activeForm._data.titleWin = "ERROR";
                activeForm._data.codeError = $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}";
                activeForm.ErrorF.Show();
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        private void startDownload()
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(checkVerCl.url), $@"{loadConfig.cfgApp.ConfigPath.temp.update}{checkVerCl.ver}.zip");
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                status.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                status.Text = "Completed";
                openUpdater();
            });
        }
    }
}
