namespace Pong.Classes
{
    public class ControlCenter
    {
        public Ball Ball { get; set; }

        public Paddle Paddle1 { get; set; }

        public Paddle Paddle2 { get; set; }

        public int Xmax { get; set;  }
        public int Xmin { get; set; }
        public int Ymax { get; set; }
        public int YMin { get; set; }

        public ControlCenter(Ball ball, Paddle paddle1, Paddle paddle2)
        {
            Ball = ball;
            Paddle1 = paddle1;
            Paddle2 = paddle2;
            Ball.Moving += this.HandleObjectMove; 
            Paddle1.Moving += this.HandleObjectMove;
            Paddle2.Moving += this.HandleObjectMove;

        }

        public void Reset()
        {

        }

        public void HandleObjectMove(object? sender, EventArgs e)
        {
            // TODOL handle moving object
            // check for collision
            // trigger collsion event if needed
        }
    }
}
