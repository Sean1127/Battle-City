using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Direction = Tank.Enum.Direction;

namespace Tank
{
    class Bullet : Object
    {
        private Direction direction;
        private int speed;
        private ImageList imageList;

        public Bullet(ImageList imageList, Direction direction, int speed)
        {
            this.imageList = imageList;
            this.direction = direction;
            this.speed = speed;
        }

        public Direction Direction
        {
            get { return Direction; }
            set { direction = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
