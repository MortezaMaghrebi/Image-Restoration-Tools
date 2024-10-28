using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ex2__change_quantization_level_
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
        public Bitmap ChangeQuantizationLevel(Bitmap original,int Q)
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
                        nRow[x * pixelSize] = (byte)((oRow[x * pixelSize] / (int)(256 / Q))*(255 / (Q - 1.0)));
                        nRow[x * pixelSize + 1] = (byte)((oRow[x * pixelSize+1] / (int)(256 / Q))*(255 / (Q - 1.0)));
                        nRow[x * pixelSize + 2] = (byte)((oRow[x * pixelSize+2] / (int)(256 / Q))*(255 / (Q - 1.0)));
                    }
                }
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);
                return newBitmap;
            }
        }
        public double Determine (double[,] Matrix)
        {
            int degree= (int)Math.Sqrt(Matrix.Length);
            double determine = 0;
            if (degree > 2)
            {
                for (int j = 0; j < degree; j++)
                {
                    double[,] subMatrix = new double[degree - 1, degree - 1];
                    for (int x = 0; x < degree - 1; x++)
                    {
                        for (int y = 0; y < degree - 1; y++)
                        {
                            int yy = (y < j) ? y : y + 1;
                            int xx = x + 1;
                            subMatrix[x, y] = Matrix[xx, yy];
                        }
                    }
                    determine += Matrix[0, j] * Math.Pow(-1, j) * Determine(subMatrix);
                }
            }
            else
            {
                determine = (Matrix[0, 0] * Matrix[1, 1]) - (Matrix[0, 1] * Matrix[1, 0]);
            }
            
            return determine;
        }
        public double[] Dastgah(double[,] Coefficient, double[] Value)
        {
            if ((Value.Length * Value.Length) != (Coefficient.Length)) { System.Windows.Forms.MessageBox.Show("incorrect data"); return null; }
            double[] answer = new double[Value.Length];
            double Co_determine = Determine(Coefficient);
            for (int j = 0; j < Value.Length; j++)
            {
                double[,] subMatrix = new double[Value.Length, Value.Length];
                for (int x = 0; x < Value.Length; x++)
                {
                    for (int y = 0; y < Value.Length; y++)
                    {
                        if (y == j) subMatrix[x, y] = Value[x];
                        else subMatrix[x, y] = Coefficient[x, y];
                    }
                }
                answer[j] = Determine(subMatrix) / Co_determine;
            }
            return answer;
        }
    }
}
