namespace pong
{
    partial class PongWindow
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
            this.pongWorld = new System.Windows.Forms.Panel();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.rbMouse = new System.Windows.Forms.RadioButton();
            this.rbKeyboard = new System.Windows.Forms.RadioButton();
            this.pongTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pongWorld
            // 
            this.pongWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pongWorld.BackColor = System.Drawing.Color.Lavender;
            this.pongWorld.Location = new System.Drawing.Point(104, 27);
            this.pongWorld.Name = "pongWorld";
            this.pongWorld.Size = new System.Drawing.Size(469, 344);
            this.pongWorld.TabIndex = 0;
            this.pongWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.pongWorld_Paint);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(13, 27);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(13, 56);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // rbMouse
            // 
            this.rbMouse.AutoSize = true;
            this.rbMouse.Location = new System.Drawing.Point(13, 86);
            this.rbMouse.Name = "rbMouse";
            this.rbMouse.Size = new System.Drawing.Size(57, 17);
            this.rbMouse.TabIndex = 3;
            this.rbMouse.TabStop = true;
            this.rbMouse.Text = "Mouse";
            this.rbMouse.UseVisualStyleBackColor = true;
            // 
            // rbKeyboard
            // 
            this.rbKeyboard.AutoSize = true;
            this.rbKeyboard.Location = new System.Drawing.Point(13, 109);
            this.rbKeyboard.Name = "rbKeyboard";
            this.rbKeyboard.Size = new System.Drawing.Size(70, 17);
            this.rbKeyboard.TabIndex = 4;
            this.rbKeyboard.TabStop = true;
            this.rbKeyboard.Text = "Keyboard";
            this.rbKeyboard.UseVisualStyleBackColor = true;
            // 
            // pongTimer
            // 
            this.pongTimer.Interval = 50;
            this.pongTimer.Tick += new System.EventHandler(this.pongTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // PongWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbKeyboard);
            this.Controls.Add(this.rbMouse);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.pongWorld);
            this.Name = "PongWindow";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.PongWindow_Load);
            this.SizeChanged += new System.EventHandler(this.PongWindow_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PongWindow_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PongWindow_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pongWorld;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.RadioButton rbMouse;
        private System.Windows.Forms.RadioButton rbKeyboard;
        private System.Windows.Forms.Timer pongTimer;
        private System.Windows.Forms.Label label1;
    }
}

