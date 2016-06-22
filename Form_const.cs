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
        private Type pen;
        private Object[,] map;
        private bool penDown;

        public Form_construct(From_menu from_menu)
        {
            InitializeComponent();
            this.from_menu = from_menu;
            this.pen = Type.Road;
            this.map = new Object[13, 13];
            this.penDown = false;
        }

        private void setMap(bool reset = false)
        {
            panel_design.Controls.Clear();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (reset) map[j, i] = new Object(Type.Road);
                    map[j, i].Size = new Size(32, 32);
                    map[j, i].Top = j * 32;
                    map[j, i].Left = i * 32;
                    map[j, i].MouseDown += new System.Windows.Forms.MouseEventHandler(block_MouseDown);
                    map[j, i].MouseUp += new System.Windows.Forms.MouseEventHandler(block_MouseUp);
                    map[j, i].MouseMove += new System.Windows.Forms.MouseEventHandler(block_MouseMove);
                    panel_design.Controls.Add(map[j, i]);
                }
            }
        }

        private void Form_construct_Load(object sender, EventArgs e)
        {
            setMap(true);
        }

        private void block_MouseUp(object sender, MouseEventArgs e)
        {
            penDown = false;
        }

        private void block_MouseDown(object sender, MouseEventArgs e)
        {
            ((Object)(sender)).type = this.pen; // get the sener object
            ((Object)(sender)).TypeChanged();
            penDown = true;
        }

        private void block_MouseMove(object sender, MouseEventArgs e)
        {
            int x = (e.X + ((Object)(sender)).Left)/32;
            int y = (e.Y + ((Object)(sender)).Top)/32;
            if (penDown)
            {
                try
                {
                    map[y, x].type = this.pen;
                    map[y, x].TypeChanged();
                }
                catch 
                {
                    return;
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
                setMap();
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
                setMap(true);
            }
            else if (result == DialogResult.No)
            {
                setMap(true);
            }
            // else Cancle -> return
        }

        private void iceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = Type.Ice;
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = Type.Road;
        }

        private void brickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = Type.Brick;
        }

        private void steelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = Type.Steel;
        }

        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = Type.Water;
        }

        private void bushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = Type.Bush;
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

        private void Form_construct_FormClosed(object sender, FormClosedEventArgs e)
        {
            from_menu.Show();
        }

        private void 結束XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
