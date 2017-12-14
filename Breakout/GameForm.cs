using Breakout.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
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

            ball = new Ball(GamePanel, 3);
            ball.AddToPanel();
            ball.Centre();
        }

        // Consider putting "Insert coin" in either a new panel or a different form entirely
        public void InstertCoin()
        {
            SetLives(5); // Start
            SetPoints(0);
            ResetGame();
            InitializeBricks();
            RestartTimer();
        }

        public void ResetGame()
        {
            this.totalPoints = 0;
            ball.ResetPosition();
        }

        public void GameOver(bool win)
        {
            if (this.timer != null)
            {
                this.timer.Stop();
            }

            // Show menu panel
            MenuPanel.Visible = true;

            // Display information based on win or lose clause
            MessageLabel.Text = (win ? "Great job!" : "Better luck next time!") + " You scored a total of " + totalPoints + " points.";
            MenuPanel.BackColor = win ? Color.FromArgb(155, 208, 240) : Color.FromArgb(209, 69, 69);

            Stream wav = win ? Properties.Resources.Win : Properties.Resources.Lose;
            this.PlaySound(wav);
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

                this.PlaySound(Properties.Resources.Life);
            }

            lbl_Points.Text = "" + this.points;
        }

        public void SetLives(int lives)
        {
            this.lives = lives;
            lbl_Lives.Text = "" + lives;

            if(lives <= 0)
            {
                GameOver(false);
            }
        }

        private SoundPlayer player = new SoundPlayer();
        public void PlaySound(Stream sound)
        {
            try
            {
                // Resetting the position and stream is to avoid "InvalidOperationException"
                // But just to be safe, I've added a try/catch too.
                sound.Position = 0;
                player.Stream = null;
                player.Stream = sound;
                player.Play();
            } catch (InvalidOperationException)
            {
                Console.WriteLine("Error playing sound.");
            }
        }

        public void InitializeBricks()
        {
            Random rand = new Random();
            this.rows = rand.Next(3, 5);
            this.columns = rand.Next(6, 8);

            // Clears the old bricks from the GamePanel for when the level is reset
            // if the current array isn't empty
            if (this.bricks != null)
            {
                foreach (Brick brick in this.bricks)
                {
                    this.GamePanel.Controls.Remove(brick.GetPictureBox());
                }
            }

            // Create new Brick 2d array
            Brick[,] bricks = new Brick[columns, rows];

            int width = 54, height = 22, padding = 10,
                margin = (GamePanel.Width - ((width + padding) * columns)) / 2;

            // Iterate through columns and rows
            for (int x = 0; x < columns; x++)
            {
                for(int y = 0; y < rows; y++)
                {
                    Brick brick = new Brick(GamePanel, margin + (x * (width + padding)), margin / 2 + (y * (height + padding)), width, height);
                    brick.AddToPanel();

                    bricks[x, y] = brick; // Add to array
                }
            }

            // Assign variables
            this.bricks = bricks;
            this.totalBricks = bricks.Length;
        }

        private void RestartTimer()
        {
            // If the timer is currently running, stop it
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

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            this.timer.Start();
            ContinueButton.Visible = false;
            this.PlaySound(Properties.Resources.Life);
        }

        // Initialized outside of Timer to improve efficiency
        private List<Brick> collided = new List<Brick>();

        private void TimerTick(object sender, EventArgs e)
        {
            // TODO && lives == 0
            // Show insert coin button

            // This isn't really needed
            if(ball == null || ball.IsDead)
            {
                // You lost
                GameOver(false);
            }

            if (!ball.CheckPanelBoundries())
            {
                PictureBox ballPicture = this.ball.GetPictureBox();

                Point pos = ball.GetPosition(),
                      nextPos = this.ball.GetNewPosition(),
                      velocity = ball.GetVelocity();

                if (paddle.CheckCollision(nextPos.X, nextPos.Y, ballPicture))
                {
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
                    GameOver(true);
                }

                // The ball didn't collide with any bricks
                if (collided.Count == 0)
                {
                    ball.UpdatePosition(nextPos.X, nextPos.Y);
                }
                else
                {
                    // We don't have to loop through the collided bricks because the outcome will be the same for both
                    // so I might aswell just pick the 0 index every time and it won't make a difference.
                    Brick target = collided[0];

                    ball.SetNewVelocity(target);

                    // Update new position after setting new velocity
                    ball.UpdatePosition(ball.GetNewPosition());

                    this.PlaySound(Properties.Resources.Brick);

                    // Hide collided bricks
                    foreach (Brick brick in collided)
                    {
                        this.AddPoints(brick.GetColour().GetPoints());
                        brick.SetDead(true);
                    }
                }

                // Empty the collided list
                collided.Clear();
            }
            else // the ball hit the bottom of the panel past the paddle
            {
                this.PlaySound(Properties.Resources.Death);

                this.timer.Stop();
                this.SetLives(this.lives - 1);

                ball.ResetPosition();
                ContinueButton.Visible = true;
            }
        }

        private void InsertCoinButton_Click(object sender, EventArgs e)
        {
            InstertCoin();
            MenuPanel.Visible = false;
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (timer == null) return;

            if (timer.Enabled && !ball.IsDead)
            {
                PictureBox pictBox = paddle.GetPictureBox();

                int half = pictBox.Width / 2;
                int newPos = e.X - half;

                if (newPos < 0 || ball.CheckCollision(new Rectangle(newPos, paddle.GetPosition().Y, pictBox.Width, pictBox.Height)))
                    return;

                paddle.UpdatePosition(newPos, paddle.GetPosition().Y);
            }
        }

    }
}
