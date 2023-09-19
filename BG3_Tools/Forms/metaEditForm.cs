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

        public metaEditForm()
        {
            InitializeComponent();
        }

        public void open_xml(string fileO)
        {
            int uIDNUl = 0;

            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MetaModel));

                using (FileStream fs = new FileStream(fileO, FileMode.OpenOrCreate))
                {
                    FileOpenUser = (MetaModel)serializer.Deserialize(fs);

                    foreach (var c in FileOpenUser.Region.Node.Children.Node[1].Attribute)
                    {
                        //listViewLastFile.Items.Add(new ListViewItem(new string[] { fileSI.Name, fileSI.CreationTime.ToString(), "999" }));
                        listView1.Items.Add(new ListViewItem(new string[] { c.Id, c.Value }));

                    }
                    //MessageBox.Show(FileOpenUser.Region.Node.Children.Node[1].Attribute[0].Value);
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
