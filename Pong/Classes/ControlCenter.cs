namespace Pong.Classes
{
    public class ControlCenter
    {
        public Ball Ball { get; set; }

        public Paddle Paddle1 { get; set; }

        public Paddle Paddle2 { get; set; }


        public ControlCenter(Ball ball, Paddle paddle1, Paddle paddle2)
        {
            Ball = ball;
            Paddle1 = paddle1;
            Paddle2 = paddle2;

        }

      

        public Task HandleObjectMove()
        {
            return null; 
        }
    }
}
