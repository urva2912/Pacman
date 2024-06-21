using System;
using System.Drawing;

namespace PacmanGame
{
    public class Ghoul : Creature
    {
        private Random random;  // Random object for random movement
        private float floatX;   // Floating point X coordinate
        private float floatY;   // Floating point Y coordinate
        private Maze maze;      // Reference to the maze for collision detection
        private int cellSize;   // Size of a cell in the maze

        // Constructor to initialize the ghoul's position and image
        public Ghoul(int x, int y, Image image, Maze maze) : base(x, y, image)
        {
            random = new Random();  // Initialize random number generator
            floatX = x;
            floatY = y;
            this.maze = maze;       // Assign the maze reference
            this.cellSize = maze.CellSize;
        }

        // Method to move towards Pacman
        public void MoveTowardsPacman(Pacman pacman)
        {
            float deltaX = pacman.X - floatX;
            float deltaY = pacman.Y - floatY;
            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            float stepSize = 2.5f; // Smaller step size for smoother movement

            if (distance > 0)
            {
                // Normalize the direction vector
                float normalizedDeltaX = (deltaX / distance) * stepSize;
                float normalizedDeltaY = (deltaY / distance) * stepSize;

                // Calculate potential new positions
                float newFloatX = floatX + normalizedDeltaX;
                float newFloatY = floatY + normalizedDeltaY;

                // Check collision with walls before updating position
                if (!IsWall(newFloatX, newFloatY))
                {
                    floatX = newFloatX;
                    floatY = newFloatY;
                    X = (int)Math.Round(floatX);
                    Y = (int)Math.Round(floatY);
                }
            }
        }

        // Method to move Ghoul randomly in the maze
        public void MoveRandomly()
        {
            int direction = random.Next(4);  // 0: up, 1: down, 2: left, 3: right
            float stepSize = 2.5f; // Smaller step size for smoother movement

            // Calculate potential new positions
            float newFloatX = floatX;
            float newFloatY = floatY;

            switch (direction)
            {
                case 0:  // Up
                    newFloatY -= stepSize;
                    break;
                case 1:  // Down
                    newFloatY += stepSize;
                    break;
                case 2:  // Left
                    newFloatX -= stepSize;
                    break;
                case 3:  // Right
                    newFloatX += stepSize;
                    break;
                default:
                    break;
            }

            // Check collision with walls before updating position
            if (!IsWall(newFloatX, newFloatY))
            {
                floatX = newFloatX;
                floatY = newFloatY;
                X = (int)Math.Round(floatX);
                Y = (int)Math.Round(floatY);
            }
        }

        // Method to check if the new position collides with a wall
        private bool IsWall(float x, float y)
        {
            int cellX = (int)Math.Floor(x / cellSize);
            int cellY = (int)Math.Floor(y / cellSize);

            return maze.CheckWall(cellX, cellY);
        }
    }
}
