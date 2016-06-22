using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dir = Tank.Enum.Dir;

namespace Tank
{
    class Bullet : Object
    {
        public bool dirUp { get; set; }
        public bool dirDown { get; set; }
        public bool dirLeft { get; set; }
        public bool dirRight { get; set; }
        public int tick { get; set; }
        public int speed { get; set; }
        private ImageList imageList;

        public Bullet(ImageList imageList, int x,int y,int direction, int speed)
        {
            this.imageList = imageList;
            this.speed = speed;
        }
    }
}
