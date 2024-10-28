using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
namespace Exc3__bit_plane_slicing_
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
        public Bitmap GammaCorrection(Bitmap original, float Gamma)
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
                        byte GammaR = (byte)(Math.Pow((oRow[x * pixelSize] / 255.0), Gamma) * 255.0);
                        byte GammaG = (byte)(Math.Pow((oRow[x * pixelSize + 1] / 255.0), Gamma) * 255.0);
                        byte GammaB = (byte)(Math.Pow((oRow[x * pixelSize + 2] / 255.0), Gamma) * 255.0);

                        nRow[x * pixelSize] = GammaR;
                        nRow[x * pixelSize + 1] = GammaG;
                        nRow[x * pixelSize + 2] = GammaB;
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public Bitmap BitPlaneSlicing(Bitmap original,int bitLevel)
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
                        nRow[x * pixelSize] = (byte)(((oRow[x * pixelSize] & (1 << bitLevel)) > 0) ? 255 : 0);
                        nRow[x * pixelSize+1] = (byte)(((oRow[x * pixelSize+1] & (1 << bitLevel)) > 0) ? 255 : 0);
                        nRow[x * pixelSize+2] = (byte)(((oRow[x * pixelSize+2] & (1 << bitLevel)) > 0) ? 255 : 0);
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }

        }
        public Bitmap BitPlaneSlicingReverse(Bitmap pic8, Bitmap pic7, Bitmap pic6, Bitmap pic5, Bitmap pic4, Bitmap pic3, Bitmap pic2, Bitmap pic1)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(pic8.Width, pic8.Height);
                BitmapData[] picData = new BitmapData[8];
                picData[0] = pic1.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[1] = pic2.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[2] = pic3.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[3] = pic4.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[4] = pic5.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[5] = pic6.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[6] = pic7.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                picData[7] = pic8.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, pic1.Width, pic1.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < pic1.Height; y++)
                {
                    
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < pic1.Width; x++)
                    {
                        nRow[x * pixelSize] = nRow[x * pixelSize + 1] = nRow[x * pixelSize + 2] = 0;
                        for (int k = 0; k < 8; k++)
                        {
                            byte* oRow = (byte*)picData[k].Scan0 + (y * picData[k].Stride);
                            nRow[x * pixelSize] += (byte)((oRow[x * pixelSize] / 255) * Math.Pow(2, k));
                            nRow[x * pixelSize + 1] += (byte)((oRow[x * pixelSize+1] / 255) * Math.Pow(2, k)); ;
                            nRow[x * pixelSize + 2] += (byte)((oRow[x * pixelSize+2] / 255) * Math.Pow(2, k));
                        }
                    }
                }
                newBitmap.UnlockBits(newData);
                pic8.UnlockBits(picData[7]);
                pic7.UnlockBits(picData[6]);
                pic6.UnlockBits(picData[5]);
                pic5.UnlockBits(picData[4]);
                pic4.UnlockBits(picData[3]);
                pic3.UnlockBits(picData[2]);
                pic2.UnlockBits(picData[1]);
                pic1.UnlockBits(picData[0]);
                return newBitmap;
            }

        }
        public Bitmap TwoQuantizationLevels(Bitmap original)
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
                        nRow[x * pixelSize] = (byte)((oRow[x * pixelSize] < 128) ? 0 : 255);
                        nRow[x * pixelSize + 1] = (byte)((oRow[x * pixelSize+1] < 128) ? 0 : 255);
                        nRow[x * pixelSize + 2] = (byte)((oRow[x * pixelSize+2] < 128) ? 0 : 255);
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public Bitmap stretch(Bitmap original, int width,int height)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(width, height);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                double Yconst=(double)height/original.Height;
                double Xconst=(double)width/original.Width;
                int pixelSize = 3;
                for (int y = 0; y < height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + ((int)(y/Yconst) * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        nRow[x * pixelSize + 0] = oRow[(int)(x / Xconst) * pixelSize + 0];
                        nRow[x * pixelSize + 1] = oRow[(int)(x / Xconst) * pixelSize + 1];
                        nRow[x * pixelSize + 2] = oRow[(int)(x / Xconst) * pixelSize + 2];
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
 
        }
    }
}
