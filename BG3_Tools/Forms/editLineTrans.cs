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
    public partial class editLineTrans : Form
    {
        public static DataGridViewRow currentRow;
        public static string uID;
        public static string text;
        public static string textT;
        public editLineTrans()
        {
            InitializeComponent();
            this.Text = uID;
            textBoxUID.Text = uID;
            richTextBoxText.Text = text;
            richTextBoxTextT.Text = textT;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Translation._data[currentRow.Index].Contentuid = textBoxUID.Text;
            //Translation._data[currentRow.Index].Text = richTextBoxText.Text;
            Translation._data[currentRow.Index].TextT = richTextBoxTextT.Text;
            //currentCell.Cells[0].Value 
            //currentCell.Cells[2].Value
            //currentCell.Cells[3].Value
            this.Close();
        }
    }
}
