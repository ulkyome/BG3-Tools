using BG3_Tools.Helpers;
using NLog;
using System;
using System.IO;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class TranslationLastOpenForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static ListViewItem data = new ListViewItem();
        public TranslationLastOpenForm()
        {
            InitializeComponent();
        }

        public void lastFileFolder(string Dir)
        {
            listViewLastFile.Items.Clear();
            DateTime dt = new DateTime(1990, 1, 1);
            string fileName = "null";

            FileSystemInfo[] fileSystemInfo = new DirectoryInfo(Dir).GetFileSystemInfos();

            foreach (FileSystemInfo fileSI in fileSystemInfo)
            {
                if (fileSI.Extension == ".json" | fileSI.Extension == ".loc")
                {
                    long length = new System.IO.FileInfo(fileSI.FullName).Length;
                    listViewLastFile.Items.Add(new ListViewItem(new string[] { fileSI.Name, fileSI.CreationTime.ToString(), length.ToString() }));
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (this.listViewLastFile.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select a file");
                return;
            }
            string nameFile = this.listViewLastFile.SelectedItems[0].Text;
            LoadingForm.TranslationF.open_json($@"{loadConfig.cfgApp.ConfigPath.temp.json}{nameFile}");
           // open_json($@"{FolderTemp}\json\{nameFile}");
        }

        private void TranslationLastOpenForm_Shown(object sender, EventArgs e)
        {
            LoadingForm.TranslationF.lastFileOpenToolStripMenuItem.Checked = true;
            lastFileFolder(loadConfig.cfgApp.ConfigPath.temp.json);
            this.Focus();
        }

        private void TranslationLastOpenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                LoadingForm.TranslationF.lastFileOpenToolStripMenuItem.Checked = false;
            }
        }

        private void TranslationLastOpenForm_Load(object sender, EventArgs e)
        {
           
        }

        private void TranslationLastOpenForm_VisibleChanged(object sender, EventArgs e)
        {
            
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            lastFileFolder(loadConfig.cfgApp.ConfigPath.temp.json);
        }
    }
}
