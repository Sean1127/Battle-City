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
    public partial class From_menu : Form
    {
        public From_menu()
        {
            InitializeComponent();
        }

        private void MenuFrom_Load(object sender, EventArgs e)
        {
            
        }

        private void button_singleplayer_Click(object sender, EventArgs e)
        {
            Form_stage form_stage = new Form_stage(this, 1);
            form_stage.Show();
            this.Hide();
        }

        private void button_multiplayer_Click(object sender, EventArgs e)
        {
            Form_stage form_stage = new Form_stage(this, 2);
            form_stage.Show();
            this.Hide();
        }

        private void button_construct_Click(object sender, EventArgs e)
        {
            Form_construct form_construct = new Form_construct(this);
            form_construct.Show();
            this.Hide();
        }
    }
}
