using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ch4_Exc2__AntiAliasing_
{
    public partial class Form1 : Form
    {
        ImageProccessing ImProcess = new ImageProccessing();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            textBox1.Text = "0.7";
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double rate;
                rate = 1/double.Parse(textBox1.Text);
                pictureBox2.Image =ImProcess.Sampling(ImProcess.Sampling((Bitmap)pictureBox1.Image, rate),1.0);
                pictureBox3.Image = ImProcess.Sampling(ImProcess.Sampling(ImProcess.AveragingFilter(ImProcess.MakeBigImage((Bitmap)pictureBox1.Image, "Replicate", 3, 3), 1, 1, ref progressBar1), rate),(1));
            }
            catch { }
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            try
            {
                op.ShowDialog();
                pictureBox1.Load(op.FileName);
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
