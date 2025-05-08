namespace Pong.Classes
{
    public class MoveFunction
    {
        public int M { get; set; }
        public int B { get; set;  }

        public bool isMovingLeft { get; set; }

        public bool isMovingUp { get; set; }

        public Point Move(Point p)
        {
            if (M > 0)
            {
                p.X++;
            }
            else
            {
                p.X--;
            }
            p.Y = M * p.X + B;
            return p; 
        }

        public void Bounce()
        {
            if (isMovingLeft)
            {
               if (isMovingUp)
                {

                }
                else
                {

                }
            }
            else
            {
                if (isMovingUp)
                {

                }
                else
                {

                }
            }
            

        }



    }
}
