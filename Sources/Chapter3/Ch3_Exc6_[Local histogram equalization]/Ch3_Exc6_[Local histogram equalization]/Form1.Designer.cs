namespace Exc6__histogram_equalizing_local_
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
            this.btnSimple = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRGB2Gray = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.picture1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(274, 23);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(146, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load picture";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSimple
            // 
            this.btnSimple.Location = new System.Drawing.Point(274, 84);
            this.btnSimple.Name = "btnSimple";
            this.btnSimple.Size = new System.Drawing.Size(146, 23);
            this.btnSimple.TabIndex = 3;
            this.btnSimple.Text = "Simple histogram equalizing";
            this.btnSimple.UseVisualStyleBackColor = true;
            this.btnSimple.Click += new System.EventHandler(this.btnSimple_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(274, 107);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(146, 23);
            this.btnLocal.TabIndex = 4;
            this.btnLocal.Text = "Local histogram equalizing";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.YellowGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(314, 170);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "50";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(274, 132);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(146, 10);
            this.progressBar1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "neighborhood square side";
            // 
            // btnRGB2Gray
            // 
            this.btnRGB2Gray.Location = new System.Drawing.Point(274, 47);
            this.btnRGB2Gray.Name = "btnRGB2Gray";
            this.btnRGB2Gray.Size = new System.Drawing.Size(146, 23);
            this.btnRGB2Gray.TabIndex = 11;
            this.btnRGB2Gray.Text = "RGB to GRAY";
            this.btnRGB2Gray.UseVisualStyleBackColor = true;
            this.btnRGB2Gray.Click += new System.EventHandler(this.btnRGB2Gray_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(274, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save picture";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picture2
            // 
            this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture2.Location = new System.Drawing.Point(426, 23);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(256, 256);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture2.TabIndex = 1;
            this.picture2.TabStop = false;
            // 
            // picture1
            // 
            this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture1.Image = global::Exc6__local_histogram_equalization_.Properties.Resources.Figure3_24;
            this.picture1.Location = new System.Drawing.Point(12, 23);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(256, 256);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 300);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRGB2Gray);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.btnSimple);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.picture1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maghrebi_Chapter3_Exc6_ [Local histogram equalization]  **FULL SPEED**";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.PictureBox picture2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSimple;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRGB2Gray;
        private System.Windows.Forms.Button btnSave;
    }
}

