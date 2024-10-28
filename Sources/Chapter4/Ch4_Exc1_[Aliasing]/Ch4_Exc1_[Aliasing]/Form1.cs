using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ch4_Exc1__Aliasing_
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
            button2.Enabled = false;
            pictureBox1.Image = ImProcess.MakeChess();
            Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            for (double rate = 0.0798; rate <= 1; rate+=0.001)
            {
                textBox1.Text = rate.ToString();
                pictureBox2.Image = ImProcess.Sampling((Bitmap)pictureBox1.Image, 1.0/rate);
                Application.DoEvents();
                if (Math.Abs(rate - 0.4798) < 0.0001) System.Threading.Thread.Sleep(2000);
                if (Math.Abs(rate - 0.9178) < 0.0001) System.Threading.Thread.Sleep(2000);
                trackBar1.Value = (int)(rate * 1000);
            }
            button2.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double rate;
                rate = 1/double.Parse(textBox1.Text);
                pictureBox2.Image = ImProcess.Sampling((Bitmap)pictureBox1.Image, rate);
            }
            catch { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = ((trackBar1.Value / 1000.0)).ToString();
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Application.DoEvents();
            for (double rate = 0.0798; rate <= 1; rate += 0.001)
            {
                textBox1.Text = rate.ToString();
                pictureBox2.Image = ImProcess.Sampling((Bitmap)pictureBox1.Image, 1.0 / rate);
                Application.DoEvents();
                if (Math.Abs(rate - 0.4798) < 0.0001) System.Threading.Thread.Sleep(2000);
                if (Math.Abs(rate - 0.9178) < 0.0001) System.Threading.Thread.Sleep(2000);
                trackBar1.Value = (int)(rate * 1000);

            }
            button2.Enabled = true;
        }
    }
}
