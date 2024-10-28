namespace Exc1__gamma_correction_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GammaTrackBar = new System.Windows.Forms.TrackBar();
            this.LblGamma = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picGamma = new System.Windows.Forms.PictureBox();
            this.pic256 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GammaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Rgb2Gray";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GammaTrackBar
            // 
            this.GammaTrackBar.LargeChange = 1;
            this.GammaTrackBar.Location = new System.Drawing.Point(12, 100);
            this.GammaTrackBar.Maximum = 20;
            this.GammaTrackBar.Minimum = -20;
            this.GammaTrackBar.Name = "GammaTrackBar";
            this.GammaTrackBar.Size = new System.Drawing.Size(121, 45);
            this.GammaTrackBar.TabIndex = 3;
            this.GammaTrackBar.Value = 1;
            this.GammaTrackBar.Scroll += new System.EventHandler(this.GammaTrackBar_Scroll);
            // 
            // LblGamma
            // 
            this.LblGamma.Location = new System.Drawing.Point(9, 148);
            this.LblGamma.Name = "LblGamma";
            this.LblGamma.Size = new System.Drawing.Size(124, 13);
            this.LblGamma.TabIndex = 4;
            this.LblGamma.Text = "Gamma = 1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save picture";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Ex1__gamma_correction_.Properties.Resources.Figure3_9;
            this.pictureBox2.Location = new System.Drawing.Point(70, 186);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Ex1__gamma_correction_.Properties.Resources.Figure3_8;
            this.pictureBox1.Location = new System.Drawing.Point(12, 186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picGamma
            // 
            this.picGamma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGamma.Location = new System.Drawing.Point(401, 10);
            this.picGamma.Name = "picGamma";
            this.picGamma.Size = new System.Drawing.Size(256, 256);
            this.picGamma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGamma.TabIndex = 5;
            this.picGamma.TabStop = false;
            // 
            // pic256
            // 
            this.pic256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic256.Image = global::Ex1__gamma_correction_.Properties.Resources.Figure3_9;
            this.pic256.Location = new System.Drawing.Point(139, 10);
            this.pic256.Name = "pic256";
            this.pic256.Size = new System.Drawing.Size(256, 256);
            this.pic256.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic256.TabIndex = 0;
            this.pic256.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 278);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picGamma);
            this.Controls.Add(this.LblGamma);
            this.Controls.Add(this.GammaTrackBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pic256);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maghrebi_Chapter3_Excersize1_ [Gamma correction]";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GammaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic256;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar GammaTrackBar;
        private System.Windows.Forms.Label LblGamma;
        private System.Windows.Forms.PictureBox picGamma;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

