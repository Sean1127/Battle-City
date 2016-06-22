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
        public ImageList animation { get; set; }
        public Timer timer;

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
                    animation = new ImageList();
                    animation.ImageSize = new Size(32, 32);
                    animation.Images.Add(Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\water1.png"));
                    animation.Images.Add(Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\water2.png"));
                    animation.Images.Add(Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\water3.png"));
                    this.Image = animation.Images[0];
                    break;
                case Type.Road:
                    crossable = true;
                    drivable = true;
                    this.Image = null;
                    break;
                case Type.Phenix:
                    destructible = true;
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\phenix.png");
                    break;
                
                default:
                    //destructible = true;
                    break;
            }
        }
    }
}