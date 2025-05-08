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
        public MovingObject()
        {

        }

        public int XMax { get; set; }

        public int XMin { get; set; }

        public int YMax { get; set; }
        public int YMin { get; set; }

        public MoveFunction MoveFunction { get; set;  }

        public Point Center { get; set; }

        public event EventHandler Moving; 

        public void Move()
        {
            Center = MoveFunction.Move(Center);
            Moving.Invoke(this, null); 
        }

        public void Move(Point to)
        {
            Center = to;
            Moving.Invoke(this, null);

        }




    }
}
