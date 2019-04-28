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
using System.Xml.Serialization;


namespace WindowsFormsApplication1
{

    
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeRO(bool b)
        {
            for (int i = 1; i <= 5; i++)
            {
                (this.Controls.Find("textBox" + i.ToString(), true)[0] as TextBox).ReadOnly = b;
            }
        }

        public void ChangeV(string a, bool b)
        {
            if (a == "textBox")
            {
                for (int i = 1; i <= 5; i++)
                {
                    (this.Controls.Find(a + i.ToString(), true)[0] as TextBox).Visible = b;
                }
            }

            else
            {
                for (int i = 1; i <= 5; i++)
                {
                    (this.Controls.Find(a + i.ToString(), true)[0] as Label).Visible = b;
                }
            }
        }

        public void CleanThisBox()
        {
            for (int i = 1; i <= 5; i++)
            {
                (this.Controls.Find("textBox" + i.ToString(), true)[0] as TextBox).Text = String.Empty;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (TABINF.Visible)
            {
                TABINF.Visible = false;
                button8.Visible = true;                
                ChangeV("textBox", true);
                ChangeV("label", true);
                button1.Text = "OK";
            }

            else
            {
                string[] str = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
                TABINF.Rows.Add(str[0], str[1], str[2], str[3], str[4]);
                TABINF.Visible = true;
                ChangeV("label", false);
                ChangeV("textBox", false);
                button1.Text = "Добавить";
                button8.Visible = false;
                CleanThisBox();
               
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TABINF.SelectedRows)
            {
                TABINF.Rows.Remove(row);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TABINF.Visible)
            {
                TABINF.Visible = false;
                ChangeV("label", true);
                ChangeV("textBox", true);
                button1.Text = "Добавить";
                ChangeRO(true);

                for (int i = 1; i <= 5; i++)
                {
                    (this.Controls.Find("textBox" + i.ToString(), true)[0] as TextBox).Text = TABINF.Rows[TABINF.CurrentRow.Index].Cells[i-1].Value.ToString(); ;
                }

            }

            else
            {
                TABINF.Visible = true;
                ChangeV("label", false);
                ChangeV("textBox", false);
                button1.Text = "Добавить";

                ChangeRO(false);
                button4.Text = "Просмотр";
                CleanThisBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TABINF.Visible)
            {
                TABINF.Visible = false;
                button8.Visible = true;
                ChangeV("label", true);
                ChangeV("textBox", true);
                button2.Text = "OK";
                for (int i = 1; i <= 5; i++)
                {
                    (this.Controls.Find("textBox" + i.ToString(), true)[0] as TextBox).Text = TABINF.Rows[TABINF.CurrentRow.Index].Cells[i - 1].Value.ToString(); ;
                }
            }

            else
            {
                string[] str = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
                TABINF.CurrentRow.SetValues(str[0], str[1], str[2], str[3], str[4]);
                TABINF.Visible = true;
                ChangeV("label", false);
                ChangeV("textBox", false);
                button2.Text = "Править";
                button8.Visible = false;
                CleanThisBox();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"1.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                for (int j = 0; j < TABINF.Rows.Count - 1; j++)
                {
                    for (int i = 0; i < TABINF.Rows[j].Cells.Count; i++)
                    {
                        streamWriter.Write(TABINF.Rows[j].Cells[i].Value + " ");
                    }

                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            StreamReader sr = new StreamReader(myStream);
                            string[] str;
                            int num = 0;
                            try
                            {
                                string[] str1 = sr.ReadToEnd().Split('\n');
                                num = str1.Count();
                                TABINF.RowCount = num;
                                for (int i = 0; i < num; i++)
                                {
                                    str = str1[i].Split(' ');
                                    for (int j = 0; j < TABINF.ColumnCount; j++)
                                    {
                                        TABINF.Rows[i].Cells[j].Value = str[j];
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Данные загружены");
                            }
                            finally
                            {
                                sr.Close();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button1.Text == "OK")
            {
                CleanThisBox();
                button1.Text = "Добавить";
                TABINF.Visible = true;
                button8.Visible = false;
            }
            if (button2.Text == "OK")
            {
                CleanThisBox();
                button2.Text = "Править";
                button8.Visible = false;
            }
        }
    }
}
