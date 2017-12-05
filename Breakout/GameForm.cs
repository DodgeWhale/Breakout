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

        int rows = 3, columns = 7, totalBricks;

        public GameForm()
        {
            // Fixes laggy ball rendering
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            paddle = new Paddle(GamePanel, GamePanel.Width / 2, GamePanel.Height - 20);
            paddle.AddToPanel();
            paddle.Centre(GamePanel.Height - 50);

            ball = new Ball(GamePanel, 3); // TODO: Set specific x, y
            ball.AddToPanel();
        }

        // Consider putting "Insert coin" in either a new panel or a different form entirely
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
            this.totalBricks = bricks.Length;
            Console.WriteLine("Total bricks: {0}", this.totalBricks);
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

            // This isn't really needed
            if(ball == null || ball.IsDead)
            {
                // You lost
                Console.WriteLine("You lost.");
                this.timer.Stop();
            }

            /* if(ball.CheckCollision(paddle.GetPictureBox()))
            {
                Point velocity = ball.GetVelocity();
                ball.UpdateVelocity(velocity.X, -velocity.Y);
            } // Add else for bricks and panel edges? Can't ever be both right? */

            PictureBox ballPicture = this.ball.GetPictureBox();
            List<Brick> collided = new List<Brick>();

            if (!ball.CheckPanelBoundries())
            {
                Point pos = ball.GetCenterPosition(),
                      nextPos = this.ball.GetNewPosition(),
                      velocity = ball.GetVelocity();

                if (paddle.CheckCollision(nextPos.X, nextPos.Y, ballPicture))
                {
                    int velX = velocity.X;
                    for (int x = velX; x != (ball.GetSpeed() * velX + velX); x += velX)
                    {
                        Console.WriteLine("X: {0}", x);
                    }

                    int xDiff = Math.Abs(pos.X - nextPos.X);
                    Console.WriteLine("xDiff: {0} | {1}, {2}", xDiff, pos.X, nextPos.X);

                    if (!paddle.GetPictureBox().Bounds.IntersectsWith(this.ball.GetPictureBox().Bounds))
                        ball.SetNewVelocity(paddle);
                }

                // Consider creating a method that converts Brick[,] to Brick[] and just foreach it.
                // I don't think I need the row and column value for anything other than getting the target brick.
                for (int x = 0; x < columns; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                        Brick target = bricks[x, y];

                        if (!target.IsDead && target.CheckCollision(nextPos.X, nextPos.Y, ballPicture))
                        {
                            collided.Add(target);
                            this.totalBricks--;
                        }
                    }
                }

                if (this.totalBricks == 0)
                {
                    // You win
                    this.timer.Stop();
                }

                // The ball didn't collide with any bricks
                if (collided.Count == 0)
                {
                    ball.UpdateCenter(nextPos.X, nextPos.Y);
                }
                else
                {
                    // We don't have to loop through the collided bricks because the outcome will be the same for both
                    // so I might aswell just pick the 0 index every time and it won't make a difference.
                    Brick target = collided[0];

                    ball.SetNewVelocity(target);

                    // Update new position after setting new velocity
                    ball.UpdateCenter(ball.GetNewPosition());

                    Point testVel = ball.GetVelocity();
                    Console.WriteLine("velX: {0}, velY: {1}", testVel.X, testVel.Y);

                    // Hide collided bricks
                    foreach (Brick brick in collided)
                    {
                        this.AddPoints(brick.GetColour().GetPoints());
                        brick.SetDead(true);
                    }
                }
            }
            else // the ball hit the bottom of the panel past the paddle
            {
                this.timer.Stop();
                ball.ResetPosition();
                this.SetLives(this.lives - 1);
            }
        }

        private void InsertCoinButton_Click(object sender, EventArgs e)
        {
            if(this.lives == 0)
                InstertCoin();
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!paddle.IsDead)
            {
                PictureBox pictBox = paddle.GetPictureBox();

                int half = pictBox.Width / 2;
                int newPos = e.X - half;

                if (newPos < 0)
                    return;
                paddle.UpdatePosition(newPos, paddle.GetPosition().Y);
            }
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            this.rows = 4;
            this.columns = 9;
        }

    }
}


/* for (int x = 0; x < columns; x++)
{
    for (int y = 0; y < rows; y++)
    {
        Brick target = bricks[x, y];

        if(target.CheckCollision(ballPicture)) {
            if (!target.IsDead)
            {
                this.AddPoints(target.GetColour().GetPoints());
                target.SetDead(true);

                PictureBox brickPicture = target.GetPictureBox();
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

                if (ballPicture.Left + (ballPicture.Width / 2) < brickPicture.Left
                    || ballPicture.Right - (ballPicture.Width / 2) < brickPicture.Right)
                {
                    ball.UpdateVelocity(-velocity.X, velocity.Y);
                } else
                {
                    ball.UpdateVelocity(velocity.X, -velocity.Y);
                }
            }
        }
    }
} */
