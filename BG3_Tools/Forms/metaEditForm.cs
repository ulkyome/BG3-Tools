using BG3_Tools.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

namespace BG3_Tools.Forms
{
    public partial class metaEditForm : Form
    {
        public static string FileNameOpen = "none";
        public static MetaModel FileOpenUser = new MetaModel();
        public static Node FileOpenUser2 = new Node();

        public static BindingList<Models.Attribute> _data = new BindingList<Models.Attribute>();

        public metaEditForm()
        {
            InitializeComponent();
        }


        public void open_xml(string fileO)
        {


            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MetaModel));

                using (FileStream fs = new FileStream(fileO, FileMode.OpenOrCreate))
                {
                    FileOpenUser = (MetaModel)serializer.Deserialize(fs);

                    _data = new BindingList<Models.Attribute>(FileOpenUser.Region.Node.Children.Node[1].Attribute);
                    dataGridView1.DataSource = _data;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR OPEN XML (Markup error or invalid format) {e.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
               open_xml(openFileDialog1.FileName);
            }
            else if (dialog == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MessageBox.Show("ERROR#O_01");
            }
        }

       
    }
}
