using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    class Bullet : Object
    {
        public int direction { get; set; }
        public int tick { get; set; }
        public int speed { get; set; }

        public Bullet(int direction, int speed, int x, int y)
        {
            this.speed = speed;
            this.Top = y;
            this.Left = x;
            this.direction = direction;
        }
    }
}
