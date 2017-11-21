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


        // Brick rows and columns
        // Memes
        static int rows = 3, columns = 7;

        public GameForm()
        {
            InitializeComponent();
            
            paddle = new Paddle(GamePanel, GamePanel.Width / 2, GamePanel.Height - 20);
            paddle.AddToPanel();
            paddle.Centre(GamePanel.Height - 20);

            ball = new Ball(GamePanel, 3); // TODO: Set specific x, y
            ball.AddToPanel();

            InitializeBricks();

            int current = 0;
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Console.Write("X: " + x + ", Y: " + y + " - " + this.bricks[x, y].GetColour().GetColour().ToString() + "\t");

                    if (current != x) Console.WriteLine();
                    current = x;
                }
            }
        }

        public void InstertCoin()
        {
            lives = 5; // Start
            ball.ResetPosition();
        }

        public void AddPoints(int points)
        {
            int tempPoints = this.lives + points;
            if(tempPoints >= 50)
            {
                this.lives = tempPoints - 50;
                lives++;
            }
            // Todo update label which displays points
        }

        public void InitializeBricks()
        {
            Brick[,] bricks = new Brick[columns, rows];
            int padding = 10;

            for(int x = 0; x < columns; x++)
            {
                for(int y = 0; y < rows; y++)
                {
                    Brick brick = new Brick(GamePanel, x * 35 + (padding * (x + 1)), y * 15 + (padding * (y + 1)), 35, 15);
                    brick.AddToPanel();

                    bricks[x, y] = brick;
                }
            }
            this.bricks = bricks;
        }

        private void RestartTimer()
        {
            if(this.timer != null && this.timer.Enabled)
                this.timer.Stop();

            Timer timer = new Timer
            {
                Interval = 16,
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

            if(!ball.CheckPanelBoundries())
            {
                this.ball.Move();
            } else
            {
                this.timer.Stop();
                ball.ResetPosition();
            }

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Brick target = bricks[x, y];

                    if(target.CheckCollision(this.ball.GetPictureBox())) {
                        if (!target.IsDead)
                        {
                            this.AddPoints(target.GetColour().GetPoints());
                            target.SetDead(true);
                        }
                    }
                }
            }
        }

        private void InsertCoinButton_Click(object sender, EventArgs e)
        {
            InstertCoin();
            RestartTimer();
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            this.ball.UpdatePosition(10, 10);
        }

    }
}
