using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Objects
{
    public abstract class GameObject
    {
        private Panel panel;
        private Point velocity;
        public bool IsDead;
        private PictureBox pictureBox;

        public GameObject(Panel panel, PictureBox pictureBox)
        {
            this.panel = panel;
            this.pictureBox = pictureBox;
        }

        public void AddToPanel()
        {
            if(!this.IsDead)
                this.GetPanel().Controls.Add(this.GetPictureBox());
        }

        public bool CheckCollision(PictureBox target)
        {
            return this.GetPictureBox().Bounds.IntersectsWith(target.Bounds);
        }

        public Panel GetPanel()
        {
            return this.panel;
        }

        public Point GetPosition()
        {
            return new Point(this.GetPictureBox().Left, this.GetPictureBox().Top);
        }
        public void UpdatePosition(int x, int y)
        {
            this.GetPictureBox().Left = x;
            this.GetPictureBox().Top = y;
        }

        public PictureBox GetPictureBox()
        {
            return this.pictureBox;
        }

        public void SetPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public Size GetDimentions()
        {
            return new Size(this.GetPictureBox().Width, this.GetPictureBox().Height);
        }

        public void UpdateDimentions(int width, int height)
        {
            this.GetPictureBox().Width = width;
            this.GetPictureBox().Height = height;
        }
        public void SetDead(bool isDead)
        {
            this.IsDead = isDead;
            this.GetPictureBox().Visible = !isDead;
        }

        public void Centre(int y)
        {
            this.UpdatePosition((panel.Width - this.GetPictureBox().Width / 2) / 2, y);
        }

        public Point GetVelocity()
        {
            return this.velocity;
        }

        public void RandomVelocity()
        {
            Random random = new Random();
            this.UpdateVelocity(random.Next(0, 2) * 2 - 1, random.Next(0, 2) * 2 - 1);
        }

        public void UpdateVelocity(int x, int y)
        {
            if (this.velocity == null)
            {
                this.velocity = new Point(x, y);
                return;
            }

            this.velocity.X = x;
            this.velocity.Y = y;
        }

    }
}
