using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace Exc3__bit_plane_slicing_
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
                OpenFileDialog Op = new OpenFileDialog();
                Op.ShowDialog();
                picOriginal.Load(Op.FileName);
            }
            catch { }
        }
        private void btnRgb2Gray_Click(object sender, EventArgs e)
        {
            try
            {
                picOriginal.Image = ImProccess.MakeGrayscale((Bitmap)picOriginal.Image);
            }
            catch { }
        }
        private void btn_BitPlaneSlicing_Click(object sender, EventArgs e)
        {
            try
            {
                pic8.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 7);
                pic7.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 6);
                pic6.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 5);
                pic5.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 4);
                pic4.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 3);
                pic3.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 2);
                pic2.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 1);
                pic1.Image = ImProccess.BitPlaneSlicing((Bitmap)picOriginal.Image, 0);
            }
            catch { }
        }
        private void btnBitPlaneSlicingReverse_Click(object sender, EventArgs e)
        {
            try
            {
                picOriginal.Image = null;
                picOriginal.Refresh();
                picOriginal.Image = ImProccess.BitPlaneSlicingReverse((Bitmap)pic8.Image, (Bitmap)pic7.Image, (Bitmap)pic6.Image, (Bitmap)pic5.Image, (Bitmap)pic4.Image, (Bitmap)pic3.Image, (Bitmap)pic2.Image, (Bitmap)pic1.Image);
            }
            catch { }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Op = new SaveFileDialog();
                Op.Filter = "|*.png";
                Op.ShowDialog();
                picOriginal.Image.Save(Op.FileName);
            }
            catch { }

        }

        private void pic1_Click(object sender, EventArgs e)
        {
            load(ref pic1);
        }
        private void pic2_Click(object sender, EventArgs e)
        {
            load(ref pic2);
        }
        private void pic3_Click(object sender, EventArgs e)
        {
            load(ref pic3);
        }
        private void pic4_Click(object sender, EventArgs e)
        {
            load(ref pic4);
        }
        private void pic5_Click(object sender, EventArgs e)
        {
            load(ref pic5);
        }
        private void pic6_Click(object sender, EventArgs e)
        {
            load(ref pic6);
        }
        private void pic7_Click(object sender, EventArgs e)
        {
            load(ref pic7);
        }
        private void pic8_Click(object sender, EventArgs e)
        {
            load(ref pic8);
        }
        private void picOriginal_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void load(ref PictureBox piC)
        {
            try
            {
                OpenFileDialog Op = new OpenFileDialog();
                Op.ShowDialog();
                int W = piC.Image.Width;
                int H = piC.Image.Height;
                piC.Load(Op.FileName);

                piC.Image = ImProccess.TwoQuantizationLevels(ImProccess.stretch((Bitmap)piC.Image,W,H));

            }
            catch { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                TopMost = true;
                pictureBox1.Visible = false;
                Show();
                btn_BitPlaneSlicing_Click(sender, e);
                Application.DoEvents();
                timer1.Enabled = true;
                label1.Text = "";
                System.Threading.Thread.Sleep(2000);
                pic1.Image = new Bitmap(pic8.Image.Width, pic8.Image.Height);
                Application.DoEvents();
                System.Threading.Thread.Sleep(700);
                pic2.Image = new Bitmap(pic8.Image.Width, pic8.Image.Height);
                Application.DoEvents();
                System.Threading.Thread.Sleep(700);
                pic3.Image = new Bitmap(pic8.Image.Width, pic8.Image.Height);
                Application.DoEvents();
                System.Threading.Thread.Sleep(700);
                btnBitPlaneSlicingReverse_Click(sender, e);
                MessageBox.Show("the original picture rebuilded by 5 pages of most significant bits of itself.");
                Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1500);
                picOriginal.Image = pictureBox1.Image;
                Application.DoEvents();
                System.Threading.Thread.Sleep(1500);
                btn_BitPlaneSlicing_Click(sender, e);
            }
            catch { }
            TopMost = false;
        }

        string str =   "First : Load a picture.\n"
                     + "Second: Click on \"Bit-plane slicing\" button.\n"
                     + "Third : Click on each picture you want and change it.\n"
                     + "Fourth: Click on \"Bit-plane slicing -> reverse\" button.\n"
                     + "Fifth : Save your new picture.";
        int k = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text.Length < str.Length) label1.Text = str.Substring(0, label1.Text.Length + 1);
                else if (k < 35) k++;
                else { k = 0; label1.Text = ""; }
            }
            catch { }
        }
    }
}
