using BG3_Tools.Forms;
using NLog;
using System;
using System.IO;
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
        public static Version Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public static string dataTimeN = DateTime.Now.ToString("MM/dd/yyyy_HH_mm");
        public LoadingForm()
        {
            InitializeComponent();

            verApp.Text = Version.ToString();

            MainF = new MainForm();
            Directory.CreateDirectory(@".\temp\json\");
            Directory.CreateDirectory(@".\temp\xml\");
            logger.Info("Create dir temp");
        }

        private void Loading_Shown(object sender, EventArgs e)
        {
            //Thread.Sleep(500);
            MainF.Show();

            this.Hide();

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            
        }

        private void Loading_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
