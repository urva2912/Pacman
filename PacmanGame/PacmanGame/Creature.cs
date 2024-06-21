//
// Creature Class
// ==============
// This is a base class for ghouls and Pacman.
//

using System.Drawing;

namespace PacmanGame
{
    public class Creature
    {
        // Fields used to define the creature
        public int x;
        public int y;
        public Image image;

        // This is the constructor used to initialise the fields.
        public Creature(int x, int y, Image image)
        {
            X = x;
            Y = y;
            Image = image;
        }

        //
        // Move()
        // ======
        // It will be used to move both Pacman and Ghoul with it’s specific movement for each creature.
        //
        public virtual void Move()
        {
            // Default move behavior (can be overridden by subclasses)
        }

        //
        // Draw()
        // ======
        // It will draw the creature at it’s relevant position.
        //
        public void Draw(Graphics g)
        {
            g.DrawImage(Image, X, Y);
        }

        //
        // Get and Set the x co-ordinate of the creature
        // =============================================
        // This will allow the form to get and set the x co-ordinate of the creature.
        //
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

        //
        // Get and Set the y co-ordinate of the creature
        // =============================================
        // This will allow the form to get and set the y co-ordinate of the creature.
        //
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

        //
        // Get and Set the image of the creature
        // =====================================
        // This will allow the form to get and set the image of the creature.
        //
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
