using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Exc4__histogram_equalization_
{
    class ImageProccessing
    {
        public Bitmap MakeGrayscale(Bitmap original)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        byte grayScale = (byte)(int)((oRow[x * pixelSize] * 0.11) + (oRow[x * pixelSize + 1] * 0.59) + (oRow[x * pixelSize + 2] * 0.3));
                        nRow[x * pixelSize] = grayScale;
                        nRow[x * pixelSize + 1] = grayScale;
                        nRow[x * pixelSize + 2] = grayScale;
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public Bitmap a_Histogram(Bitmap original, ref System.Windows.Forms.DataVisualization.Charting.Chart chart1, ref System.Windows.Forms.DataVisualization.Charting.Chart chart2)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                
                double[] S = new double[256];
                for (int i = 0; i < 256; i++) S[i] = 0;

                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        S[oRow[x * pixelSize]]++;
                    }
                }

                chart1.Series.Clear();
                chart1.Series.Add("Gray");
                for (int i = 0; i < 256; i++) chart1.Series["Gray"].Points.Add(S[i]);
                for (int i = 1; i < 256; i++) S[i] += S[i - 1];
                for (int i = 0; i < 256; i++) S[i] /= S[255];

                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        nRow[x * pixelSize+0] = (byte)(S[oRow[x * pixelSize]] * 255);
                        nRow[x * pixelSize+1] = (byte)(S[oRow[x * pixelSize]] * 255);
                        nRow[x * pixelSize+2] = (byte)(S[oRow[x * pixelSize]] * 255);
                    }
                }

                for (int i = 0; i < 256; i++) S[i] = 0;

                for (int y = 0; y < original.Height; y++)
                {
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        S[nRow[x * pixelSize]]++;
                    }
                }

                chart2.Series.Clear();
                chart2.Series.Add("Gray");
                for (int i = 0; i < 256; i++) chart2.Series["Gray"].Points.Add(S[i]);

                chart1.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart2.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart1.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart2.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;

                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
            
    }
}
