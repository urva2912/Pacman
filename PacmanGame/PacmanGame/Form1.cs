using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class Form1 : Form
    {
        private Timer gameTimer;
        private Pacman pacman;
        private List<Ghoul> ghouls;
        private Maze maze;
        private int score;
        private int lives;
        private const int CellSize = 20; // Size of each cell in the maze
        private const int ExtraSpace = 50; // Extra space at the bottom

        public Form1()
        {
            InitializeComponent();

            this.score = 0;
            this.lives = 3;

            Image wallImage = Image.FromFile("C:\\Users\\chath\\OneDrive\\Documents\\GitHub\\Pacman\\PacmanGame\\PacmanGame\\Images\\wall.jpg");
            Image kibbleImage = Image.FromFile("C:\\Users\\chath\\OneDrive\\Documents\\GitHub\\Pacman\\PacmanGame\\PacmanGame\\Images\\kibble.jpg");
            Image pacmanImage = Image.FromFile("C:\\Users\\chath\\OneDrive\\Documents\\GitHub\\Pacman\\PacmanGame\\PacmanGame\\Images\\pacman.gif");
            Image ghoul1 = Image.FromFile("C:\\Users\\chath\\OneDrive\\Documents\\GitHub\\Pacman\\PacmanGame\\PacmanGame\\Images\\ghoul1.png");
            Image ghoul2 = Image.FromFile("C:\\Users\\chath\\OneDrive\\Documents\\GitHub\\Pacman\\PacmanGame\\PacmanGame\\Images\\ghoul2.png");
            Image ghoul3 = Image.FromFile("C:\\Users\\chath\\OneDrive\\Documents\\GitHub\\Pacman\\PacmanGame\\PacmanGame\\Images\\ghoul3.jpg");

            pacman = new Pacman(1, 1, pacmanImage);
            ghouls = new List<Ghoul>
            {
            new Ghoul(18, 18, ghoul1),
            new Ghoul(1, 18, ghoul2),
            new Ghoul(18, 1, ghoul3)
            };

            // Initialize the maze with 15 rows and 20 columns
            this.maze = new Maze(20, 20, wallImage, kibbleImage, CellSize);

            // Set the form's size based on the maze dimensions
            this.ClientSize = new Size(maze.Cols * CellSize, maze.Rows * CellSize + ExtraSpace);
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

        private void DisplayScore(Graphics g)
        {
            g.DrawString($"Score: {pacman.Score}", new Font("Arial", 16), Brushes.White, new PointF(20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
