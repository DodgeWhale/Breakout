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

        private Random random = new Random();
        private BrickColour[] colours = { BrickColour.BLACK, BrickColour.BLUE, BrickColour.GREEN, BrickColour.RED, BrickColour.YELLOW };

        public Brick(GameForm form, int x, int y, int width, int height) : base(form, x, y, width, height, null)
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
            this.pictureBox = brick;
        }

        public BrickColour GetColour()
        {
            return this.colour;
        }
    }
}
