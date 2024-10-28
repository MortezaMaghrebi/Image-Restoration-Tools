using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Exc5__histogram_specification_
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
        public Bitmap HistogramSpecification(Bitmap original,double[] Histogram, ref System.Windows.Forms.DataVisualization.Charting.Chart chart1, ref System.Windows.Forms.DataVisualization.Charting.Chart chart2)
        {
            unsafe
            {
                Bitmap newBitmap = new Bitmap(original.Width, original.Height); //yek tasvir jadid va blank ijad mikonad ba tool va arzi barabare tasvire voroodi

                // baraye tasvir ha eshareGar dorost mikonad. az in be ba'd ba esharegar hashoon sarokar darim.
                BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData newData = newBitmap.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                
                //Size har pixel ra moshakhas mikonad. chon tasvir RGB ast 3 byte baraye har pixel darim.
                int pixelSize = 3;

                double[] S = new double[256];  //tabe chegali ehtemal tajamoyie tasvir asli.
                double[] G = new double[256];  //tabe chegali ehtemal tajamoyie tasviri ke mikhaim behesh beresim.

                for (int i = 0; i < 256; i++) S[i] = 0;
                for (int i = 0; i < 256; i++) G[i] = 0;

                //peida kardan histofram tasvir voroodi
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride); //cursor ra mibarad be sotoon y om tasvir.
                    for (int x = 0; x < original.Width; x++)
                    {
                        S[oRow[x * pixelSize]]++; //oRow[x*pixelsize] yani roshanayie pixel (x,y) az tasvir.
                    }
                }

                //rasm histogram voroodi
                chart1.Series.Clear();
                chart1.Series.Add("Gray");
                for (int i = 0; i < 256; i++) chart1.Series["Gray"].Points.Add(S[i]);

                //tabdil histogram voroodi be histogram tajamoyi.
                for (int i = 1; i < 256; i++) S[i] += S[i - 1];
                //normalize kardan histogram tajamoyie tasvir -> S = tabe chegali ehtemale tajamoyie tasvir.
                for (int i = 0; i < 256; i++) S[i] /= S[255];
                
                //tabdile histograme tasvire delkhah ke mikhaim behesh beresim be tabe chegali ehtemale tajamoyi (G ra be dast miAvarad).
                for (int i = 0; i < 256; i++) G[i] = Histogram[i]; //gereftan histogram az voroodi tabe.
                for (int i = 1; i < 256; i++) G[i] += G[i - 1];//tabdil An be jam'e anbareyi.
                for (int i = 0; i < 256; i++) G[i] /= G[255];//normalize kardan An.
                
                //roshanayie tasvir khorooji = andise ozvi az G ke meghdar An barabar meghdar S[roshanayie pixel voroodi] bashad.
                //meghdar An ra ba tabe WhatIsIndex bedast miAvarim
                //WhatIsIndex: parametr aval-> roshanayie pixele tasvire voroodi _  parametre dovvom: Araye G be onvane esharegar
                byte Lum = 0;//baraye khorooji tabe WhatIsIndex.
                
                //Ijad tasvir jadid
                for (int y = 0; y < original.Height; y++)
                {
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride); //cursor tasvir asli ra mibarad be sotoon y om tasvir.
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);//cursor tasvir jadid ra mibarad be sotoon y om tasvir.
                    for (int x = 0; x < original.Width; x++)
                    {
                        Lum = WhatIsIndex(S[oRow[x * pixelSize]], ref G); //roshanayie pixel (x,y) tasvir asli ra migirad va ba tabe WhatIsIndex roshanayie An pixel dar tasvir Jadid ra be dast miAvarad
                        nRow[x * pixelSize + 0] = (Lum); //R_jadid = Lum    
                        nRow[x * pixelSize + 1] = (Lum); //G_jdaid = Lum
                        nRow[x * pixelSize + 2] = (Lum); //B_jadid = Lum
                    }
                }

                //Araye S ra pak mikonad ta histogram tasvir jadid ra be dast biavarad.
                for (int i = 0; i < 256; i++) S[i] = 0;

                //Histogram tasvir jadid ra bedast miAvarad.
                for (int y = 0; y < original.Height; y++)
                {
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
                    for (int x = 0; x < original.Width; x++)
                    {
                        S[nRow[x * pixelSize]]++;
                    }
                }

                //Histogram tasvir jadid ra rasm mikonad.
                chart2.Series.Clear();
                chart2.Series.Add("Gray");
                for (int i = 0; i < 256; i++) chart2.Series["Gray"].Points.Add(S[i]);

                //nou'e nemoodar ra moshakhas mikonad. mikhaham ba taghiir oonha Label ha bazsazi beshan.
                chart1.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart2.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart1.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart2.Series["Gray"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;

                //Tasvir ha ra ghofl mikonad chon be soorate esharegary estefade shode boodan.
                newBitmap.UnlockBits(newData); 
                original.UnlockBits(originalData);
                
                //tasvir jadid ra bar migardanad.
                return newBitmap;
            }
        }
        public void PictureToHistogram(Bitmap original,ref double[] Histogram)
        {
            for(int i=0;i<256;i++)Histogram[i] = 0;

            for (int x = 0; x < original.Width; x ++)
            {
                for (int y = 0; y <original.Height ; y++)
                {
                    if (original.GetPixel(x,y).R > 0)
                    {
                        Histogram[x / 2] += ((original.Height-y-2)/2);
                        break;
                    }
                }
            }
            
        }

        //voroodie in tabe, yek meghdar koochectar az 1 va yek PDF tajamoyi ast. koroji An ozvi az PDF ast ke meghdar An barabae meghdar vodoodi bashad. Mehvar x DPF: adadi bein 0 ta 255
        private byte WhatIsIndex(double pixelValue, ref double[] G)
        {
            byte Lum = 0;
            for (int i = 1; i < 256; i++)
            {
                if (G[i] >= pixelValue)
                {
                    if (Math.Abs(G[i] - pixelValue) > Math.Abs(G[i - 1] - pixelValue)) Lum = (byte)(i-1);
                    else Lum = (byte)i;
                    return Lum;
                }
            }
            return Lum;
        }
    }
}
