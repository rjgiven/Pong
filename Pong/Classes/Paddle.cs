using System.Security.Cryptography.X509Certificates;

namespace Pong.Classes
{
    public class Paddle : MovingObject 
    {
        public int Score = 0; 
        public Paddle(PongPoint centerPoint, int witdh, int height, MoveFunction moveFunction=null) : base(centerPoint, witdh, height, moveFunction)
        {
            
        }
    }
}
