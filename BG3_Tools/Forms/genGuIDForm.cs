using BG3_Tools.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BG3_Tools.Forms
{
    public partial class genGuIDForm : Form
    {
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
