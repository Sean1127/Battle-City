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
using Direction = Tank.Enum.Direction;

namespace Tank
{
    public partial class Form_game : Form
    {
        private Form_stage form_stage;
        private Tank player1;
        private KeyEventArgs repeat;
        private ImageList[][][] imageList_tank;

        public Form_game(Form_stage form_stage, Object[][] map)
        {
            InitializeComponent();
            this.form_stage = form_stage;
        }

        private void Form_game_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;
            this.player1 = new Tank(imageList1);
            this.Controls.Add(player1);
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
            }
            PlayerMove();
            timer_move.Start();
        }

        private void Form_game_KeyUp(object sender, KeyEventArgs e)
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
            }

            if (player1.Direction == Direction.None)
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
            if (player1.Direction == Direction.Down) player1.MoveDown();
            if (player1.Direction == Direction.Left) player1.MoveLeft();
            if (player1.Direction == Direction.Right) player1.MoveRight();
            if (player1.Direction == Direction.Up) player1.MoveUp();
        }
    }
}
