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
using System.Media;


namespace SoungsHz
{
    public partial class Form2 : Form
    {
        string filePath = "ZeroLvl.txt";

        int DbZero = 0;
        string Hz = "5000";
        string Db = "0";
        SoundPlayer player = null;

        public void ZeroLvl(int x) 
        {
            // открываем файл
            using (StreamReader stream = new StreamReader(filePath))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    string str = stream.ReadLine();

                    // разбиваем строку по словами
                    string[] words = str.Split(' ');

                    // конвертируем 1-ое слово в число
                    DbZero = Int32.Parse(words[0]);
                }
            }

                    int SumDbZero = DbZero + x;
            if (SumDbZero <= 0 && SumDbZero >= -144) {
                DbZero =SumDbZero;
                Form1.GlobalVarForText = Convert.ToString(SumDbZero);

                using (FileStream fileStream = File.Open(filePath, FileMode.Create))
                {
                    using (StreamWriter output = new StreamWriter(fileStream))
                    {
                        // записываем текст в поток
                        output.Write(DbZero);
                    }
                }
            }
            else { }

            textBox1.Text = Form1.GlobalVarForText;


        }

        public Form2()
        {
            InitializeComponent();
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
  
                player = new SoundPlayer();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ZeroLvl(-10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZeroLvl(-1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZeroLvl(1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZeroLvl(10);

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form1.GlobalVar = Convert.ToString(DbZero);
            
            using (FileStream fileStream = File.Open(filePath, FileMode.Create))
            {
                using (StreamWriter output = new StreamWriter(fileStream))
                {
                    // записываем текст в поток
                    output.Write(DbZero);
                }
            }
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Db=Convert.ToString(DbZero);
            try
            {
                string FileLoc = @"Soungs\" + Hz + "Hz_" + Db + "dBFS_5s.wav";
                player.SoundLocation = FileLoc;
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = Hz;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
