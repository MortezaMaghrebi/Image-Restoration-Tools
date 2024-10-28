using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch3_Exc15__Einstein_Fuzzy_
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
        public Bitmap FuzzyContrastStretching(Bitmap original,ref double[] Mdark,ref double[] Mgray,ref double[] Mbright,int Vd,int Vg,int Vb)
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
                        int Z0_R = oRow[x * pixelSize+2];
                        int Z0_G = oRow[x * pixelSize+1];
                        int Z0_B = oRow[x * pixelSize+0];
                        double Vo_R;
                        double Vo_G;
                        double Vo_B;
                        Vo_R = (Mdark[Z0_R] * Vd + Mgray[Z0_R] * Vg + Mbright[Z0_R] * Vb) / (Mdark[Z0_R] + Mgray[Z0_R] + Mbright[Z0_R]);
                        Vo_G = (Mdark[Z0_G] * Vd + Mgray[Z0_G] * Vg + Mbright[Z0_G] * Vb) / (Mdark[Z0_G] + Mgray[Z0_G] + Mbright[Z0_G]);
                        Vo_B = (Mdark[Z0_B] * Vd + Mgray[Z0_B] * Vg + Mbright[Z0_B] * Vb) / (Mdark[Z0_B] + Mgray[Z0_B] + Mbright[Z0_B]);
                        nRow[x * pixelSize + 2] = (byte)Vo_R;
                        nRow[x * pixelSize + 1] = (byte)Vo_G;
                        nRow[x * pixelSize + 0] = (byte)Vo_B;
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
 
        
    }
}
