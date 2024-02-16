using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoungsHz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Hz=0;
        public int HzFun(int x)
        {
            return Hz = x;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HzFun(50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HzFun(100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HzFun(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HzFun(3000);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HzFun(5000);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HzFun(10000);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HzFun(20000);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
