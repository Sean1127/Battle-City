using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Map = Tank.MapFile;

namespace Tank
{
    public partial class Form_stage : Form
    {
        private From_menu from_menu;

        private bool player2;

        public Form_stage(From_menu from_menu, bool player2)
        {
            InitializeComponent();
            this.from_menu = from_menu;
            this.player2 = player2;
        }

        private void Form_stage_Load(object sender, EventArgs e)
        {

        }

        private void Form_stage_FormClosed(object sender, FormClosedEventArgs e)
        {
            from_menu.Show();
        }

        private void button_stage_Click(object sender, EventArgs e)
        {
            Object[,] map = Map.ReadMap(Environment.CurrentDirectory + @"\..\..\stage\stage" +
                ((Button)(sender)).Text.Substring(((Button)(sender)).Text.Length - 1, 1) + ".map");
            if (!player2)
            {
                Form_game form_game = new Form_game(this, map);
                form_game.Show();
            }
            else
            {
                Form_game_2player form_game = new Form_game_2player(this, map);
                form_game.Show();
            }
            this.Hide();
        }
    }
}
