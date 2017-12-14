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

        public async void SpeedBoost(double newSpeed)
        {
            this.speed = newSpeed;
            this.GetPictureBox().BackgroundImage = Properties.Resources.RedBall;

            await Task.Delay(6500);
            this.speed = 3;
            this.GetPictureBox().BackgroundImage = Properties.Resources.Ball;
        }

        public void ResetPosition()
        {
            this.Centre(this.GetPanel().Height / 2);
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

        public void SetNewVelocity(GameObject collided)
        {
            PictureBox pictureBox = collided.GetPictureBox();
            Point velocity = this.GetVelocity();

            int x = this.GetPosition().X;

            if (pictureBox.Left > (x + this.GetPictureBox().Width - this.speed) || (pictureBox.Left + pictureBox.Width - this.speed) < x)
            {
                this.UpdateVelocity(-velocity.X, velocity.Y);
            }
            else
            {
                this.UpdateVelocity(velocity.X, -velocity.Y);
            }
        }

        public int GetRadius()
        {
            return this.GetPictureBox().Width / 2;
        }

        public Point GetCenterPosition()
        {
            Point point = this.GetPosition();
            int radius = this.GetRadius();

            return new Point(point.X - radius, point.Y - radius);
        }

        public Point GetNewPosition()
        {
            Point velocity = this.GetVelocity(),
                position = this.GetPosition();

            return new Point((int)(position.X + (velocity.X * this.GetSpeed())),
                                (int)(position.Y + (velocity.Y * this.GetSpeed())));
        }

        public bool Intersects(Rectangle rect)
        {
            Rectangle ballRect = this.ToRectangle();
            int ballRadius = 8;

            double rectX = rect.X + rect.Width / 2,
                   rectY = rect.Y + rect.Height / 2,
                   circX = ballRect.X + ballRadius,
                   circY = ballRect.Y + ballRadius,
                   circDistanceX = Math.Abs(circX - rectX),
                   circDistanceY = Math.Abs(circY - rectY);

            if (circDistanceX > (rect.Width / 2 + ballRadius) || circDistanceY > (rect.Height / 2 + ballRadius))
                return false;

            if (circDistanceX <= (rect.Width / 2) || circDistanceY <= (rect.Height / 2))
                return true;

            double cornerDistance_sq = Math.Pow(circDistanceX - rect.Width / 2, 2) +
                                 Math.Pow(circDistanceY - rect.Height / 2, 2);

            if (cornerDistance_sq <= Math.Pow(ballRadius, 2))
                return true;
            return false;
        }

    }
}
