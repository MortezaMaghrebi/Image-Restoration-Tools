using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ch3_Exc9__Averaging_filter_
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
                cmbMode.SelectedIndex = cmbSize.SelectedIndex = 2;
                btnAveragingFilter_Click(sender, e);
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
            }
            catch { }
        }

        private void btnAveragingFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int KW, KH, H, W;
                KW = KH = int.Parse(cmbSize.SelectedItem.ToString().Substring(0, 2));
                H = W = int.Parse(cmbSize.SelectedItem.ToString().Substring(0, 2)) / 2;
                pictureBox2.Image = ImProccess.AveragingFilter(ImProccess.MakeBigImage((Bitmap)pictureBox1.Image, cmbMode.SelectedItem.ToString(), KW, KH), W, H, ref progressBar1);
            }
            catch { }
        }

        private void btnMakeBigPicture_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = ImProccess.MakeBigImage((Bitmap)pictureBox1.Image, cmbMode.SelectedItem.ToString(), int.Parse(cmbSize.SelectedItem.ToString().Substring(0, 2)), int.Parse(cmbSize.SelectedItem.ToString().Substring(0, 2)));
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

    }
}
