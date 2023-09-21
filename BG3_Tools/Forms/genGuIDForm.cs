using BG3_Tools.Helpers;
using NLog;
using System;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class genGuIDForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public genGuIDForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBoxUID.Text = Generate.GuID(checkBoxIsHandle.Checked);

            listBoxHistory.Items.Add(textBoxUID.Text);
        }

        private void listBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxUID.Text = listBoxHistory.SelectedItem.ToString();
        }
    }
}
