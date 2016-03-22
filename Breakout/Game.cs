using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Breakout
{
    class Game
    {
        //timer
        private DispatcherTimer timer;
        //canvas
        private Canvas canvas;

        //ball
        private Ball ball;
        //paddle
        public Paddle paddle;
        //blocks
        private List<Block> blocks;

        //constructor
        public Game(Canvas canvas)
        {
            this.canvas = canvas;
            CreateBall();
            CreatePaddle();
            CreateBlocks();
        }

        //add ball to game
        private void CreateBall()
        {
            ball = new Ball
            {
                LocationX = 390,
                LocationY = 500
            };
            canvas.Children.Add(ball);
        }

        //create paddle
        private void CreatePaddle()
        {
            paddle = new Paddle
            {
                LocationX = 350,
                LocationY = 550
            };
            canvas.Children.Add(paddle);
        }

        //create blocks
        private void CreateBlocks()
        {
            blocks = new List<Block>();
            int blocksCount = 120;
            int cols = 12;
            int xStartPos = 70;
            int yStartPos = 30;
            int step = 5;
            int row = 0;
            int col = 0;

            for (int i = 0; i < blocksCount; i++)
            {
                //is it a new row
                if (i % cols == 0 && i > 0)
                {
                    row++;
                    col = 0;
                }
                else if (i > 0)
                {
                    col++;
                }
                //block position
                int x = (50 + step) * col + xStartPos; // 0, 55, 110...
                int y = (20 + step) * row + yStartPos; // 0, 25, 50, 75...
                //create a block
                Block block = new Block
                {
                    LocationX = x,
                    LocationY = y
                };
                //add to blocks
                blocks.Add(block); //list_collection
                //add to canvas
                canvas.Children.Add(block);
                //set location in canvas
                block.SetLocation();
            }
        }

        //start game
        public void StartGame()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60); //60fps
            timer.Start();
        }

        //game loop
        private void Timer_Tick(object sebder, object e)
        {
            ball.Move();
            CheckCollision();
            IsGameOver();
        }

        //game over
        private void IsGameOver()
        {
            //all blocks removed
            if (blocks.Count == 0)
            {
                Debug.WriteLine("Game Over - Good Job!");
                timer.Stop();
            }
            //ball below paddle
            if (ball.LocationY > paddle.LocationY)
            {
                Debug.WriteLine("Game Over - Outsh!");
            }
        }

        private void CheckCollision()
        {
            //ball and paddle
            Rect rect = ball.GetRect();
            rect.Intersect(paddle.GetRect());
            if (!rect.IsEmpty)
            {
                // paddle 100 px
                //ball position 0-100
                double ballPosition = ball.LocationX - paddle.LocationX;
                //-0.5 <-> 0.5
                double hitPrecent = (ballPosition / paddle.Width) - 0.5;
                //set ball speed
                ball.SetSpeed(hitPrecent);

            }

            //ball and blocks
            foreach(Block block in blocks)
            {
                Rect ballRect = ball.GetRect();
                ballRect.Intersect(block.GetRect());
                if(!ballRect.IsEmpty)
                {
                    blocks.Remove(block);
                    //remove from Canvas
                    canvas.Children.Remove(block);
                    //SpeedX and Speedy?
                    double ballCenter = ball.LocationX + (ball.Width) / 2;
                    if (ballCenter < block.LocationX || (ballCenter > block.LocationX + block.Width))
                    {
                        ball.SpeedX *= -1;
                    }
                    else
                    {
                        ball.SpeedY *= -1;
                    }
                    //break
                    break;
                }
            }
        }
    }
}
