using BG3_Tools.Forms;
using BG3_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BG3_Tools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void uIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingForm.genGuIDF = new genGuIDForm();
            LoadingForm.genGuIDF.MdiParent = this;
            LoadingForm.genGuIDF.Show();
        }

        private void aboutTheApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //test
            LoadingForm.aboutF = new AboutForm();
            LoadingForm.aboutF.MdiParent = this;
            LoadingForm.aboutF.Show();
        }

        private void translationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingForm.TranslationF = new TranslationForm();
            LoadingForm.TranslationF.MdiParent = this;
            LoadingForm.TranslationF.Show();
        }

        private void pACToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            LoadingForm.settingF = new settingForm();
            LoadingForm.settingF.MdiParent = this;
            LoadingForm.settingF.Show();
        }
    }
}
