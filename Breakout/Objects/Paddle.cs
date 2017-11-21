using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Objects
{
    public class Paddle : GameObject
    {
        public Paddle(Panel panel, int x, int y) : base(panel, null)
        {
            Bitmap paddleImg = Properties.Resources.Paddle;

            this.SetPictureBox(new PictureBox
            {
                Width = paddleImg.Width,
                Height = paddleImg.Height,

                BackgroundImage = paddleImg
            });
        }

    }
}
