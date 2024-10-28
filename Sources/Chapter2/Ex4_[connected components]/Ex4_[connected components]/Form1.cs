using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex4__connected_components_
{
    public partial class Form1 : Form
    {
        ImageProccessing ImProccess = new ImageProccessing();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Bitmap pic = new Bitmap(pic1.Image);
            pic1.Image = null;
            pic1.Image = ImProccess.Fill(pic, 256);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Op = new OpenFileDialog();
                Op.ShowDialog();
                pic1.Load(Op.FileName);
                pic1.Image = ImProccess.Fill((Bitmap)pic1.Image, 256);
            }
            catch { }
        
        }

        private void pic1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = (e.X.ToString() + " , " + e.Y.ToString());
            ImProccess.MaxStack = int.Parse(txtStack.Text);
            pic2.Image= ImProccess.ConnectedComponent((Bitmap)pic1.Image, e.X, e.Y,comboBox1.SelectedIndex,int.Parse(txtoffset.Text));
            label1.Text += " completed." ;
            
        }

        private void btnRgb2Gray_Click(object sender, EventArgs e)
        {
            pic1.Image = ImProccess.MakeGrayscale((Bitmap)pic1.Image);
        }

        private void txtStack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtStack.Text) > 1000) txtStack.Text = "1000";
            }
            catch { }
        }

        private void pic1_MouseMove(object sender, MouseEventArgs e)
        {
        }


        

    }
}
