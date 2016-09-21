namespace oscilloscope1
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nuFrequency = new System.Windows.Forms.NumericUpDown();
            this.nuAmplitude = new System.Windows.Forms.NumericUpDown();
            this.rbTriangular = new System.Windows.Forms.RadioButton();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.rbSine = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbXAxis = new System.Windows.Forms.TrackBar();
            this.oscChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerSignalGenerator = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerOscilloscope = new System.Windows.Forms.Timer(this.components);
            this.tbYAxis = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbXScale = new System.Windows.Forms.Label();
            this.lbYScale = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuAmplitude)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbXAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYAxis)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nuFrequency);
            this.groupBox1.Controls.Add(this.nuAmplitude);
            this.groupBox1.Controls.Add(this.rbTriangular);
            this.groupBox1.Controls.Add(this.rbSquare);
            this.groupBox1.Controls.Add(this.rbSine);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(204, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerador de Função";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Frequência (Hz)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Amplitude";
            // 
            // nuFrequency
            // 
            this.nuFrequency.Location = new System.Drawing.Point(125, 152);
            this.nuFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuFrequency.Name = "nuFrequency";
            this.nuFrequency.Size = new System.Drawing.Size(65, 23);
            this.nuFrequency.TabIndex = 4;
            this.nuFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuFrequency.ValueChanged += new System.EventHandler(this.nuFrequency_ValueChanged);
            // 
            // nuAmplitude
            // 
            this.nuAmplitude.Location = new System.Drawing.Point(125, 123);
            this.nuAmplitude.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuAmplitude.Name = "nuAmplitude";
            this.nuAmplitude.Size = new System.Drawing.Size(65, 23);
            this.nuAmplitude.TabIndex = 3;
            this.nuAmplitude.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuAmplitude.ValueChanged += new System.EventHandler(this.nuAmplitude_ValueChanged);
            // 
            // rbTriangular
            // 
            this.rbTriangular.AutoSize = true;
            this.rbTriangular.Location = new System.Drawing.Point(9, 81);
            this.rbTriangular.Margin = new System.Windows.Forms.Padding(4);
            this.rbTriangular.Name = "rbTriangular";
            this.rbTriangular.Size = new System.Drawing.Size(91, 21);
            this.rbTriangular.TabIndex = 2;
            this.rbTriangular.Text = "Triangular";
            this.rbTriangular.UseVisualStyleBackColor = true;
            this.rbTriangular.CheckedChanged += new System.EventHandler(this.rbTriangular_CheckedChanged);
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Location = new System.Drawing.Point(9, 53);
            this.rbSquare.Margin = new System.Windows.Forms.Padding(4);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(126, 21);
            this.rbSquare.TabIndex = 1;
            this.rbSquare.Text = "Onda quadrada";
            this.rbSquare.UseVisualStyleBackColor = true;
            this.rbSquare.CheckedChanged += new System.EventHandler(this.rbSquare_CheckedChanged);
            // 
            // rbSine
            // 
            this.rbSine.AutoSize = true;
            this.rbSine.Checked = true;
            this.rbSine.Location = new System.Drawing.Point(9, 25);
            this.rbSine.Margin = new System.Windows.Forms.Padding(4);
            this.rbSine.Name = "rbSine";
            this.rbSine.Size = new System.Drawing.Size(78, 21);
            this.rbSine.TabIndex = 0;
            this.rbSine.TabStop = true;
            this.rbSine.Text = "Senóide";
            this.rbSine.UseVisualStyleBackColor = true;
            this.rbSine.CheckedChanged += new System.EventHandler(this.rbSine_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbYScale);
            this.groupBox2.Controls.Add(this.lbXScale);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbYAxis);
            this.groupBox2.Controls.Add(this.tbXAxis);
            this.groupBox2.Location = new System.Drawing.Point(17, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 215);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Osciloscópio";
            // 
            // tbXAxis
            // 
            this.tbXAxis.Location = new System.Drawing.Point(6, 54);
            this.tbXAxis.Name = "tbXAxis";
            this.tbXAxis.Size = new System.Drawing.Size(178, 45);
            this.tbXAxis.TabIndex = 1;
            this.tbXAxis.Scroll += new System.EventHandler(this.tbXAxis_Scroll);
            // 
            // oscChart
            // 
            chartArea3.Name = "ChartArea1";
            this.oscChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.oscChart.Legends.Add(legend3);
            this.oscChart.Location = new System.Drawing.Point(277, 16);
            this.oscChart.Name = "oscChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.oscChart.Series.Add(series3);
            this.oscChart.Size = new System.Drawing.Size(608, 482);
            this.oscChart.TabIndex = 2;
            this.oscChart.Text = "chart1";
            // 
            // timerSignalGenerator
            // 
            this.timerSignalGenerator.Tick += new System.EventHandler(this.timerSignalGenerator_Tick);
            // 
            // timerOscilloscope
            // 
            this.timerOscilloscope.Tick += new System.EventHandler(this.timerOscilloscope_Tick);
            // 
            // tbYAxis
            // 
            this.tbYAxis.Location = new System.Drawing.Point(6, 116);
            this.tbYAxis.Name = "tbYAxis";
            this.tbYAxis.Size = new System.Drawing.Size(178, 45);
            this.tbYAxis.TabIndex = 2;
            this.tbYAxis.Scroll += new System.EventHandler(this.tbYAxis_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Escala do Eixo X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Escala do Eixo Y";
            // 
            // lbXScale
            // 
            this.lbXScale.AutoSize = true;
            this.lbXScale.Location = new System.Drawing.Point(12, 155);
            this.lbXScale.Name = "lbXScale";
            this.lbXScale.Size = new System.Drawing.Size(46, 17);
            this.lbXScale.TabIndex = 5;
            this.lbXScale.Text = "label5";
            // 
            // lbYScale
            // 
            this.lbYScale.AutoSize = true;
            this.lbYScale.Location = new System.Drawing.Point(12, 172);
            this.lbYScale.Name = "lbYScale";
            this.lbYScale.Size = new System.Drawing.Size(46, 17);
            this.lbYScale.TabIndex = 6;
            this.lbYScale.Text = "label6";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 510);
            this.Controls.Add(this.oscChart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Osciloscópio Digital";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuAmplitude)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbXAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYAxis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuFrequency;
        private System.Windows.Forms.NumericUpDown nuAmplitude;
        private System.Windows.Forms.RadioButton rbTriangular;
        private System.Windows.Forms.RadioButton rbSquare;
        private System.Windows.Forms.RadioButton rbSine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart oscChart;
        private System.Windows.Forms.Timer timerSignalGenerator;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerOscilloscope;
        private System.Windows.Forms.TrackBar tbXAxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbYAxis;
        private System.Windows.Forms.Label lbYScale;
        private System.Windows.Forms.Label lbXScale;
    }
}

