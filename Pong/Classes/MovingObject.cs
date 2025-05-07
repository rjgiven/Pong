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
        public bool XDirection { get; set;  }
        public bool YDirection { get; set;  }

        public int XMax { get; set; }

        public int XMin { get; set; }

        public int YMax { get; set; }
        public int YMin { get; set; }

        public MoveFunction MoveFunction { get; set;  }

        public Point Center { get; set; }

        public Task MoveCommand { get; set; }

        
        public Task<Point> MoveCenter(int X, int Y)
        {
            throw new NotImplementedException(); 
        } 

    }
}
