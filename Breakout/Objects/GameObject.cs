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
        public GameForm form;
        private Rectangle rect;
        private Point velocity;
        public bool IsDead;
        public PictureBox pictureBox;

        public GameObject(GameForm form, int x, int y, int width, int height, PictureBox pictureBox)
        {
            this.form = form;
            this.rect = new Rectangle(x, y, width, height);
            this.pictureBox = pictureBox;
        }

        public void AddToForm()
        {
            if(!this.IsDead)
                this.form.Controls.Add(this.GetPictureBox());
        }

        public bool CheckCollision(PictureBox target)
        {
            return this.GetPictureBox().Bounds.IntersectsWith(target.Bounds);
        }

        public Point GetPosition()
        {
            return new Point(this.rect.X, this.rect.Y);
        }
        public void UpdatePosition(int x, int y)
        {
            this.GetPictureBox().Left = x;
            this.GetPictureBox().Top = y;
        }

        public Rectangle GetRect()
        {
            return this.rect;
        }

        public PictureBox GetPictureBox()
        {
            return this.pictureBox;
        }

        public Size GetDimentions()
        {
            return new Size(this.GetPictureBox().Width, this.GetPictureBox().Height);
        }

        public void UpdateDimentions(int width, int height, PaintEventArgs e)
        {
            this.GetPictureBox().Width = width;
            this.GetPictureBox().Height = height;
        }

    }
}
