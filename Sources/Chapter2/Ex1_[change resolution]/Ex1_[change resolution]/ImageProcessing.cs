using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
namespace Ex1__change_resolution_
{
    class ImageProcessing
    {
        public static Bitmap MakeGrayScale(Bitmap original)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);
                int pixelSize = 3;
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow;
                }
                
            }

        }
    }
}
