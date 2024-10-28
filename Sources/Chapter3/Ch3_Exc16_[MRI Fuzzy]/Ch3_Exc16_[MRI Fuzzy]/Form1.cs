using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ch3_Exc16__MRI_Fuzzy_
{
    public partial class Form1 : Form
    {
        ImageProcessing ImProcess = new ImageProcessing();
        double[] Mzero;
        double[] mBL;
        double[] mWH;
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


        double LastZero = (1 / 3.0);
        private void makeFunctions()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart1.Series.Add("Zero");
            chart2.Series.Add("BL");
            chart2.Series.Add("WH");
            for (int z = -255; z < 256; z++)
            {
                double a = -(LastZero * 255);
                double b = a / 2;
                double c = 0;
                if (z < a)
                {
                    Mzero[z+255] = 0;
                }
                else if ((z >= a) && (z <= b))
                {
                    Mzero[z+255] = 2 * Math.Pow(((z - a) / (c - a)), 2.0);
                }
                else if ((z > b) && (z <= c))
                {
                    Mzero[z + 255] = 1 - 2 * Math.Pow(((z - c) / (c - a)), 2.0);
                }
                else
                {
                    Mzero[z + 255] = Mzero[255-z];
                }
                if(z>=0 && z<255)
                {
                    mBL[z] = 1 - (z / (255 * 3.0 / 4));
                    if (mBL[z] < 0) mBL[z] = 0;
                    mWH[255 - z] = mBL[z];
                }
                chart1.Series["Zero"].Points.Add(Mzero[z+255]);
            }
            for (int z = 0; z < 256; z++)
            {
                chart2.Series["BL"].Points.Add(mBL[z]);
                chart2.Series["WH"].Points.Add(mWH[z]);
            }
            chart2.Series["BL"].Color = Color.Black;
            chart2.Series["WH"].Color = Color.Gray;
            chart1.Series["Zero"].Color = Color.LightSeaGreen ;
            chart2.Series["BL"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["WH"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Zero"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;

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
                Mzero = new double[511];
                mBL = new double[256];
                mWH = new double[256];
                makeFunctions();
                btnFBED_Click(sender, e);
        }

        private void btnFBED_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = ImProcess.FuzzyEdgeDetection((Bitmap)pictureBox1.Image, ref Mzero, ref mBL, ref mWH, ref progressBar1, ref chart1);
            }
            catch { }
        }

    }
}
