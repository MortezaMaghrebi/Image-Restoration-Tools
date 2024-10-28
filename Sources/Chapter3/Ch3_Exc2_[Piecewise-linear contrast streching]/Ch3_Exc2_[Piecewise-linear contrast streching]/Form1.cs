using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exc2__piecewise_linear_contrast_streching_
{
    public partial class Form1 : Form
    {
        ImageProccessing ImProccess = new ImageProccessing();
        public Form1()
        {
            InitializeComponent();
        }


        private void MakeFunction(ref double[] function, ref System.Windows.Forms.DataVisualization.Charting.Chart Chart, double Xvalue, double Yvalue ,double Zvalue)
        {
            try
            {
                double x1 = (255 / 32.0) + (Xvalue * (15.0 * 255 / 32.0));
                double y1 = (255 / 32.0) + (Yvalue * (5.0 * 255 / 32.0));

                double x2 = 255 - x1;
                double y2 = 255 - y1;

                if (y2 < y1) y2 = y1 = (y2 + y1) / 2;

                double X = -x1 * Zvalue;
                x1=x1-X;
                x2=x2-X;

                Chart.Series.Clear();
                Chart.Series.Add("A");

                for (int i = 0; i < 256; i++)
                {
                    double y = 0;
                    if (i < x1) y = (y1 / x1) * i;
                    else if (i > x2) y = ((255-y2) / (255-x2)) * (i - x2) + y2;
                    else y = ((y2 - y1) / (x2 - x1)) * (i - x1) + y1;
                    Chart.Series["A"].Points.Add((int)y);
                    function[i] = y / 255;
                }
                Chart.Series["A"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                Chart.Series["A"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            catch { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                //if (trackBar1.Value < trackBar2.Value) { trackBar1.Value = trackBar2.Value; return; }
                double[] function = new double[256];
                MakeFunction(ref function, ref chart1, (trackBar1.Value / 80.0) + 0.5, trackBar2.Value / 40.0, trackBar3.Value / 40.0);
                pictureBox2.Image = ImProccess.PiecewiseLinearContrasting((Bitmap)pictureBox1.Image, ref function);
            }
            catch { }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            try
            {
                //if (trackBar1.Value*5 < trackBar2.Value) { trackBar2.Value = trackBar1.Value/5; return; }
                double[] function = new double[256];
                MakeFunction(ref function, ref chart1, (trackBar1.Value / 80.0) + 0.5, trackBar2.Value / 40.0, trackBar3.Value / 40.0);
                pictureBox2.Image = ImProccess.PiecewiseLinearContrasting((Bitmap)pictureBox1.Image, ref function);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Show();
                Application.DoEvents();
                double[] function = new double[256];
                MakeFunction(ref function, ref chart1, (trackBar1.Value / 80.0)+0.5, trackBar2.Value / 40.0, trackBar3.Value / 40.0);
                pictureBox2.Image = ImProccess.PiecewiseLinearContrasting((Bitmap)pictureBox1.Image, ref function);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                pictureBox1.Load(op.FileName);
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
                pictureBox2.Image.Save(sv.FileName);
            }
            catch { }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            try
            {
                double[] function = new double[256];
                MakeFunction(ref function, ref chart1, (trackBar1.Value / 80.0) + 0.5, trackBar2.Value / 40.0, trackBar3.Value / 40.0);
                pictureBox2.Image = ImProccess.PiecewiseLinearContrasting((Bitmap)pictureBox1.Image, ref function);
            }
            catch { }
        }
    }
}
