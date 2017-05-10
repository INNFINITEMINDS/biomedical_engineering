using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace pong
{
    public class GameController
    {
        private const int ballDiameter = 10;        
        public int worldWidth;
        public int worldHeight;
        private Ball pongBall;
        private Player pongPlayer;

        public GameController(int _worldWidth, int _worldHeight)
        {            
            this.worldWidth = _worldWidth;
            this.worldHeight = _worldHeight;

            //Default position of the ball -- middle of the "field" or world
            int ballCenterX = this.worldWidth / 2;
            int ballCenterY = this.worldHeight / 2;
            Point ballCenter = new Point(ballCenterX, ballCenterY);

            this.pongBall = new Ball(ballCenter, ballDiameter);
            this.pongPlayer = new Player(new Point(20, 0), 10, 100);
        }

        public void SetWorld(int _worldWidth, int _worldHeight)
        {            
            this.worldWidth = _worldWidth;
            this.worldHeight = _worldHeight;
            //Default position of the ball -- middle of the "field" or world
            int ballCenterX = this.worldWidth / 2;
            int ballCenterY = this.worldHeight / 2;
            Point ballCenter = new Point(ballCenterX, ballCenterY);
            this.pongBall.location = ballCenter;
        }
        
        public void Draw(PaintEventArgs e)
        {            
            Pen p = new Pen(Color.Black, 5);            
            //Drawing the ball
            e.Graphics.DrawEllipse(p, this.pongBall.location.X, this.pongBall.location.Y, this.pongBall.diameter, this.pongBall.diameter);
            e.Graphics.DrawRectangle(p, this.pongPlayer.location.X, this.pongPlayer.location.Y, this.pongPlayer.width, this.pongPlayer.height);
        }

        public void Update()
        {
            //Moves the player
            this.pongPlayer.Move(0, 50);
            //Moves the ball
            this.pongBall.Move(10, 0);

            //Checks if the ball has collided with one of the walls
            if (this.pongBall.Hit(new Point(this.worldWidth,this.worldHeight)))
            {
                bool x = false;
            }

            //Checks if the ball has collided with the player
        }
    }
}
