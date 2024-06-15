using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public abstract class Creature
    {
        public int x;
        public int y; 
        public Image image;

        public Creature(int x, int y, Image image)
        {
            X = x;
            Y = y;
            Image = image;
        }

        public abstract void Move();

        public void Draw(Graphics g)
        {
            g.DrawImage(Image, X * 20, Y * 20, 20, 20);
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Image Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }
    }
}
