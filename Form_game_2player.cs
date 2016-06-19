using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Direction = Tank.Enum.Direction;

namespace Tank
{
    public partial class Form_game_2player : Form
    {
        private Form_stage form_stage;
        private Tank player1;
        private Tank player2;
        private KeyEventArgs repeat;
        private ImageList[][][] imageList_tank;

        public Form_game_2player(Form_stage form_stage)
        {
            InitializeComponent();
            this.form_stage = form_stage;
        }

        private void timer_move_Tick(object sender, EventArgs e)
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            if (player1.Direction == Direction.Down) player1.MoveDown();
            if (player1.Direction == Direction.Left) player1.MoveLeft();
            if (player1.Direction == Direction.Right) player1.MoveRight();
            if (player1.Direction == Direction.Up) player1.MoveUp();
            if (player2.Direction == Direction.Down) player2.MoveDown();
            if (player2.Direction == Direction.Left) player2.MoveLeft();
            if (player2.Direction == Direction.Right) player2.MoveRight();
            if (player2.Direction == Direction.Up) player2.MoveUp();
        }

        private void Form_game_2player_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;
            this.player1 = new Tank(imageList1);
            this.player2 = new Tank(imageList2);
            this.Controls.Add(player2);
            this.Controls.Add(player1);
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
                    player1.Direction = Direction.Left;
                    break;
                case Keys.Right:
                    player1.Direction = Direction.Right;
                    break;
                case Keys.Down:
                    player1.Direction = Direction.Down;
                    break;
                case Keys.Up:
                    player1.Direction = Direction.Up;
                    break;
                case Keys.W:
                    player2.Direction = Direction.Up;
                    break;
                case Keys.A:
                    player2.Direction = Direction.Left;
                    break;
                case Keys.S:
                    player2.Direction = Direction.Down;
                    break;
                case Keys.D:
                    player2.Direction = Direction.Right;
                    break;
            }
            PlayerMove();
            timer_move.Start();
        }

        private void Form_game_2player_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player1.Direction = Direction.None;
                    break;
                case Keys.Right:
                    player1.Direction = Direction.None;
                    break;
                case Keys.Down:
                    player1.Direction = Direction.None;
                    break;
                case Keys.Up:
                    player1.Direction = Direction.None;
                    break;
                case Keys.W:
                    player2.Direction = Direction.None;
                    break;
                case Keys.A:
                    player2.Direction = Direction.None;
                    break;
                case Keys.S:
                    player2.Direction = Direction.None;
                    break;
                case Keys.D:
                    player2.Direction = Direction.None;
                    break;
            }

            if (player1.Direction == Direction.None && player2.Direction == Direction.None)
            {
                timer_move.Stop();
            }
        }

        private void Form_game_2player_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
