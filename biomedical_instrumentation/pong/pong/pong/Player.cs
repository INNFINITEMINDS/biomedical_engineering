using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pong
{
    public class Player
    {
        public Point location;
        public int width;
        public int height;

        public Player(Point _origin, int _width, int _height)
        {
            this.location = _origin;
            this.width = _width;
            this.height = _height;
        }

        public void Move(int distanceX, int distanceY)
        {
            this.location.X += distanceX;
            this.location.Y += distanceY;
        }
    }
}
