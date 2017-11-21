using Breakout.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class GameForm : Form
    {

        private Timer timer;

        Paddle paddle;
        Ball ball;
        Brick[,] bricks;

        int lives = 0;
        int points = 0;

        static int rows = 3, columns = 7;

        public GameForm()
        {
            InitializeComponent();

            int paddleWidth = 50;

            paddle = new Paddle(this, (this.Width / 2) + paddleWidth / 2, this.Height - 20, paddleWidth, 20);
            ball = new Ball(this, 10, 10, 10, 10); // TODO: Set specific x, y

            InitializeBricks();
            RestartTimer();
        }

        public void InstertCoin()
        {
            lives = 5; // Start
        }

        public void AddPoints(int points)
        {
            int tempPoints = this.lives + points;
            if(tempPoints >= 50)
            {
                this.lives = tempPoints - 50;
                lives++;
            }
        }

        public void InitializeBricks()
        {
            bricks = new Brick[rows, columns];

            for(int x = 0; x < rows; x++)
            {
                for(int y = 0; y < columns; y++)
                {
                    Console.WriteLine("X: " + x + ", Y: " + y);
                    Brick brick = new Brick(this, x * 10, y * 10, 35, 15); ;
                    brick.AddToForm();

                    bricks[x, y] = brick;
                }
            }
        }

        private void RestartTimer()
        {
            if(this.timer != null && this.timer.Enabled) this.timer.Stop();

            Timer timer = new Timer
            {
                Interval = 5000,
                Enabled = true,
            };

            timer.Tick += new EventHandler(TimerTick);
            this.timer = timer;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if(ball == null || ball.IsDead)
            {
                // You lost
                Console.WriteLine("You lost.");
                this.timer.Stop();
            }

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    // Check collision
                    // bricks[x][y].Draw(e);
                }
            }
        }

        // I THINK INVALIDATE CAUSES THE FORM TO REPAINT. THATS WHEN YOU RE RENDER THE BALL AND BRICKS AND STUFF
        protected override void OnPaint(PaintEventArgs e)
        {
            /* base.OnPaint(e);
            _paddle.Draw(e);
            {
                for (int i = 0; i < _NumBalls; i++)
                {
                    _balls[i].Draw(e);
                }
                foreach (var blk in _blocks)
                {
                    blk.Draw(e);
                }
            } */
        }


    }
}
