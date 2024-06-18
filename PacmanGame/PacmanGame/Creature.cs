using System.Drawing;

namespace PacmanGame
{
    public class Creature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Image Image { get; set; }

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
    }
}
