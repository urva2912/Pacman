using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Maze
    {
        private int[,] grid;
        private int rows;
        private int columns;
        private Image wallImage;
        private Image kibbleImage;
        private int cellSize;

        public Maze(int rows, int columns, Image wallImage, Image kibbleImage, int cellSize)
        {
            this.rows = rows;
            this.columns = columns;
            this.wallImage = wallImage;
            this.kibbleImage = kibbleImage;
            this.cellSize = cellSize;
            grid = new int[rows, columns];
            InitializeMaze();
        }

        private void InitializeMaze()
        {
             // Initialize maze with walls and kibbles
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 || i == rows - 1 || j == 0 || j == columns - 1)
                    {
                        grid[i, j] = 1; // Wall
                    }
                    else
                    {
                        grid[i, j] = 0; // Kibble
                    }
                }
            }

            //This creates a column of walls at the right side bottom
            grid[16, 16] = 1; 
            grid[15, 16] = 1;
            grid[14, 16] = 1;
            grid[13, 16] = 1;

            //This creates a row of walls at the right side bottom
            grid[16, 15] = 1;
            grid[16, 14] = 1;
            grid[16, 13] = 1;

            //This creates a row of walls at the left side bottom
            grid[16, 3] = 1;
            grid[16, 4] = 1;
            grid[16, 5] = 1;
            grid[16, 6] = 1;

            //This creates a column of walls at the left side bottom
            grid[15, 3] = 1;
            grid[14, 3] = 1;
            grid[13, 3] = 1;

            //This creates a column of walls at the left side top
            grid[3, 3] = 1;
            grid[4, 3] = 1;
            grid[5, 3] = 1;
            grid[6, 3] = 1;

            //This creates a row of walls at the left side top
            grid[3, 4] = 1;
            grid[3, 5] = 1;
            grid[3, 6] = 1;

            //This creates a row of walls at the right side top
            grid[3, 13] = 1;
            grid[3, 14] = 1;
            grid[3, 15] = 1;
            grid[3, 16] = 1;

            //This creates a column of walls at the left side top
            grid[4, 16] = 1;
            grid[5, 16] = 1;
            grid[6, 16] = 1;
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        g.DrawImage(wallImage, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                    else if (grid[i, j] == 0)
                    {
                        g.DrawImage(kibbleImage, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                }
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return columns;
            }

            set
            {
                columns = value;
            }
        }
    }


}
