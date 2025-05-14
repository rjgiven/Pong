namespace Pong.Classes
{
    public class MoveFunction
    {
        public MoveFunction(decimal m, int b, bool isMovingRight)
        {
            M = m;
            B = b;
            this.isMovingRight = isMovingRight;
            this.isMovingUp = m < 0;
        }

        public decimal M { get; set; }
        public int B { get; set;  }

        public bool isMovingRight { get; set; }

        public bool isMovingUp { get; set; }

        public PongPoint Move(PongPoint currentPoint, int inc)
        {
            if (isMovingRight)
            {
                currentPoint.X += inc;
            }
            else
            {
                currentPoint.X -= inc;
            }
            currentPoint.Y = (int)(M * currentPoint.X + B);
            return currentPoint; 
        }

        public void Bounce(PongPoint currentPoint)
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

            M *= -1;
            B = currentPoint.X;

        }



    }
}
