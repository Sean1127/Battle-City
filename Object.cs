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
        public bool destructible { get; set; }
        public bool drivable { get; set; }
        public bool crossable { get; set; }
        public Type type { get; set; }
        public ImageList water { get; set; }

        public Object() { }

        public Object(Type type)
        {
            this.type = type;
            this.destructible = false;
            this.drivable = false;
            this.crossable = false;
            TypeChanged();
        }

        public void TypeChanged()
        {
            switch (type)
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
    }
}