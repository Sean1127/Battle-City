using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Map = Tank.MapFile;

namespace Tank
{
    public partial class Form_construct : Form
    {
        private From_menu from_menu;
        private string type;
        private Object[,] map;

        public Form_construct(From_menu from_menu)
        {
            InitializeComponent();
            this.from_menu = from_menu;
        }

        private void Form_construct_Load(object sender, EventArgs e)
        {
            this.type = "road";
            resetMap();
        }

        private void panel_design_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)e.X / 32;
            int y = (int)e.Y / 32;
            if (panel_design.Controls.Contains(map[y, x]))
            {
                panel_design.Controls.Remove(map[y, x]);
                map[y, x].Dispose();
            }
            map[y, x] = new Object(type);
            map[y, x].Size = new Size(32, 32);
            map[y, x].Top = y * 32;
            map[y, x].Left = x * 32;
            panel_design.Controls.Add(map[y, x]);
        }

        private void Form_construct_FormClosed(object sender, FormClosedEventArgs e)
        {
            from_menu.Show();
        }

        private void resetMap()
        {
            map = new Object[13,13];
            panel_design.Controls.Clear();
            /*map[] = phynex*/
        }

        private void 開啟OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    map = Map.ReadMap(open.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 儲存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "map files (*.map)|*.map";
            if (save.ShowDialog() == DialogResult.OK)
            {
                Map.WriteMap(map, save.FileName);
            }
        }

        private void 新增NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save the current file?", "Warning",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                儲存SToolStripMenuItem_Click(sender, e);
                resetMap();
            }
            else if (result == DialogResult.No)
            {
                resetMap();
            }
            else
            {
                return;
            }
        }

        private void iceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "ice";
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "road";
        }

        private void brickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "brick";
        }

        private void steelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "steel";
        }

        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "water";
        }

        private void bushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "buch";
        }

        private void Form_construct_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to leave without saving?", "Warning",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                return;
            }
            else if (result == DialogResult.No)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "map files (*.map)|*.map";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Map.WriteMap(map, save.FileName);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
