using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    class Tank : PictureBox
    {
        private bool up;
        private bool down;
        private bool left;
        private bool right;
        private bool animate_type;
        private int speed = 2;
        private System.Windows.Forms.ImageList imageList;

        public Tank(System.Windows.Forms.ImageList imageList)
        {
            this.imageList = imageList;
            this.animate_type = false;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public bool Up
        {
            get { return up; }
            set { up = value; }
        }

        public void SetDown(bool b)
        {
            down = b;
        }

        public void SetRight(bool b)
        {
            right = b;
        }

        public void SetLeft(bool b)
        {
            left = b;
        }

        public bool getRight()
        {
            return right;
        }

        public bool getLeft()
        {
            return left;
        }

        public bool getDown()
        {
            return down;
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
    }
}
