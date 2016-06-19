using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    public class Object : PictureBox
    {
        protected bool destructible;
        protected bool drivable;
        protected bool crossable;

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