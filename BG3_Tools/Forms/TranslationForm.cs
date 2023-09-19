using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using BG3_Tools.Models;
using BG3_Tools.Helpers;
using System.Drawing;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.RegularExpressions;
using BG3_Tools.Forms;
using LSLib.LS;
using LSLib.LS.Enums;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace BG3_Tools
{
    public partial class TranslationForm : Form
    {
        public TranslationForm()
        {
            InitializeComponent();
        }

        public static string FolderTemp = string.Format(@"{0}\temp\", Environment.CurrentDirectory);
        public static string dataTimeN = DateTime.Now.ToString("MM/dd/yyyy_HH_mm");
        public static string FileNameOpen = "none";

        public static ContentList FileOpenUser = new ContentList();
        public static ContentList FileOpenSoft = new ContentList();

        public static BindingList<Content> _data = new BindingList<Content>();

        //public static ContentList data = new ContentList();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (panelLastOpen.Visible)
            {
                lastFileOpenToolStripMenuItem.Checked = true;
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = _data;

            dataGridView1.Columns["Contentuid"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Contentuid"].FillWeight = 20;
            dataGridView1.Columns["Contentuid"].MinimumWidth = 32;
            dataGridView1.Columns["Contentuid"].Width = 232;
            dataGridView1.Columns["Contentuid"].ReadOnly = true;
            dataGridView1.Columns["Contentuid"].Resizable = DataGridViewTriState.True;
            dataGridView1.Columns["Contentuid"].HeaderText = "uID";

            dataGridView1.Columns["Version"].Visible = false;

            dataGridView1.Columns["Text"].HeaderText = "text";
            dataGridView1.Columns["Text"].FillWeight = 300;
            dataGridView1.Columns["Text"].MinimumWidth = 20;
            dataGridView1.Columns["Text"].Width = 358;

            dataGridView1.Columns["TextT"].HeaderText = "Text Translate";
            dataGridView1.Columns["TextT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["TextT"].FillWeight = 365;
            dataGridView1.Columns["TextT"].MinimumWidth = 365;


           /* DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "completed";
            checkColumn.HeaderText = "completed";
            checkColumn.FalseValue = "false";
            checkColumn.IndeterminateValue = "false";
            checkColumn.TrueValue = "true";
            checkColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            checkColumn.FillWeight = 12;
            checkColumn.MinimumWidth = 22;
            checkColumn.Width = 60;

            dataGridView1.Columns.Add(checkColumn);
           */
            tBoxUID.Text = Generate.GuID(false);

            lastFileFolder($@"{FolderTemp}\json\");
        }

        public void open_json(string fileO)
        {
            _data.Clear();
            Match m = Regex.Match(Path.GetFileNameWithoutExtension(fileO), @"(.*)_temporary_(.*)", RegexOptions.Multiline);
            FileNameOpen = m.Groups[2].Value;

            try
            {
                _data = JsonConvert.DeserializeObject<BindingList<Content>>(File.ReadAllText(fileO));
                dataGridView1.DataSource = _data;
                this.Text = $"{FileNameOpen} | rows {_data.Count}";

                panelLastOpen.Visible = false;
                lastFileOpenToolStripMenuItem.Checked = false;
                indexTableAdd();
                findDuplicate_uID();
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR OPEN JSON (Markup error or invalid format) {e.Message}");
            }
        }
        public void open_xml(string fileO)
        {
            panelLastOpen.Visible = false;
            lastFileOpenToolStripMenuItem.Checked = false;

            int uIDNUl = 0;

            _data.Clear();

            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream(fileO, FileMode.OpenOrCreate))
                {
                    FileOpenUser = (ContentList)serializer.Deserialize(fs);

                    foreach (var c in FileOpenUser.Content.ToList())
                    {
                        c.TextT = c.Text; //добавляем в строку translate тот же оригинальный текст

                        if (c.Contentuid == "")
                        {
                            uIDNUl++;
                            FileOpenUser.Content.Remove(c); //чистим строки с пустыми Contentuid
                        }
                    }

                    if( uIDNUl > 0) {
                        MessageBox.Show($"deletet null rows {uIDNUl} !");
                    }

                    this.Text = $"{FileNameOpen} | rows {FileOpenUser.Content.Count}";
                    _data = new BindingList<Content>(FileOpenUser.Content);
                    dataGridView1.DataSource = _data;

                    indexTableAdd();
                    findDuplicate_uID();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR OPEN XML (Markup error or invalid format) {e.Message}");
            }
        }

        public void indexTableAdd()
        {
            int index = 0;
            foreach (var test in _data)
            {
                dataGridView1.Rows[index].HeaderCell.Value = index.ToString();
                index++;
            }
        }

        public void findDuplicate_uID()
        {
            Dictionary<string, int> freqMap = _data.GroupBy(x => x.Contentuid).Where(g => g.Count() > 1).ToDictionary(x => x.Key, x => x.Count());

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (var test in freqMap)
                {
                    //Console.WriteLine($"key: {test.Key}  value: {test.Value}");
                    if (row.Cells[0].Value.ToString().Equals(test.Key))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        row.Cells[0].ErrorText = "Duplicate uID";

                        break;
                    }

                }


            }
            findNull_row();
        }

        public void findNull_row()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells[0].Value.ToString().Equals(""))
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.Cells[0].ErrorText = "null uID";

                    break;
                }
                else if(row.Cells[0].Value == null)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.Cells[0].ErrorText = "null uID";

                    break;
                }
                else if (row.Cells[2].Value == null)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.Cells[2].ErrorText = "null text";

                    break;
                }
                else if (row.Cells[2].Value.ToString().Equals(""))
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.Cells[2].ErrorText = "null text";

                    break;
                }
                else if (row.Cells[3].Value == null)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.Cells[3].ErrorText = "null textT";

                    break;
                }
                else if (row.Cells[3].Value.ToString().Equals(""))
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    row.Cells[3].ErrorText = "null textT";

                    break;
                }
            }
        }

        public void open_loca(string fileO)
        {
            panelLastOpen.Visible = false;
            lastFileOpenToolStripMenuItem.Checked = false;

            int uIDNUl = 0;

            _data.Clear();

            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);

            try
            {
                var resource = LocaUtils.Load(fileO);
                var format = LocaUtils.ExtensionToFileFormat($@"{FolderTemp}\xml\{FileNameOpen}.xml");
                LocaUtils.Save(resource, $@"{FolderTemp}\xml\{FileNameOpen}.xml", format);

                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream($@"{FolderTemp}\xml\{FileNameOpen}.xml", FileMode.OpenOrCreate))
                {
                    FileOpenUser = (ContentList)serializer.Deserialize(fs);

                    foreach (var c in FileOpenUser.Content.ToList())
                    {
                        c.TextT = c.Text;

                        if (c.Contentuid == "")
                        {
                            uIDNUl++;
                            FileOpenUser.Content.Remove(c);
                        }
                    }

                    if (uIDNUl > 0)
                    {
                        MessageBox.Show($"deletet null rows {uIDNUl} !");
                    }
                    //MessageBox.Show($"add rows {FileOpenUser.Content.Count}");
                    this.Text = $"{FileNameOpen} | rows {FileOpenUser.Content.Count}";
                    _data = new BindingList<Content>(FileOpenUser.Content);
                    dataGridView1.DataSource = _data;

                    indexTableAdd();

                    findDuplicate_uID();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "Conversion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void open_xmlMatch(string file)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    FileOpenSoft = (ContentList)serializer.Deserialize(fs);
                    int count = dataGridView1.Rows.Count;
                    foreach (var c in FileOpenSoft.Content)
                    {
                        bool isnew = true;
                        for (int i = 0; i < count; i++)
                        {
                            var val = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            if (val == c.Contentuid)
                            {
                                dataGridView1.Rows[i].Cells[3].Value = c.Text;
                                isnew = false;
                            } 
                        }
                        if (isnew)
                            _data.Add(new Content { Contentuid = c.Contentuid, Version = c.Version, Text = c.Text, TextT = c.Text });
                    }
                    indexTableAdd();
                    findDuplicate_uID();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR OPEN FILE (Markup error or invalid format)");
            }
        }

        public void open_locaMatch(string file)
        {
            FileNameOpen = Path.GetFileNameWithoutExtension(file);

            try
            {
                var resource = LocaUtils.Load(file);
                var format = LocaUtils.ExtensionToFileFormat($@"{FolderTemp}\xml\{FileNameOpen}.xml");
                LocaUtils.Save(resource, $@"{FolderTemp}\xml\{FileNameOpen}.xml", format);

                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream($@"{FolderTemp}\xml\{FileNameOpen}.xml", FileMode.OpenOrCreate))
                {
                    FileOpenSoft = (ContentList)serializer.Deserialize(fs);
                    int count = dataGridView1.Rows.Count;
                    foreach (var c in FileOpenSoft.Content)
                    {
                        bool isnew = true;
                        for (int i = 0; i < count; i++)
                        {
                            var val = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            if (val == c.Contentuid)
                            {
                                dataGridView1.Rows[i].Cells[3].Value = c.Text;
                                isnew = false;
                            }
                        }
                        if (isnew)
                            _data.Add(new Content { Contentuid = c.Contentuid, Version = c.Version, Text = c.Text, TextT = c.Text });
                    }
                    indexTableAdd();
                    findDuplicate_uID();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "Conversion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void lastFileFolder(string Dir)
        {
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

        public void saveTempJson()
        {
            string json = JsonConvert.SerializeObject(_data, Formatting.Indented);

            File.WriteAllText(string.Format(@".\temp\json\{0}_temporary_{1}.json", dataTimeN, FileNameOpen), json);
        }

        public void save_xml(string fileSave)
        {
            
            XDocument doc = new XDocument(new XComment("Freshly baked localization file made with a tool from Ulkyome"));
            XElement contentList = new XElement("contentList", new XAttribute("date", dataTimeN));
            try
            {
                List<XElement> content = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Select(row => new XElement("content", row.Cells[3].Value.ToString(), new XAttribute("contentuid", row.Cells[0].Value.ToString()), new XAttribute("version", row.Cells[1].Value.ToString()))).ToList();
                contentList.Add(content);
                doc.Add(contentList);
                doc.Save(fileSave);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void save_loca(string fileSave)
        {
            try
            {
                XDocument doc = new XDocument(new XComment("Freshly baked localization file made with a tool from Ulkyome"));
                XElement contentList = new XElement("contentList", new XAttribute("date", dataTimeN));
                try
                {
                    List<XElement> content = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Select(row => new XElement("content", row.Cells[3].Value.ToString(), new XAttribute("contentuid", row.Cells[0].Value.ToString()), new XAttribute("version", row.Cells[1].Value.ToString()))).ToList();
                    contentList.Add(content);
                    doc.Add(contentList);
                    doc.Save($@"{FolderTemp}\xml\{FileNameOpen}.xml");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                var resource = LocaUtils.Load($@"{FolderTemp}\xml\{FileNameOpen}.xml");
                var format = LocaUtils.ExtensionToFileFormat(fileSave);
                LocaUtils.Save(resource, fileSave, format);

            }
            catch (Exception exc)
            {
                MessageBox.Show($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "Conversion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        open_xml(openFileDialog1.FileName);
                        break;
                    case 2:
                        open_loca(openFileDialog1.FileName);
                        break;
                    default:
                        MessageBox.Show("ERROR FORMAT");
                        break;
                }
            }
            else if (dialog == DialogResult.Cancel)
            {
                //
            }
            else
            {
                MessageBox.Show("ERROR#O_01");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = FileNameOpen;
            var dialog = saveFileDialog1.ShowDialog();
            //MessageBox.Show($" (LSLib v{Common.LibraryVersion()})");
            if (dialog == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                            save_xml(saveFileDialog1.FileName);
                        break;
                    case 2:
                            save_loca(saveFileDialog1.FileName);
                        break;
                    default:
                            MessageBox.Show("ERROR FORMAT SAVE");
                        break;
                }

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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == null)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                dataGridView1.Rows[e.RowIndex].Cells[2].ErrorText = "null value";
            }
            else if(dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                dataGridView1.Rows[e.RowIndex].Cells[3].ErrorText = "null value";
            }
            else if(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[e.RowIndex].Cells[2].ErrorText = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].ErrorText = "";
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[2].ErrorText = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].ErrorText = "";
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;

                if (autoSaveToolStripMenuItem.Checked)
                {
                    saveTempJson();
                }

                findDuplicate_uID();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _data.Add(new Content { Contentuid = tBoxUID.Text, Version = Convert.ToInt32(tBoxVer.Text), Text = tBoxText.Text, TextT = tBoxText.Text });
            indexTableAdd();
            findDuplicate_uID();
            if (autoSaveToolStripMenuItem.Checked)
            {
                saveTempJson();
            }
            tBoxUID.Text = Generate.GuID(false);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        open_xmlMatch(openFileDialog1.FileName);
                        break;
                    case 2:
                        open_locaMatch(openFileDialog1.FileName);
                        break;
                    default:
                        MessageBox.Show("ERROR FORMAT SAVE");
                        break;
                }
            }
            else if (dialog == DialogResult.Cancel)
            {
                //
            }
            else
            {
                MessageBox.Show("ERROR#O_01");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex < dataGridView1.ColumnCount && e.RowIndex < dataGridView1.RowCount)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }

                dataGridView1.Rows[e.RowIndex].Selected = true;
                Rectangle r = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                contextMenuStrip1.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
            }
        }

        private void Translation_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Close windows?", "Close?", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _data.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelAddLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panelAddLineToolStripMenuItem.Checked) {
                panelAddLineTool.Visible = true;
                panelAddLineToolStripMenuItem.Checked = true;
            }
            else
            {
                panelAddLineTool.Visible = false;
                panelAddLineToolStripMenuItem.Checked = false;
            }
        }

        private void autoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoSaveToolStripMenuItem.Checked)
            {

                autoSaveToolStripMenuItem.Checked = false;
            }
            else
            {
                autoSaveToolStripMenuItem.Checked = true;
            }
        }

        private void lastFileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastFileOpenToolStripMenuItem.Checked)
            {
                panelLastOpen.Visible = false;
                lastFileOpenToolStripMenuItem.Checked = false;
            }
            else
            {
                panelLastOpen.Visible = true;
                lastFileOpenToolStripMenuItem.Checked = true;
            }
        }

        private void listViewLastFile_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (this.listViewLastFile.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select a file");
                return;
            }
            string nameFile = this.listViewLastFile.SelectedItems[0].Text;

            open_json($@"{FolderTemp}\json\{nameFile}");
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.Rows[0].HeaderCell.Value = 1;
            dataGridView1.Rows[e.RowIndex].HeaderCell.Value = 1;
            //MessageBox.Show(_data.Count.ToString());
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //MessageBox.Show("test");
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Добавить удалить строку
        }

        private void openRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = this.dataGridView1.CurrentRow;

            editLineTransForm.uID = currentRow.Cells[0].Value.ToString();
            editLineTransForm.text = currentRow.Cells[2].Value.ToString();
            editLineTransForm.textT = currentRow.Cells[3].Value.ToString();
            editLineTransForm.currentRow = currentRow;
            //добавить открыть 
            LoadingForm.editLineT = new editLineTransForm();
            LoadingForm.editLineT.MdiParent = LoadingForm.MainF;
            LoadingForm.editLineT.Show();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
