using BG3_Tools.Forms;
using NLog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BG3_Tools
{
    public partial class MainForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MainForm()
        {
            InitializeComponent();
            this.Text = $"{this.Text} - build ver: {LoadingForm.Version}";
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void uIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(f => f.Name == "genGuIDForm")) return;

            LoadingForm.genGuIDF = new genGuIDForm();
            LoadingForm.genGuIDF.MdiParent = this;
            LoadingForm.genGuIDF.Show();
        }

        private void aboutTheApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(f => f.Name == "AboutForm")) return;
            LoadingForm.aboutF = new AboutForm();
            LoadingForm.aboutF.MdiParent = this;
            LoadingForm.aboutF.Show();
        }

        private void translationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingForm.TranslationF = new TranslationForm();
            LoadingForm.TranslationF.MdiParent = this;
            LoadingForm.TranslationF.Show();

            LoadingForm.TranslationLastOpenF = new TranslationLastOpenForm();
            LoadingForm.TranslationLastOpenF.MdiParent = this;
            LoadingForm.TranslationLastOpenF.Show();
            LoadingForm.TranslationLastOpenF.Focus();
        }

        private void pACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(f => f.Name == "PackageForm")) return;

            LoadingForm.packageF = new PackageForm();
            LoadingForm.packageF.MdiParent = this;
            LoadingForm.packageF.Show();
        }

        private void metaEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingForm.metaEditF = new metaEditForm();
            LoadingForm.metaEditF.MdiParent = this;
            LoadingForm.metaEditF.Show();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(f => f.Name == "settingForm")) return;

            LoadingForm.settingF = new settingForm();
            LoadingForm.settingF.MdiParent = this;
            LoadingForm.settingF.Show();
        }
    }
}
