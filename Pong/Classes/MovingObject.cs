using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
    public class MovingObject
    {
        public MovingObject(PongPoint centerPoint, int witdh, int height, MoveFunction moveFunction)
        {
            MoveFunction = moveFunction;
            Center = centerPoint;
        }

        public int Width { get; set;  }

        public int Height { get; set;  }

        public int XMax
        {
            get
            {
                return Center.X + Width/2;
            }
        }

        public int XMin
        {
            get
            {
                return Center.X - Width / 2;
            }
        }

        public int YMax
        {
            get
            {
                return Center.X + Width / 2;
            }
        }
        public int YMin
        {
            get
            {
                return Center.X - Width / 2;
            }
        }

        public MoveFunction MoveFunction { get; set;  }

        public PongPoint Center { get; set; }

        public event EventHandler Moving;
        

        public void Move(int Increment)
        {
            Center = MoveFunction.Move(Center, Increment);
            Moving.Invoke(this, null); 
        }

        public void Move(PongPoint to)
        {
            Center = to;
            Moving.Invoke(this, null);

        }

        public void Bouse()
        {
            MoveFunction.Bounce(Center); 
        }




    }
}
