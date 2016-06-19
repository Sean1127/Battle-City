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
    public partial class Form_stage : Form
    {
        private From_menu from_menu;

        private int number;

        public Form_stage(From_menu from_menu, int number)
        {
            InitializeComponent();
            this.from_menu = from_menu;
            this.number = number;
        }

        private void Form_stage_Load(object sender, EventArgs e)
        {

        }

        private void Form_stage_FormClosed(object sender, FormClosedEventArgs e)
        {
            from_menu.Show();
        }

        private void button_stage1_Click(object sender, EventArgs e)
        {
            Form_game form_game = new Form_game(this, number);
            form_game.Show();
            this.Hide();
        }
    }
}
