using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exc6__histogram_equalizing_local_
{
    public partial class Form1 : Form
    {
        ImageProccessing ImProccess = new ImageProccessing();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                picture1.Load(op.FileName);
            }
            catch { }
        }

        private void btnSimple_Click(object sender, EventArgs e)
        {
            try
            {
                picture2.Image = ImProccess.HistogramEqualization((Bitmap)picture1.Image);
            }
            catch { };
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox1.Text);
                if (a < 3) a = 3;
                if (a > Math.Max(picture1.Image.Width * 2, picture1.Image.Height * 2)) a = Math.Max(picture1.Image.Width * 2, picture1.Image.Height * 2);
                if (a % 2 == 0) a--;
                textBox1.Text = a.ToString();
            }
            catch { textBox1.Text = "7"; }
            Application.DoEvents();
            try
            {
                picture2.Image = ImProccess.LocalHistogramEqualizing((Bitmap)picture1.Image,int.Parse(textBox1.Text),ref progressBar1);
            }
            catch { };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            textBox1.Text = "69";
            Application.DoEvents();
            btnLocal_Click(sender, e);
        }

        private void btnRGB2Gray_Click(object sender, EventArgs e)
        {
            try
            {
                picture1.Image = ImProccess.MakeGrayscale((Bitmap)picture1.Image);
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Sv = new SaveFileDialog();
                Sv.Filter = "|*.png";
                Sv.ShowDialog();
                picture2.Image.Save(Sv.FileName);
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox1.Text);
                if (a > Math.Max(picture1.Image.Width * 2, picture1.Image.Height * 2)) a = Math.Max(picture1.Image.Width * 2, picture1.Image.Height * 2);
                textBox1.Text = a.ToString();
            }
            catch { }

        }




    }
}
