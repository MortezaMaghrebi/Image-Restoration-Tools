using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Exc2__piecewise_linear_contrast_streching_
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
        public Bitmap PiecewiseLinearContrasting(Bitmap original,ref double[]function)
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
                        nRow[x * pixelSize + 0] = (byte)(function[oRow[x * pixelSize + 0]] * 255.0);
                        nRow[x * pixelSize + 1] = (byte)(function[oRow[x * pixelSize + 1]]*255.0);
                        nRow[x * pixelSize + 2] = (byte)(function[oRow[x * pixelSize + 2]]*255.0);
                    }
                    
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }

    }
}
