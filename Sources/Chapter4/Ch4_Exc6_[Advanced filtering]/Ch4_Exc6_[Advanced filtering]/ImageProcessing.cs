using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch4_Exc6__Advanced_filtering_
{
    class ImageProcessing
    {
        public int s;
        public int ss(int k)
        {
            return 0;
        }
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
        public Bitmap ChangeSize(Bitmap original, int newWith, int newHeigh)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(newWith, newHeigh);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, newWith, newHeigh), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                double xResize = (original.Width / (double)newWith);
                double yResize = (original.Height / (double)newHeigh);

                for (int y = 0; y < newHeigh; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (int)(y * yResize) * originalData.Stride;
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < newWith; x++)
                    {
                        nRow[x * pixelSize] = oRow[(int)(x * xResize) * pixelSize];
                        nRow[x * pixelSize + 1] = oRow[(int)(x * xResize) * pixelSize + 1];
                        nRow[x * pixelSize + 2] = oRow[(int)(x * xResize) * pixelSize + 2];
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public Bitmap Fill(Bitmap image, int size)
        {
            try
            {
                int fromX, toX;
                int fromY, toY;
                double ResizeValue;
                if (image.Width > image.Height)
                {
                    fromX = (image.Width - image.Height) / 2;
                    toX = fromX + image.Height;
                    fromY = 0;
                    toY = image.Height;
                    ResizeValue = (toX - fromX) / (double)size;
                }
                else
                {
                    fromX = 0;
                    toX = image.Width;
                    fromY = (image.Height - image.Width) / 2;
                    toY = fromY + image.Width;
                    ResizeValue = (toX - fromX) / (double)size;
                }
                Bitmap pic = new Bitmap(size, size);
                int ii = 0, jj = 0;
                for (double i = fromX; (i <= toX) && (ii < size); i += ResizeValue)
                {
                    jj = 0;
                    for (double j = fromY; (j <= toY) && (jj < size); j += ResizeValue)
                    {
                        pic.SetPixel(ii, jj++, image.GetPixel((int)i, (int)j));
                    }
                    ii++;
                }
                return pic;
            }
            catch { System.Windows.Forms.MessageBox.Show("Error"); return null; }
        }

        public double[,] IdealLowPassFilter(int W, int H, int r)
        {
            double[,] filter = new double[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (Math.Pow((i - W / 2.0), 2) + Math.Pow((j - H / 2.0), 2) <= r * r) filter[i, j] = 1;
                    else filter[i, j] = 0;
                }
            }
            return filter;
        }
        public double[,] IdealHighPassFilter(int W, int H, int r)
        {
            double[,] filter = new double[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (Math.Pow((i - W / 2.0), 2) + Math.Pow((j - H / 2.0), 2) <= r * r) filter[i, j] = 0;
                    else filter[i, j] = 1;
                }
            }
            return filter;
        }

        public double[,] GaussianLowPassFilter(int W, int H, int r)
        {
            double[,] filter = new double[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    filter[i, j] = Math.Exp(-(Math.Pow(i - W / 2.0, 2) + Math.Pow(j - H / 2.0, 2)) / (2 * r * r));
                }
            }
            return filter;
        }
        public double[,] GaussianHighPassFilter(int W, int H, int r)
        {
            double[,] filter = new double[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    filter[i, j] = 1.0 - Math.Exp(-(Math.Pow(i - W / 2.0, 2) + Math.Pow(j - H / 2.0, 2)) / (2 * r * r));
                }
            }
            return filter;
        }

        public double[,] ButterworthLowPassFilter(int W, int H, int r, int n)
        {
            double[,] filter = new double[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    double D = Math.Sqrt(Math.Pow(i - W / 2.0, 2) + Math.Pow(j - H / 2.0, 2));
                    filter[i, j] = 1.0 / (1 + Math.Pow(D / r, 2 * n));
                }
            }
            return filter;
        }
        public double[,] ButterworthHighPassFilter(int W, int H, int r, int n)
        {
            double[,] filter = new double[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    double D = Math.Sqrt(Math.Pow(i - W / 2.0, 2) + Math.Pow(j - H / 2.0, 2));
                    filter[i, j] = 1.0 / (1 + Math.Pow(r / D, 2 * n));
                }
            }
            return filter;
        }

    }
}
