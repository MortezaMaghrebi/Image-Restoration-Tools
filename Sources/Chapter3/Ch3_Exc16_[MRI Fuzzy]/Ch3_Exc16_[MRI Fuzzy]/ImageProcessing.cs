using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch3_Exc16__MRI_Fuzzy_
{
    class ImageProcessing
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
        public Bitmap FuzzyEdgeDetection(Bitmap original1,ref double[] Mzero,ref double[] mBL,ref double[] mWH,ref System.Windows.Forms.ProgressBar prg,ref System.Windows.Forms.DataVisualization.Charting.Chart chart1)
        {
            unsafe
            {
                Bitmap original = new Bitmap(ZeroPadding(MakeGrayscale(original1)));
                Bitmap newBitmap = new Bitmap(original1.Width, original1.Height);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, original1.Width, original1.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pxS = 3;
                byte* o0 = (byte*)originalData.Scan0;
                byte* n0 = (byte*)newData.Scan0;
                int oS = originalData.Stride;
                int nS = newData.Stride;
                double m1, m2, m3, m4;
                double mZ;
                double min1,min2;
                double FuzzyAnswer;
                double zSum = 0;
                double Sum = 0;
                for (int y = 0; y < original1.Height; y++)
                {
                    prg.Value = (y+1) * 100 / original.Height;
                    System.Windows.Forms.Application.DoEvents();
                    for (int x = 0; x < original1.Width; x++)
                    {
                        int Y = y + 1;
                        int X = x + 1;
                            
                            m1 = Mzero[(int)((o0 + Y * oS)[(X) * pxS + 0] - (o0 + (Y + 0) * oS)[(X + 1) * pxS + 0]) + 255];
                            m2 = Mzero[(int)((o0 + Y * oS)[(X) * pxS + 0] - (o0 + (Y - 0) * oS)[(X - 1) * pxS + 0]) + 255];
                            m3 = Mzero[(int)((o0 + Y * oS)[(X) * pxS + 0] - (o0 + (Y + 1) * oS)[(X + 0) * pxS + 0]) + 255];
                            m4 = Mzero[(int)((o0 + Y * oS)[(X) * pxS + 0] - (o0 + (Y - 1) * oS)[(X - 0) * pxS + 0]) + 255];

                            mZ = m1;
                            if (m2 < mZ) mZ = m2;
                            if (m3 < mZ) mZ = m3;
                            if (m4 < mZ) mZ = m4;
                            
                            zSum = Sum = 0;
                            for (int z = 0; z < 256; z++)
                            {
                                min1 = (mZ < mWH[z]) ? mZ : mWH[z];
                                min2 = ((1-mZ) < mBL[z]) ? (1-mZ) : mBL[z];
                                FuzzyAnswer = (min1 > min2) ? min1 : min2;
                                zSum += z * FuzzyAnswer;
                                Sum += FuzzyAnswer;
                            }
                            for (int c = 0; c < 3; c++)
                            {
                                (n0 + y * nS)[x * pxS + c] = (byte)(zSum / Sum);
                            }
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        private Bitmap ZeroPadding(Bitmap original)
        {
            unsafe
            {
                int W = 1, H = 1;
                Bitmap newBitmap = new Bitmap(original.Width + 2 * W, original.Height + 2 * H);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + ((y + H) * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            nRow[(x + W) * pixelSize + c] = oRow[x * pixelSize + c];
                        }
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }

        
    }
}
