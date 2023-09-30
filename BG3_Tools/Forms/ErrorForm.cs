using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class ErrorForm : Form
    {
        public static ErrorForm ErrorF = new ErrorForm();
        public static string titleError = "ERROR#001";
        public static string titleDesc = "ERROR Desc";
        public static string CodeErr = "string code error app";
        public static string titleWindows = "ERROR#001";
        public static string linkApp = null;
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void bSend_Click(object sender, EventArgs e)
        {

        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ErrorForm_Shown(object sender, EventArgs e)
        {
            labelTitle.Text = titleError;
            labelDesc.Text = titleDesc;
            richTextBoxCodeErr.Text = CodeErr;
            if (linkApp == null) {
                linkLabelApp.Visible = false;
            }
            else
            {
                linkLabelApp.Text = linkApp;
            }
            this.Text = titleWindows;

            panelCode.Enabled = false;
            panelCode.Visible = false;
            this.Size = new Size(470, 150);//295
        }

        private void ErrorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static void openForm(string title, string desc,string titleWin = "Error", string code = "null", string lApp = null)
        {
            titleWindows = titleWin;

            titleError = title;
            titleDesc = desc;
            CodeErr = code;
            linkApp = lApp;
            ErrorF.Show();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (panelCode.Enabled)
            {
                panelCode.Enabled = false;
                panelCode.Visible = false;
                this.Size = new Size(470, 150);
            }
            else
            {
                panelCode.Enabled = true;
                panelCode.Visible = true;
                this.Size = new Size(470, 295);   
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
