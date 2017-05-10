using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong
{
    public partial class PongWindow : Form
    {
        public GameController gameController;

        public PongWindow()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
        }

        private void PongWindow_Load(object sender, EventArgs e)
        {
            this.gameController = new GameController(pongWorld.Width, pongWorld.Height);
            this.Refresh();
        }

        private void PongWindow_Paint(object sender, PaintEventArgs e)
        {
            this.pongWorld.Refresh();
        }

        private void pongWorld_Paint(object sender, PaintEventArgs e)
        {
            this.gameController.Draw(e);            
        }

        private void PongWindow_SizeChanged(object sender, EventArgs e)
        {
            this.gameController.SetWorld(pongWorld.Width, pongWorld.Height);
            this.Refresh();
        }

        private void pongTimer_Tick(object sender, EventArgs e)
        {
            this.gameController.Update();
            this.Refresh();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            this.pongTimer.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            this.pongTimer.Stop();
        }

        private void PongWindow_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString() + " " + e.Y.ToString();
        }
    }
}
