namespace Exc3__bit_plane_slicing_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRgb2Gray = new System.Windows.Forms.Button();
            this.btn_BitPlaneSlicing = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBitPlaneSlicingReverse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.pic6 = new System.Windows.Forms.PictureBox();
            this.pic7 = new System.Windows.Forms.PictureBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(28, 284);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(230, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRgb2Gray
            // 
            this.btnRgb2Gray.Location = new System.Drawing.Point(28, 308);
            this.btnRgb2Gray.Name = "btnRgb2Gray";
            this.btnRgb2Gray.Size = new System.Drawing.Size(230, 23);
            this.btnRgb2Gray.TabIndex = 2;
            this.btnRgb2Gray.Text = "Rgb2Gray";
            this.btnRgb2Gray.UseVisualStyleBackColor = true;
            this.btnRgb2Gray.Click += new System.EventHandler(this.btnRgb2Gray_Click);
            // 
            // btn_BitPlaneSlicing
            // 
            this.btn_BitPlaneSlicing.Location = new System.Drawing.Point(28, 332);
            this.btn_BitPlaneSlicing.Name = "btn_BitPlaneSlicing";
            this.btn_BitPlaneSlicing.Size = new System.Drawing.Size(230, 23);
            this.btn_BitPlaneSlicing.TabIndex = 3;
            this.btn_BitPlaneSlicing.Text = "Bit-plane slicing";
            this.btn_BitPlaneSlicing.UseVisualStyleBackColor = true;
            this.btn_BitPlaneSlicing.Click += new System.EventHandler(this.btn_BitPlaneSlicing_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBitPlaneSlicingReverse
            // 
            this.btnBitPlaneSlicingReverse.Location = new System.Drawing.Point(28, 356);
            this.btnBitPlaneSlicingReverse.Name = "btnBitPlaneSlicingReverse";
            this.btnBitPlaneSlicingReverse.Size = new System.Drawing.Size(230, 23);
            this.btnBitPlaneSlicingReverse.TabIndex = 5;
            this.btnBitPlaneSlicingReverse.Text = "Bit-plane slicing -> Reverse";
            this.btnBitPlaneSlicingReverse.UseVisualStyleBackColor = true;
            this.btnBitPlaneSlicingReverse.Click += new System.EventHandler(this.btnBitPlaneSlicingReverse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "You can click on each picture and change it.";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pic1
            // 
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic1.Location = new System.Drawing.Point(1011, 266);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(230, 230);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            // 
            // pic2
            // 
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic2.Location = new System.Drawing.Point(775, 266);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(230, 230);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic2.TabIndex = 0;
            this.pic2.TabStop = false;
            this.pic2.Click += new System.EventHandler(this.pic2_Click);
            // 
            // pic3
            // 
            this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic3.Location = new System.Drawing.Point(539, 266);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(230, 230);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic3.TabIndex = 0;
            this.pic3.TabStop = false;
            this.pic3.Click += new System.EventHandler(this.pic3_Click);
            // 
            // pic4
            // 
            this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic4.Location = new System.Drawing.Point(303, 266);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(230, 230);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic4.TabIndex = 0;
            this.pic4.TabStop = false;
            this.pic4.Click += new System.EventHandler(this.pic4_Click);
            // 
            // pic5
            // 
            this.pic5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic5.Location = new System.Drawing.Point(1011, 30);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(230, 230);
            this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic5.TabIndex = 0;
            this.pic5.TabStop = false;
            this.pic5.Click += new System.EventHandler(this.pic5_Click);
            // 
            // pic6
            // 
            this.pic6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic6.Location = new System.Drawing.Point(775, 30);
            this.pic6.Name = "pic6";
            this.pic6.Size = new System.Drawing.Size(230, 230);
            this.pic6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic6.TabIndex = 0;
            this.pic6.TabStop = false;
            this.pic6.Click += new System.EventHandler(this.pic6_Click);
            // 
            // pic7
            // 
            this.pic7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic7.Location = new System.Drawing.Point(539, 30);
            this.pic7.Name = "pic7";
            this.pic7.Size = new System.Drawing.Size(230, 230);
            this.pic7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic7.TabIndex = 0;
            this.pic7.TabStop = false;
            this.pic7.Click += new System.EventHandler(this.pic7_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Image = global::Exc3__bit_plane_slicing_.Properties.Resources.Figure3_13;
            this.picOriginal.Location = new System.Drawing.Point(28, 30);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(230, 230);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            this.picOriginal.Click += new System.EventHandler(this.picOriginal_Click);
            // 
            // pic8
            // 
            this.pic8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic8.Location = new System.Drawing.Point(303, 30);
            this.pic8.Name = "pic8";
            this.pic8.Size = new System.Drawing.Size(230, 230);
            this.pic8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic8.TabIndex = 0;
            this.pic8.TabStop = false;
            this.pic8.Click += new System.EventHandler(this.pic8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Exc3__bit_plane_slicing_.Properties.Resources.CODE;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 24);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 526);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBitPlaneSlicingReverse);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btn_BitPlaneSlicing);
            this.Controls.Add(this.btnRgb2Gray);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.pic5);
            this.Controls.Add(this.pic6);
            this.Controls.Add(this.pic7);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.pic8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maghrebi_Chapter3_Excersize3_ [Bit-plane Slicing and hide a  picture into another" +
    " picture]";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.PictureBox pic7;
        private System.Windows.Forms.PictureBox pic6;
        private System.Windows.Forms.PictureBox pic5;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRgb2Gray;
        private System.Windows.Forms.Button btn_BitPlaneSlicing;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBitPlaneSlicingReverse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

