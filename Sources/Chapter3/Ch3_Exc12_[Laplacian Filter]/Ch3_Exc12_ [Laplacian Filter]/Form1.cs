using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ch3_Exc9__Laplacian_filter_
{
    public partial class Form1 : Form
    {
        ImageProccessing ImProccess = new ImageProccessing();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                cmbMode.SelectedIndex = 2;
                btnLaplacianFilter_Click(sender, e);
                Application.DoEvents();
                progressBar1.Value = 100;
                Application.DoEvents();
                Application.DoEvents();
                System.Threading.Thread.Sleep(2000);
                btnAdd_Click(sender, e);

            }
            catch { }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OP = new OpenFileDialog();
                OP.ShowDialog();
                pictureBox1.Load(OP.FileName);
                pictureBox1.Image = ImProccess.MakeGrayscale((Bitmap)pictureBox1.Image);
            }
            catch { }
        }

        private void btnLaplacianFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] Kernel = new int[3, 3];
                Kernel[0,0] =int.Parse(x0y0.Text);
                Kernel[0,1] =int.Parse(x0y1.Text);
                Kernel[0,2] =int.Parse(x0y2.Text);
                Kernel[1,0] =int.Parse(x1y0.Text);
                Kernel[1,1] =int.Parse(x1y1.Text);
                Kernel[1,2] =int.Parse(x1y2.Text);
                Kernel[2,0] =int.Parse(x2y0.Text);
                Kernel[2,1] =int.Parse(x2y1.Text);
                Kernel[2,2] =int.Parse(x2y2.Text);
                Bitmap Big = ImProccess.MakeBigImage((Bitmap)pictureBox1.Image, cmbMode.SelectedItem.ToString(), 3, 3);
                pictureBox2.Image = ImProccess.LaplacianFilter(Big, Kernel, ref progressBar1,false,0);
            }
            catch { }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog OP = new SaveFileDialog();
                OP.Filter="|*.png";
                OP.ShowDialog();
                pictureBox2.Image.Save(OP.FileName);
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] Kernel = new int[3, 3];
                Kernel[0, 0] = int.Parse(x0y0.Text);
                Kernel[0, 1] = int.Parse(x0y1.Text);
                Kernel[0, 2] = int.Parse(x0y2.Text);
                Kernel[1, 0] = int.Parse(x1y0.Text);
                Kernel[1, 1] = int.Parse(x1y1.Text);
                Kernel[1, 2] = int.Parse(x1y2.Text);
                Kernel[2, 0] = int.Parse(x2y0.Text);
                Kernel[2, 1] = int.Parse(x2y1.Text);
                Kernel[2, 2] = int.Parse(x2y2.Text);
                Bitmap Big = ImProccess.MakeBigImage((Bitmap)pictureBox1.Image, cmbMode.SelectedItem.ToString(), 3, 3);
                pictureBox2.Image = ImProccess.LaplacianFilter(Big, Kernel, ref progressBar1, true,int.Parse(txtCoefficient.Text));
            }
            catch { }
        }

    }
}
