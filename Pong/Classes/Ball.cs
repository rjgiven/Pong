using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
    public class Ball : MovingObject
    {
        public Ball(PongPoint centerPoint, int witdh, int height, MoveFunction moveFunction) : base(centerPoint, witdh, height, moveFunction)
        {
        }

    }
}
