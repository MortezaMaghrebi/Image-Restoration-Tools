using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex1__change_resolution_
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
                Bitmap pic = new Bitmap(256, 256);
                pic = ImProccess.Fill((Bitmap)buf.BackgroundImage, 256);
                pic256.BackgroundImage = null;
                Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                pic256.BackgroundImage = pic;
                Application.DoEvents();
                System.Threading.Thread.Sleep(700);
                btnRgb2Gray_Click(sender, e);
                Application.DoEvents();
                System.Threading.Thread.Sleep(700);
                btnShow4Resolution_Click(sender, e);
            }
            catch { }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Op = new OpenFileDialog();
                Op.ShowDialog();
                buf.Load(Op.FileName);
                buf.BackgroundImage = buf.Image;
                buf.Image = null;
                pic256.BackgroundImage = ImProccess.Fill((Bitmap)buf.BackgroundImage,256);   
            }
            catch { }
        }

        private void buf_Click(object sender, EventArgs e)
        {
            try
            {
                pic256.BackgroundImage = ImProccess.Fill((Bitmap)buf.BackgroundImage, 256);
            }
            catch { }
        }

        private void btnRgb2Gray_Click(object sender, EventArgs e)
        {
            try
            {
                pic256.BackgroundImage = ImProccess.MakeGrayscale((Bitmap)pic256.BackgroundImage);
            }
            catch { }
        }

        private void btnShow4Resolution_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = btnRgb2Gray.Enabled = false;
            try
            {
                pic128.BackgroundImage = ImProccess.ChangeSize((Bitmap)pic256.BackgroundImage, 128, 128);
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);
                pic64.BackgroundImage = ImProccess.ChangeSize((Bitmap)pic256.BackgroundImage, 64, 64);
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);
                pic32.BackgroundImage = ImProccess.ChangeSize((Bitmap)pic256.BackgroundImage, 32, 32);
            }
            catch { }
            btnOpen.Enabled = btnRgb2Gray.Enabled = true;
        }




    }
}
