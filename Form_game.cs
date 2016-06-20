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

namespace Tank
{

    public partial class Form_game : Form
    {
        private Form_stage form_stage;
        private Tank player1;
        private KeyEventArgs repeat;
        private ImageList[][][] imageList_tank;
        private Object[,] map;

        public Form_game(Form_stage form_stage, Object[,] map)
        {
            InitializeComponent();
            this.form_stage = form_stage;
            this.map = map;
        }

        private void Form_game_Load(object sender, EventArgs e)
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
            panel1.Controls.Add(player1);
            player1.BringToFront();
            player1.Spawn();
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
            }
            timer_move.Start();
        }

        private void Form_game_KeyUp(object sender, KeyEventArgs e)
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
            if (player1.dirDown) player1.MoveDown();
            if (player1.dirLeft) player1.MoveLeft();
            if (player1.dirRight) player1.MoveRight();
            if (player1.dirUp) player1.MoveUp();
        }
    }
}
