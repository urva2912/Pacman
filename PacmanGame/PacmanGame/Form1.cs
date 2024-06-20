using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class Form1 : Form
    {
        private Pacman pacman;
        private List<Ghoul> ghouls;
        private Maze maze;

        public static int CellSize { get; } = 20; // Size of each cell in the maze
        private const int ExtraSpace = 50; // Extra space at the bottom

       public Form1()
       {
            InitializeComponent();

            // Load and resize images
            Image wallImage = ResizeImage(Properties.Resources.wall, CellSize, CellSize);
            Image kibbleImage = ResizeImage(Properties.Resources.kibble, CellSize, CellSize);
            Image pacmanOpen = ResizeImage(Properties.Resources.mouthOpen, CellSize, CellSize);
            Image pacmanClose = ResizeImage(Properties.Resources.mouthClose, CellSize, CellSize);
            Image pacmanUp = ResizeImage(Properties.Resources.pacmanUp, CellSize, CellSize);
            Image pacmanRight = ResizeImage(Properties.Resources.pacmanRight, CellSize, CellSize);
            Image pacmanLeft = ResizeImage(Properties.Resources.pacmanLeft, CellSize, CellSize);
            Image pacmanDown = ResizeImage(Properties.Resources.pacmanDown, CellSize, CellSize);
            Image ghoul1 = ResizeImage(Properties.Resources.ghoul1, CellSize, CellSize);
            Image ghoul2 = ResizeImage(Properties.Resources.ghoul2, CellSize, CellSize);
            Image ghoul3 = ResizeImage(Properties.Resources.ghoul3, CellSize, CellSize);

            // Initialize the maze with 20 rows and 20 columns.
            maze = new Maze(20, 20, wallImage, kibbleImage, CellSize);

            pacman = new Pacman(10 * CellSize, 9 * CellSize, pacmanOpen, pacmanClose, pacmanUp, pacmanRight, pacmanLeft, pacmanDown, maze);

            ghouls = new List<Ghoul>
            {
                new Ghoul(18 * CellSize, 18 * CellSize, ghoul1),
                new Ghoul(1 * CellSize, 18 * CellSize, ghoul2),
                new Ghoul(18 * CellSize, 1 * CellSize, ghoul3)
            };

            // Set the form's size based on the maze dimensions
            this.ClientSize = new Size(maze.Cols * CellSize, maze.Rows * CellSize + ExtraSpace);

            // Remove kibbles from specific positions
            maze.RemoveKibble(10, 9);
            maze.RemoveKibble(18, 18);
            maze.RemoveKibble(1, 18);
            maze.RemoveKibble(18, 1);
            maze.RemoveKibble(1, 1);

            gameTimer = new Timer(); // Initialize the timer
            gameTimer.Interval = 100; // Timer interval
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();

            // Set up key event handlers
            this.KeyDown += Form1_KeyDown;

            this.DoubleBuffered = true;
       }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle input to change Pacman's direction
            pacman.HandleInput(e.KeyCode);
        }


        private void CollisionWithGhoul()
        {
            Rectangle pacmanBounds = new Rectangle(pacman.X, pacman.Y, pacman.Image.Width, pacman.Image.Height);

            foreach (var ghoul in ghouls)
            {
                Rectangle ghoulBounds = new Rectangle(ghoul.X, ghoul.Y, ghoul.Image.Width, ghoul.Image.Height);

                if (pacmanBounds.IntersectsWith(ghoulBounds))
                {
                    GameOver();
                    return; // Exit early since game over
                }
            }
        }


        private void CollisionWithKibble()
        {
            if (maze.CheckKibble(pacman.X / CellSize, pacman.Y / CellSize))
            {
                pacman.EatKibble();
                maze.ConsumeKibble(pacman.X / CellSize, pacman.Y / CellSize);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Check collisions
            CollisionWithGhoul();
            CollisionWithKibble();

            pacman.Animate();
            
            // Check win condition
            if (AllKibblesConsumed())
            {
                GameWon();
            }

            Invalidate(); // Redraw the form
                          // Update game logic here

            // Move Pacman
            pacman.Move();

            // Move each Ghoul
            foreach (var ghoul in ghouls)
            {
                ghoul.MoveTowardsPacman(pacman);
                ghoul.MoveRandomly();  // Or ghoul.MoveTowardsPacman(pacman);
            }

            // Check collisions, win conditions, etc.

            Invalidate(); // Redraw the form
        }


        private bool AllKibblesConsumed()
        {
            for (int i = 0; i < maze.Rows; i++)
            {
                for (int j = 0; j < maze.Cols; j++)
                {
                    if (maze.CheckKibble(j, i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            maze.Draw(g);
            pacman.Draw(g);
            foreach (var ghoul in ghouls)
            {
                ghoul.Draw(g);
            }
            DisplayScore(g);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Your code to handle the form load event
        }

        private void DisplayScore(Graphics g)
        {
            g.DrawString($"Score: {pacman.Score}", new Font("Arial", 16), Brushes.Black, new PointF(20, maze.Rows * CellSize + 10));
        }
        
        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Game Over!");
        }

        private void GameWon()
        {
            gameTimer.Stop();
            MessageBox.Show("Congratulations, You Won!");
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
