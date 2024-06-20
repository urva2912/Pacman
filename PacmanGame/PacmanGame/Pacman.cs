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
        public int score;
        public Image pacmanImage;
        public Direction currentDirection;
        private Maze maze;
        private int moveSpeed;

        public Pacman(int x, int y, Image pacmanImage, Maze maze)
            : base(x, y, pacmanImage)
        {
            this.pacmanImage = pacmanImage;
            currentDirection = Direction.None; // Initial direction
            this.maze = maze;
            this.moveSpeed = 5; // Set the initial move speed
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
    }
}
