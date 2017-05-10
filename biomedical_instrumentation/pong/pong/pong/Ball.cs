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

        public Ball(Point _location, int _diameter)
        {
            this.location = _location;
            this.diameter = _diameter;
        }

        public void Move(int distanceX, int distanceY)
        {
            this.location = new Point(this.location.X + distanceX, this.location.Y + distanceY);
        }

        public bool Hit(Point _location)
        {
            if (this.location.X + (this.diameter / 2) >= _location.X)
                return true;
            else
                return false;            
        }
    }
}
