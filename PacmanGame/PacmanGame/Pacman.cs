//
// Pacman Class
// ============
// To manage the Pacman movement, animation and scoring
//

using System.Drawing;
using System.Windows.Forms;

namespace PacmanGame
{
    // This is an enumeration which consists a set of possible directions for the pacman.
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
        //Fields used to define pacman.
        private int score;// This will be used to increase the score when the pacman eats a kibble.
        private Image mouthOpen;// This is used to represent the image for mouth open.
        private Image mouthClose;// This is used to represent the image for mouth close.
        private bool isMouthOpen;// This is to check whether the mouth of pacman is open.
        private Image pacmanUp;// This is used to represent the image for pacman towards up.
        private Image pacmanRight;// This is used to represent the image for pacman towards right.
        private Image pacmanLeft;// This is used to represent the image for pacman towards left.
        private Image pacmanDown;// This is used to represent the image for pacman towards down.
        public Direction currentDirection;// This is used to define the direction of movement of pacman.
        private Maze maze;// Creating an instance for Maze class.
        private int moveSpeed;// This is the speed which pacman will move.
        private int width;// This will set the width of the mouthOpen image.
        private int height;// This will set the height of the mouthOpen image.

        //This is the constructor used to initialise all the fields.
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

            // Set the width and height based on the size of the images
            this.width = mouthOpen.Width;
            this.height = mouthOpen.Height;
        }

        //
        // EatKibble()
        // ===========
        // It will increase the Pacman’s score by 1 when it eats each kibble.
        //
        public void EatKibble()
        {
            score++;
        }

        //
        // Move()
        // ======
        // It will override the move method for the Pacman.
        //
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
            if (!maze.CheckWall(newX / maze.CellSize, newY / maze.CellSize) &&
                !maze.CheckWall((newX + width - 1) / maze.CellSize, newY / maze.CellSize) &&
                !maze.CheckWall(newX / maze.CellSize, (newY + height - 1) / maze.CellSize) &&
                !maze.CheckWall((newX + width - 1) / maze.CellSize, (newY + height - 1) / maze.CellSize))
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

        //
        // Get and Set the score for each kibble
        // =====================================
        // This will allow the form to get and set the score for each kibble.
        //
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

        //
        // Get and Set the current direction of pacman
        // ===========================================
        // This will allow the form to get and set the current direction of pacman.
        //
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

        //
        // HandleInput()
        // =============
        // It will update the movement based on the user input.
        //
        public void HandleInput(Keys key)
        {
            // Update the direction based on user input
            switch (key)
            {
                case Keys.Up:
                    if (!maze.CheckWall(X / maze.CellSize, (Y - moveSpeed) / maze.CellSize) &&
                        !maze.CheckWall((X + width - 1) / maze.CellSize, (Y - moveSpeed) / maze.CellSize))
                    {
                        currentDirection = Direction.Up;
                    }
                    break;
                case Keys.Down:
                    if (!maze.CheckWall(X / maze.CellSize, (Y + height + moveSpeed - 1) / maze.CellSize) &&
                        !maze.CheckWall((X + width - 1) / maze.CellSize, (Y + height + moveSpeed - 1) / maze.CellSize))
                    {
                        currentDirection = Direction.Down;
                    }
                    break;
                case Keys.Left:
                    if (!maze.CheckWall((X - moveSpeed) / maze.CellSize, Y / maze.CellSize) &&
                        !maze.CheckWall((X - moveSpeed) / maze.CellSize, (Y + height - 1) / maze.CellSize))
                    {
                        currentDirection = Direction.Left;
                    }
                    break;
                case Keys.Right:
                    if (!maze.CheckWall((X + width + moveSpeed - 1) / maze.CellSize, Y / maze.CellSize) &&
                        !maze.CheckWall((X + width + moveSpeed - 1) / maze.CellSize, (Y + height - 1) / maze.CellSize))
                    {
                        currentDirection = Direction.Right;
                    }
                    break;
            }
        }

        //
        // Get and Set the speed of pacman
        // ===============================
        // This will allow the form to get and set the speed of pacman.
        //
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

        //
        // MouthAnimate()
        // ==============
        // It will set the Pacman’s mouth for animation.
        //
        public void MouthAnimate()
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

        //
        // Get and Set the image for pacman towards up
        // ===========================================
        // This will allow the form to get and set the image of pacman towards up.
        //
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

        //
        // Get and Set the image for pacman towards right
        // ==============================================
        // This will allow the form to get and set the image of pacman towards right.
        //
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

        //
        // Get and Set the image for pacman towards left
        // =============================================
        // This will allow the form to get and set the image of pacman towards left.
        //
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

        //
        // Get and Set the image for pacman towards down
        // =============================================
        // This will allow the form to get and set the image of pacman towards down.
        //
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
