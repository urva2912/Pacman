using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Ghoul : Creature
    {
        private Random random = new Random();
        public Image ghoulImage;

        public Ghoul(int x, int y, Image ghoulImage)
            : base(x, y, ghoulImage)
        {
            this.ghoulImage = ghoulImage;
        }

        public override void Move()
        {
            // Simple random movement for ghouls
            int direction = random.Next(4);
            switch (direction)
            {
                case 0: X--; break; // Left
                case 1: X++; break; // Right
                case 2: Y--; break; // Up
                case 3: Y++; break; // Down
            }
        }
    }
}
