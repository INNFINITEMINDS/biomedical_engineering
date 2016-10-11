namespace intro_serial
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btAbrir = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btEnviar = new System.Windows.Forms.Button();
            this.tbTextoEnviar = new System.Windows.Forms.TextBox();
            this.tbReceber = new System.Windows.Forms.TextBox();
            this.btReceber = new System.Windows.Forms.Button();
            this.cbPortasCOM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btRecebeByte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAbrir
            // 
            this.btAbrir.Location = new System.Drawing.Point(12, 57);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(75, 23);
            this.btAbrir.TabIndex = 0;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(11, 86);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(75, 23);
            this.btFechar.TabIndex = 1;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(102, 83);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(103, 23);
            this.btEnviar.TabIndex = 2;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // tbTextoEnviar
            // 
            this.tbTextoEnviar.Location = new System.Drawing.Point(102, 57);
            this.tbTextoEnviar.Name = "tbTextoEnviar";
            this.tbTextoEnviar.Size = new System.Drawing.Size(103, 20);
            this.tbTextoEnviar.TabIndex = 3;
            // 
            // tbReceber
            // 
            this.tbReceber.Location = new System.Drawing.Point(102, 112);
            this.tbReceber.Name = "tbReceber";
            this.tbReceber.Size = new System.Drawing.Size(103, 20);
            this.tbReceber.TabIndex = 5;
            // 
            // btReceber
            // 
            this.btReceber.Location = new System.Drawing.Point(102, 138);
            this.btReceber.Name = "btReceber";
            this.btReceber.Size = new System.Drawing.Size(103, 23);
            this.btReceber.TabIndex = 4;
            this.btReceber.Text = "Receber";
            this.btReceber.UseVisualStyleBackColor = true;
            this.btReceber.Click += new System.EventHandler(this.btReceber_Click);
            // 
            // cbPortasCOM
            // 
            this.cbPortasCOM.FormattingEnabled = true;
            this.cbPortasCOM.Location = new System.Drawing.Point(139, 18);
            this.cbPortasCOM.Name = "cbPortasCOM";
            this.cbPortasCOM.Size = new System.Drawing.Size(121, 21);
            this.cbPortasCOM.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Portas COM disponíveis";
            // 
            // btRecebeByte
            // 
            this.btRecebeByte.Location = new System.Drawing.Point(102, 168);
            this.btRecebeByte.Name = "btRecebeByte";
            this.btRecebeByte.Size = new System.Drawing.Size(103, 23);
            this.btRecebeByte.TabIndex = 8;
            this.btRecebeByte.Text = "Receber byte";
            this.btRecebeByte.UseVisualStyleBackColor = true;
            this.btRecebeByte.Click += new System.EventHandler(this.btRecebeByte_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 214);
            this.Controls.Add(this.btRecebeByte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPortasCOM);
            this.Controls.Add(this.tbReceber);
            this.Controls.Add(this.btReceber);
            this.Controls.Add(this.tbTextoEnviar);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btAbrir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox tbTextoEnviar;
        private System.Windows.Forms.TextBox tbReceber;
        private System.Windows.Forms.Button btReceber;
        private System.Windows.Forms.ComboBox cbPortasCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRecebeByte;
    }
}

