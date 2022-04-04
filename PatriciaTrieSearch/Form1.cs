using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using PatrieceTrie;
using System.Windows.Forms;

namespace PatriciaTrieSearch
{
    public partial class Form1 : Form
    {

        SuffixTree St = new SuffixTree();
        Color color = Color.Blue;
        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grf = Graphics.FromImage(bmp);
            grf.Clear(color);

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.ShowDialog();

        }
        public void FindWords()
        {
            //richTextBox1.Text += " ";
            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            //StringBuilder word = new StringBuilder();
            //int count = 0;
            //var length = richTextBox1.Text.Length;
            //for (int i = 0; i < length; i++)
            //{

            //    if ((char.ToLower(richTextBox1.Text[i]) >= 'a' && char.ToLower(richTextBox1.Text[i]) <= 'z') || richTextBox1.Text[i] == '"' || char.IsDigit(richTextBox1.Text[i]))
            //    {
            //        word.Append(richTextBox1.Text[i]);
            //    }
            //    else
            //    {
            //        if (St.Find(St.node, word.Append(' ')) != null)
            //        {
            //            word.Remove(word.Length - 1, 1);
            //            richTextBox1.Select(i - word.Length, word.Length);
            //            richTextBox1.SelectionColor = color;
            //            count++;
            //        }
            //        word.Clear();
            //    }
            //}
            //timer.Stop();
            //textBox1.Text = Convert.ToString(timer.ElapsedMilliseconds);
            //textBox2.Text = Convert.ToString(count);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            StringBuilder word = new StringBuilder();
            StringBuilder text = new StringBuilder(richTextBox1.Text).Append(' ');
            int count = 0;
            var length = text.Length;
            for (int i = 0; i < length; i++)
            {
                var a = text[i];
                if ((char.ToLower(text[i]) >= 'а' && char.ToLower(text[i]) <= 'я') || text[i] == '"' || char.IsDigit(text[i]))
                {
                    word.Append(text[i]);
                }
                else
                {
                    if (St.Find(St.node, word.Append(' ')) != null)
                    {
                        word.Remove(word.Length - 1, 1);
                        richTextBox1.Select(i - word.Length, word.Length);
                        richTextBox1.SelectionColor = color;
                        count++;
                    }
                    word.Clear();
                }
            }
            
            timer.Stop();
            textBox1.Text = Convert.ToString(timer.ElapsedMilliseconds);
            textBox2.Text = Convert.ToString(count);
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim()== "")
            {
                MessageBox.Show("Вы не в вели или загрузили текст");
                return;
            }
            FindWords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grf = Graphics.FromImage(bmp);
            grf.Clear(color);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            string sb = File.ReadAllText(openFileDialog1.FileName);
            richTextBox1.Text = sb;
        }
    }
}
