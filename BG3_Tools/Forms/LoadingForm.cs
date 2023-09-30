using BG3_Tools.Forms;
using BG3_Tools.Helpers;
using BG3_Tools.Models;
using NLog;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;

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
                startDownload();
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

            ErrorForm.openForm("testTitle",$"donload new version app","ERROR","", checkVerCl.url);

            //
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
