using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ex4__connected_components_
{
    class ImageProccessing
    {
        int stack = 0;
        public int MaxStack = 1000;
        int adjacencytype = 0;
        int maxoffset = 5;
        int XX = 0, YY = 0;
        byte R, G,B;
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
        public Bitmap ConnectedComponent(Bitmap original, int x, int y, int adjacencyType,int maxOffset)
        {
            stack = 0;
            adjacencytype = adjacencyType;
            maxoffset = maxOffset;
            Bitmap answer = new Bitmap(original.Width, original.Height);
            BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData newData = answer.LockBits(new Rectangle(0, 0, answer.Width, answer.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            try
            {
                unsafe
                {
                    R = (byte)(255 - ((byte*)originalData.Scan0 + (y * originalData.Stride))[x * 3]);
                    G = (byte)(255 - ((byte*)originalData.Scan0 + (y * originalData.Stride))[x * 3 + 1]/4);
                    B = (byte)(255 - ((byte*)originalData.Scan0 + (y * originalData.Stride))[x * 3 + 2]/2);
                    for (int i = 0; i < newData.Width; i++)
                    {
                        for (int j = 0; j < newData.Height; j++)
                        {
                            ((byte*)newData.Scan0 + (j * newData.Stride))[i * 3] = R;
                            ((byte*)newData.Scan0 + (j * newData.Stride))[i * 3 + 1] = G;
                            ((byte*)newData.Scan0 + (j * newData.Stride))[i * 3 + 2] = B;
                        }
                    }
                }
                XX = x+1;
                YY = y+1;
                Boolean finished = false;
                while (!finished) { stack = 0; finished = GCC(ref originalData, ref newData, 0, 0, XX, YY); }
                answer.UnlockBits(newData);
                original.UnlockBits(originalData);
            }
            catch {}
            return answer;
        }
        Boolean GCC(ref BitmapData originalData, ref BitmapData newData, int motherX, int motherY, int X, int Y)
        {
            stack++;
            if (stack > MaxStack) { XX = X; YY = Y; return false; }
            unsafe
            {
                if ((X < 0) || (Y < 0)) return false;
                int pixelSize = 3;
                if (!((((byte*)newData.Scan0 + (Y * newData.Stride))[X * pixelSize] == R) || (((byte*)newData.Scan0 + (Y * newData.Stride))[X * pixelSize + 1] == G) || (((byte*)newData.Scan0 + (Y * newData.Stride))[X * pixelSize + 1] == B)))return false;
                ((byte*)newData.Scan0 + (Y * newData.Stride))[X * pixelSize] = ((byte*)originalData.Scan0 + (Y * originalData.Stride))[X * pixelSize];
                ((byte*)newData.Scan0 + (Y * newData.Stride))[X * pixelSize+1] = ((byte*)originalData.Scan0 + (Y * originalData.Stride))[X * pixelSize+1];
                ((byte*)newData.Scan0 + (Y * newData.Stride))[X * pixelSize+2] = ((byte*)originalData.Scan0 + (Y * originalData.Stride))[X * pixelSize+2];
                byte CurrentVal, MotherVal, Val1, Val2;
                MotherVal = ((byte*)originalData.Scan0 + (Y * originalData.Stride))[X * pixelSize];
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((i == motherX) && (j == motherY)) continue;
                        else
                        {
                            try
                            {
                                if (((X + i) < 0) || ((Y + j) < 0)) continue;
                                CurrentVal = ((byte*)originalData.Scan0 + ((Y + j) * originalData.Stride))[(X + i) * pixelSize];
                                Val1 = ((byte*)originalData.Scan0 + ((Y) * originalData.Stride))[(X + i) * pixelSize];
                                Val2 = ((byte*)originalData.Scan0 + ((Y + j) * originalData.Stride))[(X) * pixelSize];

                                if (checkConnectivity(-i, -j, MotherVal, CurrentVal, Val1, Val2, adjacencytype , maxoffset))
                                {
                                    GCC(ref originalData, ref newData, -i, -j, X + i, Y + j);
                                }
                                ((byte*)originalData.Scan0 + (Y * originalData.Stride))[X * pixelSize] = 255;
                            }
                            catch { }
                        }
                    }
                }
            }
            return true;
        }
        Boolean checkConnectivity(int x, int y,int Value1,int Value2,int Value3,int Value4, int adjacencyType, int MaxOffset)
        {
            Boolean ISconnected=false;
            switch (adjacencyType)
            {
                case 0:
                    if ((x * y == 0) && (Math.Abs(Value1 - Value2) <= MaxOffset)) return true;
                    else return false;
                case 1:
                    if (Math.Abs(Value1 - Value2) <= MaxOffset) return true;
                    else return false;
                case 2:
                    if (x * y == 0)
                    {
                        if (Math.Abs(Value1 - Value2) <= MaxOffset) return true;
                        else return false;
                    }
                    else if ((Math.Abs(Value1 - Value2) <= MaxOffset) && (Math.Abs((Value1 + Value2) - (2 * Value3)) > (2 * MaxOffset)) && (Math.Abs((Value1 + Value2) - (2 * Value4)) > (2 * MaxOffset))) return true;
                    else return false;
            }
            return ISconnected;
        }
    }
}
