using BG3_Tools.Helpers;
using BG3_Tools.Models;
using NLog;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BG3_Tools.Forms
{
    public partial class metaEditForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static string FileNameOpen = "none";
        public static MetaModel FileOpenUser = new MetaModel();

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
            catch (Exception exc)
            {
                MessageBox.Show($"ERROR OPEN XML (Markup error or invalid format) {exc.Message}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        public void save_xml(string fileSave)
        {
            FileOpenUser.Region.Node.Children.Node[1].Attribute = _data.ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MetaModel));
            try
            {
                using (FileStream fs = new FileStream(fileSave, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, FileOpenUser, ns);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = FileNameOpen;
            var dialog = saveFileDialog1.ShowDialog();
            //MessageBox.Show($" (LSLib v{Common.LibraryVersion()})");
            if (dialog == DialogResult.OK)
            {
                save_xml(saveFileDialog1.FileName);
            }
            else if (dialog == DialogResult.Cancel)
            {
                //
            }
            else
            {
                MessageBox.Show("ERROR#S_01");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxUID.Text = Generate.GuID(checkBoxIsHandle.Checked);
        }
    }
}
