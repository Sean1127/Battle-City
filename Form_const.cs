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
using Type = Tank.Enum.Type;

namespace Tank
{
    public partial class Form_construct : Form
    {
        private From_menu from_menu;
        private Type type;
        private Object[,] map;

        public Form_construct(From_menu from_menu)
        {
            InitializeComponent();
            this.from_menu = from_menu;
            this.type = Type.Road;
            this.map = new Object[13, 13];
        }

        private void Form_construct_Load(object sender, EventArgs e)
        {
            clearMap();
        }

        private void block_MouseClick(object sender, EventArgs e)
        {
            ((Object)(sender)).type = this.type;
            ((Object)(sender)).TypeChanged();
        }

        private void Form_construct_FormClosed(object sender, FormClosedEventArgs e)
        {
            from_menu.Show();
        }

        private void clearMap()
        {
            panel_design.Controls.Clear();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    map[j, i] = new Object(Type.Road);
                    map[j, i].Size = new Size(32, 32);
                    map[j, i].Top = j * 32;
                    map[j, i].Left = i * 32;
                    map[j, i].Click += new System.EventHandler(block_MouseClick);
                    panel_design.Controls.Add(map[j, i]);
                }
            }
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

                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        panel_design.Controls.Add(map[j, i]);
                    }
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
                clearMap();
            }
            else if (result == DialogResult.No)
            {
                clearMap();
            }
            else // Cancle
            {
                return;
            }
        }

        private void iceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.Ice;
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.Road;
        }

        private void brickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.Brick;
        }

        private void steelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.Steel;
        }

        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.Water;
        }

        private void bushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = Type.Bush;
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
                else // Cancle
                {
                    e.Cancel = true;
                }
            }
            else // Cancel
            {
                e.Cancel = true;
            }
        }
    }
}
