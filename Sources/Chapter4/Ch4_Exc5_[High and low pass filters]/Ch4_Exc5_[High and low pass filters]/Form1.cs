using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fourier;

namespace Ch4_Exc5__High_and_low_pass_filters_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ImageProcessingFourier.FFT2 IPF = new ImageProcessingFourier.FFT2();
        Fourier.Fourier fourier = new Fourier.Fourier();
        ImageProcessing ImProcess = new ImageProcessing();

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            Refresh();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            btnFilter_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            try
            {
                op.ShowDialog();
                pictureBox1.Load(op.FileName);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            try
            {
                sv.Filter = "|*.png";
                sv.ShowDialog();
                pictureBox4.Image.Save(sv.FileName);
            }
            catch { }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            double [,]filter = new double[1,1];
            int W = pictureBox1.Image.Width;
            int H = pictureBox1.Image.Height;
            int r = trackBar1.Value;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Low pass":
                    switch (comboBox2.SelectedItem.ToString())
                    {
                        case "Ideal":
                            filter = ImProcess.IdealLowPassFilter(W, H, r);
                            break;
                        case "Butterworth":
                            filter = ImProcess.ButterworthLowPassFilter(W, H, r,2);
                            break;
                        case "Gaussian":
                            filter = ImProcess.GaussianLowPassFilter(W, H, r);
                            break;
                    }
                    break;
                case "High pass":
                    switch (comboBox2.SelectedItem.ToString())
                    {
                        case "Ideal":
                            filter = ImProcess.IdealHighPassFilter(W, H, r);
                            break;
                        case "Butterworth":
                            filter = ImProcess.ButterworthHighPassFilter(W, H, r, 2);
                            break;
                        case "Gaussian":
                            filter = ImProcess.GaussianHighPassFilter(W, H, r);
                            break;
                    }
                    break;
            }
            pictureBox3.Image = fourier.NormalizeImage(filter, W, H);
            IPF.fft2((Bitmap)pictureBox1.Image);
            IPF.Filter(filter);
            pictureBox4.Image = IPF.ifft2();
            
        }
    }
}
