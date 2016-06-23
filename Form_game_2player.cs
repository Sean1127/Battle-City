using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dir = Tank.Enum.Dir;
using Type = Tank.Enum.Type;
using System.Timers;

namespace Tank
{
    public partial class Form_game_2player : Form
    {
        private Form_stage form_stage;
        private Tank player1;
        private Tank player2;
        private KeyEventArgs repeat;
        private ImageList[][][] imageList_tank;
        private Object[,] map;
        private Bullet[] bullet;
        

        public Form_game_2player(Form_stage form_stage, Object[,] map)
        {
            InitializeComponent();
            this.form_stage = form_stage;
            this.map = map;
        }

        private void Form_game_2player_Load(object sender, EventArgs e)
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
            this.player2 = new Tank(imageList2, Const.spawnLocation2X, Const.spawnLocation2Y);
            panel1.Controls.Add(player1);
            panel1.Controls.Add(player2);
            player1.BringToFront();
            player2.BringToFront();
            player1.Spawn();
            player2.Spawn();
            bullet = new Bullet[6];
            timer_bullet.Start();
        }

        private void timer_move_Tick(object sender, EventArgs e)
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            if (player1.dirDown && !Collision_Down(player1, player2) && !Collision_Down(player1)) player1.MoveDown();
            if (player1.dirLeft && !Collision_Left(player1, player2) && !Collision_Left(player1)) player1.MoveLeft();
            if (player1.dirRight && !Collision_Right(player1, player2) && !Collision_Right(player1)) player1.MoveRight();
            if (player1.dirUp && !Collision_Top(player1, player2) && !Collision_Up(player1)) player1.MoveUp();
            if (player2.dirDown && !Collision_Down(player2, player1) && !Collision_Down(player2)) player2.MoveDown();
            if (player2.dirLeft && !Collision_Left(player2, player1) && !Collision_Left(player2)) player2.MoveLeft();
            if (player2.dirRight && !Collision_Right(player2, player1) && !Collision_Right(player2)) player2.MoveRight();
            if (player2.dirUp && !Collision_Top(player2, player1) && !Collision_Up(player2)) player2.MoveUp();
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
                    player1.dirLeft = (player1.spawning) ? false : true;
                    player1.direction = Dir.Left;
                    break;
                case Keys.Right:
                    player1.dirRight = (player1.spawning) ? false : true;
                    player1.direction = Dir.Right;
                    break;
                case Keys.Down:
                    player1.dirDown = (player1.spawning) ? false : true;
                    player1.direction = Dir.Down;
                    break;
                case Keys.Up:
                    player1.dirUp = (player1.spawning) ? false : true;
                    player1.direction = Dir.Up;
                    break;
                case Keys.W:
                    player2.dirUp = (player2.spawning) ? false : true;
                    player2.direction = Dir.Up;
                    break;
                case Keys.A:
                    player2.dirLeft = (player2.spawning) ? false : true;
                    player2.direction = Dir.Left;
                    break;
                case Keys.S:
                    player2.dirDown = (player2.spawning) ? false : true;
                    player2.direction = Dir.Down;
                    break;
                case Keys.D:
                    player2.dirRight = (player2.spawning) ? false : true;
                    player2.direction = Dir.Right;
                    break;
                case Keys.Space:
                    Bullet temp = player1.Fire();
                    if (temp != null)
                    {
                        bullet[0] = temp;
                        panel1.Controls.Add(bullet[0]);
                        bullet[0].BringToFront();
                        player1.BringToFront();
                    }
                    break;
                case Keys.J:
                    Bullet temp1 = player2.Fire();
                    if (temp1 != null)
                    {
                        bullet[1] = temp1;
                        panel1.Controls.Add(bullet[1]);
                        bullet[1].BringToFront();
                        player2.BringToFront();
                    }
                    break;
            }
            timer_move.Start();
        }

        private void Form_game_2player_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player1.dirLeft = false;
                    player1.direction = Dir.Left;
                    break;
                case Keys.Right:
                    player1.dirRight = false;
                    player1.direction = Dir.Right;
                    break;
                case Keys.Down:
                    player1.dirDown = false;
                    player1.direction = Dir.Down;
                    break;
                case Keys.Up:
                    player1.dirUp = false;
                    player1.direction = Dir.Up;
                    break;
                case Keys.W:
                    player2.dirUp = false;
                    player2.direction = Dir.Up;
                    break;
                case Keys.A:
                    player2.dirLeft = false;
                    player2.direction = Dir.Left;
                    break;
                case Keys.S:
                    player2.dirDown = false;
                    player2.direction = Dir.Down;
                    break;
                case Keys.D:
                    player2.dirRight = false;
                    player2.direction = Dir.Right;
                    break;
                    /*
                case Keys.Space:
                    Bullet bullet1 = player1.Fire();
                    if (bullet1 != null)
                    {
                        panel1.Controls.Add(bullet1);
                    }
                    break;
                case Keys.RControlKey:
                    Bullet bullet2 = player2.Fire();
                    if (bullet2 != null)
                    {
                        panel1.Controls.Add(bullet2);
                    }
                    break;*/
            }

            if (!(player1.dirDown || player1.dirLeft || player1.dirRight || player1.dirUp ||
                player2.dirDown || player2.dirLeft || player2.dirRight || player2.dirUp))
            {
                timer_move.Stop();
            }
        }

        public bool Collision_Top(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X, temp.Location.Y + temp.Height, temp.Width, 1);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        public bool Collision_Down(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X, temp.Location.Y - 1, temp.Width, 1);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        public bool Collision_Right(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X - 1, temp.Location.Y, 1, temp.Height);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        public bool Collision_Left(PictureBox tar, PictureBox block)
        {
            PictureBox temp = new PictureBox();
            temp.Bounds = block.Bounds;
            temp.SetBounds(temp.Location.X + temp.Width, temp.Location.Y, 1, temp.Height);
            if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
            else return false;
        }

        public bool Collision_Left(PictureBox tar)
        {
            if (tar.Left == 0) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X + temp.Width, temp.Location.Y, 1, temp.Height);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        public bool Collision_Down(PictureBox tar)
        {
            if (tar.Top == 384) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X, temp.Location.Y - 1, temp.Width, 1);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        public bool Collision_Right(PictureBox tar)
        {
            if (tar.Left == 384) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X - 1, temp.Location.Y, 1, temp.Height);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        public bool Collision_Up(PictureBox tar)
        {
            if (tar.Top == 0) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.drivable)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Bounds = ob.Bounds;
                        temp.SetBounds(temp.Location.X, temp.Location.Y + temp.Height, temp.Width, 1);
                        if (tar.Bounds.IntersectsWith(temp.Bounds)) return true;
                    }
                }
            }
            return false;
        }

        private void Form_game_2player_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void timer_bullet_Tick(object sender, EventArgs e)
        {
            //label1.Text = "yes";
           
        }
        private bool HitUp(Bullet b)
        {
            if (b.Top == 0) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.crossable)
                    {
                        if (b.Bounds.IntersectsWith(ob.Bounds))
                        {
                            if (ob.destructible)
                            {
                                if (ob.type == Type.Phenix)
                                {
                                   // GameOver(ob, b);
                                }
                                else
                                {
                                    ob.type = Type.Road;
                                }
                            }
                            ob.TypeChanged();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool HitDown(Bullet b)
        {
            if (b.Top == 384) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.crossable)
                    {
                        if (b.Bounds.IntersectsWith(ob.Bounds))
                        {
                            if (ob.destructible)
                            {
                                if (ob.type == Type.Phenix)
                                {
                                    //GameOver(ob, b);
                                }
                                else
                                {
                                    ob.type = Type.Road;
                                }
                            }
                            ob.TypeChanged();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool HitRight(Bullet b)
        {
            if (b.Left == 384) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.crossable)
                    {
                        if (b.Bounds.IntersectsWith(ob.Bounds))
                        {
                            if (ob.destructible)
                            {
                                if (ob.type == Type.Phenix)
                                {
                                    //GameOver(ob, b);
                                }
                                else
                                {
                                    ob.type = Type.Road;
                                }
                            }
                            ob.TypeChanged();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool HitLeft(Bullet b)
        {
            if (b.Left < 0) return true;
            foreach (Object ob in map)
            {
                if (ob != null)
                {
                    if (!ob.crossable)
                    {
                        if (b.Bounds.IntersectsWith(ob.Bounds))
                        {
                            if (ob.destructible)
                            {
                                if (ob.type == Type.Phenix)
                                {
                                    //GameOver(ob, b);
                                }
                                else
                                {
                                    ob.type = Type.Road;
                                }
                            }
                            ob.TypeChanged();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void GameOver(/*Object ob, Bullet b*/Tank c, Bullet b)
        {
            c.Explode();
            b.Explode();
            //ob.Image = Image.FromFile(Environment.CurrentDirectory + @"\..\..\image\terrain\phenix_dead.png");
            timer_bullet.Stop();
            MessageBox.Show("Game Over", "You're base has been destroyed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            form_stage.Close();
            this.Close();

        }

        private void timer_bullet_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (bullet[i] == null) continue;
                if (bullet[i].tick == 3) panel1.Controls.Remove(bullet[i]);
                switch (bullet[i].direction)
                {
                    case Dir.Up:
                        if (i == 0)
                        {
                            if (!Collision_Top(bullet[i], player2)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player2);
                                GameOver(player2,bullet[i] );
                            }
                        }
                        if (i == 1)
                        {
                            if (!Collision_Top(bullet[i], player1)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player1);
                                GameOver(player1, bullet[i]);
                            }
                        }
                        

                       
                        if (!HitUp(bullet[i])) bullet[i].Fly();
                        else
                        {
                            bullet[i].Explode();
                        }
                        break;
                    case Dir.Down:
                        if (i == 0)
                        {
                            if (!Collision_Top(bullet[i], player2)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player2);
                                GameOver(player2, bullet[i]);
                            }
                        }
                        if (i == 1)
                        {
                            if (!Collision_Top(bullet[i], player1)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player1);
                                GameOver(player1,bullet[i]);
                            }
                        }
                       
                        if (!HitDown(bullet[i])) bullet[i].Fly();
                        else
                        {
                            bullet[i].Explode();

                        }
                        break;
                    case Dir.Right:
                        if (i == 0)
                        {
                            if (!Collision_Top(bullet[i], player2)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player2);
                                GameOver(player2, bullet[i]);
                            }
                        }
                        if (i == 1)
                        {
                            if (!Collision_Top(bullet[i], player1)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player1);
                                GameOver(player1, bullet[i]);
                            }
                        }
                        
                        if (!HitRight(bullet[i])) bullet[i].Fly();
                        else
                        {
                            bullet[i].Explode();
                        }
                        break;
                    case Dir.Left:
                        if (i == 0)
                        {
                            if (!Collision_Left(bullet[i], player2)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player2);
                                GameOver(player2, bullet[i]);
                            }
                        }
                        if (i == 1)
                        {
                            if (!Collision_Left(bullet[i], player1)) bullet[i].Fly();
                            else
                            {
                                bullet[i].Explode();
                                panel1.Controls.Remove(player1);
                                GameOver(player1, bullet[i]);
                            }
                        }
                        
                        if (!HitLeft(bullet[i])) bullet[i].Fly();
                        else
                        {
                            bullet[i].Explode();
                        }
                        break;
                }
            }
        }
    }
}
