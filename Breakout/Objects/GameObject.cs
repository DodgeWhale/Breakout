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

        public bool CheckCollision(int x, int y, PictureBox target)
        {
            return this.GetPictureBox().Bounds.IntersectsWith(new Rectangle(x, y, target.Width, target.Height));
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
            PictureBox pictBox = this.GetPictureBox();
            return new Point(pictBox.Left, pictBox.Top);
        }

        public void UpdatePosition(Point point)
        {
            this.UpdatePosition(point.X, point.Y);
        }

        public void UpdatePosition(int x, int y)
        {
            PictureBox pictBox = this.GetPictureBox();

            pictBox.Left = x;
            pictBox.Top = y;
        }

        public PictureBox GetPictureBox()
        {
            return this.pictureBox;
        }

        public void SetPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
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

        public int Right()
        {
            return this.GetPanel().Width - (this.GetPictureBox().Left + this.GetPictureBox().Width);
        }

        public Rectangle ToRectangle()
        {
            PictureBox pictBox = this.GetPictureBox();
            return new Rectangle(pictBox.Left, pictBox.Top, pictBox.Width, pictBox.Height);
        }
    }
}
