using BG3_Tools.Models;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static string FileNameOpen = "none";
        public static MetaModel FileOpenUser = new MetaModel();
        public static Node FileOpenUser2 = new Node();

        public static BindingList<Models.Attribute> _data = new BindingList<Models.Attribute>();

        public metaEditForm()
        {
            InitializeComponent();
        }

        public void open_xml_test(string fileO)
        {
           
            dataSetMeta.ReadXml(fileO, XmlReadMode.Auto);
            //dataGridView1.DataSource = dataSetMeta.Tables[1];
            foreach (DataTable table in dataSetMeta.Tables)
            {
                MessageBox.Show(table.ToString());
                for (int i = 0; i < table.Columns.Count; ++i)
                    Console.Write("\t" + table.Columns[i].ColumnName.Substring(0, Math.Min(6, table.Columns[i].ColumnName.Length)));
                Console.WriteLine();
                foreach (var row in table.AsEnumerable())
                {
                    for (int i = 0; i < table.Columns.Count; ++i)
                    {
                        Console.Write("\t" + row[i]);
                    }
                    Console.WriteLine();
                }
            }
            dataGridView1.DataSource = dataSetMeta;
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

            XDocument doc = new XDocument(new XComment("Freshly baked localization file made with a tool from Ulkyome"));
            XElement contentList = new XElement("contentList", new XAttribute("date", "0"));
            try
            {
                List<XElement> content = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Select(row => new XElement("content", row.Cells[3].Value.ToString(), new XAttribute("contentuid", row.Cells[0].Value.ToString()), new XAttribute("version", row.Cells[1].Value.ToString()))).ToList();
                contentList.Add(content);
                doc.Add(contentList);
                doc.Save(fileSave);
                logger.Info("save xml file");
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
            MessageBox.Show("test");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                open_xml_test(openFileDialog1.FileName);
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
