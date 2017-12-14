using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Objects
{
    public class Cherry : GameObject
    {
        public Cherry(Panel panel) : base(panel, null)
        {
            Bitmap ballImg = Properties.Resources.Cherry;

            this.SetPictureBox(new PictureBox
            {
                Width = ballImg.Width,
                Height = ballImg.Height,

                BackgroundImage = ballImg,
                BackColor = Color.Transparent
            });

            this.AddToPanel();
            this.Centre();
        }

    }
}
