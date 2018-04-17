namespace GATriangle
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
            this.drawTriangle = new System.Windows.Forms.Button();
            this.firefoxPicture = new System.Windows.Forms.PictureBox();
            this.trianglesPicture = new System.Windows.Forms.PictureBox();
            this.startIteration = new System.Windows.Forms.Button();
            this.iterationTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.endIteration = new System.Windows.Forms.Button();
            this.addIterationTimes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.firefoxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trianglesPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addIterationTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // drawTriangle
            // 
            this.drawTriangle.Location = new System.Drawing.Point(1304, 12);
            this.drawTriangle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(227, 70);
            this.drawTriangle.TabIndex = 1;
            this.drawTriangle.Text = "Draw Triangles";
            this.drawTriangle.UseVisualStyleBackColor = true;
            this.drawTriangle.Click += new System.EventHandler(this.drawTriangle_Click);
            // 
            // firefoxPicture
            // 
            this.firefoxPicture.Image = ((System.Drawing.Image)(resources.GetObject("firefoxPicture.Image")));
            this.firefoxPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("firefoxPicture.InitialImage")));
            this.firefoxPicture.Location = new System.Drawing.Point(658, 12);
            this.firefoxPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.firefoxPicture.Name = "firefoxPicture";
            this.firefoxPicture.Size = new System.Drawing.Size(640, 640);
            this.firefoxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.firefoxPicture.TabIndex = 3;
            this.firefoxPicture.TabStop = false;
            // 
            // trianglesPicture
            // 
            this.trianglesPicture.Enabled = false;
            this.trianglesPicture.Location = new System.Drawing.Point(13, 12);
            this.trianglesPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trianglesPicture.Name = "trianglesPicture";
            this.trianglesPicture.Size = new System.Drawing.Size(640, 640);
            this.trianglesPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trianglesPicture.TabIndex = 4;
            this.trianglesPicture.TabStop = false;
            // 
            // startIteration
            // 
            this.startIteration.Location = new System.Drawing.Point(1304, 261);
            this.startIteration.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.startIteration.Name = "startIteration";
            this.startIteration.Size = new System.Drawing.Size(227, 70);
            this.startIteration.TabIndex = 5;
            this.startIteration.Text = "Start Iteration";
            this.startIteration.UseVisualStyleBackColor = true;
            this.startIteration.Click += new System.EventHandler(this.startIteration_Click);
            // 
            // iterationTimes
            // 
            this.iterationTimes.Location = new System.Drawing.Point(1304, 418);
            this.iterationTimes.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.iterationTimes.Name = "iterationTimes";
            this.iterationTimes.Size = new System.Drawing.Size(224, 31);
            this.iterationTimes.TabIndex = 6;
            this.iterationTimes.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1300, 392);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Iteration times";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // endIteration
            // 
            this.endIteration.Location = new System.Drawing.Point(1304, 583);
            this.endIteration.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.endIteration.Name = "endIteration";
            this.endIteration.Size = new System.Drawing.Size(227, 70);
            this.endIteration.TabIndex = 8;
            this.endIteration.Text = "End Iteration";
            this.endIteration.UseVisualStyleBackColor = true;
            this.endIteration.Click += new System.EventHandler(this.endIteration_Click);
            // 
            // addIterationTimes
            // 
            this.addIterationTimes.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.addIterationTimes.Location = new System.Drawing.Point(1307, 214);
            this.addIterationTimes.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.addIterationTimes.Maximum = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            this.addIterationTimes.Name = "addIterationTimes";
            this.addIterationTimes.Size = new System.Drawing.Size(224, 31);
            this.addIterationTimes.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1544, 663);
            this.Controls.Add(this.addIterationTimes);
            this.Controls.Add(this.endIteration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iterationTimes);
            this.Controls.Add(this.startIteration);
            this.Controls.Add(this.trianglesPicture);
            this.Controls.Add(this.firefoxPicture);
            this.Controls.Add(this.drawTriangle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.firefoxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trianglesPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addIterationTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button drawTriangle;
        private System.Windows.Forms.PictureBox firefoxPicture;
        private System.Windows.Forms.PictureBox trianglesPicture;
        private System.Windows.Forms.Button startIteration;
        private System.Windows.Forms.TextBox iterationTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button endIteration;
        private System.Windows.Forms.NumericUpDown addIterationTimes;
    }
}

