using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fourier;
namespace Ch4_Exc6__Advanced_filtering_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
        ImageProcessing ImProcess = new ImageProcessing();
        private Point mouseOffset;
        private bool isMouseDown = false;
        PictureBox btnNow;
        Fourier.Fourier fourier = new Fourier.Fourier();
        struct IMAGE
        {
            public PictureBox picture;
            public Fourier.Fourier.number[,] complex;
            public int index;
            public int width, height;
        }
        IMAGE[] img;
        int Ni, Ri;
        Boolean isPicMoving = false;
        Boolean isPicResizing = false;
        Boolean isDrawFilter = false;
        Point PicmousePos;
        Point PicPos;
        Point center; int radius;
        double picX,picY;
        int picHeight;
        private bool isRightMouseDown = false; int YY, XX, XXy, Xx1 = 0, Xx2 = 0, Xx3 = 0, IsX = 0, OPC; double OPCT = 1;
        #endregion
        #region Body
        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            Refresh();
            Application.DoEvents();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            System.Threading.Thread.Sleep(500);
            img = new IMAGE[20];
            Ni = -1; Ri = -1;
            for (int i = 0; i < 20; i++)
            {
                Application.DoEvents();
                img[i].picture = new PictureBox();
                img[i].picture.MouseMove += pic_MouseMove;
                img[i].picture.MouseUp += pic_MouseUp;
                img[i].picture.MouseDoubleClick += pic_MouseDoubleClick;
                img[i].picture.Visible = false;
                panel1.Controls.Add(img[i].picture);
                img[i].picture.Width = 26; img[i].picture.Height = 15;
                img[i].picture.Left = 20;
                img[i].picture.Top = 40 + i * 20;
                img[i].picture.BackgroundImageLayout = ImageLayout.Zoom;
                img[i].picture.SizeMode = PictureBoxSizeMode.Zoom;
                System.Threading.Thread.Sleep(10);
                img[i].picture.Refresh();
                img[i].picture.BorderStyle = BorderStyle.FixedSingle;
                img[i].picture.Name = "Picture" + (i + 1).ToString();
                
            }
            
            img[0 ].picture.MouseDown  += new MouseEventHandler(pic0_MouseDown);
            img[1 ].picture.MouseDown  += new MouseEventHandler(pic1_MouseDown);
            img[2 ].picture.MouseDown  += new MouseEventHandler(pic2_MouseDown);
            img[3 ].picture.MouseDown  += new MouseEventHandler(pic3_MouseDown);
            img[4 ].picture.MouseDown  += new MouseEventHandler(pic4_MouseDown);
            img[5 ].picture.MouseDown  += new MouseEventHandler(pic5_MouseDown);
            img[6 ].picture.MouseDown  += new MouseEventHandler(pic6_MouseDown);
            img[7 ].picture.MouseDown  += new MouseEventHandler(pic7_MouseDown);
            img[8 ].picture.MouseDown  += new MouseEventHandler(pic8_MouseDown);
            img[9 ].picture.MouseDown  += new MouseEventHandler(pic9_MouseDown);
            img[10].picture.MouseDown += new MouseEventHandler(pic10_MouseDown);
            img[11].picture.MouseDown += new MouseEventHandler(pic11_MouseDown);
            img[12].picture.MouseDown += new MouseEventHandler(pic12_MouseDown);
            img[13].picture.MouseDown += new MouseEventHandler(pic13_MouseDown);
            img[14].picture.MouseDown += new MouseEventHandler(pic14_MouseDown);
            img[15].picture.MouseDown += new MouseEventHandler(pic15_MouseDown);
            img[16].picture.MouseDown += new MouseEventHandler(pic16_MouseDown);
            img[17].picture.MouseDown += new MouseEventHandler(pic17_MouseDown);
            img[18].picture.MouseDown += new MouseEventHandler(pic18_MouseDown);
            img[19].picture.MouseDown += new MouseEventHandler(pic19_MouseDown);
            Ni = -1 ; lblSelect.Text = "Selected picture: None";
            Ni = -1; lblResult.Text = "Display result in: None";
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            lineShape1.X1 = lineShape1.Y1 = lineShape1.X2 = 0; lineShape1.Y2 = Height - 1;
            lineShape2.X1 = lineShape2.Y1 = lineShape2.Y2 = 0; lineShape2.X2 = Width - 1;
            lineShape3.X1 = lineShape3.X2 = Width - 1; lineShape3.Y1 = 0; lineShape3.Y2 = Height - 1;
            lineShape4.Y1 = lineShape4.Y2 = Height - 1; lineShape4.X1 = 0; lineShape4.X2 = Width - 1;
            lineShape5.Y1 = lineShape5.Y2 = panel1.Top+13; lineShape5.X1 = 1; lineShape5.X2 = Width - 2;
            picIm.Left = Width - picIm.Width - picMax.Width - picExit.Width - 1;
            picMax.Left = picIm.Left + picIm.Width;
            picExit.Left = picIm.Left + picIm.Width + picMax.Width;
            panel1.Width = Width - 24;
            panel1.Height = Height - 61;
            lblSelect.Width = Width - 732;
            lblResult.Width = Width - 732;
            picResize.Left = Width - 17;
            picResize.Top = Height - 17;
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            picMax_MouseUp(sender, e);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                isRightMouseDown = true;
                YY = e.Y;
                OPC = (int)(Opacity * 100);

            }

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X + 3, mouseOffset.Y + 26);
                Location = mousePos;
            }
            if (isRightMouseDown)
            {
                Opacity = (OPC + e.Y - YY) / 100.0;
                if (IsX == 0) { IsX = 1; XX = e.X; XXy = e.Y; Xx1 = 0; Xx2 = 0; Xx3 = 0; }
                if (((XX - e.X) > 100) && (Xx1 == 0) && (!((XXy - e.Y) > 20))) { Xx1 = 1; System.Media.SystemSounds.Exclamation.Play(); }
                if (((e.X - XX) > 35) && (Xx1 == 1) && (Xx2 == 0)) { Xx2 = 1; System.Media.SystemSounds.Exclamation.Play(); }
                if ((e.Y - XXy > 80) && (Xx1 * Xx2 == 1) && (Xx3 == 0)) { Xx3 = 1; System.Media.SystemSounds.Hand.Play(); }
                if ((XXy - e.Y) > 20) { Xx1 = 0; Xx2 = 0; Xx3 = 0; }

            }
            if (Opacity < 0.06) Opacity = 0.05;
            else if (Opacity > 0.99) Opacity = 1;
            OPCT = Opacity;

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                isRightMouseDown = false;
                if ((Xx1 * Xx2 * Xx3) == 1) Close();
                IsX = 0;
            }

        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
        }

        string isolate(string path)
        {
            if (path == null) path = "";
            string fname = "";
            Boolean found = false;
            int i;
            for (i = path.Length - 1; (!found) && (i >= 0); i--)
            {
                if (path[i].ToString() == "\\") { found = true; break; }
            }
            if (found) fname = path.Substring(i + 1, path.Length - i - 1);
            return fname;
        }

        private void picIm_MouseEnter(object sender, EventArgs e)
        {
            picIm.BackColor = Color.White;
        }
        private void picIm_MouseDown(object sender, MouseEventArgs e)
        {
            picIm.BackColor = Color.SteelBlue;
        }
        private void picIm_MouseUp(object sender, MouseEventArgs e)
        {
            picIm.BackColor = Color.White;
            WindowState = FormWindowState.Minimized;
        }
        private void picIm_MouseLeave(object sender, EventArgs e)
        {
            picIm.BackColor = Color.Transparent;
        }
        private void picExit_MouseEnter(object sender, EventArgs e)
        {
            picExit.BackColor = Color.White;
        }
        private void picExit_MouseDown(object sender, MouseEventArgs e)
        {
            picExit.BackColor = Color.SteelBlue;
        }
        private void picExit_MouseUp(object sender, MouseEventArgs e)
        {
            picExit.BackColor = Color.White;
            this.Close();
        }
        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.BackColor = Color.Transparent;
        }
        private void picMax_MouseEnter(object sender, EventArgs e)
        {
            picMax.BackColor = Color.White;
        }
        private void picMax_MouseDown(object sender, MouseEventArgs e)
        {
            picMax.BackColor = Color.SteelBlue;
        }
        private void picMax_MouseUp(object sender, MouseEventArgs e)
        {
            picMax.BackColor = Color.White;
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Maximized;
            else WindowState = FormWindowState.Normal;
        }
        private void picMax_MouseLeave(object sender, EventArgs e)
        {
            picMax.BackColor = Color.Transparent;
        }
        
        #endregion
        #region pictures
        private void pic0_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[0], e); Ni = 0;
        }
        private void pic1_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[1], e); Ni = 1;
        }
        private void pic2_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[2], e); Ni = 2;
        }
        private void pic3_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[3], e); Ni = 3;
        }
        private void pic4_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[4], e); Ni = 4;
        }
        private void pic5_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[5], e); Ni = 5;
        }
        private void pic6_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[6], e); Ni = 6;
        }
        private void pic7_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[7], e); Ni = 7;
        }
        private void pic8_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[8], e); Ni = 8;
        }
        private void pic9_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[9], e); Ni = 9;
        }
        private void pic10_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[10], e); Ni = 10;
        }
        private void pic11_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[11], e); Ni = 11;
        }
        private void pic12_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[12], e); Ni=12;
        }
        private void pic13_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[13], e); Ni=13;
        }
        private void pic14_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[14], e); Ni=14;
        }
        private void pic15_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[15], e); Ni=15;
        }
        private void pic16_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[16], e); Ni=16;
        }
        private void pic17_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[17], e); Ni=17;
        }
        private void pic18_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[18], e); Ni=18;
        }
        private void pic19_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown(ref img[19], e); Ni=19;
        } 

        private void pMouseDown(ref IMAGE img1,MouseEventArgs e)
        {
            img1.picture.BringToFront();
            lblSelect.Text = "Selected picture: " + img1.picture.Name;
            if (e.Button == MouseButtons.Left)
            {
                PicmousePos = Control.MousePosition;
                PicPos = img1.picture.Location;
                isPicMoving = true;
                if(isDrawFilter) center = new Point(e.X*img[Ni].picture.BackgroundImage.Width/img[Ni].picture.Width,e.Y*img[Ni].picture.BackgroundImage.Height/img[Ni].picture.Height);
            }
            else if (e.Button == MouseButtons.Right && !isDrawFilter)
            {
                PicmousePos = Control.MousePosition;
                isPicResizing = true;
                picHeight = img1.picture.Height;
                picX = (double)e.X / img1.picture.Width;
                picY = (double)e.Y / img1.picture.Height;
                PicPos = new Point(e.X + img1.picture.Location.X, e.Y + img1.picture.Location.Y);
            }
            else if (e.Button == MouseButtons.Right && isDrawFilter)
            {
                img[Ni].picture.Image = null;
            }
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPicMoving)
            {
                if (isDrawFilter)
                {
                    radius = (int)Math.Sqrt(Math.Pow(e.X * img[Ni].picture.BackgroundImage.Width / img[Ni].picture.Width - center.X, 2) + Math.Pow(e.Y * img[Ni].picture.BackgroundImage.Height / img[Ni].picture.Height - center.Y, 2));
                }
                else
                {
                    Point mousePos = Control.MousePosition;
                    int x = mousePos.X - PicmousePos.X + PicPos.X;//if (x < -(img[Ni].picture.Width - panel1.Width)) x = -(img[Ni].picture.Width - panel1.Width); if (x > 0) x = 0; 
                    int y = mousePos.Y - PicmousePos.Y + PicPos.Y;//if (y < -(img[Ni].picture.Height - panel1.Height)) y = -(img[Ni].picture.Height - panel1.Height); if (y > 0) y = 0; 
                    img[Ni].picture.Location = new Point(x, y);
                }
            }
            if (isPicResizing)
            {
                Point mousePos = Control.MousePosition;
                double y = mousePos.Y - PicmousePos.Y;
                int h;
                h = (int)(picHeight + y * 2);
                if (h > 5000) h = 5000;
                if (h < 14) h = 14;

                if (h > 14 && h < 5000)
                {
                    img[Ni].picture.Height = h;
                    img[Ni].picture.Width = img[Ni].picture.Height * img[Ni].picture.BackgroundImage.Width / img[Ni].picture.BackgroundImage.Height;
                    img[Ni].picture.Left = (int)(PicPos.X - img[Ni].picture.Width * picX);
                    img[Ni].picture.Top = (int)(PicPos.Y - img[Ni].picture.Height * picY);
                }
            }
            if (Opacity < 0.06) Opacity = 0.05;
            else if (Opacity > 0.99) Opacity = 1;
            OPCT = Opacity;
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawFilter)
            {
                Bitmap filter;
                if (img[Ni].picture.Image == null)
                {
                    filter = new Bitmap(img[Ni].picture.BackgroundImage);
                    for (int i = 0; i < filter.Width; i++)
                    {
                        for (int j = 0; j < filter.Height; j++)
                        {
                            filter.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                        }
                    }

                }
                else filter = new Bitmap(img[Ni].picture.Image);
                if (isPicMoving && isDrawFilter)
                {
                    Double[] NotchFilter = getFilter();
                    for (int i = center.X-radius; i <= center.X+radius; i++)
                    {
                        for (int j = center.Y-radius; j <= center.Y+radius; j++)
                        {
                            double r = Math.Sqrt(Math.Pow(i - center.X, 2) + Math.Pow(j - center.Y, 2));
                            if (radius == 0) radius = 1;
                            int index = (int)r * 255 / radius;
                            if (index > 255) index = 255;
                            int alfa=0, alfa2=0;
                            if (i > 0 && i < filter.Width && j > 0 && j < filter.Height)
                            {
                                alfa = (int)(255 - 2 * NotchFilter[index] * 2);
                                alfa2 = filter.GetPixel(i, j).A;
                            }
                            if (r <= radius)
                            {
                                if (alfa2 > 0) if (alfa < alfa2) alfa = alfa2;
                                if (i > 0 && i < filter.Width && j > 0 && j < filter.Height)
                                {
                                    try
                                    {
                                        int Cx = filter.Width / 2, Cy = filter.Height / 2;
                                        filter.SetPixel(i, j, Color.FromArgb(alfa, 0, 0, 0));
                                        filter.SetPixel(Cx + (Cx - i), Cy + (Cy - j), Color.FromArgb(alfa, 0, 0, 0));
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
                img[Ni].picture.Image = filter;
                img[Ni].picture.SizeMode = PictureBoxSizeMode.Zoom;
            } isPicMoving = false;
            isPicResizing = false;
        }
        private void pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double w = img[Ni].picture.Width,h = img[Ni].picture.Height;
            double H = ((double)img[Ni].picture.BackgroundImage.Height / img[Ni].picture.BackgroundImage.Width);
            double Xc = img[Ni].picture.Left + (img[Ni].picture.Width / 2), Yc = img[Ni].picture.Top + (img[Ni].picture.Height / 2);
            int k = 0,L,T;
            while (Math.Abs(w - 300) > 2)
            {
                k = 1;
                w = ((w * 9) + 300) / 10;
                img[Ni].picture.Width = (int)w;
                img[Ni].picture.Height = (int)(w * H);
                L = (int)(Xc - img[Ni].picture.Width / 2);
                if (img[Ni].picture.Width + L < 0) L = -img[Ni].picture.Width +20;
                else if (L > panel1.Width) L = panel1.Width -20;
                T = (int)(Yc - img[Ni].picture.Height / 2);
                if (img[Ni].picture.Height + T < 0) T = -img[Ni].picture.Height +20;
                else if (T > panel1.Height) T = panel1.Height -20;
                img[Ni].picture.Location = new Point(L, T);
                img[Ni].picture.Refresh(); System.Threading.Thread.Sleep(1);
            }
            if (k == 0)
            {
                while (Math.Abs(w - img[Ni].picture.BackgroundImage.Width) > 2)
                {
                    k = 1;
                    w = ((w * 9) + img[Ni].picture.BackgroundImage.Width) / 10;
                    img[Ni].picture.Width = (int)w;
                    img[Ni].picture.Height = (int)(w * H);
                    img[Ni].picture.Left = (int)(Xc - img[Ni].picture.Width / 2);
                    img[Ni].picture.Top = (int)(Yc - img[Ni].picture.Height / 2);
                    img[Ni].picture.Refresh(); System.Threading.Thread.Sleep(1);
                }
            }
        }

        void fit(ref PictureBox pic)
        {
            if ((double)(pic.Height / pic.Width) > (double)(pic.BackgroundImage.Height / pic.BackgroundImage.Width)) pic.Height = pic.Width * pic.BackgroundImage.Height / pic.BackgroundImage.Width;
            else pic.Width = pic.Height * pic.BackgroundImage.Width / pic.BackgroundImage.Height;
            if (pic.Width + pic.Left < 0) pic.Left = -pic.Width + 20;
            else if (pic.Left > panel1.Width) pic.Left = panel1.Width - 20;
            if (pic.Height + pic.Top < 0) pic.Top = -pic.Height + 20;
            else if (pic.Top > panel1.Height) pic.Top = panel1.Height - 20;
        }
        #endregion
        #region Buttons
        void btnMouseDown(object sender, MouseEventArgs e)
        {
            btnNow.SizeMode = PictureBoxSizeMode.Normal;
        }
        void btnMouseUp(object sender, MouseEventArgs e)
        {
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            switch (btnNow.Name)
            {
                case "btnSort":
                    int k = 0;
                    for (int i = 0; i < 20; i++)
                    {
                        Application.DoEvents();
                        img[i].picture.Width = 26; img[i].picture.Height = 15;
                        img[i].picture.Left = 20;
                        img[i].picture.Top = 40 + k * 20;
                        if (img[i].picture.Visible) k++;
                        System.Threading.Thread.Sleep(50);
                        img[i].picture.Refresh();
                    }
                    break;
                case "btnOpen":
                    op.ShowDialog();
                    try
                    {
                        if (Ni>=0)
                        {
                            picPicture.Load(op.FileName);
                            img[Ni].picture.BackgroundImage = picPicture.Image;
                            img[Ni].complex = fourier.complex((Bitmap)img[Ni].picture.BackgroundImage);
                            img[Ni].picture.Name = isolate(op.FileName);
                            lblSelect.Text = "Selected picture: " + img[Ni].picture.Name;
                            fit(ref img[Ni].picture);
                        }
                    }
                    catch { }
                    break;
                case "btnSave":
                    sv.ShowDialog();
                    try { img[Ni].picture.BackgroundImage.Save(sv.FileName); }
                        catch{MessageBox.Show("Error on saving image");}
                    break;
                case "btnSelect":
                    Ri = Ni;
                    lblResult.Text = "Display result in: " + img[Ri].picture.Name;
                    break;
                case "btnFFT2":
                    if (Ni>=0 && Ri>=0)
                    {
                        img[Ri].complex=fourier.FFT2(img[Ni].complex);
                        double[,] buf = fourier.log(fourier.abs(fourier.fftshift(img[Ri].complex)));
                        img[Ri].picture.BackgroundImage = fourier.NormalizeImage(buf, buf.GetLength(0), buf.GetLength(1));
                        img[Ri].width = img[Ni].picture.BackgroundImage.Width;
                        img[Ri].height = img[Ni].picture.BackgroundImage.Height;
                        fit(ref img[Ri].picture);
                    }
                    break;
                case "btniFFT2":
                    if (Ri>=0 && Ni>=0)
                    {
                        if (img[Ni].picture.Image!=null)
                        {
                            Bitmap Notches = new Bitmap(img[Ni].picture.Image);
                            Fourier.Fourier.number[,] filtered = Filter(ref Notches,ref img[Ni].complex);
                            img[Ri].complex = fourier.iFFT2(filtered);
                        }
                        else img[Ri].complex =fourier.iFFT2(img[Ni].complex); 
                        double[,] buf = fourier.abs(img[Ri].complex);
                        try
                        {
                            img[Ri].picture.BackgroundImage = fourier.NormalizeImage(buf, img[Ni].width, img[Ni].height);
                        }
                        catch 
                        {
                            img[Ri].picture.BackgroundImage = fourier.NormalizeImage(buf, img[Ri].complex.GetLength(0), img[Ri].complex.GetLength(1));
                        }
                        fit(ref img[Ri].picture);
                    }
                    break;
                case "btnMakefilter":
                    if (pnlfilter.Visible == false)
                    {
                        pnlfilter.Left = (panel1.Width - pnlfilter.Width) / 2;
                        pnlfilter.Top = (panel1.Height - pnlfilter.Height) / 2;
                    }
                    pnlfilter.Visible = !pnlfilter.Visible;
                    pnlfilter.BringToFront();
                    label1.Text = "Drawing filter = " + (pnlfilter.Visible?"On":"Off");
                    break;
                case "btnNotchfilter":
                    isDrawFilter = !isDrawFilter;
                    label1.Text = "Placing filter = " + (isDrawFilter?"On":"Off");
                    break;
            }
        }
        void btnMouseLeave(object sender, EventArgs e)
        {
            btnNow.SizeMode = PictureBoxSizeMode.Normal;
        }
        private void btnSort_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnSort;
            btnSort.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Arrange pictures"; 
        }
        private void btnOpen_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnOpen; 
            btnOpen.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Load a picture";
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnSave;
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Save selected image";
        }
        private void btnSelect_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnSelect;
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Select for results";
        }
        private void btnFFT2_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnFFT2;
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Get fourier transform";
        }
        private void btniFFT2_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btniFFT2;
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Reverse fourier transform";
        }
        private void btnMakefilter_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnMakefilter;
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Change the filter";
        }
        private void btnNotchfilter_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn();
            btnNow = btnNotchfilter;
            btnNow.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "Place notch filters";
        }
        void refreshBtn()
        {
            label1.Text = "Advanced filtering";
            btnFFT2.SizeMode = PictureBoxSizeMode.Normal;
            btniFFT2.SizeMode = PictureBoxSizeMode.Normal;
            btnMakefilter.SizeMode = PictureBoxSizeMode.Normal;
            btnNotchfilter.SizeMode = PictureBoxSizeMode.Normal;
            btnOpen.SizeMode = PictureBoxSizeMode.Normal;
            btnSave.SizeMode = PictureBoxSizeMode.Normal;
            btnSelect.SizeMode = PictureBoxSizeMode.Normal;
            btnSort.SizeMode = PictureBoxSizeMode.Normal;
            Application.DoEvents();
        }
        #endregion
        #region Filter
        private void line(int x1, int y1, int x2, int y2)
        {
            try
            {
                Bitmap a = new Bitmap(picHistogram.Image);
                for (int i = x1; i <= x2; i += Math.Sign(x2 - x1))
                {
                    int j = (int)((double)(i - x1) * (y2 - y1) / (x2 - x1)) + y1;
                    for (int k = j; k < a.Height; k += 2) a.SetPixel(i, k, Color.Red);
                }

                picHistogram.Image = a;
            }
            catch { }
        }

        int x1, x2 = 256, y1, y2 = 128;
        private void picHistogram_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > x2 || e.X == 0)
                {
                    x1 = x2;
                    y1 = y2;
                    x2 = e.X;
                    y2 = e.Y;
                    line(x1, y1, x2, y2);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                picHistogram.Image = new Bitmap(256, 128);
                x1 = x2 = y1 = 0;
                y2 = 128;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            double [,]filter = new double[1,1];
            int W = 512;
            int H = 512;
            int r = trackBar1.Value;
            picHistogram.Image = new Bitmap(256, 128);

            switch (comboBox1.SelectedItem.ToString())
            {
                case "High pass":
                    switch (comboBox2.SelectedItem.ToString())
                    {
                        case "Ideal":
                            filter = ImProcess.IdealLowPassFilter(W, H, r);
                            break;
                        case "Butterworth":
                            filter = ImProcess.ButterworthLowPassFilter(W, H, r,2);
                            break;
                        case "Gaussian":
                            filter = ImProcess.GaussianLowPassFilter(W, H, r);
                            break;
                    }
                    break;
                case "Low pass":
                    switch (comboBox2.SelectedItem.ToString())
                    {
                        case "Ideal":
                            filter = ImProcess.IdealHighPassFilter(W, H, r);
                            break;
                        case "Butterworth":
                            filter = ImProcess.ButterworthHighPassFilter(W, H, r, 2);
                            break;
                        case "Gaussian":
                            filter = ImProcess.GaussianHighPassFilter(W, H, r);
                            break;
                    }
                    break;
            }
            for (int x = 256; x < 511; x++)
            {
                x1 = (x-256);
                y1 = (int)(filter[x,256]*128);
                x2 = x1+1;
                y2 = (int)(filter[x+1, 256] * 128);
                line(x1, y1, x2, y2);

            }
        }
        public double[] getFilter()
        {
            Double[] Filter = new double[256];
            if(picHistogram.Image==null)
            {
                MessageBox.Show("Please draw a histogram for the filter");
                return null;
            }
            Bitmap original =  new Bitmap(picHistogram.Image);
            for (int i = 0; i < 256; i++) Filter[i] = 0;

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 128; y++)
                {
                    if (original.GetPixel(x, y).R > 0)
                    {
                        Filter[x] += ((128 - y - 2) / 2);
                        break;
                    }
                }
            }
            return Filter;
        }

        public Fourier.Fourier.number[,] Filter(ref Bitmap Hf,ref Fourier.Fourier.number[,] Fuv)
        {
            Fourier.Fourier.number[,] shifted = fourier.fftshift(Fuv);
            double abs, angle;

            for (int x = 0; x < Fuv.GetLength(0); x++)
            {
                for (int y = 0; y < Fuv.GetLength(1); y++)
                {
                    abs = shifted[x, y].abs();
                    angle = shifted[x, y].angle();
                    abs *= ((255 - Hf.GetPixel(x, y).A) / 255.0);
                    shifted[x, y].FromAbsAngle(abs, angle);
                }
            }
            return fourier.ifftshift(shifted);
        }

        #endregion

        private void lblNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Boolean found = false;
            int i = 0;
            while (!found && i<20)
            {
                if (img[i].picture.Visible == false)
                {
                    img[i].picture.BringToFront();
                    img[i].picture.BackgroundImage = picPicture.BackgroundImage;
                    img[i].complex = fourier.complex((Bitmap)img[i].picture.BackgroundImage);
                    img[i].index = i;
                    img[i].picture.Width = img[i].picture.Height =100;
                    fit(ref img[i].picture);
                    img[i].picture.Left = ((panel1.Width - picPicture.Width) / 2)-150+(i%10)*20+(i/10)*50;
                    img[i].picture.Top = (panel1.Height - picPicture.Height) / 2 -100+(i%10)*20-(i/10)*20;
                    img[i].picture.Visible = true;
                    found = true;
                }
                i++;
            }
        }

        private void picHistogram_MouseDown_1(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pnlfilter_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left) pnlfilter.BringToFront();
            else pnlfilter.SendToBack();
            if (e.Button == MouseButtons.Left)
            {
                pnlfilter.BackColor = Color.FromArgb(230, 230, 230);
                PicmousePos = Control.MousePosition;
                PicPos = pnlfilter.Location;
                isPicMoving = true;
            }

        }
        private void pnlfilter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPicMoving)
            {
                    Point mousePos = Control.MousePosition;
                    int x = mousePos.X - PicmousePos.X + PicPos.X;
                    int y = mousePos.Y - PicmousePos.Y + PicPos.Y;
                    Point nP  = new Point(x, y);
                    if(nP.X<0)nP.X=0;
                    if(nP.Y<0)nP.Y=0;
                    if(nP.X+pnlfilter.Width>panel1.Width)nP.X = panel1.Width - pnlfilter.Width;
                    if(nP.Y+pnlfilter.Height>panel1.Height)nP.Y = panel1.Height - pnlfilter.Height;
                    pnlfilter.Location = nP;
            }
        }
        private void pnlfilter_MouseUp(object sender, MouseEventArgs e)
        {
            pnlfilter.BackColor = Color.FromArgb(224, 224, 224);
            isPicMoving = false;

        }

        private void picResize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PicmousePos = Control.MousePosition;
                PicPos.X = Width;
                PicPos.Y = Height;
                isPicMoving = true;
            }
        }

        private void picResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPicMoving)
            {
                Point mousePos = Control.MousePosition;
                int x = mousePos.X - PicmousePos.X + PicPos.X;
                int y = mousePos.Y - PicmousePos.Y + PicPos.Y;
                Point nP = new Point(x, y);
                if (nP.X < 646) nP.X = 646;
                if (nP.Y < 360) nP.Y = 360;
                Width = nP.X; Height = nP.Y;
            }

        }

        private void picResize_MouseUp(object sender, MouseEventArgs e)
        {
            isPicMoving = false;

        }






    }
}
