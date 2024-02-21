/*
 *developer: Lazarenkov A.A.
    */



using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace SoungsHz
{


    public partial class Form1 : Form
    {
        public static string GlobalVar="0";
        public static string GlobalVarForText = "0";
        public string ZeroLvlDb;
        public int ZeroLvlWork;

        string filePath = "ZeroLvl.txt";

        string ForTextDb="0";


        SoundPlayer player = null;
        string fileName = string.Empty;
        string Hz = "50";
        string Db = "0";
        string[] Gamma0 = {"16.35","32.7","65.41","130.8","261.6","523.3","1047","2093","4186","4435","4899","4978","5274","5588","5920","6272","6645","7040","7459","7902","10000","15000","20000"};
        public Form1()
        {
            InitializeComponent();

        }

        public void HzFun(string x)
        {
            Hz = x;
            textBox1.Text = Hz;
        }
        public void DbFun(int x=0) 
        {

            using (StreamReader stream = new StreamReader(filePath))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    string str = stream.ReadLine();

                    // разбиваем строку по словами
                    string[] words = str.Split(' ');

                    // конвертируем 1-ое слово в число
                    ZeroLvlWork = Int32.Parse(words[0]);
                    ZeroLvlDb =words[0];

                }
            }

            int SumDb = Convert.ToInt32(Db) + x-ZeroLvlWork;
            if ((SumDb <= 0-ZeroLvlWork) && (SumDb >= -144- ZeroLvlWork))
            {
                Db = Convert.ToString(SumDb+ZeroLvlWork);
                ForTextDb = Convert.ToString(SumDb);
            }
            else {
                
            }
            textBox2.Text = ForTextDb;

        }


    private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HzFun("50");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            HzFun("100");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HzFun("1000");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            HzFun("3000");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            HzFun("5000");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HzFun("10000");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            HzFun("15000");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            HzFun("20000");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
          

                try
                {
                    string FileLoc = @"Soungs\" + Hz + "Hz_" + Db + "dBFS_5s.wav";
                    player.SoundLocation = FileLoc;
                    player.Play();
                    Thread.Sleep(2000);// Звук идёт 2 секунды

                    player.Stop();
            }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

       /*Выбор вручную
        * private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog()
                {
                    Filter = "WAV|*.wav",
                    Multiselect = false,
                    ValidateNames = true
                };
            if (oFD.ShowDialog() == DialogResult.OK) 
                {
                fileName = oFD.FileName;
                }
        }*/



        private void button10_Click(object sender, EventArgs e)
        {
            DbFun(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DbFun(-10);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            DbFun(1);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DbFun(-1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button14_Click(object sender, EventArgs e) //Гамма 0
        {
            
                for (int i = 0; i < 23; i++)
                {


                    Thread.Sleep(1000);
                    try
                    {
                        string FileLoc = @"Soungs\Gamma0\" + Gamma0[i] + "Hz_" + "0" + "dBFS_1s.wav";
                        player.SoundLocation = FileLoc;
                        player.Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            
 

        }

        private void button15_Click(object sender, EventArgs e)//Гамма -30
        {
           

            for (int i = 0; i < 23; i++)
            {   



                Thread.Sleep(1000);
                try
                {
                    string FileLoc = @"Soungs\Gamma-30\" + Gamma0[i] + "Hz_" + "-30" + "dBFS_1s.wav";
                    player.SoundLocation = FileLoc;
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void Calibration_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.Show();
        }
    }
}
