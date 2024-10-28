namespace Ex1__change_resolution_
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pic256 = new System.Windows.Forms.PictureBox();
            this.pic128 = new System.Windows.Forms.PictureBox();
            this.pic64 = new System.Windows.Forms.PictureBox();
            this.pic32 = new System.Windows.Forms.PictureBox();
            this.btnShow4Resolutions = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.buf = new System.Windows.Forms.PictureBox();
            this.btnRgb2Gray = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buf)).BeginInit();
            this.SuspendLayout();
            // 
            // pic256
            // 
            this.pic256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic256.Location = new System.Drawing.Point(12, 41);
            this.pic256.Name = "pic256";
            this.pic256.Size = new System.Drawing.Size(256, 256);
            this.pic256.TabIndex = 0;
            this.pic256.TabStop = false;
            // 
            // pic128
            // 
            this.pic128.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic128.Location = new System.Drawing.Point(274, 41);
            this.pic128.Name = "pic128";
            this.pic128.Size = new System.Drawing.Size(256, 256);
            this.pic128.TabIndex = 1;
            this.pic128.TabStop = false;
            // 
            // pic64
            // 
            this.pic64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic64.Location = new System.Drawing.Point(536, 41);
            this.pic64.Name = "pic64";
            this.pic64.Size = new System.Drawing.Size(256, 256);
            this.pic64.TabIndex = 2;
            this.pic64.TabStop = false;
            // 
            // pic32
            // 
            this.pic32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic32.Location = new System.Drawing.Point(798, 41);
            this.pic32.Name = "pic32";
            this.pic32.Size = new System.Drawing.Size(256, 256);
            this.pic32.TabIndex = 3;
            this.pic32.TabStop = false;
            // 
            // btnShow4Resolutions
            // 
            this.btnShow4Resolutions.Location = new System.Drawing.Point(552, 321);
            this.btnShow4Resolutions.Name = "btnShow4Resolutions";
            this.btnShow4Resolutions.Size = new System.Drawing.Size(172, 23);
            this.btnShow4Resolutions.TabIndex = 4;
            this.btnShow4Resolutions.Text = "Show in 4 different resolutions";
            this.btnShow4Resolutions.UseVisualStyleBackColor = true;
            this.btnShow4Resolutions.Click += new System.EventHandler(this.btnShow4Resolution_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(390, 321);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Load Picture";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // buf
            // 
            this.buf.BackgroundImage = global::Ex1__change_resolution_.Properties.Resources.Nature_Wallpapers__05___p30download_com___02;
            this.buf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.buf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buf.Location = new System.Drawing.Point(277, 316);
            this.buf.Name = "buf";
            this.buf.Size = new System.Drawing.Size(96, 39);
            this.buf.TabIndex = 6;
            this.buf.TabStop = false;
            this.buf.Click += new System.EventHandler(this.buf_Click);
            // 
            // btnRgb2Gray
            // 
            this.btnRgb2Gray.Location = new System.Drawing.Point(471, 321);
            this.btnRgb2Gray.Name = "btnRgb2Gray";
            this.btnRgb2Gray.Size = new System.Drawing.Size(75, 23);
            this.btnRgb2Gray.TabIndex = 7;
            this.btnRgb2Gray.Text = "RGB2GRAY";
            this.btnRgb2Gray.UseVisualStyleBackColor = true;
            this.btnRgb2Gray.Click += new System.EventHandler(this.btnRgb2Gray_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "256,256";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "128,128";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "64,64";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(795, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "32,32";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Picture Resolutions:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(274, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Original Image";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(391, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Step 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(472, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Step2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(552, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Step3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 363);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRgb2Gray);
            this.Controls.Add(this.buf);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnShow4Resolutions);
            this.Controls.Add(this.pic32);
            this.Controls.Add(this.pic64);
            this.Controls.Add(this.pic128);
            this.Controls.Add(this.pic256);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Morteza Maghrebi _ Ex1 _ show a picture in four different resolutions";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.PictureBox pic256;
        private System.Windows.Forms.PictureBox pic128;
        private System.Windows.Forms.PictureBox pic64;
        private System.Windows.Forms.PictureBox pic32;
        private System.Windows.Forms.Button btnShow4Resolutions;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox buf;
        private System.Windows.Forms.Button btnRgb2Gray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

