using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exc4__histogram_equalization_
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
                pictureBox3_Click(sender, e);
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
        private void btn_histogramEq_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = ImProccess.a_Histogram((Bitmap)pictureBox1.Image, ref chart1, ref chart2);
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
            btn_histogramEq_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox4.Image;
            btn_histogramEq_Click(sender, e);
        }


    }
}
