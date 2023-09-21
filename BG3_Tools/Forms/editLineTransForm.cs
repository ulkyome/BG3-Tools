using NLog;
using System;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class editLineTransForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static DataGridViewRow currentRow;
        public static string uID;
        public static string text;
        public static string textT;
        public editLineTransForm()
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
            TranslationForm._data[currentRow.Index].TextT = richTextBoxTextT.Text;
            //currentCell.Cells[0].Value 
            //currentCell.Cells[2].Value
            //currentCell.Cells[3].Value
            this.Close();
        }
    }
}
