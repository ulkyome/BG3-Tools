using BG3_Tools.Forms;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void uIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loading.genGuIDF = new genGuID();
            Loading.genGuIDF.MdiParent = this;
            Loading.genGuIDF.Show();
        }

        private void aboutTheApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //test
            Loading.about = new About();
            Loading.about.MdiParent = this;
            Loading.about.Show();
        }

        private void translationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loading.TranslationF = new Translation();
            Loading.TranslationF.MdiParent = this;
            Loading.TranslationF.Show();
        }

        private void pACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon");
        }

        private void metaEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon");
        }
    }
}
