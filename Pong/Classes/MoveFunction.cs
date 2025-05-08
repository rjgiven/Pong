namespace Pong.Classes
{
    public class MoveFunction
    {
        public int M { get; set; }
        public int B { get; set;  }

        public bool isMovingRight { get; set; }

        public bool isMovingUp { get; set; }

        public Point Move(Point p)
        {
            if (isMovingRight)
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
            if (isMovingRight)
            {
                if (isMovingUp)
                {
                    isMovingRight = false; 
                }
                else
                {
                    isMovingUp = true; 
                }
            }
            else
            {
                if (isMovingUp)
                {
                    isMovingUp = false; 
                }
                else
                {
                    isMovingRight = true; 
                }
            }

        }



    }
}
