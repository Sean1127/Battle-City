using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Direction = Tank.Enum.Direction;
using Color = Tank.Enum.Color;

namespace Tank
{
    public class Tank : Object
    {
        private Direction direction;
        private Color color;
        private int speed = 2;
        private ImageList[][][] imageList_tank;
        private ImageList imageList_explode;
        private int level;
        private int ammo;

        // 測試用，最後要刪掉
        private ImageList imageList;
        private bool animate_type;
        // 測試

        public Tank(System.Windows.Forms.ImageList imageList/*, ImageList[][][] imageList1, ImageList imageList2*/)
        {
            /*
             * this.imageList_tank = imageList1;
             * this.imageList_explode = imageList2;
             */
            this.imageList = imageList; //
            this.animate_type = false; //
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.direction = Direction.None;
        }

        public void MoveUp()
        {
            this.Top -= speed;
            this.Image = (animate_type) ? imageList.Images[0] : imageList.Images[1];
            animate_type = (animate_type) ? false : true;
        }

        public void MoveDown()
        {
            this.Top += speed;
            this.Image = (animate_type) ? imageList.Images[2] : imageList.Images[3];
            animate_type = (animate_type) ? false : true;
        }

        public void MoveLeft()
        {
            this.Left -= speed;
            this.Image = (animate_type) ? imageList.Images[4] : imageList.Images[5];
            animate_type = (animate_type) ? false : true;
        }

        public void MoveRight()
        {
            this.Left += speed;
            this.Image = (animate_type) ? imageList.Images[6] : imageList.Images[7];
            animate_type = (animate_type) ? false : true;
        }

        public bool collision()
        {
            return true;
        }

        public void fire()
        {

        }

        public void upgrade()
        {

        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Ammo
        {
            get { return ammo; }
            set { ammo = value; }
        }
    }
}
