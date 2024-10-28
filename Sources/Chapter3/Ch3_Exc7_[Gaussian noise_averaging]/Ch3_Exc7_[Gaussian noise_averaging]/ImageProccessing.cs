using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch3_Exc7__Gaussian_noise_averaging_
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
        public void GetValuesOfpicture(Bitmap original, ref double[,] R, ref double[,] G, ref double[,] B)
        {
            unsafe
            {
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        R[x, y] += oRow[x * pixelSize+0];
                        G[x, y] += oRow[x * pixelSize+1];
                        B[x, y] += oRow[x * pixelSize+2];
                    }
                }
                original.UnlockBits(originalData);
            }
        }
        public Bitmap MakeImageFromValues(int width, int height, ref double[,] R, ref double[,] G, ref double[,] B)
        {
            unsafe
            {
                Bitmap original = new Bitmap(width, height);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        oRow[x * pixelSize + 0] = (byte)R[x, y];
                        oRow[x * pixelSize + 1] = (byte)G[x, y];
                        oRow[x * pixelSize + 2] = (byte)B[x, y];
                    }
                }
                original.UnlockBits(originalData);
                return original;
            }
        }
    
    }
}
