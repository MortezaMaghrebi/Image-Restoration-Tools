namespace Ex3__up_sample_with_bilinear_interpolation_
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRGB2GRAY = new System.Windows.Forms.Button();
            this.btnZOOM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXlevel = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic512 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYlevel = new System.Windows.Forms.TextBox();
            this.btnSimpleZoom = new System.Windows.Forms.Button();
            this.pic128 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic512)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(22, 183);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(128, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load picture";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRGB2GRAY
            // 
            this.btnRGB2GRAY.Location = new System.Drawing.Point(22, 212);
            this.btnRGB2GRAY.Name = "btnRGB2GRAY";
            this.btnRGB2GRAY.Size = new System.Drawing.Size(128, 23);
            this.btnRGB2GRAY.TabIndex = 3;
            this.btnRGB2GRAY.Text = "RGB2GRAY";
            this.btnRGB2GRAY.UseVisualStyleBackColor = true;
            this.btnRGB2GRAY.Click += new System.EventHandler(this.btnRGB2GRAY_Click);
            // 
            // btnZOOM
            // 
            this.btnZOOM.Location = new System.Drawing.Point(22, 258);
            this.btnZOOM.Name = "btnZOOM";
            this.btnZOOM.Size = new System.Drawing.Size(128, 53);
            this.btnZOOM.TabIndex = 4;
            this.btnZOOM.Text = "ZOOM whith bilinear interpolation";
            this.btnZOOM.UseVisualStyleBackColor = true;
            this.btnZOOM.Click += new System.EventHandler(this.btnZOOM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // txtXlevel
            // 
            this.txtXlevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtXlevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXlevel.ForeColor = System.Drawing.Color.Red;
            this.txtXlevel.Location = new System.Drawing.Point(25, 241);
            this.txtXlevel.Name = "txtXlevel";
            this.txtXlevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtXlevel.Size = new System.Drawing.Size(47, 13);
            this.txtXlevel.TabIndex = 7;
            this.txtXlevel.Text = "3.9";
            this.txtXlevel.Click += new System.EventHandler(this.txtXlevel_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.pic512);
            this.panel1.Location = new System.Drawing.Point(156, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 512);
            this.panel1.TabIndex = 9;
            // 
            // pic512
            // 
            this.pic512.Location = new System.Drawing.Point(0, 0);
            this.pic512.Name = "pic512";
            this.pic512.Size = new System.Drawing.Size(119, 128);
            this.pic512.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic512.TabIndex = 2;
            this.pic512.TabStop = false;
            this.pic512.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic512_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X";
            // 
            // txtYlevel
            // 
            this.txtYlevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtYlevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYlevel.ForeColor = System.Drawing.Color.Red;
            this.txtYlevel.Location = new System.Drawing.Point(97, 241);
            this.txtYlevel.Name = "txtYlevel";
            this.txtYlevel.Size = new System.Drawing.Size(50, 13);
            this.txtYlevel.TabIndex = 11;
            this.txtYlevel.Text = "3.2";
            this.txtYlevel.Click += new System.EventHandler(this.txtYlevel_Click);
            // 
            // btnSimpleZoom
            // 
            this.btnSimpleZoom.Location = new System.Drawing.Point(22, 311);
            this.btnSimpleZoom.Name = "btnSimpleZoom";
            this.btnSimpleZoom.Size = new System.Drawing.Size(128, 25);
            this.btnSimpleZoom.TabIndex = 12;
            this.btnSimpleZoom.Text = "Simple Zoom";
            this.btnSimpleZoom.UseVisualStyleBackColor = true;
            this.btnSimpleZoom.Click += new System.EventHandler(this.btnSimpleZoom_Click);
            // 
            // pic128
            // 
            this.pic128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic128.Image = global::Ex3__up_sample_with_bilinear_interpolation_.Properties.Resources.An_Autumn_Beauty;
            this.pic128.Location = new System.Drawing.Point(22, 25);
            this.pic128.Name = "pic128";
            this.pic128.Size = new System.Drawing.Size(128, 128);
            this.pic128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic128.TabIndex = 0;
            this.pic128.TabStop = false;
            this.pic128.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic128_MouseMove);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save picture";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 21);
            this.button1.TabIndex = 14;
            this.button1.Text = "Make a gradient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(22, 514);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Stop and Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(689, 562);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSimpleZoom);
            this.Controls.Add(this.txtYlevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtXlevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZOOM);
            this.Controls.Add(this.btnRGB2GRAY);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pic128);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Morteza Maghrebi _ Ex3 _ UpSampling with bilinear interpolation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic512)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic128;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRGB2GRAY;
        private System.Windows.Forms.Button btnZOOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXlevel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic512;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYlevel;
        private System.Windows.Forms.Button btnSimpleZoom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExit;
    }
}

