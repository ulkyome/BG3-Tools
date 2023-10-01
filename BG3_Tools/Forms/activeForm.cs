using BG3_Tools.Models;
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
    public partial class activeForm : Form
    {
        public static activeForm ErrorF = new activeForm();
        public static activeFormModel _data;
        public activeForm()
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
            labelTitle.Text = _data.title;
            labelDesc.Text = _data.description;

            if (_data.codeError == null)
            {
                buttonShow.Visible = false;
            }
            else
            {
                richTextBoxCodeErr.Text = _data.codeError;
            }
            

            if (_data.link == null) {
                linkLabelApp.Visible = false;
            }
            else
            {
                linkLabelApp.Text = _data.link;
            }

            this.Text = _data.titleWin;

            panelCode.Enabled = false;
            panelCode.Visible = false;
            this.Size = new Size(470, 150);//295
        }

        private void ErrorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static void openForm(activeFormModel data)
        {
            _data = data;
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

        private void linkLabelApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(_data.link);
            Application.Exit();
        }
    }
}
