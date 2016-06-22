using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Type = Tank.Enum.Type;
using Dir = Tank.Enum.Dir;

namespace Tank
{

    public partial class Form_game : Form
    {
        private Form_stage form_stage;
        private Tank player1;
        private KeyEventArgs repeat;
        private ImageList[][][] imageList_tank;
        private Object[,] map;
        private Bullet boom;

        public Form_game(Form_stage form_stage, Object[,] map)
        {
            InitializeComponent();
            this.form_stage = form_stage;
            this.map = map;
        }

        private void Form_game_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            this.player1 = new Tank(imageList1, Const.spawnLocation1X, Const.spawnLocation1Y);
            panel1.Controls.Add(player1);
            player1.BringToFront();
            player1.Spawn();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    map[j, i].Size = new Size(32, 32);
                    map[j, i].Top = j * 32;
                    map[j, i].Left = i * 32;
                    panel1.Controls.Add(map[j, i]);
                    if (map[j, i].type == Type.Bush) map[j, i].BringToFront();
                }
            }
        }

        private void Form_game_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form_game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Equals(repeat))
            {
                return;
            }
            repeat = e;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player1.dirLeft = (player1.spawning) ? false : true;
                    player1.direction = Dir.Left;
                    break;
                case Keys.Right:
                    player1.dirRight = (player1.spawning) ? false : true;
                    player1.direction = Dir.Right;
                    break;
                case Keys.Down:
                    player1.dirDown = (player1.spawning) ? false : true;
                    player1.direction = Dir.Down;
                    break;
                case Keys.Up:
                    player1.dirUp = (player1.spawning) ? false : true;
                    player1.direction = Dir.Up;
                    break;
                case Keys.Space:
                    break;
                    
            }
            timer_move.Start();
        }

        private void Form_game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player1.dirLeft = false;
                    player1.direction = Dir.Left;
                    break;
                case Keys.Right:
                    player1.dirRight = false;
                    player1.direction = Dir.Right;
                    break;
                case Keys.Down:
                    player1.dirDown = false;
                    player1.direction = Dir.Down;
                    break;
                case Keys.Up:
                    player1.dirUp = false;
                    player1.direction = Dir.Up;
                    break;
            }

            if (!(player1.dirDown || player1.dirLeft || player1.dirRight || player1.dirUp))
            {
                timer_move.Stop();
            }
        }

        private void timer_move_Tick(object sender, EventArgs e)
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            if (player1.dirDown && !Collision_Down(player1)) player1.MoveDown();
            if (player1.dirLeft && !Collision_Left(player1)) player1.MoveLeft();
            if (player1.dirRight && !Collision_Right(player1)) player1.MoveRight();
            if (player1.dirUp && !Collision_Up(player1)) player1.MoveUp();
        }

        public bool Collision_Left(PictureBox tar)
        {
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X + temp.Width, temp.Location.Y, 1, temp.Height);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        public bool Collision_Down(PictureBox tar)
        {
            foreach (Object ob in map)
            {
                if (ob != null)
                {

                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X, temp.Location.Y - 1, temp.Width, 1);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        public bool Collision_Right(PictureBox tar)
        {
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X - 1, temp.Location.Y, 1, temp.Height);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        public bool Collision_Up(PictureBox tar)
        {
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X, temp.Location.Y + temp.Height, temp.Width, 1);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }
    }
}
