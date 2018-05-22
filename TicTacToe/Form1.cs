using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private class Player
        {
            public Player(char icon,int id, System.Drawing.Color Color, System.Drawing.Bitmap Sprite)
            {
                this.id = id;
                this.icon = icon;
                this.Color = Color;
                this.Sprite = Sprite;
            }

            public System.Drawing.Bitmap Sprite;
            public System.Drawing.Color Color;
            public char icon;
            public int id;
        }

        int[,] grid = new int[3,3];
        int move = 0;

        Player turn;
        Player Player1 = new Player('○',1, System.Drawing.Color.Red  , Properties.Resources.o);
        Player Player2 = new Player('×',2, System.Drawing.Color.Blue , Properties.Resources.x);

        Random Rnd = new Random();

        public Form1()
        {
            if (Rnd.Next(0,2) == 1)
            {
                turn = Player1;
            }
            else
            {
                turn = Player2;
            }

            InitializeComponent();
            UpdateAll();
        }

        //Logic

        public void Reset()
        {
            move = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    grid[x,y] = 0;
                }
            }

            button1.BackgroundImage = base.BackgroundImage;
            button2.BackgroundImage = base.BackgroundImage;
            button3.BackgroundImage = base.BackgroundImage;
            button4.BackgroundImage = base.BackgroundImage;
            button5.BackgroundImage = base.BackgroundImage;
            button6.BackgroundImage = base.BackgroundImage;
            button7.BackgroundImage = base.BackgroundImage;
            button8.BackgroundImage = base.BackgroundImage;
            button9.BackgroundImage = base.BackgroundImage;
        }
            
        public void SwapTurn()
        {
            if (turn.id == 2)
            {
                turn = Player1;
            }
            else
            {
                turn = Player2;
            }
        }

        Player IDtoPlayer(int id)
        {
            if (id == 1)
            {
                return Player1;
            }
            return Player2;
        }


        //Returns ID else 0
        int Check3(int a, int b, int c)
        {
            if (a == b && b == c)
            {
                if (a == 0)
                    return 0;
                return a;
            }
            return 0;
        }

        int GetWinner()
        {
            //Horizontal
            int gid = Check3(grid[0,0], grid[1,0], grid[2, 0]);
            if (gid != 0) { return gid; }

            gid = Check3(grid[0, 1], grid[1,1], grid[2, 1]);
            if (gid != 0) { return gid; }

            gid = Check3(grid[0, 2], grid[1, 2], grid[2, 2]);
            if (gid != 0) { return gid; }

            //Vertical
            gid = Check3(grid[0, 0], grid[0, 1], grid[0, 2]);
            if (gid != 0) { return gid; }

            gid = Check3(grid[1, 0], grid[1, 1], grid[1, 2]);
            if (gid != 0) { return gid; }

            gid = Check3(grid[2, 0], grid[2, 1], grid[2, 2]);
            if (gid != 0) { return gid; }

            //Diagonal 
            gid = Check3(grid[0, 0], grid[1, 1], grid[2, 2]);
            if (gid != 0) { return gid; }

            gid = Check3(grid[0, 2], grid[1, 1], grid[2, 0]);
            if (gid != 0) { return gid; }


            return 0;
        }

        void EnableAll(bool yes)
        {
            button1.Enabled = yes;
            button2.Enabled = yes;
            button3.Enabled = yes;
            button4.Enabled = yes;
            button5.Enabled = yes;
            button6.Enabled = yes;
            button7.Enabled = yes;
            button8.Enabled = yes;
            button9.Enabled = yes;
        }

        void Final(Player winner, bool draw)
        {
            EnableAll(false);
            label1.ForeColor = winner.Color;

            if (draw)
            {
                label1.ForeColor = System.Drawing.Color.Gray;
                label1.Text = "Gelijk spel";
                return;
            }


            if (winner.id == 1)
            {
                label1.Text = "Rood";
            }
            else
            {
                label1.Text = "Blauw";
            }
            label1.Text += " heeft gewonnen";

        }

        public void JustDidMove()
        {
            move++;
            SwapTurn();

            int winner = GetWinner();

            if (winner != 0)
            {
                Final(IDtoPlayer(winner),false);
                return;
            }

            if (move >= 9)
            {
                Final(IDtoPlayer(winner),true);
                return;
            }

            UpdateAll();
        }

        public void UpdateAll()
        {
            button11.BackColor = turn.Color;
        }

        //Buttons

        //Restart
        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            EnableAll(true);
            Reset();
            UpdateAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackgroundImage == base.BackgroundImage)
            {
                button1.BackgroundImage = turn.Sprite;
                grid[0,0] = turn.id;
                JustDidMove();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackgroundImage == base.BackgroundImage)
            {
                button2.BackgroundImage = turn.Sprite;
                grid[1, 0] = turn.id;
                JustDidMove();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackgroundImage == base.BackgroundImage)
            {
                button5.BackgroundImage = turn.Sprite;
                grid[2, 0] = turn.id;
                JustDidMove();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackgroundImage == base.BackgroundImage)
            {
                button3.BackgroundImage = turn.Sprite;
                grid[0, 1] = turn.id;
                JustDidMove();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackgroundImage == base.BackgroundImage)
            {
                button4.BackgroundImage = turn.Sprite;
                grid[1, 1] = turn.id;
                JustDidMove();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackgroundImage == base.BackgroundImage)
            {
                button6.BackgroundImage = turn.Sprite;
                grid[2, 1] = turn.id;
                JustDidMove();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackgroundImage == base.BackgroundImage)
            {
                button7.BackgroundImage = turn.Sprite;
                grid[0, 2] = turn.id;
                JustDidMove();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackgroundImage == base.BackgroundImage)
            {
                button8.BackgroundImage = turn.Sprite;
                grid[1, 2] = turn.id;
                JustDidMove();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackgroundImage == base.BackgroundImage)
            {
                button9.BackgroundImage = turn.Sprite;
                grid[2, 2] = turn.id;
                JustDidMove();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (move == 0)
            {
                SwapTurn();
                UpdateAll();
            }
        }
    }
}
