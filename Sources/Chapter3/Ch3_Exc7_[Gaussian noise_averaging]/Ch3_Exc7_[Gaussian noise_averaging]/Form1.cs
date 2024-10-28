using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Ch3_Exc7__Gaussian_noise_averaging_
{
    public partial class Form1 : Form
    {
        string folderPath = "";
        FolderBrowserDialog FBD = new FolderBrowserDialog();
        ImageProccessing ImProccess = new ImageProccessing();
        
        public Form1()
        {
            InitializeComponent();
        }

        string isolate(string path,ref string type)
        {
            string fname = "";
                
            try
            {
                if (path == null) path = "";
                type = "";
                Boolean found = false;
                Boolean TypeFound = false;
                int i; int j = 0;
                for (i = path.Length - 1; (!found) && (i >= 0); i--)
                {
                    if (!TypeFound) if (path[i].ToString() == ".") { j = i; TypeFound = true; }
                    if (path[i].ToString() == "\\") { found = true; break; }
                }
                if (TypeFound && found) type = path.Substring(j + 1, path.Length - j - 1);
                if (found) fname = path.Substring(i + 1, path.Length - i - 1);
            }
            catch { }
                return fname;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                string str = "";
                string folder = Application.ExecutablePath;
                folder = folder.Substring(0, (folder.Length - isolate(folder, ref str).Length - 1)) + "\\" + "GaussianNoise";
                folderPath = folder;
                foreach (string path in System.IO.Directory.GetFiles(folder))
                {
                    string type = "";
                    string fname = isolate(path, ref type);
                    if (type.ToLower() == "png" || type.ToLower() == "jpg" || type.ToLower() == "bmp" || type.ToLower() == "gif" || type.ToLower() == "ico") listBox1.Items.Add(fname);
                }
                Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);

                btnCalculate_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("The folder of images could not be found, please choose another folder.");
            }
        }

        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                FBD.ShowDialog();
                folderPath = FBD.SelectedPath;
                listBox1.Items.Clear();
                foreach (string path in System.IO.Directory.GetFiles(folderPath))
                {
                    string type="";
                    string fname = isolate(path, ref type);
                    if(type.ToLower()=="png"||type.ToLower()=="jpg"||type.ToLower()=="bmp"||type.ToLower()=="gif"||type.ToLower()=="ico") listBox1.Items.Add(fname);
                }
            }
            catch { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(folderPath + "\\" + listBox1.SelectedItem.ToString());
            }
            catch
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean GotSize = false;
                double[,] R = new double[0, 0];
                double[,] G = new double[0, 0];
                double[,] B = new double[0, 0];
                ArrayList Errors = new ArrayList();
                int numOfpictures = 0;
                int PictureHeight = 0, PictureWidth = 0;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    try
                    {
                        pictureBox1.Load(folderPath + "\\" + listBox1.Items[i].ToString());
                        // GET THE SIZE OF FIRST IMAGE
                        if (!GotSize)
                        {
                            PictureHeight = pictureBox1.Image.Height;
                            PictureWidth = pictureBox1.Image.Width;
                            R = new double[pictureBox1.Image.Width, pictureBox1.Image.Height];
                            G = new double[pictureBox1.Image.Width, pictureBox1.Image.Height];
                            B = new double[pictureBox1.Image.Width, pictureBox1.Image.Height];
                            for (int x = 0; x < pictureBox1.Image.Width; x++)
                            {
                                for (int y = 0; y < pictureBox1.Image.Height; y++)
                                {
                                    R[x, y] = 0;
                                    G[x, y] = 0;
                                    B[x, y] = 0;
                                }
                            }
                            GotSize = true;
                        }
                        // GET THE SIZE OF FIRST IMAGE
                        if (pictureBox1.Image.Width == PictureWidth && pictureBox1.Image.Height == PictureHeight)
                        {
                            ImProccess.GetValuesOfpicture((Bitmap)pictureBox1.Image, ref R, ref G, ref B);
                            numOfpictures++;
                        }
                    }
                    catch
                    {
                        Errors.Add(i);
                    }
                    progressBar1.Value = (int)((i + 1) * 100.0 / listBox1.Items.Count);
                    Application.DoEvents();
                }
                for (int i = Errors.Count - 1; i >= 0; i--) { listBox1.Items.RemoveAt((int)Errors[i]); Application.DoEvents(); }
                for (int x = 0; x < pictureBox1.Image.Width; x++)
                {
                    for (int y = 0; y < pictureBox1.Image.Height; y++)
                    {
                        R[x, y] = R[x, y] / numOfpictures;
                        G[x, y] = G[x, y] / numOfpictures;
                        B[x, y] = B[x, y] / numOfpictures;
                    }
                }
                pictureBox2.Image = ImProccess.MakeImageFromValues(PictureWidth, PictureHeight, ref R,ref G,ref B);
                MessageBox.Show("Number of pictures: " + numOfpictures.ToString());
            }
            catch { MessageBox.Show("Error"); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "|.png";
                sv.ShowDialog();
                pictureBox2.Image.Save(sv.FileName);
            }
            catch { }
        }
       
        
    }
}
