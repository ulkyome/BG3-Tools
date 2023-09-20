﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class TranslationLastOpenForm : Form
    {
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
                    listViewLastFile.Items.Add(new ListViewItem(new string[] { fileSI.Name, fileSI.CreationTime.ToString(), "999" }));
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
            LoadingForm.TranslationF.open_json($@"{TranslationForm.FolderTemp}\json\{nameFile}");
           // open_json($@"{FolderTemp}\json\{nameFile}");
        }

        private void TranslationLastOpenForm_Shown(object sender, EventArgs e)
        {
            LoadingForm.TranslationF.lastFileOpenToolStripMenuItem.Checked = true;
            lastFileFolder($@"{TranslationForm.FolderTemp}\json\");
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
            lastFileFolder($@"{TranslationForm.FolderTemp}\json\");
        }
    }
}