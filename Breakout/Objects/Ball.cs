using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Objects
{
    public class Ball : GameObject
    {
        private double speed;

        public Ball(Panel panel, double speed) : base(panel, null)
        {
            Bitmap ballImg = Properties.Resources.Ball;

            this.SetPictureBox(new PictureBox
            {
                Width = ballImg.Width,
                Height = ballImg.Height,

                BackgroundImage = ballImg,
                BackColor = Color.Transparent
            });
            
            this.speed = speed;
            this.ResetPosition();
        }

        public double GetSpeed()
        {
            return this.speed;
        }

        public void ResetPosition()
        {
            Panel panel = this.GetPanel();
            this.Centre(panel.Height - 100);
            this.RandomVelocity();
        }

        /// <summary>
        /// Checks whether the ball has exceeded the game panel boundries
        /// </summary>
        /// <returns>Whether or not the ball hit the bottom of the screen</returns>
        public bool CheckPanelBoundries()
        {
            Point velocity = this.GetVelocity(),
                position = this.GetPosition();

            // SIDES
            if(position.X <= 0)
            {
                velocity.X = 1;
            } else if(position.X + this.GetPictureBox().Width >= this.GetPanel().Width)
            {
                velocity.X = -1;
            }
            // TOP AND BOTTOM
            if (position.Y <= 0)
            {
                velocity.Y = 1;
            }
            else if (position.Y >= this.GetPanel().Height)
            {
                return true;
            }

            this.UpdateVelocity(velocity.X, velocity.Y);
            return false;
        }

        public void Move()
        {
            Point velocity = this.GetVelocity(),
                position = this.GetPosition();

            this.UpdatePosition((int) (position.X + (velocity.X * this.GetSpeed())),
                                (int) (position.Y + (velocity.Y * this.GetSpeed())));
        }

    }
}
