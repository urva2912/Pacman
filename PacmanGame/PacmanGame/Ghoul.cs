//
// Ghoul Class
// ===========
// To manage the movement of the ghoul which represents an enemy character that is moving around the maze.
//

using System;
using System.Drawing;

namespace PacmanGame
{
    public class Ghoul : Creature
    {
        private Random random;// This is used to create a random object.

        // This is the constructor used to initialise the field.
        public Ghoul(int x, int y, Image image) : base(x, y, image)
        {
            random = new Random();  // Initialize random number generator
        }

        //
        // MoveTowardsPacman()
        // ===================
        // It will adjust the direction to move towards pacman.
        //
        public void MoveTowardsPacman(Pacman pacman)
        {
            int deltaX = pacman.X - this.X;
            int deltaY = pacman.Y - this.Y;
            int stepSize = 5; // Increase step size to 10 pixels per move

            // Adjust Ghoul's position based on direction towards Pacman
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (deltaX > 0 && X + stepSize < 800 - Image.Width) // Check right boundary
                    X += stepSize; // Move right
                else if (deltaX < 0 && X - stepSize > 0) // Check left boundary
                    X -= stepSize; // Move left
            }
            else
            {
                if (deltaY > 0 && Y + stepSize < 600 - Image.Height) // Check bottom boundary
                    Y += stepSize; // Move down
                else if (deltaY < 0 && Y - stepSize > 0) // Check top boundary
                    Y -= stepSize; // Move up
            }
        }

        //
        // MoveRandomly()
        // ==============
        // It will move the ghouls randomly in the maze.
        //
        public void MoveRandomly()
        {
            int direction = random.Next(4);  // 0: up, 1: down, 2: left, 3: right
            int stepSize = 5; // Increase step size to 5 pixels per move

            switch (direction)
            {
                case 0:  // Up
                    if (Y - stepSize > 0) // Check top boundary
                        Y -= stepSize;
                    break;
                case 1:  // Down
                    if (Y + stepSize < 600 - Image.Height) // Check bottom boundary
                        Y += stepSize;
                    break;
                case 2:  // Left
                    if (X - stepSize > 0) // Check left boundary
                        X -= stepSize;
                    break;
                case 3:  // Right
                    if (X + stepSize < 800 - Image.Width) // Check right boundary
                        X += stepSize;
                    break;
                default:
                    break;
            }
        }
    }
}
