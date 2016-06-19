using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = Tank.Enum.Color;

namespace Tank
{
    public class Tank : Object
    {
        public bool dirUp { get; set; }
        public bool dirDown { get; set; }
        public bool dirLeft { get; set; }
        public bool dirRight { get; set; }
        public Color color { get; set; }
        public int speed { get; set; }
        public ImageList[][][] imageList_tank { get; set; }
        public ImageList imageList_explode { get; set; }
        public int level { get; set; }
        public int ammo { get; set; }

        public ImageList imageList { get; set; } // 
        public bool animate_type { get; set; } // 

        public Tank(System.Windows.Forms.ImageList imageList/*, ImageList[][][] imageList1, ImageList imageList2*/)
        {
            /*
             * this.imageList_tank = imageList1;
             * this.imageList_explode = imageList2;
             */
            this.imageList = imageList; //
            this.animate_type = false; //
            this.Size = new Size(32, 32);
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.speed = 1;
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
    }
}
