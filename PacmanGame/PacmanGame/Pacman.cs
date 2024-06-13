using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Pacman : Creature
    {
        public int Score { get; private set; }
        public Image pacmanImage;

        public Pacman(int x, int y, Image pacmanImage)
            : base(x, y, pacmanImage)
        {
            this.pacmanImage = pacmanImage;
        }

        public void EatKibble()
        {
            Score++;
        }

        public override void Move()
        {
            // Pacman movement logic
        }

        
    }
}
