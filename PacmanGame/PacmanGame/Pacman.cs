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
            // Update Pacman's position based on the current direction
            switch (currentDirection)
            {
                case Direction.Up:
                    Y -= moveSpeed;
                    break;
                case Direction.Down:
                    Y += moveSpeed;
                    break;
                case Direction.Left:
                    X -= moveSpeed;
                    break;
                case Direction.Right:
                    X += moveSpeed;
                    break;
            }

            // Ensure Pacman stays within game boundaries
            StayWithinBoundaries();
        }

        private void StayWithinBoundaries()
        {
            // Assuming game boundary variables: gameWidth and gameHeight
            int gameWidth = 400; // Example width
            int gameHeight = 400; // Example height

            if (X < 0) X = 0;
            if (Y < 0) Y = 0;
            if (X > gameWidth) X = gameWidth;
            if (Y > gameHeight) Y = gameHeight;
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
