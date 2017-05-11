using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace pong
{
    public class Ball
    {
        public Color color { get; set; }
        public Point location { get; set; }
        public int diameter { get; set; }
        public int directionX { get; set; }
        public int directionY { get; set; }
        public int degreeMotion { get; set; }

        public Ball(Point _location, int _diameter)
        {
            this.location = _location;
            this.diameter = _diameter;
            this.directionX = 1;
            this.directionY = 1;
        }

        public void Move(int distanceX, int distanceY)
        {
            this.location = new Point(this.location.X + (distanceX * this.directionX), this.location.Y + (distanceY * this.directionY * -1));
        }

        public bool Hit(Point _location)
        {
            //Checks if the point is within the ball
            if (_location.X >= this.location.X - (this.diameter / 2) && _location.X <= this.location.X + (this.diameter / 2))
                return true;
            else if (_location.Y >= this.location.Y - (this.diameter / 2) && _location.Y <= this.location.Y + (this.diameter / 2))
                return true;
            else
                return false;
        }
    }
}
