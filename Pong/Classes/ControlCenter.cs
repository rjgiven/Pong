using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Pong.Classes
{
    public class ControlCenter : ObservableObject
    {
        Ball _ball;
        public Ball Ball {
            get { return _ball; }
            set { SetProperty(ref _ball, value); }
        }

        public Paddle LeftPaddle { get; set; }

        public Paddle RightPaddle { get; set; }

        public int BallRadius = 20;

        // board size/borders
        private int Xmax { get; set; }
        private int Xmin { get; set; } 
        private int Ymax { get; set; }
        private int YMin { get; set; } 
        


        private int BALL_SPEED = 5;

        //private Stopwatch stopWatch = new Stopwatch();
        private Timer Timer { get; set; }
        public int PaddleWidth { get; set; } = 10;
        public int PaddleHeight { get; set; } = 50;
        public int PaddleMargin { get; set; } = 5;

        public ControlCenter(int xMin, int xMax, int yMin, int yMax, int? iniSpeed=5)
        {
            Xmin = xMin;
            Xmax = xMax;
            YMin = yMin;
            Ymax = yMax;
            if (iniSpeed != null) BALL_SPEED = (int)iniSpeed;

            InitializeGame(); 

        }

        private void InitializeGame()
        {
            // create some random value
            bool isMovingRight = DateTime.Now.Microsecond % 2 == 0;
            int randAngle = (new Random()).Next(5,85);
            decimal ballM = (decimal)Math.Tan(Math.PI * randAngle / 180); 
            

            // TODO: set proper ini params for the game
            var iniBallPoint = new PongPoint(Xmax/2, Ymax/2);

            var ballMovingFunc = new MoveFunction(ballM, iniBallPoint.X,isMovingRight: isMovingRight);

            Ball = new Ball(iniBallPoint, BallRadius, BallRadius, ballMovingFunc);

            var pl = new PongPoint(Xmin + (PaddleWidth/2) + PaddleMargin, Ymax/2);
            LeftPaddle = new Paddle(pl, PaddleWidth, PaddleHeight);

            var pr = new PongPoint(Xmax - (PaddleWidth / 2) + PaddleMargin, Ymax/2);
            RightPaddle = new Paddle(pr, PaddleWidth, PaddleHeight);


            Ball.Moving += this.HandleObjectMove;
            LeftPaddle.Moving += this.HandleObjectMove;
            RightPaddle.Moving += this.HandleObjectMove;

           
        }

        private void TimeTick(object? state)
        {
            Ball.Move(BALL_SPEED);
            CheckBousing();
            CheckScore();

            // increase speed over time for less boring
            this.BALL_SPEED++; 
        }

        private void CheckScore()
        {
            if (Ball.XMax >= this.Xmax)
            {  // left player win
                LeftPaddle.Score++;
                Replay();
            }

            if (Ball.XMin <= this.Xmin)
            {
                RightPaddle.Score++;
                Replay();
            }

        }

        public void Replay()
        {
         
        }

        public void StartGame()
        {
            // random time interval
            var randTic = 10; // (new Random()).Next(20, 20);
            Timer = new Timer(TimeTick, null, 0, randTic);
        }


        public void HandleObjectMove(object? sender, EventArgs e)
        {


        }

        private void CheckBousing()
        {
            // TODOL handle moving object
            // check for collision
            if (HitLeftPaddle()  // hit paddle 1
                || HitRightPaddle()  // hit paddle 2
                || HitWall())
            {
                Ball.Bouse();
            }
        }

        private bool HitWall()
        {
            return Ball.YMax >= Ymax  // hit edge
                || Ball.YMin <= YMin; // hit edge
        }

        private bool HitRightPaddle()
        {
            return Ball.XMax >= RightPaddle.XMin
                    && Ball.Center.Y >= RightPaddle.YMin
                    && Ball.Center.Y <= RightPaddle.YMax;
        }

        private bool HitLeftPaddle()
        {
            // the ball is round, center y equal to touch point y
            return Ball.XMin <= LeftPaddle.XMax
                    && Ball.Center.Y >= LeftPaddle.YMin
                    && Ball.Center.Y <= LeftPaddle.YMax;
            


        }
    }
}