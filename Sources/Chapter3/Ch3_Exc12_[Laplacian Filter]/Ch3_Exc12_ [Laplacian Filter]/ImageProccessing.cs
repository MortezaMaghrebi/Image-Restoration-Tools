using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch3_Exc9__Laplacian_filter_
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
 
        public  Bitmap MakeBigImage(Bitmap original, string Mode, int Kernelwidth, int Kernelheight)
        {
            int m = Kernelwidth / 2;
            int n = Kernelheight / 2;
            switch (Mode)
            {
                case "Ignore boarders":
                    return original;
                case "Zero padding":
                    return ZeroPadding(original, m, n);
                case "Replicate":
                    return Replicate(original, m, n);
                case "Mirror":
                    return Mirror(original, m, n);
            }
            return original;
        }
        private Bitmap ZeroPadding(Bitmap original,int W,int H)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width + 2 * W, original.Height + 2 * H);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0,newBitmap.Width , newBitmap.Height ), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
                    byte* nRow = (byte*)newData.Scan0 + ((y+H) * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            nRow[(x+W) * pixelSize + c] = oRow[x * pixelSize + c];
                        }
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        private Bitmap Replicate(Bitmap original, int W, int H)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width + (2 * W), original.Height + (2 * H));
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                IntPtr n0 = newData.Scan0;
                IntPtr o0 = originalData.Scan0;
                int nS = newData.Stride;
                int oS = originalData.Stride;

                for (int x = 0; x < newBitmap.Width; x++)
                {
                    for (int y = 0; y < newBitmap.Height; y++)
                    {
                        if (x < W)
                        {
                            if (y < H)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + 0 * oS)[0 * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + 0 * oS)[0 * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + 0 * oS)[0 * pixelSize + 2];
                            }
                            else if (y < H + original.Height)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (y - H) * oS)[0 * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (y - H) * oS)[0 * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (y - H) * oS)[0 * pixelSize + 2];
                            }
                            else
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (original.Height - 1) * oS)[0 * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (original.Height - 1) * oS)[0 * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (original.Height - 1) * oS)[0 * pixelSize + 2];
                            }
                        }
                        else if (x < W + original.Width)
                        {
                            if (y < H)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + 0 * oS)[(x - W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + 0 * oS)[(x - W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + 0 * oS)[(x - W) * pixelSize + 2];
                            }
                            else if (y < H + original.Height)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (y - H) * oS)[(x - W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (y - H) * oS)[(x - W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (y - H) * oS)[(x - W) * pixelSize + 2];
                            }
                            else
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (original.Height - 1) * oS)[(x - W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (original.Height - 1) * oS)[(x - W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (original.Height - 1) * oS)[(x - W) * pixelSize + 2];
                            }
                        }
                        else
                        {
                            if (y < H)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + 0 * oS)[(original.Width - 1) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + 0 * oS)[(original.Width - 1) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + 0 * oS)[(original.Width - 1) * pixelSize + 2];
                            }
                            else if (y < H + original.Height)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (y - H) * oS)[(original.Width - 1) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (y - H) * oS)[(original.Width - 1) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (y - H) * oS)[(original.Width - 1) * pixelSize + 2];
                            }
                            else
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (original.Height - 1) * oS)[(original.Width - 1) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (original.Height - 1) * oS)[(original.Width - 1) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (original.Height - 1) * oS)[(original.Width - 1) * pixelSize + 2];
                            }
                        }
                    }
                }
                
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        private Bitmap Mirror(Bitmap original, int W, int H)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width + (2 * W), original.Height + (2 * H));
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int pixelSize = 3;
                IntPtr n0 = newData.Scan0;
                IntPtr o0 = originalData.Scan0;
                int nS = newData.Stride;
                int oS = originalData.Stride;

                for (int x = 0; x < newBitmap.Width; x++)
                {
                    for (int y = 0; y < newBitmap.Height; y++)
                    {
                        if (x < W)
                        {
                            if (y < H)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (H - y) * oS)[(W - x) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (H - y) * oS)[(W - x) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (H - y) * oS)[(W - x) * pixelSize + 2];
                            }
                            else if (y < H + original.Height)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (y - H) * oS)[(W - x) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (y - H) * oS)[(W - x) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (y - H) * oS)[(W - x) * pixelSize + 2];
                            }
                            else
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(W - x) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(W - x) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(W - x) * pixelSize + 2];
                            }
                        }
                        else if (x < W + original.Width)
                        {
                            if (y < H)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (H - y) * oS)[(x - W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (H - y) * oS)[(x - W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (H - y) * oS)[(x - W) * pixelSize + 2];
                            }
                            else if (y < H + original.Height)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (y - H) * oS)[(x - W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (y - H) * oS)[(x - W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (y - H) * oS)[(x - W) * pixelSize + 2];
                            }
                            else
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(x - W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(x - W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(x - W) * pixelSize + 2];
                            }
                        }
                        else
                        {
                            if (y < H)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (H - y) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (H - y) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (H - y) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 2];
                            }
                            else if (y < H + original.Height)
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (y - H) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (y - H) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (y - H) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 2];
                            }
                            else
                            {
                                ((byte*)n0 + y * nS)[x * pixelSize + 0] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 0];
                                ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 1];
                                ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)o0 + (2 * original.Height - 1 - y + H) * oS)[(2 * original.Width - 1 - x + W) * pixelSize + 2];
                            }
                        }
                    }
                } 

                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public Bitmap LaplacianFilter(Bitmap original, int[,] Kernel, ref System.Windows.Forms.ProgressBar prg,Boolean add,int Coefficient)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width - 2 , original.Height - 2 );
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int[,] newPicture = new int[newBitmap.Width, newBitmap.Height];
                IntPtr n0 = newData.Scan0;
                IntPtr o0 = originalData.Scan0;
                int nS = newData.Stride;
                int oS = originalData.Stride;
                int pixelSize = 3;
                int min = 0;
                int max = 0;
                for (int y = 1; y < original.Height - 1; y++)
                {
                    for (int x = 1; x < original.Width - 1; x++)
                    {
                        int pixVal = 0;
                        
                        for (int j = -1; j <= 1; j++)
                        {
                            for (int i = -1; i <= 1; i++)
                            {
                                pixVal += ((((byte*)o0 + (y + j) * oS)[(x + i) * pixelSize])*Kernel[i+1,j+1]);
                            }
                        }
                        pixVal /= 9;
                        if (x == 1 && y == 1) min = max = pixVal;
                        if (pixVal < min) min = pixVal;
                        else if (pixVal > max) max = pixVal;
                        newPicture[x - 1, y - 1] = pixVal;
                    }
                    prg.Value = (y+1) * 97 / (original.Height);
                    System.Windows.Forms.Application.DoEvents();
                }
                if (!add)
                {
                    for (int y = 0; y < newBitmap.Height; y++)
                    {
                        for (int x = 0; x < newBitmap.Width; x++)
                        {
                            ((byte*)n0 + y * nS)[x * pixelSize + 0] = (byte)((newPicture[x, y] - min) * 255.0 / (max - min));
                            ((byte*)n0 + y * nS)[x * pixelSize + 1] = ((byte*)n0 + y * nS)[x * pixelSize + 0];
                            ((byte*)n0 + y * nS)[x * pixelSize + 2] = ((byte*)n0 + y * nS)[x * pixelSize + 0];
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                else Sum2(ref originalData, ref newPicture, ref newData , Coefficient);
                prg.Value = 100;
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        
        }
        public Bitmap Sum(Bitmap original1, Bitmap original2)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original1.Width, original1.Height);
                BitmapData originalData1 = original1.LockBits(new Rectangle(0, 0, original1.Width, original1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData originalData2 = original2.LockBits(new Rectangle(0, 0, original1.Width, original1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, original1.Width, original1.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                int[,] Pix = new int[original1.Width, original1.Height];
                int min=0, max=0;
                int pixelSize = 3;

                for (int y = 0; y < original1.Height; y++)
                {
                    byte* oRow1 = (byte*)originalData1.Scan0 + (y * originalData1.Stride);
                    byte* oRow2 = (byte*)originalData2.Scan0 + (y * originalData2.Stride);
                    if(y==0) min = max = oRow1[0 * pixelSize] + oRow2[0 * pixelSize];
                    for (int x = 0; x < original1.Width; x++)
                    {
                        Pix[x, y] = oRow1[x * pixelSize] + oRow2[x * pixelSize];
                        if (Pix[x, y] > max) max = Pix[x, y];
                        if (Pix[x, y] < min) min = Pix[x, y];
                    }
                }
                for (int y = 0; y < newBitmap.Height; y++)
                {
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < newBitmap.Width; x++)
                    {

                        nRow[x * pixelSize + 0] = (byte)((Pix[x, y] - min) * 255.0 / (max - min));
                        nRow[x * pixelSize + 1] = nRow[x * pixelSize + 0];
                        nRow[x * pixelSize + 2] = nRow[x * pixelSize + 0];
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                newBitmap.UnlockBits(newData);
                original1.UnlockBits(originalData1);
                original2.UnlockBits(originalData2); 
                return newBitmap;
            }

        }
        public void Sum2(ref BitmapData originalData1,ref int[,] picture2,ref BitmapData newData,int Coefficient)
        {
            unsafe
            {
                int[,] Pix = new int[originalData1.Width, originalData1.Height];
                int min = 0, max = 0;
                int pixelSize = 3;

                for (int y = 1; y < originalData1.Height-1; y++)
                {
                    byte* oRow1 = (byte*)originalData1.Scan0 + (y * originalData1.Stride);
                    if (y == 1) min = max = oRow1[1 * pixelSize] + picture2[0,0]*Coefficient;
                    for (int x = 1; x < originalData1.Width-1; x++)
                    {
                        Pix[x-1, y-1] = oRow1[x * pixelSize] + picture2[x-1,y-1]*Coefficient;
                        if (Pix[x-1, y-1] > max) max = Pix[x-1, y-1];
                        if (Pix[x-1, y-1] < min) min = Pix[x-1, y-1];
                    }
                }
                for (int y = 0; y < originalData1.Height-2; y++)
                {
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < originalData1.Width-2; x++)
                    {
                        nRow[x * pixelSize + 0] = (byte)((Pix[x, y] - min) * 255.0 / (max - min));
                        nRow[x * pixelSize + 1] = nRow[x * pixelSize + 0];
                        nRow[x * pixelSize + 2] = nRow[x * pixelSize + 0];
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
            }

        }
        private void sort(ref int[] array)
        {
             int i , j , item;
             for (i = array.Length - 1; i > 0; i--)
             {
                 for (j = 0; j < i; j++) 
                 {
                     if (array[j] > array[j + 1]) 
                     {
                         item = array[j];
                         array[j] = array[j + 1];
                         array[j + 1] = item;
                     }
                 }
             }
        }

    }
}
