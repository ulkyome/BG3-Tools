using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BG3_Tran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string FileOpenL = @".\temp\temporary.xml";
        public static string dataTimeN = DateTime.Now.ToString("MM/dd/yyyy HH:mm");

        public static ContentList data = new ContentList();
        private void Form1_Load(object sender, EventArgs e)
        {
            bool fileExist = File.Exists(FileOpenL);
            if (fileExist)
            {
                open_xml();
            }
        }

        public void open_xml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContentList));

            using (FileStream fs = new FileStream(FileOpenL, FileMode.OpenOrCreate))
            {
                var test = (ContentList)serializer.Deserialize(fs);

                foreach (var c in test.Content)
                {
                    dataGridView1.Rows.Add(c.Contentuid, c.Version, c.Text, c.Text);
                }
            }
        }

        public void save_xml(string fileSave)
        {
            XDocument doc = new XDocument(new XComment("Freshly baked localization file made with a tool from Ulkyome"));
            XElement contentList = new XElement("contentList", new XAttribute("date", dataTimeN));
            List<XElement> content = dataGridView1.Rows.Cast<DataGridViewRow>()
            .Select(row => new XElement("content", row.Cells[3].Value.ToString(), new XAttribute("contentuid", row.Cells[0].Value.ToString()), new XAttribute("version", row.Cells[1].Value.ToString()))).ToList();
            contentList.Add(content);
            doc.Add(contentList);
            doc.Save(fileSave);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                FileOpenL = openFileDialog1.FileName;
                open_xml();
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
                Directory.Delete(@".\temp\", true);
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
            Directory.CreateDirectory(@".\temp\");
            save_xml(@".\temp\temporary.xml");
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
    }
}
