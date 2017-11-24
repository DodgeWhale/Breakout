using Breakout.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout
{
    public partial class GameForm : Form
    {
        private Timer timer;

        Paddle paddle;
        Ball ball;
        Brick[,] bricks;

        int lives = 0,
            points = 0,
            totalPoints = 0;

        int rows = 3, columns = 7;

        public GameForm()
        {
            // Fixes laggy ball rendering
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            paddle = new Paddle(GamePanel, GamePanel.Width / 2, GamePanel.Height - 20);
            paddle.AddToPanel();
            paddle.Centre(GamePanel.Height - 20);

            ball = new Ball(GamePanel, 3); // TODO: Set specific x, y
            ball.AddToPanel();

            Console.WriteLine(TESTMEMES.Left + ", " + TESTMEMES.Right + ", " + TESTMEMES.Top + ", " + TESTMEMES.Bottom);
        }

        public void InstertCoin()
        {
            SetLives(1); // Start
            SetPoints(0);
            ResetGame();
            InitializeBricks();
            RestartTimer();
        }

        public void ResetGame()
        {
            ball.ResetPosition();
        }

        public void AddPoints(int points)
        {
            this.totalPoints += points;
            this.SetPoints(this.points + points);
        } 

        public void SetPoints(int points)
        {
            int lifeRate = 100;
            this.points = points;

            if (this.points >= lifeRate)
            {
                this.points -= lifeRate;
                SetLives(this.lives + 1);
            }

            lbl_Points.Text = "Points: " + this.points;
        }

        public void SetLives(int lives)
        {
            this.lives = lives;
            lbl_Lives.Text = "Lives: " + lives;

            if(lives <= 0)
            {
                ResetGame();
            }
        }

        public void InitializeBricks()
        {
            // Clears the old bricks from the GamePanel for when the level is reset
            if (this.bricks != null)
            {
                foreach (Brick brick in this.bricks)
                {
                    this.GamePanel.Controls.Remove(brick.GetPictureBox());
                }
            }

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
            // TODO && lives == 0
            // Show insert coin button
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
                this.SetLives(this.lives - 1);
            }

            if(ball.CheckCollision(paddle.GetPictureBox()))
            {
                Point velocity = ball.GetVelocity();
                ball.UpdateVelocity(velocity.X, -velocity.Y);
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

                            PictureBox brickPicture = target.GetPictureBox();
                            PictureBox ballPicture = this.ball.GetPictureBox();

                            Point velocity = ball.GetVelocity();

                            Console.WriteLine(ballPicture.Right + ", " + brickPicture.Left);
                            Console.WriteLine(ballPicture.Left + ", " + brickPicture.Right);
                            Console.WriteLine("-----");

                            int panelWidth = this.GamePanel.Width,
                                ballRight = panelWidth - (ballPicture.Left + ballPicture.Width),
                                brickRight = panelWidth - (brickPicture.Left + brickPicture.Width);

                            // this.timer.Stop();

                            if (ballRight < brickPicture.Left || ballPicture.Left > brickRight)
                            {
                                ball.UpdateVelocity(-velocity.X, velocity.Y);
                            } else
                            {
                                ball.UpdateVelocity(velocity.X, -velocity.Y);
                            }

                            /* if (ballPicture.Left + (ballPicture.Width / 2) < brickPicture.Left
                                || ballPicture.Right - (ballPicture.Width / 2) < brickPicture.Right)
                            {
                                ball.UpdateVelocity(-velocity.X, velocity.Y);
                            } else
                            {
                                ball.UpdateVelocity(velocity.X, -velocity.Y);
                            } */
                        }
                    }
                }
            }
        }

        private void InsertCoinButton_Click(object sender, EventArgs e)
        {
            if(this.lives == 0)
                InstertCoin();
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(!paddle.IsDead)
                paddle.UpdatePosition(e.X - paddle.GetPictureBox().Width / 2, paddle.GetPosition().Y);
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            this.rows = 4;
            this.columns = 9;
        }

    }
}
