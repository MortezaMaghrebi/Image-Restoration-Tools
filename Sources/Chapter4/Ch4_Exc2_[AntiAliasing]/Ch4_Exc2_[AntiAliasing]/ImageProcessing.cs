using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ch4_Exc2__AntiAliasing_
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

        public Bitmap MakeBigImage(Bitmap original, string Mode, int Kernelwidth, int Kernelheight)
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
        private Bitmap ZeroPadding(Bitmap original, int W, int H)
        {
            unsafe
            {
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
        public Bitmap AveragingFilter(Bitmap original, int W, int H, ref System.Windows.Forms.ProgressBar prg)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width - 2 * W, original.Height - 2 * H);
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                IntPtr n0 = newData.Scan0;
                IntPtr o0 = originalData.Scan0;
                int nS = newData.Stride;
                int oS = originalData.Stride;
                int pixelSize = 3;

                for (int y = H; y < original.Height - H; y++)
                {
                    for (int x = W; x < original.Width - W; x++)
                    {
                        double[] C = new double[3];
                        for (int c = 0; c < 3; c++)
                        {
                            for (int i = -W; i <= W; i++)
                            {
                                for (int j = -H; j <= H; j++)
                                {
                                    C[c] += ((byte*)o0 + (y + j) * oS)[(x + i) * pixelSize + c];
                                }
                            }
                            ((byte*)n0 + (y - H) * nS)[(x - W) * pixelSize + c] = (byte)(C[c] / ((2 * W + 1) * (2 * H + 1)));
                        }
                    }
                    prg.Value = (y - H + 1) * 100 / (original.Height - 2 * H);
                    System.Windows.Forms.Application.DoEvents();
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }


    }
}
