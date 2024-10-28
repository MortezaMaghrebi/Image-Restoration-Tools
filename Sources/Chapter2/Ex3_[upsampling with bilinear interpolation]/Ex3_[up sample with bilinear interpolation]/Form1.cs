using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex3__up_sample_with_bilinear_interpolation_
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
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                pic128.Load(op.FileName);
                //pic128.Image = ImProccess.Fill((Bitmap)pic128.Image, 128);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap a = ImProccess.Fill((Bitmap)pic128.Image, 128);
                pic128.Image = null;
                Show();
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                pic128.Image = a;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(30);
                btnSimpleZoom_Click(sender, e);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                btnZOOM_Click(sender, e);
            }
            catch { }
        }

        private void btnRGB2GRAY_Click(object sender, EventArgs e)
        {
            try
            {
                pic128.Image = ImProccess.MakeGrayscale((Bitmap)pic128.Image);
            }
            catch { }
        }

        private void btnZOOM_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoad.Enabled = button1.Enabled = btnRGB2GRAY.Enabled = btnSave.Enabled = btnSimpleZoom.Enabled = btnZOOM.Enabled = false;
                Application.DoEvents();
                pic512.Image = ImProccess.Zoom((Bitmap)pic128.Image, double.Parse(txtXlevel.Text), double.Parse(txtYlevel.Text));
                btnLoad.Enabled =button1.Enabled = btnRGB2GRAY.Enabled = btnSave.Enabled = btnSimpleZoom.Enabled = btnZOOM.Enabled = true;
            }
            catch { }
        }


        private void pic512_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                label1.Text = "(" + e.X.ToString() + "," + e.Y.ToString() + ")" + "  RGB: " + ((Bitmap)(pic512.Image)).GetPixel(e.X, e.Y).R.ToString() + " , " + ((Bitmap)(pic512.Image)).GetPixel(e.X, e.Y).G.ToString() + " , " + ((Bitmap)(pic512.Image)).GetPixel(e.X, e.Y).B.ToString();
                Application.DoEvents();
            }
            catch { }
        }

        private void pic128_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                label1.Text = "(" + e.X.ToString() + "," + e.Y.ToString() + ")" + "  RGB: " + ((Bitmap)(pic128.Image)).GetPixel(e.X, e.Y).R.ToString() + " , " + ((Bitmap)(pic128.Image)).GetPixel(e.X, e.Y).G.ToString() + " , " + ((Bitmap)(pic128.Image)).GetPixel(e.X, e.Y).B.ToString();
                Application.DoEvents();
            }
            catch { }
        }

        private void txtXlevel_Click(object sender, EventArgs e)
        {
            txtXlevel.SelectionStart = 0;
            txtXlevel.SelectionLength = txtXlevel.TextLength;
        }

        private void txtYlevel_Click(object sender, EventArgs e)
        {
            txtYlevel.SelectionStart = 0;
            txtYlevel.SelectionLength = txtYlevel.TextLength;
        }

        private void btnSimpleZoom_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = button1.Enabled = btnRGB2GRAY.Enabled = btnSave.Enabled = btnSimpleZoom.Enabled = btnZOOM.Enabled = false;
            try
            {
                pic512.Image = ImProccess.SimpleZoom((Bitmap)pic128.Image, double.Parse(txtXlevel.Text), double.Parse(txtYlevel.Text));
            }
            catch { }
            btnLoad.Enabled = button1.Enabled = btnRGB2GRAY.Enabled = btnSave.Enabled = btnSimpleZoom.Enabled = btnZOOM.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "|*.jpg";
                sv.ShowDialog();
                pic512.Image.Save(sv.FileName);
                MessageBox.Show("saved");
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap a = new Bitmap(3, 3);
                a.SetPixel(0, 0, Color.MediumSeaGreen);
                a.SetPixel(0, 1, Color.Indigo);
                a.SetPixel(0, 2, Color.Sienna);
                a.SetPixel(1, 0, Color.YellowGreen);
                a.SetPixel(1, 1, Color.Thistle);
                a.SetPixel(1, 2, Color.SkyBlue);
                a.SetPixel(2, 0, Color.PapayaWhip);
                a.SetPixel(2, 1, Color.Olive);
                a.SetPixel(2, 2, Color.MediumAquamarine);
                pic512.Image = ImProccess.Zoom(a, (512 / 2.0) - 1, (512 / 2.0) - 1);
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc = System.Diagnostics.Process.GetProcessesByName(Application.ProductName)[0];
                prc.Kill();
            }
            catch
            {
                Application.ExitThread();
                Application.Exit();
            }
        }

    }
}
