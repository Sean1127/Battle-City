using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Dir = Tank.Enum.Dir;

namespace Tank
{
    public class Bullet : Object
    {
        public Dir direction { get; set; }
        public int tick { get; set; }
        public int speed { get; set; }
        private Tank sender;

        public Bullet(Dir direction, int speed, int x, int y, Tank sender)
        {
            this.sender = sender;
            this.speed = speed;
            this.Top = y;
            this.Left = x;
            this.direction = direction;
            this.Size = new Size(32, 32);
            switch(direction)
            {
                case Dir.Up:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\ammo_up.png");
                    break;
                case Dir.Down:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\ammo_down.png");
                    break;
                case Dir.Right:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\ammo_Right.png");
                    break;
                case Dir.Left:
                    this.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\ammo_Left.png");
                    break;
            }
        }

        public void Explode()
        {
            this.timer = new Timer();
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_tick);
            this.tick = 0;
            switch (direction)
            {
                case Dir.Up:
                    Top = Top - 12;
                    break;
                case Dir.Down:
                    Top = Top + 12;
                    break;
                case Dir.Right:
                    Left = Left - 12;
                    break;
                case Dir.Left:
                    Left = Left + 12;
                    break;
            }
            this.timer.Start();
        }

        public void timer_tick(object sender, EventArgs e)
        {
            switch (tick)
            {
                case 0:
                    Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\pop1.png");
                    break;
                case 1:
                    Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\pop2.png");
                    break;
                case 2:
                    Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\pop3.png");
                    break;
                case 3:
                    Image = null;
                    this.sender.ammo++;
                    break;
            }
            tick++;
        }

        public void Fly()
        {
            switch (direction)
            {
                case Dir.Up:
                    Top -= speed;
                    break;
                case Dir.Down:
                    Top += speed;
                    break;
                case Dir.Right:
                    Left += speed;
                    break;
                case Dir.Left:
                    Left -= speed;
                    break;
            }
        }
    }
}
