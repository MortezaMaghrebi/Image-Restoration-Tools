using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fourier;

namespace Ch4_Exc4__Change_abs_or_angle_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Fourier.Fourier fourier = new Fourier.Fourier();
        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            Refresh();

            Fourier.Fourier.number[,] cm = fourier.FFT2(fourier.complex((Bitmap)pictureBox1.Image));
            Fourier.Fourier.number[,] ln = fourier.FFT2(fourier.complex((Bitmap)pictureBox2.Image));
            pictureBox3.Image  =fourier.NormalizeImage(fourier.abs(fourier.iFFT2( fourier.reconstruct(fourier.abs(cm),fourier.angle(ln)))),pictureBox1.Image.Width,pictureBox1.Image.Height);
            pictureBox4.Image = fourier.NormalizeImage(fourier.abs(fourier.iFFT2(fourier.reconstruct(fourier.abs(ln), fourier.angle(cm)))), pictureBox1.Image.Width, pictureBox1.Image.Height);
        }
    }
}
