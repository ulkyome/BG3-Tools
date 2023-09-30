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
using LSLib.LS;
using NLog;
using BG3_Tools.Forms.TranslationEditor;

namespace BG3_Tools.Forms
{
    public partial class TranslationForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public TranslationForm()
        {
            InitializeComponent();
        }

        public static string FileNameOpen = "none";

        public static ContentList FileOpenUser = new ContentList();
        public static ContentList FileOpenSoft = new ContentList();

        public static BindingList<Content> _data = new BindingList<Content>();

        //public static ContentList data = new ContentList();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            tBoxUID.Text = Generate.GuID(false);
        }

        public void open_json(string fileO)
        {
            _data.Clear();
            Match m = Regex.Match(Path.GetFileNameWithoutExtension(fileO), @"(.*)_temporary_(.*)", RegexOptions.Multiline);
            FileNameOpen = m.Groups[2].Value;

            try
            {
                logger.Info("Open json file");
                _data = JsonConvert.DeserializeObject<BindingList<Content>>(File.ReadAllText(fileO));
                dataGridView1.DataSource = _data;
                this.Text = $"{FileNameOpen} | rows {_data.Count}";

                //panelLastOpen.Visible = false;
                lastFileOpenToolStripMenuItem.Checked = false;
                indexTableAdd();
                findDuplicate_uID();
            }
            catch (Exception e)
            {
                ErrorForm.openForm("ERROR OPEN JSON", $"(Markup error or invalid format) {e.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
            }
        }

        public void open_xml_test(string fileO)
        {
            dataSet1.ReadXml(fileO);
            dataGridView1.DataSource = dataSet1.Tables[1];
            foreach (DataTable table in dataSet1.Tables)
            {
                Console.WriteLine(table);
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
        }

        public void open_xml(string fileO)
        {
            
            //panelLastOpen.Visible = false;
            lastFileOpenToolStripMenuItem.Checked = false;

            int uIDNUl = 0;
            int textNUl = 0;
            _data.Clear();

            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream(fileO, FileMode.OpenOrCreate))
                {
                    logger.Info("Open xml file");
                    FileOpenUser = (ContentList)serializer.Deserialize(fs);

                    foreach (var c in FileOpenUser.Content.ToList())
                    {
                        if (c.Text == null)
                        {
                            textNUl++;
                            FileOpenUser.Content.Remove(c);
                        }
                        else
                        {

                            if (c.Contentuid == "")
                            {
                                uIDNUl++;
                                FileOpenUser.Content.Remove(c); //чистим строки с пустыми Contentuid
                            }

                            c.TextT = c.Text; //добавляем в строку translate тот же оригинальный текст
                        }
                    }

                    if (uIDNUl > 0)
                    {
                        MessageBox.Show($"deletet null rows {uIDNUl} !");
                        logger.Info($"deletet null rows {uIDNUl}");
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
                ErrorForm.openForm("ERROR OPEN XML", $"(Markup error or invalid format) {e.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
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
            logger.Info($"index header cell add {index}");
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
            logger.Info("market duplicate uID cells");
            findNull_row();
        }

        public void findNull_row()
        {
            logger.Info("find null rows");
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
            //panelLastOpen.Visible = false;
            lastFileOpenToolStripMenuItem.Checked = false;

            int uIDNUl = 0;
            int textNUl = 0;

            _data.Clear();

            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);

            try
            {
                var resource = LocaUtils.Load(fileO);
                var format = LocaUtils.ExtensionToFileFormat($@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml");
                LocaUtils.Save(resource, $@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml", format);

                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream($@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml", FileMode.OpenOrCreate))
                {
                    logger.Info("Open loca file");
                    FileOpenUser = (ContentList)serializer.Deserialize(fs);

                    foreach (var c in FileOpenUser.Content.ToList())
                    {
                        if (c.Text == null)
                        {
                            textNUl++;
                            FileOpenUser.Content.Remove(c);
                        }
                        else
                        {

                            if (c.Contentuid == "")
                            {
                                uIDNUl++;
                                FileOpenUser.Content.Remove(c); //чистим строки с пустыми Contentuid
                            }

                            c.TextT = c.Text; //добавляем в строку translate тот же оригинальный текст
                        }
                    }

                    if (uIDNUl > 0)
                    {
                        MessageBox.Show($"deletet null rows {uIDNUl} !");
                        logger.Info($"deletet null rows {uIDNUl}");
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
                //MessageBox.Show($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "Conversion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorForm.openForm("ERROR OPEN loca", $"(Markup error or invalid format) {exc.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        public void open_xmlMatch(string file)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    logger.Info("Open xml match file");
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
                ErrorForm.openForm("ERROR OPEN XML", $"(Markup error or invalid format) {e.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
            }
        }

        public void open_locaMatch(string file)
        {
            FileNameOpen = Path.GetFileNameWithoutExtension(file);

            try
            {
                var resource = LocaUtils.Load(file);
                var format = LocaUtils.ExtensionToFileFormat($@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml");
                LocaUtils.Save(resource, $@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml", format);

                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

                using (FileStream fs = new FileStream($@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml", FileMode.OpenOrCreate))
                {
                    logger.Info("Open loca match file");
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
                ErrorForm.openForm("ERROR OPEN XML", $"(Markup error or invalid format) {exc.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        /*public void lastFileFolder(string Dir)
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
        }*/

        public void saveTempJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_data, Formatting.Indented);
              
                File.WriteAllText($@"{loadConfig.cfgApp.ConfigPath.temp.json}{LoadingForm.dataTimeN}_temporary_{FileNameOpen}.json", json);
                logger.Info("save json file");
            }
            catch(Exception exc)
            {
                ErrorForm.openForm("ERROR Save json", $" {exc.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        public void save_xml(string fileSave)
        {
            
            XDocument doc = new XDocument(new XComment("Freshly baked localization file made with a tool from Ulkyome"));
            XElement contentList = new XElement("contentList", new XAttribute("date", LoadingForm.dataTimeN));
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
                ErrorForm.openForm("ERROR SAVE XML", $" {exc.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
            }
        }

        public void save_loca(string fileSave)
        {
            try
            {
                XDocument doc = new XDocument(new XComment("Freshly baked localization file made with a tool from Ulkyome"));
                XElement contentList = new XElement("contentList", new XAttribute("date", LoadingForm.dataTimeN));
                try
                {
                    List<XElement> content = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Select(row => new XElement("content", row.Cells[3].Value.ToString(), new XAttribute("contentuid", row.Cells[0].Value.ToString()), new XAttribute("version", row.Cells[1].Value.ToString()))).ToList();
                    contentList.Add(content);
                    doc.Add(contentList);
                    doc.Save($@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml");
                    logger.Info("save temp xml file");
                }
                catch (Exception e)
                {
                    ErrorForm.openForm("ERROR save loca", $" {e.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
                    logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{e}");
                }

                var resource = LocaUtils.Load($@"{loadConfig.cfgApp.ConfigPath.temp.xml}{FileNameOpen}.xml");
                var format = LocaUtils.ExtensionToFileFormat(fileSave);
                LocaUtils.Save(resource, fileSave, format);
                logger.Info("save loca file");

            }
            catch (Exception exc)
            {
                ErrorForm.openForm("ERROR save loca", $" {exc.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
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
                        logger.Error($"Error format file select user");
                        break;
                }
            }
            else if (dialog == DialogResult.Cancel)
            {
                //
            }
            else
            {
                ErrorForm.openForm("ERROR dialog", $"ERR switch format", "ERROR", "NULL");
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
                            ErrorForm.openForm("ERROR SAVE FORMAT", $"error selected format", "ERROR", "NULL");
                            logger.Error($"Error format save file select user");
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
                ErrorForm.openForm("ERROR SAVE DIALOG", $"error dialog");
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                    dataGridView1.Rows[e.RowIndex].Cells[2].ErrorText = "null value";
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                    dataGridView1.Rows[e.RowIndex].Cells[3].ErrorText = "null value";
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
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
            catch(Exception exc) 
            {
                //MessageBox.Show($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "cell err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorForm.openForm("ERROR", $"Internal error {exc.Message}", "ERROR", $"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
                logger.Error($"Internal error!{Environment.NewLine}{Environment.NewLine}{exc}");
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
                        ErrorForm.openForm("ERROR", $"error format save");
                        logger.Error($"Error format save file select user");
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
                ErrorForm.openForm("ERROR open dialog", "error 01");
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
                //panelLastOpen.Visible = false;
                LoadingForm.TranslationLastOpenF.Hide();
                lastFileOpenToolStripMenuItem.Checked = false;
            }
            else
            {
               LoadingForm.TranslationLastOpenF.Show();
               lastFileOpenToolStripMenuItem.Checked = true;
            }
        }

        private void listViewLastFile_SelectedIndexChanged(object sender, EventArgs e)
        {
         
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
            if (this.MdiChildren.Any(f => f.Name == "findForm")) return;
            LoadingForm.findF = new findForm();
            LoadingForm.findF.MdiParent = LoadingForm.MainF;
            LoadingForm.findF.Show();
        }

        private void lastFileOpenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (lastFileOpenToolStripMenuItem.Checked)
            {
                LoadingForm.TranslationLastOpenF.Show();

            }
            else
            {
                LoadingForm.TranslationLastOpenF.Hide();
            }
        }

        public void selectRow(int index)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Rows[index].Selected = true;
        }
    }
}
