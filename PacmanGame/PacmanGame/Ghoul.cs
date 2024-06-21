using System;
using System.Drawing;

namespace PacmanGame
{
    public class Ghoul : Creature
    {
        private Random random;  // Random object for random movement
        private float floatX;   // Floating point X coordinate
        private float floatY;   // Floating point Y coordinate

        // Constructor to initialize the ghoul's position and image
        public Ghoul(int x, int y, Image image) : base(x, y, image)
        {
            random = new Random();  // Initialize random number generator
            floatX = x;
            floatY = y;
        }

        // Method to move towards Pacman
        public void MoveTowardsPacman(Pacman pacman)
        {
            float deltaX = pacman.X - floatX;
            float deltaY = pacman.Y - floatY;
            float stepSize = 2.5f; // Smaller step size for smoother movement

            // Adjust Ghoul's position based on direction towards Pacman
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (deltaX > 0 && floatX + stepSize < 800 - Image.Width) // Check right boundary
                    floatX += stepSize; // Move right
                else if (deltaX < 0 && floatX - stepSize > 0) // Check left boundary
                    floatX -= stepSize; // Move left
            }
            else
            {
                if (deltaY > 0 && floatY + stepSize < 600 - Image.Height) // Check bottom boundary
                    floatY += stepSize; // Move down
                else if (deltaY < 0 && floatY - stepSize > 0) // Check top boundary
                    floatY -= stepSize; // Move up
            }

            // Update the integer positions for rendering and collision detection
            int newX = (int)Math.Round(floatX);
            int newY = (int)Math.Round(floatY);

            // Ensure Ghoul stays within the maze boundaries
            if (newX >= 0 && newX + Image.Width <= 800 && newY >= 0 && newY + Image.Height <= 600)
            {
                X = newX;
                Y = newY;
            }
        }

        // Method to move Ghoul randomly in the maze
        public void MoveRandomly()
        {
            int direction = random.Next(4);  // 0: up, 1: down, 2: left, 3: right
            float stepSize = 2.5f; // Smaller step size for smoother movement

            switch (direction)
            {
                case 0:  // Up
                    if (floatY - stepSize > 0) // Check top boundary
                        floatY -= stepSize;
                    break;
                case 1:  // Down
                    if (floatY + stepSize < 600 - Image.Height) // Check bottom boundary
                        floatY += stepSize;
                    break;
                case 2:  // Left
                    if (floatX - stepSize > 0) // Check left boundary
                        floatX -= stepSize;
                    break;
                case 3:  // Right
                    if (floatX + stepSize < 800 - Image.Width) // Check right boundary
                        floatX += stepSize;
                    break;
                default:
                    break;
            }

            // Update the integer positions for rendering and collision detection
            int newX = (int)Math.Round(floatX);
            int newY = (int)Math.Round(floatY);

            // Ensure Ghoul stays within the maze boundaries
            if (newX >= 0 && newX + Image.Width <= 800 && newY >= 0 && newY + Image.Height <= 600)
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
