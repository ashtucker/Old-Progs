using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;


namespace CourseProject
{
    public partial class DialogueForm : Form
    {
        public DialogueForm()
        {
            InitializeComponent();
        }

        string k;

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DialogueForm_Load(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f = new About();
            f.Show();
        }


        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SprM f = new SprM();
            f.Show();
        }

        string m = "1";
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //задаем путь к нашему рабочему файлу XML
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "c:\\";
            open.Filter = "xml files (*.xml)|*.xml";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                k = open.FileName;
                                //читаем данные из файла
                XDocument doc = XDocument.Load(k);

                foreach (XElement el in doc.Root.Elements())
                {
                    if (el.Attribute("id").Value == m)
                    {
                        textBox1.Text = el.Attribute("text").Value;

                        foreach (XElement element in el.Elements())
                        {
                            richTextBox1.Text = richTextBox1.Text + element.Value + '\n';
                        }
                    }
                }
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int find = richTextBox1.Find(textBox2.Text);
            if (find >= 0)
            {
                listBox1.Items.Add(DateTime.Now + " Вопрос: " + textBox1.Text + " Ответ: " + textBox2.Text + '\n');
                XDocument doc = XDocument.Load(k);
                foreach (XElement el in doc.Root.Elements())
                {
                    if (el.Attribute("id").Value == m)
                    {
                        textBox1.Text = el.Attribute("text").Value;
                        richTextBox1.Text = String.Empty;
                        richTextBox2.Text = String.Empty;
                        foreach (XElement element in el.Elements())
                        {
                            if (textBox2.Text == element.Value)
                            {
                                m = element.Attribute("nextid").Value;
                            }
                            richTextBox1.Text = richTextBox1.Text + element.Value + '\n';
                        }
                    }
                    if (m == "0")
                    {
                        listBox1.Items.Add("Диалог окончен. Вы можете сохранить ход диалога.");
                        textBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
                        richTextBox1.Text = String.Empty;
                        richTextBox2.Text = String.Empty;
                    }
                }

                textBox2.Text = String.Empty;
            }
            else
            {
                richTextBox2.Text = "Ошибка ввода.";
                textBox2.Text = String.Empty;
            }
        }

        private void сохранитьЛогДиалогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savelog = new SaveFileDialog();
            savelog.InitialDirectory = "c:\\";
            savelog.Filter = "txt files (*.txt)|*.txt";
            savelog.FilterIndex = 2;
            savelog.RestoreDirectory = true;

            if (savelog.ShowDialog() == DialogResult.OK)
            {
                TextWriter writer = new StreamWriter(savelog.FileName);
                foreach (var item in listBox1.Items)
                    writer.WriteLine(item.ToString());
                writer.Close();
            }
            listBox1.Text = String.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
