using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    public class BrickColour {

        public static readonly BrickColour BLUE = new BrickColour(10, Color.Blue);
        public static readonly BrickColour GREEN = new BrickColour(10, Color.Green);
        public static readonly BrickColour RED = new BrickColour(20, Color.Red);
        public static readonly BrickColour ORANGE = new BrickColour(10, Color.Orange);
        public static readonly BrickColour YELLOW = new BrickColour(10, Color.Yellow);

        private int points;
        private Color colour;

        BrickColour(int points, Color colour)
        {
            this.points = points;
            this.colour = colour;
        }

        public int GetPoints()
        {
            return this.points;
        }

        public Color GetColour()
        {
            return this.colour;
        }

    }
}
