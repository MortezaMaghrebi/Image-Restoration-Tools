using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch4_Exc1__Aliasing_
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
        public Bitmap MakeChess()
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(256, 256);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0,256, 256), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y <256; y++)
                {
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < 256; x++)
                    {
                        if (y % 2 == x % 2)
                        {
                            nRow[x * pixelSize + 0] = 255;
                            nRow[x * pixelSize + 1] = 255;
                            nRow[x * pixelSize + 2] = 255;
                        }
                    }
                }
                newBitmap.UnlockBits(newData);
                return newBitmap;
            }
        }
        public Bitmap Sampling(Bitmap original,double rate)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap((int)(original.Width / rate), (int)(original.Height / rate));
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, (int)(original.Width/rate), (int)(original.Height/rate)), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                int X = 0; int Y = 0;
                for (double y = 0; (y < original.Height)&&(Y<newBitmap.Height); y+=rate)
                {
                    byte* oRow = (byte*)originalData.Scan0 + ((int)y * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + (Y * newData.Stride);
                    X = 0;
                    for (double x = 0; (x < original.Width) && (X < newBitmap.Width); x += rate)
                    {
                        nRow[X * pixelSize + 0] = oRow[(int)x * pixelSize + 0];
                        nRow[X * pixelSize + 1] = oRow[(int)x * pixelSize + 1];
                        nRow[X * pixelSize + 2] = oRow[(int)x * pixelSize + 2]; 
                        X++;
                    }
                    Y++;
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }

    }
}
