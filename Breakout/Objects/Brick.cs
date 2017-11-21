using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Objects
{
    public class Brick : GameObject
    {
        public BrickColour colour;

        private static Random random = new Random();
        private static BrickColour[] colours = { BrickColour.BLACK, BrickColour.BLUE, BrickColour.GREEN, BrickColour.RED, BrickColour.YELLOW };

        public Brick(Panel panel, int x, int y, int width, int height) : base(panel, null)
        {
            // Sets random colour
            this.colour = colours[random.Next(colours.Length)];

            PictureBox brick = new PictureBox
            {
                BackColor = this.colour.GetColour(),

                Width = width,
                Height = height,
                Left = x,
                Top = y,

                Tag = "BRICK"
            };
            this.SetPictureBox(brick);
        }

        public BrickColour GetColour()
        {
            return this.colour;
        }
    }
}
