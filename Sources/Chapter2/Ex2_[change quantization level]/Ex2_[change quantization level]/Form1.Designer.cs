namespace Ex2__change_quantization_level_
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic8 = new System.Windows.Forms.PictureBox();
            this.pic16 = new System.Windows.Forms.PictureBox();
            this.pic32 = new System.Windows.Forms.PictureBox();
            this.pic64 = new System.Windows.Forms.PictureBox();
            this.pic128 = new System.Windows.Forms.PictureBox();
            this.pic256 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantization level = 256";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantization level = 128";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantization level = 64";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantization level = 32";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantization level = 16";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantization level = 8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Quantization level = 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(417, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Quantization level = 2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(557, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Load picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(557, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "RGB2GRAY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnRGB2GRAY_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(557, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 60);
            this.button3.TabIndex = 18;
            this.button3.Text = "Change Quantization Level";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnChangeQuantizationLevel_Click);
            // 
            // pic2
            // 
            this.pic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic2.Location = new System.Drawing.Point(412, 204);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(128, 128);
            this.pic2.TabIndex = 14;
            this.pic2.TabStop = false;
            // 
            // pic4
            // 
            this.pic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic4.Location = new System.Drawing.Point(278, 204);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(128, 128);
            this.pic4.TabIndex = 12;
            this.pic4.TabStop = false;
            // 
            // pic8
            // 
            this.pic8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic8.Location = new System.Drawing.Point(146, 204);
            this.pic8.Name = "pic8";
            this.pic8.Size = new System.Drawing.Size(128, 128);
            this.pic8.TabIndex = 10;
            this.pic8.TabStop = false;
            // 
            // pic16
            // 
            this.pic16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic16.Location = new System.Drawing.Point(12, 204);
            this.pic16.Name = "pic16";
            this.pic16.Size = new System.Drawing.Size(128, 128);
            this.pic16.TabIndex = 8;
            this.pic16.TabStop = false;
            // 
            // pic32
            // 
            this.pic32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic32.Location = new System.Drawing.Point(414, 36);
            this.pic32.Name = "pic32";
            this.pic32.Size = new System.Drawing.Size(128, 128);
            this.pic32.TabIndex = 6;
            this.pic32.TabStop = false;
            // 
            // pic64
            // 
            this.pic64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic64.Location = new System.Drawing.Point(280, 36);
            this.pic64.Name = "pic64";
            this.pic64.Size = new System.Drawing.Size(128, 128);
            this.pic64.TabIndex = 4;
            this.pic64.TabStop = false;
            // 
            // pic128
            // 
            this.pic128.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic128.Location = new System.Drawing.Point(146, 36);
            this.pic128.Name = "pic128";
            this.pic128.Size = new System.Drawing.Size(128, 128);
            this.pic128.TabIndex = 2;
            this.pic128.TabStop = false;
            // 
            // pic256
            // 
            this.pic256.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic256.Image = global::Ex2__change_quantization_level_.Properties.Resources.a;
            this.pic256.Location = new System.Drawing.Point(12, 36);
            this.pic256.Name = "pic256";
            this.pic256.Size = new System.Drawing.Size(128, 128);
            this.pic256.TabIndex = 0;
            this.pic256.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 348);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pic8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pic16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pic32);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pic64);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic128);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic256);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Morteza Maghrebi _ Ex2 _ show picture in 8 type of quantization levels";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic256;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic128;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic64;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic32;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pic16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pic8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

