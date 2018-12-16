namespace PolylineSmooth
{
    partial class MainForm : System.Windows.Forms.Form
    {

        /// <summary>
	/// Designer variable used to keep track of non-visual components.
	/// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
	/// Disposes resources used by the form.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
	/// This method is required for Windows Forms designer support.
	/// Do not change the method contents inside the source code editor. The Forms designer might
	/// not be able to load this method if it was changed manually.
	/// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panelTop = new System.Windows.Forms.Panel();
            this.comboMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labTension = new System.Windows.Forms.Label();
            this.labIter = new System.Windows.Forms.Label();
            this.numTension = new System.Windows.Forms.NumericUpDown();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.butSmooth = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.numTension).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numIterations).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.chart1).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.comboMethod);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.labTension);
            this.panelTop.Controls.Add(this.labIter);
            this.panelTop.Controls.Add(this.numTension);
            this.panelTop.Controls.Add(this.numIterations);
            this.panelTop.Controls.Add(this.butSmooth);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(689, 48);
            this.panelTop.TabIndex = 0;
            // 
            // comboMethod
            // 
            this.comboMethod.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right);
            this.comboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethod.FormattingEnabled = true;
            this.comboMethod.Items.AddRange(new object[] { "Interpolation (Catmull-Rom)", "Approximation (Chaikin)" });
            this.comboMethod.Location = new System.Drawing.Point(159, 15);
            this.comboMethod.Name = "comboMethod";
            this.comboMethod.Size = new System.Drawing.Size(187, 21);
            this.comboMethod.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(105, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labTension
            // 
            this.labTension.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.labTension.AutoSize = true;
            this.labTension.Location = new System.Drawing.Point(560, 18);
            this.labTension.Name = "labTension";
            this.labTension.Size = new System.Drawing.Size(45, 13);
            this.labTension.TabIndex = 2;
            this.labTension.Text = "Tension";
            // 
            // labIter
            // 
            this.labIter.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.labIter.Location = new System.Drawing.Point(352, 15);
            this.labIter.Name = "labIter";
            this.labIter.Size = new System.Drawing.Size(130, 18);
            this.labIter.TabIndex = 2;
            this.labIter.Text = "Nr of iterations";
            this.labIter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTension
            // 
            this.numTension.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.numTension.DecimalPlaces = 2;
            this.numTension.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numTension.Location = new System.Drawing.Point(611, 16);
            this.numTension.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTension.Name = "numTension";
            this.numTension.Size = new System.Drawing.Size(66, 20);
            this.numTension.TabIndex = 1;
            this.numTension.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTension.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // numIterations
            // 
            this.numIterations.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.numIterations.Location = new System.Drawing.Point(488, 16);
            this.numIterations.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            this.numIterations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(66, 20);
            this.numIterations.TabIndex = 1;
            this.numIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numIterations.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // butSmooth
            // 
            this.butSmooth.Location = new System.Drawing.Point(12, 12);
            this.butSmooth.Name = "butSmooth";
            this.butSmooth.Size = new System.Drawing.Size(83, 24);
            this.butSmooth.TabIndex = 0;
            this.butSmooth.Text = "Smooth";
            this.butSmooth.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.chart1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 48);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(689, 437);
            this.panelMain.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(689, 437);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 485);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "PolylineSmooth";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.numTension).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numIterations).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.chart1).EndInit();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboMethod;
        private System.Windows.Forms.Button butSmooth;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.NumericUpDown numTension;
        private System.Windows.Forms.Label labIter;
        private System.Windows.Forms.Label labTension;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
    }
}
