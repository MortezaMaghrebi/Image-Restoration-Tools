namespace Ch3_Exc9__Laplacian_filter_
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
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.btnLaplacianFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.x0y0 = new System.Windows.Forms.TextBox();
            this.x1y0 = new System.Windows.Forms.TextBox();
            this.x2y0 = new System.Windows.Forms.TextBox();
            this.x0y1 = new System.Windows.Forms.TextBox();
            this.x1y1 = new System.Windows.Forms.TextBox();
            this.x2y1 = new System.Windows.Forms.TextBox();
            this.x0y2 = new System.Windows.Forms.TextBox();
            this.x1y2 = new System.Windows.Forms.TextBox();
            this.x2y2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCoefficient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 290);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(253, 25);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load picture";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Zero padding",
            "Ignore boarders",
            "Replicate",
            "Mirror"});
            this.cmbMode.Location = new System.Drawing.Point(391, 289);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(137, 21);
            this.cmbMode.TabIndex = 4;
            this.cmbMode.Text = "Mode";
            // 
            // btnLaplacianFilter
            // 
            this.btnLaplacianFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaplacianFilter.Location = new System.Drawing.Point(390, 310);
            this.btnLaplacianFilter.Name = "btnLaplacianFilter";
            this.btnLaplacianFilter.Size = new System.Drawing.Size(139, 19);
            this.btnLaplacianFilter.TabIndex = 5;
            this.btnLaplacianFilter.Text = "Laplacian filter";
            this.btnLaplacianFilter.UseVisualStyleBackColor = true;
            this.btnLaplacianFilter.Click += new System.EventHandler(this.btnLaplacianFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mode:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(251, 4);
            this.progressBar1.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(253, 25);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save picture";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // x0y0
            // 
            this.x0y0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x0y0.Location = new System.Drawing.Point(296, 290);
            this.x0y0.Name = "x0y0";
            this.x0y0.Size = new System.Drawing.Size(22, 20);
            this.x0y0.TabIndex = 11;
            this.x0y0.Text = "-1";
            this.x0y0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x1y0
            // 
            this.x1y0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x1y0.Location = new System.Drawing.Point(317, 290);
            this.x1y0.Name = "x1y0";
            this.x1y0.Size = new System.Drawing.Size(22, 20);
            this.x1y0.TabIndex = 12;
            this.x1y0.Text = "-1";
            this.x1y0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x2y0
            // 
            this.x2y0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x2y0.Location = new System.Drawing.Point(338, 290);
            this.x2y0.Name = "x2y0";
            this.x2y0.Size = new System.Drawing.Size(22, 20);
            this.x2y0.TabIndex = 13;
            this.x2y0.Text = "-1";
            this.x2y0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x0y1
            // 
            this.x0y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x0y1.Location = new System.Drawing.Point(296, 309);
            this.x0y1.Name = "x0y1";
            this.x0y1.Size = new System.Drawing.Size(22, 20);
            this.x0y1.TabIndex = 14;
            this.x0y1.Text = "-1";
            this.x0y1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x1y1
            // 
            this.x1y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x1y1.Location = new System.Drawing.Point(317, 309);
            this.x1y1.Name = "x1y1";
            this.x1y1.Size = new System.Drawing.Size(22, 20);
            this.x1y1.TabIndex = 15;
            this.x1y1.Text = "8";
            this.x1y1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x2y1
            // 
            this.x2y1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x2y1.Location = new System.Drawing.Point(338, 309);
            this.x2y1.Name = "x2y1";
            this.x2y1.Size = new System.Drawing.Size(22, 20);
            this.x2y1.TabIndex = 16;
            this.x2y1.Text = "-1";
            this.x2y1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x0y2
            // 
            this.x0y2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x0y2.Location = new System.Drawing.Point(296, 328);
            this.x0y2.Name = "x0y2";
            this.x0y2.Size = new System.Drawing.Size(22, 20);
            this.x0y2.TabIndex = 17;
            this.x0y2.Text = "-1";
            this.x0y2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x1y2
            // 
            this.x1y2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x1y2.Location = new System.Drawing.Point(317, 328);
            this.x1y2.Name = "x1y2";
            this.x1y2.Size = new System.Drawing.Size(22, 20);
            this.x1y2.TabIndex = 18;
            this.x1y2.Text = "-1";
            this.x1y2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x2y2
            // 
            this.x2y2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.x2y2.Location = new System.Drawing.Point(338, 328);
            this.x2y2.Name = "x2y2";
            this.x2y2.Size = new System.Drawing.Size(22, 20);
            this.x2y2.TabIndex = 19;
            this.x2y2.Text = "-1";
            this.x2y2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Filter:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(390, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 20);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add to picture";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCoefficient
            // 
            this.txtCoefficient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCoefficient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoefficient.Location = new System.Drawing.Point(490, 329);
            this.txtCoefficient.Multiline = true;
            this.txtCoefficient.Name = "txtCoefficient";
            this.txtCoefficient.Size = new System.Drawing.Size(38, 18);
            this.txtCoefficient.TabIndex = 22;
            this.txtCoefficient.Text = "4";
            this.txtCoefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(472, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "X";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(274, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Ch3_Exc12__Laplacian_filter_.Properties.Resources.Figure3_40;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 360);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.x2y2);
            this.Controls.Add(this.x1y2);
            this.Controls.Add(this.x0y2);
            this.Controls.Add(this.x2y1);
            this.Controls.Add(this.x1y1);
            this.Controls.Add(this.x0y1);
            this.Controls.Add(this.x2y0);
            this.Controls.Add(this.x1y0);
            this.Controls.Add(this.x0y0);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLaplacianFilter);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCoefficient);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maghrebi_Chapter3_Excersize12_ [Laplacian filter]";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Button btnLaplacianFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox x0y0;
        private System.Windows.Forms.TextBox x1y0;
        private System.Windows.Forms.TextBox x2y0;
        private System.Windows.Forms.TextBox x0y1;
        private System.Windows.Forms.TextBox x1y1;
        private System.Windows.Forms.TextBox x2y1;
        private System.Windows.Forms.TextBox x0y2;
        private System.Windows.Forms.TextBox x1y2;
        private System.Windows.Forms.TextBox x2y2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCoefficient;
        private System.Windows.Forms.Label label3;
    }
}

