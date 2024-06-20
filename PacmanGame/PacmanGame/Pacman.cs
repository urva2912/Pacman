//pacman class
using System.Drawing;
using System.Windows.Forms;

namespace PacmanGame
{
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public class Pacman : Creature
    {
        private int score;
        private Image mouthOpen;
        private Image mouthClose;
        private bool isMouthOpen;
        private Image pacmanUp;
        private Image pacmanRight;
        private Image pacmanLeft;
        private Image pacmanDown;
        public Direction currentDirection;
        private Maze maze;
        private int moveSpeed;

        public Pacman(int x, int y, Image mouthOpen, Image mouthClose, Image pacmanUp, Image pacmanRight, Image pacmanLeft, Image pacmanDown, Maze maze)
            : base(x, y, mouthOpen)
        {
            this.mouthOpen = mouthOpen;
            this.mouthClose = mouthClose;
            this.isMouthOpen = true;
            currentDirection = Direction.None; // Initial direction
            this.maze = maze;
            this.moveSpeed = 5; // Set the initial move speed

            // Assign Pacman images for different directions
            PacmanUp = pacmanUp;
            PacmanDown = pacmanDown;
            PacmanLeft = pacmanLeft;
            PacmanRight = pacmanRight;
        }

        public void EatKibble()
        {
            score++;
        }

        public override void Move()
        {
            int newX = X;
            int newY = Y;

            // Update Pacman's position based on the current direction
            switch (currentDirection)
            {
                case Direction.Up:
                    newY -= moveSpeed;
                    break;
                case Direction.Down:
                    newY += moveSpeed;
                    break;
                case Direction.Left:
                    newX -= moveSpeed;
                    break;
                case Direction.Right:
                    newX += moveSpeed;
                    break;
            }

            // Check if the new position collides with a wall
            if (!maze.CheckWall(newX / maze.CellSize, newY / maze.CellSize))
            {
                X = newX;
                Y = newY;

                // Check for kibble at the new position and consume it
                if (maze.CheckKibble(newX / maze.CellSize, newY / maze.CellSize))
                {
                    maze.ConsumeKibble(newX / maze.CellSize, newY / maze.CellSize);
                    EatKibble();
                }
            }

        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public Direction CurrentDirection
        {
            get
            {
                return currentDirection;
            }

            set
            {
                currentDirection = value;
            }
        }

        public void HandleInput(Keys key)
        {
            int newX = X;
            int newY = Y;

            // Update the direction based on user input
            switch (key)
            {
                case Keys.Up:
                    currentDirection = Direction.Up;
                    break;
                case Keys.Down:
                    currentDirection = Direction.Down;
                    break;
                case Keys.Left:
                    currentDirection = Direction.Left;
                    break;
                case Keys.Right:
                    currentDirection = Direction.Right;
                    break;
            }

            if (!maze.CheckWall(newX / maze.CellSize, newY / maze.CellSize))
            {
                // Update the direction based on user input
                switch (key)
                {
                    case Keys.Up:
                        currentDirection = Direction.Up;
                        break;
                    case Keys.Down:
                        currentDirection = Direction.Down;
                        break;
                    case Keys.Left:
                        currentDirection = Direction.Left;
                        break;
                    case Keys.Right:
                        currentDirection = Direction.Right;
                        break;
                }
            }
        }

        public int MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
            set
            {
                moveSpeed = value;
            }
        }

        public void Animate()
        {
            isMouthOpen = !isMouthOpen;

            switch (currentDirection)
            {
                case Direction.Up:
                    Image = isMouthOpen ? PacmanUp : mouthClose;
                    break;
                case Direction.Down:
                    Image = isMouthOpen ? PacmanDown : mouthClose;
                    break;
                case Direction.Left:
                    Image = isMouthOpen ? PacmanLeft : mouthClose;
                    break;
                case Direction.Right:
                    Image = isMouthOpen ? PacmanRight : mouthClose;
                    break;
            }
        }

        public Image PacmanUp
        {
            get
            {
                return pacmanUp;
            }
            set
            {
                pacmanUp = value;
            }
        }

        public Image PacmanRight
        {
            get
            {
                return pacmanRight;
            }
            set
            {
                pacmanRight = value;
            }
        }

        public Image PacmanLeft
        {
            get
            {
                return pacmanLeft;
            }
            set
            {
                pacmanLeft = value;
            }
        }

        public Image PacmanDown
        {
            get
            {
                return pacmanDown;
            }
            set
            {
                pacmanDown = value;
            }
        }
    }
}
