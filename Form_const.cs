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
    public partial class Form_construct : Form
    {
        private From_menu from_menu;

        public Form_construct(From_menu from_menu)
        {
            InitializeComponent();
            this.from_menu = from_menu;
        }

        private void Form_construct_Load(object sender, EventArgs e)
        {

        }

        private void Form_construct_FormClosed(object sender, FormClosedEventArgs e)
        {
            from_menu.Show();
        }
    }
}
