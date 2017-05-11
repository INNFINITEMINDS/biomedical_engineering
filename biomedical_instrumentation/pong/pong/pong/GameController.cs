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
        private const int ballDiameter = 20;        
        public int worldWidth;
        public int worldHeight;
        private Ball pongBall;
        private Player pongPlayer;
        public int scoreDefense = 0;
        public int scoreGoals = 0;

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

        private double Deg2Rad(double _angle)
        {
            return Math.PI * (_angle / 180.0);
        }

        public void Update()
        {
            double s = Math.Sin(Math.PI * -90 / 180);

            //Steps that the cursor will move
            int dstep = this.pongBall.diameter;

            //Moves the player
            this.pongPlayer.Move(0, 10);

            //Moves the ball
            this.pongBall.Move(dstep, dstep);

            double auxx = this.pongBall.directionX;
            double auxy = this.pongBall.directionY;

            //Checks if the ball has hit  
            if (this.pongBall.Hit(new Point(this.worldWidth, this.worldHeight)))
            {            
                this.pongBall.directionX = Convert.ToInt32(auxx * Math.Cos(this.Deg2Rad(-90)) - auxy * Math.Sin(this.Deg2Rad(-90)));
                this.pongBall.directionY = Convert.ToInt32(auxy * Math.Cos(this.Deg2Rad(-90)) + auxx * Math.Sin(this.Deg2Rad(-90)));
            }
            //Checks if the ball has hit  
            else if (this.pongBall.Hit(new Point(0, this.worldHeight)))
            {
                this.pongBall.directionX = Convert.ToInt32(auxx * Math.Cos(this.Deg2Rad(-90)) - auxy * Math.Sin(this.Deg2Rad(-90)));
                this.pongBall.directionY = Convert.ToInt32(auxy * Math.Cos(this.Deg2Rad(-90)) + auxx * Math.Sin(this.Deg2Rad(-90)));
            }
            //Checks if the ball has hit
            else if (this.pongBall.Hit(new Point(0, 0)))
            {
                this.pongBall.directionX = Convert.ToInt32(auxx * Math.Cos(this.Deg2Rad(-90)) - auxy * Math.Sin(this.Deg2Rad(-90)));
                this.pongBall.directionY = Convert.ToInt32(auxy * Math.Cos(this.Deg2Rad(-90)) + auxx * Math.Sin(this.Deg2Rad(-90)));
            }
            //Checks if the ball has hit
            else if (this.pongBall.Hit(new Point(0, this.worldHeight)))
            {
                this.pongBall.directionX = Convert.ToInt32(auxx * Math.Cos(this.Deg2Rad(-90)) - auxy * Math.Sin(this.Deg2Rad(-90)));
                this.pongBall.directionY = Convert.ToInt32(auxy * Math.Cos(this.Deg2Rad(-90)) + auxx * Math.Sin(this.Deg2Rad(-90)));
            }

            if (this.pongBall.location.Y < 0 || this.pongBall.location.Y > this.worldHeight)
                this.pongBall.directionY *= -1;

            if (this.pongBall.location.X < 0 || this.pongBall.location.X > this.worldWidth)
                this.pongBall.directionX *= -1;

            //Checks if the ball has collided with the player
        }
    }
}
