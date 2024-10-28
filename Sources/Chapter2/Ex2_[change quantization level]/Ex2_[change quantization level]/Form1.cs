using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Ex2__change_quantization_level_
{
    public partial class Form1 : Form
    {
        ImageProccessing ImProccess = new ImageProccessing();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRGB2GRAY_Click(object sender, EventArgs e)
        {
            pic256.Image = ImProccess.MakeGrayscale((Bitmap)pic256.Image);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                pic256.Load(op.FileName);
                pic256.Image = ImProccess.Fill((Bitmap)pic256.Image, 128);
            }
            catch
            {
                
            }
        }

        private void btnChangeQuantizationLevel_Click(object sender, EventArgs e)
        {
                Application.DoEvents();
            pic128.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 128);
                Application.DoEvents();
                System.Threading.Thread.Sleep(40);
            pic64.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 64);
                Application.DoEvents();
                System.Threading.Thread.Sleep(40);
            pic32.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 32);
                Application.DoEvents();
                System.Threading.Thread.Sleep(40);
            pic16.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 16);
                Application.DoEvents();
                System.Threading.Thread.Sleep(40);
            pic8.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 8);
                Application.DoEvents();
                System.Threading.Thread.Sleep(40);
            pic4.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 4);
                Application.DoEvents();
                System.Threading.Thread.Sleep(40);
            pic2.Image = ImProccess.ChangeQuantizationLevel((Bitmap)pic256.Image, 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            btnChangeQuantizationLevel_Click(sender, e);
        }

    }
}
