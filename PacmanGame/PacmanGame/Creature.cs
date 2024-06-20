using System.Drawing;

namespace PacmanGame
{
    public class Creature
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

        public virtual void Move()
        {
            // Default move behavior (can be overridden by subclasses)
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Image, X, Y);
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
