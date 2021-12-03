using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        public class Cell
        {
            public virtual bool IsAlive { get; set; }
            public int X; //X-coordinate
            public int Y; //Y-coordinate
            public PictureBox cellbox;

            public List<Cell> neighbours = new List<Cell>();
        }

        public class PotCell : Cell
        {
            public override bool IsAlive {get { return false;} }
            
        }


        public Form1()
        {
            InitializeComponent();

            int coldist = ((Board.Width / 2) / nmrOfcols); //Calculate distance for cell in grid
            int rowdist = (Board.Height / nmrOfrows);


            for (int i = 0; i < nmrOfrows; i++)
            {
                GridArr[i] = new int[nmrOfcols * 2];
                for (int k = 0; k < nmrOfcols*2; k++)
                {
                    PictureBox pc = new PictureBox();
                    pc.Location = new Point(coldist * k, rowdist * i); //Spawnpoint of pictureboxes
                    pc.Parent = Board;
                    pc.Size = new Size(coldist, rowdist);
                    pc.Parent = Board;
                    pc.MouseClick += new System.Windows.Forms.MouseEventHandler(pc_MouseClick);
                    pclist.Add(pc);
                    GridArr[i][k] = pclist.IndexOf(pc);
                    pc.BackColor = Color.Transparent;
                }
            }
        }

        public bool runSim = false;
        public List<Cell> cells = new List<Cell>();
        public static int nmrOfrows = 10;
        public static int nmrOfcols = 10; 
        public bool hasClicked = false;
        public List<PictureBox> pclist = new List<PictureBox>();
        public int[][] GridArr = new int[nmrOfrows][];
        public List<PotCell> potlist = new List<PotCell>();


        private void button1_Click(object sender, EventArgs e)
        {
            if(!runSim)
            {
                runSim = true;
            }
            else
            {
                runSim = false;
            }
            Simulation(runSim);
        }

        void Simulation(bool run)
        {

            if(run) //Game
            {
                UpdateBoard(potlist);

                #region Generate Potcells
                foreach (Cell c in cells)
                {
                    if(c.X>0 && c.X < nmrOfcols*2)
                    {
                        PotCell left = new PotCell()
                        {
                            X = c.X - 1,
                            Y = c.Y
                        };

                        potlist.Add(left);

                        PotCell right = new PotCell()
                        {
                            X = c.X + 1,
                            Y = c.Y
                        };

                        potlist.Add(right);
                    }

                    if(c.Y > 0 && c.Y < nmrOfrows)
                    {
                        PotCell up = new PotCell()
                        {
                            X = c.X,
                            Y = c.Y - 1
                        };

                        potlist.Add(up);

                        PotCell down = new PotCell()
                        {
                            X = c.X,
                            Y = c.Y +1
                        };

                        potlist.Add(down);
                    }

                    if (c.Y > 0 && c.Y < nmrOfrows && c.X > 0 && c.X < nmrOfcols * 2)
                    {
                        PotCell upleft = new PotCell()
                        {
                            X = c.X - 1,
                            Y = c.Y - 1
                        };

                        potlist.Add(upleft);

                        PotCell downleft = new PotCell()
                        {
                            X = c.X - 1,
                            Y = c.Y + 1
                        };

                        potlist.Add(downleft);

                        PotCell upright = new PotCell()
                        {
                            X = c.X + 1,
                            Y = c.Y - 1
                        };

                        potlist.Add(upright);

                        PotCell downright = new PotCell()
                        {
                            X = c.X + 1,
                            Y = c.Y + 1
                        };

                        potlist.Add(downright); //fix this shit
                    }
                }
                #endregion

                UpdateBoard(potlist);
            }
        }

        private void UpdateBoard(List<PotCell> potlist)
        {
            for (int i = 0; i < potlist.Count; i++)
            {
                foreach (Cell c in cells)
                {
                    if (potlist[i].X == c.X && potlist[i].Y == c.Y)
                    {
                        potlist.RemoveAt(i);
                    }
                }
            }

            for (int i = 0; i < potlist.Count; i++)
            {
                for (int k = 0; k < potlist.Count; k++)
                {
                    if (potlist[i].X == potlist[k].X && potlist[i].Y == potlist[k].Y && potlist[i] != potlist[k])
                    {
                        potlist.RemoveAt(i);
                    }
                }
            }
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

            for(int i = 1;i<nmrOfrows;i++)
            {
                g.DrawLine(p,0,(Board.Height/nmrOfrows)*i,Board.Width,(Board.Height/nmrOfrows)*i);
            }

            for (int i = 1; i < nmrOfcols*2; i++)
            {
                g.DrawLine(p, ((Board.Width/2) / nmrOfcols) * i, 0,((Board.Width/2) / nmrOfcols) * i, Board.Height);
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            hasClicked = false;
        }

        private void pc_MouseClick(object sender, MouseEventArgs e)
        {

            PictureBox pc = (PictureBox)sender;

            hasClicked = true;
            Cell item = new Cell();
            item.cellbox = pc;

            foreach(int[] row in GridArr)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] == pclist.IndexOf(pc))
                    {
                        item.Y = Array.IndexOf(GridArr, row);
                        item.X = i;
                    }
                }
            }
            item.cellbox.BackColor = Color.Blue;
            item.IsAlive = true;
            cells.Add(item);

        }
    }
}
