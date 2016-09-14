namespace STR_Projeto1
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chGrafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nuFrequencia = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmarFreq = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cdCorGrafico = new System.Windows.Forms.ColorDialog();
            this.btnCor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuFrequencia)).BeginInit();
            this.SuspendLayout();
            // 
            // chGrafico
            // 
            legend1.Name = "Legend1";
            this.chGrafico.Legends.Add(legend1);
            this.chGrafico.Location = new System.Drawing.Point(327, 18);
            this.chGrafico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chGrafico.Name = "chGrafico";
            this.chGrafico.Size = new System.Drawing.Size(490, 429);
            this.chGrafico.TabIndex = 0;
            this.chGrafico.Text = "chart1";
            // 
            // nuFrequencia
            // 
            this.nuFrequencia.Location = new System.Drawing.Point(18, 45);
            this.nuFrequencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nuFrequencia.Name = "nuFrequencia";
            this.nuFrequencia.Size = new System.Drawing.Size(138, 26);
            this.nuFrequencia.TabIndex = 1;
            this.nuFrequencia.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Frequência (Hz)";
            // 
            // btnConfirmarFreq
            // 
            this.btnConfirmarFreq.Location = new System.Drawing.Point(18, 81);
            this.btnConfirmarFreq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfirmarFreq.Name = "btnConfirmarFreq";
            this.btnConfirmarFreq.Size = new System.Drawing.Size(132, 35);
            this.btnConfirmarFreq.TabIndex = 3;
            this.btnConfirmarFreq.Text = "Gerar Senóide";
            this.btnConfirmarFreq.UseVisualStyleBackColor = true;
            this.btnConfirmarFreq.Click += new System.EventHandler(this.btnConfirmarFreq_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Configurações";
            // 
            // btnCor
            // 
            this.btnCor.Location = new System.Drawing.Point(28, 159);
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(108, 34);
            this.btnCor.TabIndex = 5;
            this.btnCor.Text = "Cor";
            this.btnCor.UseVisualStyleBackColor = true;
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 465);
            this.Controls.Add(this.btnCor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirmarFreq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuFrequencia);
            this.Controls.Add(this.chGrafico);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuFrequencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chGrafico;
        private System.Windows.Forms.NumericUpDown nuFrequencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmarFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog cdCorGrafico;
        private System.Windows.Forms.Button btnCor;
    }
}

