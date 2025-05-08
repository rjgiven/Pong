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
        public MovingObject(int x, int y, MoveFunction moveFunction)
        {

        }
        public bool XDirection { get; set;  }
        public bool YDirection { get; set;  }

        public int XMax { get; set; }

        public int XMin { get; set; }

        public int YMax { get; set; }
        public int YMin { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public MoveFunction MoveFunction { get; set;  }

        public Point Center { get; set; }


        public event EventHandler Moving; 

     

        public Task Move()
        {
            throw new NotImplementedException();
        }



    }
}
