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
        public int speed { get; set; }
        private ImageList imageList;

        public Bullet(ImageList imageList, int direction, int speed)
        {
            this.imageList = imageList;
            this.speed = speed;
        }
    }
}
