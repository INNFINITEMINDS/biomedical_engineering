using DataAcquisition;

namespace intro_threads
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


            //Stops the acquisition thread
            if (this.threadAcq.IsAlive())
                this.threadAcq.Stop();


            //Stops the processing thread
            if (this.threadProc.IsAlive())
                this.threadProc.Stop();

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerGenerator = new System.Windows.Forms.Timer(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.nuAmplitude = new System.Windows.Forms.NumericUpDown();
            this.nuFrequency = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(109, 12);
            this.mainChart.Name = "mainChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mainChart.Series.Add(series1);
            this.mainChart.Size = new System.Drawing.Size(672, 344);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // timerGenerator
            // 
            this.timerGenerator.Interval = 50;
            this.timerGenerator.Tick += new System.EventHandler(this.timerGenerator_Tick);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 126);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(13, 184);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(75, 23);
            this.btPause.TabIndex = 2;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(12, 155);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 3;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(13, 210);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // nuAmplitude
            // 
            this.nuAmplitude.Location = new System.Drawing.Point(12, 39);
            this.nuAmplitude.Name = "nuAmplitude";
            this.nuAmplitude.Size = new System.Drawing.Size(91, 20);
            this.nuAmplitude.TabIndex = 5;
            this.nuAmplitude.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuAmplitude.ValueChanged += new System.EventHandler(this.nuAmplitude_ValueChanged);
            // 
            // nuFrequency
            // 
            this.nuFrequency.Location = new System.Drawing.Point(12, 89);
            this.nuFrequency.Name = "nuFrequency";
            this.nuFrequency.Size = new System.Drawing.Size(91, 20);
            this.nuFrequency.TabIndex = 6;
            this.nuFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuFrequency.ValueChanged += new System.EventHandler(this.nuFrequency_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Amplitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Frequência (Hz)";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuFrequency);
            this.Controls.Add(this.nuAmplitude);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.mainChart);
            this.Name = "MainWindow";
            this.Text = "Biomedical Instrumentation - Threads";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Timer timerGenerator;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown nuAmplitude;
        private System.Windows.Forms.NumericUpDown nuFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

