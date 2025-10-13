namespace Retrofy
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ResultTexture = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OriginTexture = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DitherAlgorithm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ExportTexture = new System.Windows.Forms.Button();
            this.ApplyDither = new System.Windows.Forms.Button();
            this.DitherValue = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTexture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginTexture)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DitherValue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ResultTexture);
            this.groupBox2.Location = new System.Drawing.Point(418, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 400);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Result Texture ";
            // 
            // ResultTexture
            // 
            this.ResultTexture.Location = new System.Drawing.Point(6, 20);
            this.ResultTexture.Name = "ResultTexture";
            this.ResultTexture.Size = new System.Drawing.Size(388, 374);
            this.ResultTexture.TabIndex = 1;
            this.ResultTexture.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.OriginTexture);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 400);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Origin Texture ";
            // 
            // OriginTexture
            // 
            this.OriginTexture.Location = new System.Drawing.Point(6, 20);
            this.OriginTexture.Name = "OriginTexture";
            this.OriginTexture.Size = new System.Drawing.Size(388, 374);
            this.OriginTexture.TabIndex = 0;
            this.OriginTexture.TabStop = false;
            this.OriginTexture.DragDrop += new System.Windows.Forms.DragEventHandler(this.OriginTexture_DragDrop);
            this.OriginTexture.DragEnter += new System.Windows.Forms.DragEventHandler(this.OriginTexture_DragEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DitherValue);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.DitherAlgorithm);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 418);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 105);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Dithering ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(52, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag && Drop Your Texture Here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dithering Algorithm";
            // 
            // DitherAlgorithm
            // 
            this.DitherAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DitherAlgorithm.FormattingEnabled = true;
            this.DitherAlgorithm.Items.AddRange(new object[] {
            "None",
            "Floyd–Steinberg (Error Diffusion)",
            "Serpentine Dither",
            "Bayer (Ordered)"});
            this.DitherAlgorithm.Location = new System.Drawing.Point(9, 33);
            this.DitherAlgorithm.Name = "DitherAlgorithm";
            this.DitherAlgorithm.Size = new System.Drawing.Size(242, 21);
            this.DitherAlgorithm.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Colors Level";
            // 
            // ExportTexture
            // 
            this.ExportTexture.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportTexture.Location = new System.Drawing.Point(615, 426);
            this.ExportTexture.Name = "ExportTexture";
            this.ExportTexture.Size = new System.Drawing.Size(203, 46);
            this.ExportTexture.TabIndex = 5;
            this.ExportTexture.Text = "Export Texture";
            this.ExportTexture.UseVisualStyleBackColor = true;
            this.ExportTexture.Click += new System.EventHandler(this.ExportTexture_Click);
            // 
            // ApplyDither
            // 
            this.ApplyDither.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyDither.Location = new System.Drawing.Point(418, 426);
            this.ApplyDither.Name = "ApplyDither";
            this.ApplyDither.Size = new System.Drawing.Size(191, 46);
            this.ApplyDither.TabIndex = 6;
            this.ApplyDither.Text = "Apply Dithering";
            this.ApplyDither.UseVisualStyleBackColor = true;
            this.ApplyDither.Click += new System.EventHandler(this.ApplyDither_Click);
            // 
            // DitherValue
            // 
            this.DitherValue.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.DitherValue.Location = new System.Drawing.Point(9, 73);
            this.DitherValue.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.DitherValue.Name = "DitherValue";
            this.DitherValue.Size = new System.Drawing.Size(242, 21);
            this.DitherValue.TabIndex = 3;
            this.DitherValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 535);
            this.Controls.Add(this.ApplyDither);
            this.Controls.Add(this.ExportTexture);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retrofy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultTexture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginTexture)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DitherValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox ResultTexture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox OriginTexture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DitherAlgorithm;
        private System.Windows.Forms.Button ExportTexture;
        private System.Windows.Forms.Button ApplyDither;
        private System.Windows.Forms.NumericUpDown DitherValue;
    }
}

