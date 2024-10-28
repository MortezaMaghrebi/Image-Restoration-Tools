using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Exc6__histogram_equalizing_local_
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
        public Bitmap HistogramEqualization(Bitmap original)
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

                for (int i = 1; i < 256; i++) S[i] += S[i - 1];
                for (int i = 0; i < 256; i++) S[i] /= S[255];

                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        nRow[x * pixelSize + 0] = (byte)(S[oRow[x * pixelSize]] * 255);
                        nRow[x * pixelSize + 1] = (byte)(S[oRow[x * pixelSize]] * 255);
                        nRow[x * pixelSize + 2] = (byte)(S[oRow[x * pixelSize]] * 255);
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

                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public Bitmap LocalHistogramEqualizing(Bitmap original, int SquareSide,ref System.Windows.Forms.ProgressBar progress)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                double[] PrB = new double[256];
                double[] PrG = new double[256];
                double[] PrR = new double[256];
                double[] SB = new double[256];
                double[] SG = new double[256];
                double[] SR = new double[256];
                for (int i = 0; i < 256; i++) PrB[i] = SB[i] = PrG[i] = SG[i] = PrR[i] = SR[i] = 0;
                int m = SquareSide / 2;
                if (m > (original.Width - 1)) m = original.Width - 1;
                if (m > (original.Height-1)) m = original.Height - 1;
                int pixelSize = 3;
                byte* o0= (byte*)originalData.Scan0; int oS = originalData.Stride;
                byte* n0 =(byte*)newData.Scan0;      int nS = newData.Stride;
                int xm=0, xM=0, ym=0, yM=0;
                for (int Y = 0; Y < original.Height; Y ++)
                {
                    Boolean Up = (Y%2==0);
                    int startValue = Up?0:original.Width-1;
                    int Val = Up?1:-1;
                    
                    for (int X = startValue ;(Up?(X < original.Width):(X>-1)); X+=Val)
                    {
                        if (X - m < 0) xm = X; else xm = m;
                        if (Y - m < 0) ym = Y; else ym = m;
                        if (X + m >= original.Width) xM = original.Width - X - 1; else xM = m;
                        if (Y + m >= original.Height) yM = original.Height - Y - 1; else yM = m;

                        if (X == 0 && Y == 0)
                        {
                            for (int x = 0; x <= m; x++)
                            {
                                for (int y = 0; y <= m; y++)
                                {
                                    PrB[(o0 + y * oS)[x * pixelSize + 0]]++;
                                    PrG[(o0 + y * oS)[x * pixelSize + 1]]++;
                                    PrR[(o0 + y * oS)[x * pixelSize + 2]]++;
                                }
                            }
                        }
                        else if (((X == original.Width - 1) && !Up) || ((X == 0) && Up))
                        {
                            if (Y > m)
                            {
                                for (int x = -xm; x <= xM; x++)
                                {
                                    PrB[(o0 + (Y - m - 1) * oS)[(X + x) * pixelSize + 0]]--;
                                    PrG[(o0 + (Y - m - 1) * oS)[(X + x) * pixelSize + 1]]--;
                                    PrR[(o0 + (Y - m - 1) * oS)[(X + x) * pixelSize + 2]]--;
                                }
                            }
                            if ((Y + m) < original.Height)
                            {
                                for (int x = -xm; x <= xM; x++)
                                {
                                    PrB[(o0 + (Y + m) * oS)[(X + x) * pixelSize + 0]]++;
                                    PrG[(o0 + (Y + m) * oS)[(X + x) * pixelSize + 1]]++;
                                    PrR[(o0 + (Y + m) * oS)[(X + x) * pixelSize + 2]]++;
                                }
                            }
                        }
                        else if (Up)
                        {
                            if (X > m)
                            {
                                for (int y = -ym; y <= yM; y++)
                                {
                                    PrB[(o0 + (Y + y) * oS)[(X - xm - 1) * pixelSize + 0]]--;
                                    PrG[(o0 + (Y + y) * oS)[(X - xm - 1) * pixelSize + 1]]--;
                                    PrR[(o0 + (Y + y) * oS)[(X - xm - 1) * pixelSize + 2]]--;
                                }
                            }
                            if ((X + m) < original.Width)
                            {
                                for (int y = -ym; y <= yM; y++)
                                {
                                    PrB[(o0 + (Y + y) * oS)[(X + m) * pixelSize + 0]]++;
                                    PrG[(o0 + (Y + y) * oS)[(X + m) * pixelSize + 1]]++;
                                    PrR[(o0 + (Y + y) * oS)[(X + m) * pixelSize + 2]]++;
                                }
                            }
                        }
                        else if (!Up)
                        {
                            if ((X + m + 1) < original.Width)
                            {
                                for (int y = -ym; y <= yM; y++)
                                {
                                    PrB[(o0 + (Y + y) * oS)[(X + m + 1) * pixelSize + 0]]--;
                                    PrG[(o0 + (Y + y) * oS)[(X + m + 1) * pixelSize + 1]]--;
                                    PrR[(o0 + (Y + y) * oS)[(X + m + 1) * pixelSize + 2]]--;
                                }
                            }
                            if ((X - m) >= 0)
                            {
                                for (int y = -ym; y <= yM; y++)
                                {
                                    PrB[(o0 + (Y + y) * oS)[(X - m) * pixelSize + 0]]++;
                                    PrG[(o0 + (Y + y) * oS)[(X - m) * pixelSize + 1]]++;
                                    PrR[(o0 + (Y + y) * oS)[(X - m) * pixelSize + 2]]++;
                                }
                            }
                        }

                        SB[0] = PrB[0];
                        SG[0] = PrG[0];
                        SR[0] = PrR[0];

                        for (int i = 1; i < 256; i++)
                        {
                            SB[i] = PrB[i] + SB[i - 1];
                            SG[i] = PrG[i] + SG[i - 1];
                            SR[i] = PrR[i] + SR[i - 1];
                        }
                        (n0 + (Y * nS))[X * pixelSize + 0] = (byte)(SB[(o0 + (Y * oS))[X * pixelSize + 0]] * 255.0 / SB[255]);
                        (n0 + (Y * nS))[X * pixelSize + 1] = (byte)(SG[(o0 + (Y * oS))[X * pixelSize + 1]] * 255.0 / SG[255]);
                        (n0 + (Y * nS))[X * pixelSize + 2] = (byte)(SR[(o0 + (Y * oS))[X * pixelSize + 2]] * 255.0 / SR[255]);
                    }
                    progress.Value = (int)((Y + 1) * 100.0 / original.Height);
                    System.Windows.Forms.Application.DoEvents();
                }

                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }

    }
}
