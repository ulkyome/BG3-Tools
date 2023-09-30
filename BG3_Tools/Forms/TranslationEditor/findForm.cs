using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BG3_Tools.Forms.TranslationEditor
{
    public partial class findForm : Form
    {
        public findForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;
            int index = 0;
            
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (var row in TranslationForm._data.ToList())
                {
                    //if (row.Cells[2].Value.ToString().Contains(searchValue))
                    if (row.Text.Contains(searchValue))
                    {
                        //rowIndex = row.Contentuid;
                        //dataGridView1.Rows[row.Index].Selected = true;
                        LoadingForm.TranslationF.selectRow(index);

                        break;
                    }
                    index++;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
