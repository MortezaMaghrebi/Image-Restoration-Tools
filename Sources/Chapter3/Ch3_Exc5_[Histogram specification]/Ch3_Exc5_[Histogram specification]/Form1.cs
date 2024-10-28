using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exc5__histogram_specification_
{
    public partial class Form1 : Form
    {
        Boolean chart1_isSum = false;
        Boolean chart2_isSum = false;
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
                x1 = x2 = y1 = 512;
                y2 = 512;
                pictureBox4_Click(sender, e);
                btn_histogramSpecification_Click(sender, e);
            }
            catch { }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                pictureBox1.Load(op.FileName);
                pictureBox1.Image=ImProccess.MakeGrayscale((Bitmap)pictureBox1.Image);
            }
            catch { }
        }
        private void btn_histogramSpecification_Click(object sender, EventArgs e)
        {
            try
            {
                picHistogram.Image.Save("E:\\b.png");
                double[] Histogram = new double[256];
                ImProccess.PictureToHistogram((Bitmap)picHistogram.Image, ref Histogram);
                try
                {
                    chart3.Series.Clear();
                    chart3.Series.Add("Gray");
                    for (int i = 0; i < 256; i++) chart3.Series["Gray"].Points.Add((int)Histogram[i]);
                    ChangeChartType(ref chart3, true);
                }
                catch { }
                Application.DoEvents();
                pictureBox2.Image = ImProccess.HistogramSpecification((Bitmap)pictureBox1.Image,Histogram, ref chart1, ref chart2);
                chart1_isSum = false;
                if (checkBox1.Checked) { ChangeChartType(ref chart1, true); chart1_isSum = true; }
                chart2_isSum = false;
                if (checkBox2.Checked) { ChangeChartType(ref chart2, true); chart2_isSum = true; }
            }
            catch { }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked && !chart1_isSum) { ChangeChartType(ref chart1, true); chart1_isSum = true; }
                else if (!checkBox1.Checked && chart1_isSum) { ChangeChartType(ref chart1, false); chart1_isSum = false; }
            }
            catch { }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked && !chart2_isSum) { ChangeChartType(ref chart2, true); chart2_isSum = true; }
                else if (!checkBox2.Checked && chart2_isSum) { ChangeChartType(ref chart2, false); chart2_isSum = false; }
            }
            catch { }
        }
        private void ChangeChartType(ref System.Windows.Forms.DataVisualization.Charting.Chart chart, Boolean Sum)
        {
            try
            {
                if (Sum)
                {
                    for (int i = 1; i < 256; i++) chart.Series["Gray"].Points[i].SetValueY(chart.Series["Gray"].Points[i].YValues[0] + chart.Series["Gray"].Points[i - 1].YValues[0]);
                    chart.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    chart.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                }
                else
                {
                    for (int i = 255; i > 0; i--) chart.Series["Gray"].Points[i].SetValueY(chart.Series["Gray"].Points[i].YValues[0] - chart.Series["Gray"].Points[i - 1].YValues[0]);
                    chart.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    chart.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                }
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox3.Image;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox4.Image;
        }

        private void line(int x1, int y1, int x2, int y2)
        {
            try
            {
                Bitmap a = new Bitmap(picHistogram.Image);
                for (int i = x1; i <= x2; i += Math.Sign(x2 - x1))
                {
                    int j = (int)((double)(i - x1) * (y2 - y1) / (x2 - x1)) + y1;
                    for (int k = j; k < a.Height; k += 2) a.SetPixel(i, k, Color.Red);
                }

                 picHistogram.Image = a;
            }
            catch { }
        }

        int x1, x2 = 512, y1, y2 = 512;
        private void picHistogram_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > x2 ||e.X==0)
                {
                    x1 = x2;
                    y1 = y2;
                    x2 = e.X;
                    y2 = e.Y;
                    line(x1, y1, x2, y2);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                picHistogram.Image = new Bitmap(512, 512);
                x1 = x2 = y1 = 0;
                y2 = 512;
            }

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chart3.Visible = checkBox3.Checked;
        }

        private void picHistogram_Click(object sender, EventArgs e)
        {

        }


    }
}
