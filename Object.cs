using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Type = Tank.Enum.Type;

namespace Tank
{
    public class Object : PictureBox
    {
        protected bool destructible = false;
        protected bool drivable = false;
        protected bool crossable = false;
        protected Type type;
        private ImageList water;

        public Object(Type type)
        {
            this.type = type;
            switch(type)
            {
                case Type.Brick:
                    destructible = true;
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\brick.png");
                    break;
                case Type.Steel:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\steel.png");
                    destructible = true;
                    break;
                case Type.Bush:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\bush.png");
                    drivable = true;
                    crossable = true;
                    break;
                case Type.Ice:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\ice.png");
                    drivable = true;
                    crossable = true;
                    break;
                case Type.Water:
                    crossable = true;
                    water = new ImageList();
                    water.ImageSize = new Size(32, 32);
                    water.Images.Add(Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\water1.png"));
                    water.Images.Add(Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\water2.png"));
                    water.Images.Add(Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\water3.png"));
                    this.Image = water.Images[0];
                    break;
                case Type.Road:
                    crossable = true;
                    drivable = true;
                    this.Image = null;
                    break;
                default:
                    break;
            }
        }

        public bool Destructible
        {
            get { return destructible; }
            set { destructible = value; }
        }

        public bool Drivable
        {
            get { return drivable; }
            set { drivable = value; }
        }

        public bool Crossable
        {
            get { return crossable; }
            set { crossable = value; }
        }
    }
}