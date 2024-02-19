using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoungsHz
{
    public partial class Form1 : Form
    {

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
            int SumDb = Convert.ToInt32(Db) + x;
            if (SumDb <= 0 && SumDb >= -144)
            {
                Db = Convert.ToString(SumDb);
            }
            else {
                Db = Db;
            }
            
            textBox2.Text = Db;

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
                string FileLoc= @"Soungs\" + Hz+"Hz_" + Db + "dBFS_5s.wav";
                player.SoundLocation = FileLoc;
                player.Play();
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
        }



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

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i=0;i<23; i++) {
                HzFun(Gamma0[i]);
                DbFun(0);

                textBox1.Text = Hz;
                textBox2.Text = Db;

                Thread.Sleep(1000);
                try
                {
                    string FileLoc = @"Soungs\Gamma0\" + Hz + "Hz_" + Db + "dBFS_1s.wav";
                    player.SoundLocation = FileLoc;
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i < 23; i++)
            { 
                HzFun(Gamma0[i]);
                textBox1.Text = Hz;
                textBox2.Text = Db;

                Thread.Sleep(1000);
                try
                {
                    string FileLoc = @"Soungs\Gamma-30\" + Hz + "Hz_" + Db + "dBFS_1s.wav";
                    player.SoundLocation = FileLoc;
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
