using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    public partial class Form_game_2player : Form
    {
        private Form_stage form_stage;
        private Tank player1;
        private Tank player2;
        private KeyEventArgs repeat;
        private ImageList[][][] imageList_tank;
        private Object[,] map;

        public Form_game_2player(Form_stage form_stage, Object[,] map)
        {
            InitializeComponent();
            this.form_stage = form_stage;
            this.map = map;
        }

        private void Form_game_2player_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    map[j, i].Size = new Size(32, 32);
                    map[j, i].Top = j * 32;
                    map[j, i].Left = i * 32;
                    panel1.Controls.Add(map[j, i]);
                }
            }

            this.player1 = new Tank(imageList1, Const.spawnLocation1X, Const.spawnLocation1Y);
            this.player2 = new Tank(imageList2, Const.spawnLocation2X, Const.spawnLocation2Y);
            panel1.Controls.Add(player1);
            panel1.Controls.Add(player2);
            player1.BringToFront();
            player2.BringToFront();
            player1.Spawn();
            player2.Spawn();
        }

        private void timer_move_Tick(object sender, EventArgs e)
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            if (player1.dirDown && !Collision_Down(player1,player2)) player1.MoveDown();
            if (player1.dirLeft && !Collision_Left(player1,player2)) player1.MoveLeft();
            if (player1.dirRight && !Collision_Right(player1, player2)) player1.MoveRight();
            if (player1.dirUp && !Collision_Top(player1, player2)) player1.MoveUp();
            if (player2.dirDown && !Collision_Down(player2, player1)) player2.MoveDown();
            if (player2.dirLeft && !Collision_Left(player2, player1)) player2.MoveLeft();
            if (player2.dirRight && !Collision_Right(player2, player1)) player2.MoveRight();
            if (player2.dirUp && !Collision_Top(player2, player1)) player2.MoveUp();
        }

        private void Form_game_2player_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.Right:
                    player1.dirRight = (player1.spawning) ? false : true;
                    break;
                case Keys.Down:
                    player1.dirDown = (player1.spawning) ? false : true;
                    break;
                case Keys.Up:
                    player1.dirUp = (player1.spawning) ? false : true;
                    break;
                case Keys.W:
                    player2.dirUp = (player2.spawning) ? false : true;
                    break;
                case Keys.A:
                    player2.dirLeft = (player2.spawning) ? false : true;
                    break;
                case Keys.S:
                    player2.dirDown = (player2.spawning) ? false : true;
                    break;
                case Keys.D:
                    player2.dirRight = (player2.spawning) ? false : true;
                    break;
            }
            timer_move.Start();
        }

        private void Form_game_2player_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player1.dirLeft = false;
                    break;
                case Keys.Right:
                    player1.dirRight = false;
                    break;
                case Keys.Down:
                    player1.dirDown = false;
                    break;
                case Keys.Up:
                    player1.dirUp = false;
                    break;
                case Keys.W:
                    player2.dirUp = false;
                    break;
                case Keys.A:
                    player2.dirLeft = false;
                    break;
                case Keys.S:
                    player2.dirDown = false;
                    break;
                case Keys.D:
                    player2.dirRight = false;
                    break;
            }

            if (!(player1.dirDown || player1.dirLeft || player1.dirRight || player1.dirUp ||
                player2.dirDown || player2.dirLeft || player2.dirRight || player2.dirUp))
            {
                timer_move.Stop();
            }
        }

        public bool Collision_Top(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X, temp.Location.Y + temp.Height - 1, temp.Width, 1);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        public bool Collision_Down(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X, temp.Location.Y, temp.Width, 1);
            if (tar.Bounds.IntersectsWith(block.Bounds)) return true;
            else return false;
        }

        public bool Collision_Right(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X, temp.Location.Y, 1, temp.Height);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        public bool Collision_Left(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X + temp.Width - 1, temp.Location.Y, 1, temp.Height);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        private void Form_game_2player_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
