using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exc1__gamma_correction_
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
                GammaTrackBar.Value = 6;
                GammaTrackBar_Scroll(sender, e);
            }
            catch { }
        }

        private void GammaTrackBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                string s = (Math.Pow(1.3, GammaTrackBar.Value)).ToString();
                if (s.Length > 5) s = s.Substring(0, 5);
                LblGamma.Text = "Gamma = " + s;
                picGamma.Image = ImProccess.GammaCorrection((Bitmap)pic256.Image, (float)((Math.Pow(1.3, GammaTrackBar.Value))));
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Op = new OpenFileDialog();
                Op.ShowDialog();
                pic256.Load(Op.FileName);
            }
            catch { }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pic256.Image = ImProccess.MakeGrayscale((Bitmap)pic256.Image);
            }
            catch { }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "|*.png";
                sv.ShowDialog();
                picGamma.Image.Save(sv.FileName);
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pic256.Image = pictureBox1.Image;
                GammaTrackBar_Scroll(sender, e);
            }
            catch { }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                pic256.Image = pictureBox2.Image;
                GammaTrackBar_Scroll(sender, e);
            }
            catch { }
        }
    }
}
