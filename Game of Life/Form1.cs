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
            public bool IsAlive { get; set; }
            public int X; //X-coordinate
            public int Y; //Y-coordinate

            public List<Cell> neighbours = new List<Cell>();
        }

        public Form1()
        {
            InitializeComponent();
        }
        public bool runSim = false;
        public List<Cell> cells = new List<Cell>();
        public int nmrOfrows = 10;
        public int nmrOfcols = 10;

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
                Cell item = new Cell();
                item.X = 2;
                item.Y = 2;
                cells.Add(item);

                Cell test = new Cell();
                test.X = 8;
                test.Y = 1;
                cells.Add(test);

                Render();
            }
        }

        void Render()
        {
            int[,] GridArr = new int[nmrOfrows, nmrOfcols]; // Want to store cells in 2D array...
            Pen blue = new Pen(Color.Blue);

            foreach (Cell c in cells)
            {
                int coldist = ((Board.Width / 2) / nmrOfcols); //Calculate distance for cell in grid
                int rowdist = (Board.Height / nmrOfrows);

                PictureBox pc = new PictureBox();

                pc.Margin = new Padding(0);
                pc.Padding = new Padding(0); // not working??

                pc.Location = new Point (coldist*c.X, rowdist*c.Y); //Spawnpoint of cell
                pc.BackColor = Color.Blue;
                pc.Parent = Board;
                pc.Size = new Size(coldist, rowdist);
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
    }
}
