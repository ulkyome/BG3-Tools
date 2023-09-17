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
using static System.Net.WebRequestMethods;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BG3_Tools
{
    public partial class Translation : Form
    {
        public Translation()
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
            


            dataGridView1.DataSource = _data;
            dataGridView1.Columns["index"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["index"].FillWeight = 20;
            dataGridView1.Columns["index"].MinimumWidth = 36;
            dataGridView1.Columns["index"].Width = 36;
            dataGridView1.Columns["index"].ReadOnly = true;
            dataGridView1.Columns["index"].Resizable = DataGridViewTriState.True;
            dataGridView1.Columns["index"].HeaderText = "index";

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


            //open_xml(string.Format("{0}{1}", FolderTemp, lastFileFolder(FolderTemp)));
            //listViewLastFile = lastFileFolder(FolderTemp);
            lastFileFolder(FolderTemp);
        }

        public void open_json(string fileO)
        {
            _data.Clear();

            string pattern = @"(.*)_temporary_(.*)";

            RegexOptions options = RegexOptions.Multiline;

            Match m = Regex.Match(Path.GetFileNameWithoutExtension(fileO), pattern, options);


            FileNameOpen = m.Groups[2].Value;

            


            try
            {
                _data.Clear();
                var json = System.IO.File.ReadAllText(fileO);
                _data = JsonConvert.DeserializeObject<BindingList<Content>>(json);
                dataGridView1.DataSource = _data;

                this.Text = $"{FileNameOpen} | rows {_data.Count}";

                panelLastOpen.Visible = false;
                lastFileOpenToolStripMenuItem.Checked = false;

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

            _data.Clear();

            FileNameOpen = Path.GetFileNameWithoutExtension(fileO);
            try
            {
                int uIDNUl = 0;
                int index = 0;
                XmlSerializer serializer = new XmlSerializer(typeof(ContentList));


                using (FileStream fs = new FileStream(fileO, FileMode.OpenOrCreate))
                {
                    FileOpenUser = (ContentList)serializer.Deserialize(fs);

                    foreach (var c in FileOpenUser.Content.ToList())
                    {
                        c.index = index;
                        c.TextT = c.Text;

                        if (c.Contentuid == "")
                        {
                            uIDNUl++;
                            FileOpenUser.Content.Remove(c);
                        }

                        index++;
                    }

                    if( uIDNUl > 0) {
                        MessageBox.Show($"deletet null rows {uIDNUl} !");
                    }
                   
                    //MessageBox.Show($"add rows {FileOpenUser.Content.Count}");
                    this.Text = $"{FileNameOpen} | rows {FileOpenUser.Content.Count}";
                    _data = new BindingList<Content>(FileOpenUser.Content);
                    dataGridView1.DataSource = _data;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR OPEN XML (Markup error or invalid format) {e.Message}");
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
                            dataGridView1.Rows.Add(c.Contentuid, c.Version, c.Text, "test");

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR OPEN XML (Markup error or invalid format)");
            }
        }

        public void lastFileFolder(string Dir)
        {


            //Directory.CreateDirectory(@".\temp\");
            DateTime dt = new DateTime(1990, 1, 1);
            string fileName = "null";
            
            FileSystemInfo[] fileSystemInfo = new DirectoryInfo(Dir).GetFileSystemInfos();

            foreach (FileSystemInfo fileSI in fileSystemInfo)
            {
                if (fileSI.Extension == ".json" | fileSI.Extension == ".loc")
                {
         
                    listViewLastFile.Items.Add(new ListViewItem(new string[] { fileSI.Name, fileSI.CreationTime.ToString(), "999" }));
                    /*
                    if (dt < Convert.ToDateTime(fileSI.CreationTime))
                    {
                        dt = Convert.ToDateTime(fileSI.CreationTime);
                        fileName = fileSI.Name;
                    }
                    */
                }
            }
  
        }

        public void saveTempJson()
        {

            string json = JsonConvert.SerializeObject(dataGridView1.DataSource, Formatting.Indented);

            System.IO.File.WriteAllText(string.Format(@".\temp\{0}_temporary_{1}.json", dataTimeN, FileNameOpen), json);

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {

                open_xml(openFileDialog1.FileName);
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
            var dialog = saveFileDialog1.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                //FileSaveL = saveFileDialog1.FileName;
                save_xml(saveFileDialog1.FileName);
                //Directory.Delete(@".\temp\", true);
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

            //var finded = FileOpenUser.Content.Find(item => item.Contentuid == dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            // добавить проверку на пустоту 
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == null)
            {
                
            }
            else if(dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
            {

            }
            else if(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            }

            if (autoSaveToolStripMenuItem.Checked)
            {
                saveTempJson();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //<LSTag Type="Spell" Tooltip="Target_HealingSpirit_Heal">
            /*if (e.ColumnIndex == 2 && e.RowIndex >= 2) // проверяем, что это нужная колонка и строка
             {
                 string cellText = e.Value.ToString(); // получаем текст ячейки

                 string pattern = @"<LSTag (.*)<\/LSTag>";

                 RegexOptions options = RegexOptions.Multiline;

                 foreach (Match m in Regex.Matches(cellText, pattern, options))
                 {
                     e.Paint(e.CellBounds, DataGridViewPaintParts.All); // отрисовываем ячейку
                     using (Brush brush = new SolidBrush(Color.Red)) // создаем кисть для красного цвета
                     {
                         //MessageBox.Show($"{m.Value} found.");
                         SizeF size = e.Graphics.MeasureString(string.Join(" ", m.Value, 0, 0), e.CellStyle.Font); // вычисляем размер предыдущих словw
                         //MessageBox.Show($"{size} test.");
                         Point location = new Point(e.CellBounds.X + (int)size.Width+3, e.CellBounds.Y); // вычисляем координаты начала слова
                     }

                 }

             }*/
            /*
                if (cellText.Contains("<LSTag")) // проверяем, что нужное слово есть в тексте
                {

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All); // отрисовываем ячейку

                    using (Brush brush = new SolidBrush(Color.Red)) // создаем кисть для красного цвета
                    {
                        string[] words = cellText.Split(' '); // разбиваем текст на слова

                        for (int i = 0; i < words.Length; i++) // перебираем слова
                        {
                            if (words[i] == "</LSTag>") // если это нужное слово, рисуем его красным цветом
                            {
                                SizeF size = e.Graphics.MeasureString(string.Join(" ", words, 0, i), e.CellStyle.Font); // вычисляем размер предыдущих словw
                                Point location = new Point(e.CellBounds.X + (int)size.Width, e.CellBounds.Y); // вычисляем координаты начала слова

                                e.Graphics.DrawString(words[i], e.CellStyle.Font, brush, location); // рисуем слово красным цветом
                            }
                            else // если это не нужное слово, рисуем его обычным цветом
                            {
                                SizeF size = e.Graphics.MeasureString(string.Join(" ", words, 0, i), e.CellStyle.Font); // вычисляем размер предыдущих слов
                                Point location = new Point(e.CellBounds.X + (int)size.Width, e.CellBounds.Y); // вычисляем координаты начала слова

                                //e.Graphics.DrawString(words[i], e.CellStyle.Font, e.CellStyle.ForeColor, location); // рисуем слово обычным цветом
                            }
                        }
                    }

                    e.Handled = true; // отменяем стандартную отрисовку ячейки
                }*/
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            _data.Add(new Content { Text = "tet", Contentuid="testID", Version = 1});
            //dataGridView1.Rows.Add(tBoxUID.Text, tBoxVer.Text, tBoxText.Text, tBoxText.Text);
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
                open_xmlMatch(openFileDialog1.FileName);
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

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                /*dgvBookmarks.Rows[e.RowIndex].Selected = true;
                Rectangle r = dgvBookmarks.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                contextMenu.Show((Control)sender, r.Left + e.X, r.Top + e.Y);*/
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

            open_json($"{FolderTemp}{nameFile}");
        }
    }
}
