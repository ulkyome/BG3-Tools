using BG3_Tools.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BG3_Tools
{
    public partial class Loading : Form
    {
        public static Translation TranslationF;
        public static Main MainF;
        public static genGuID genGuIDF;
        public static editLineTrans editLineT;
        public static About about;
        public Loading()
        {
            InitializeComponent();
            MainF = new Main();
            Directory.CreateDirectory(@".\temp\json\");
            Directory.CreateDirectory(@".\temp\xml\");
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
