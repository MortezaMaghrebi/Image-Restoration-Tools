using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ch3_Exc15__Einstein_Fuzzy_
{
    public partial class Form1 : Form
    {
        ImageProcessing ImProcess = new ImageProcessing();
        double[] Mdark;
        double[] Mgray;
        double[] Mbright;
        int Vd = 0;
        int Vg = 127;
        int Vb = 255;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            try
            {
                op.ShowDialog();
                pictureBox1.Load(op.FileName);
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            try
            {
                sv.Filter = "|*.png";
                sv.ShowDialog();
                pictureBox2.Image.Save(sv.FileName);
            }
            catch { }
        }
        private void makeFunctions()
        {
            chart1.Series.Clear();
            chart1.Series.Add("dark");
            chart1.Series.Add("gray");
            chart1.Series.Add("bright");
            for (int i = 0; i < 256; i++)
            {
                if (i < (255 / 3.0))
                {
                    Mdark[i] = 1;
                    Mgray[i] = Mbright[i] = 0;
                }
                else if (i > (255 * 2 / 3.0))
                {
                    Mbright[i] = 1;
                    Mgray[i] = Mdark[i] = 0;
                }
                else if (i<127)
                {
                    Mgray[i] =1- Math.Abs(127 - i) * 2 / ((2 * 255 / 3.0) - (255 / 3.0));
                    Mdark[i] = 1.0 - Mgray[i];
                    Mbright[i] = 0;
                }
                else if (i >= 127)
                {
                    Mgray[i] = 1 - Math.Abs(127 - i) * 2 / ((2 * 255 / 3.0) - (255 / 3.0));
                    if (Mgray[i] < 0) Mgray[i] = 0;
                    Mbright[i] = 1.0 - Mgray[i];
                    Mdark[i] = 0;
                }
                chart1.Series["dark"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart1.Series["gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["bright"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;

                chart1.Series["dark"].Points.Add(Mdark[i]);
                chart1.Series["gray"].Points.Add(Mgray[i]);
                chart1.Series["bright"].Points.Add(Mbright[i]);
            }
        }
        private void btnGray_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = ImProcess.MakeGrayscale((Bitmap)pictureBox1.Image);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnGray_Click(sender, e);
            btnFBCS_Click(sender, e);
        }

        private void btnFBCS_Click(object sender, EventArgs e)
        {
            try
            {
                Mdark = new double[256];
                Mgray = new double[256];
                Mbright = new double[256];
                makeFunctions();
                pictureBox2.Image = ImProcess.FuzzyContrastStretching((Bitmap)pictureBox1.Image, ref Mdark, ref Mgray, ref Mbright, Vd, Vg, Vb);
            }
            catch { }
        }
    }
}
