using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
    public class MovingObject : ObservableObject
    {
        public MovingObject(PongPoint centerPoint, int witdh, int height, MoveFunction moveFunction)
        {
            MoveFunction = moveFunction;
            Width = witdh;
            Height = height;
            Center = centerPoint;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int XMax
        {
            get
            {
                return Center.X + Width / 2;
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

        public MoveFunction MoveFunction { get; set; }

        PongPoint _center;
        public PongPoint Center
        {
            get
            { return _center; }
            set
            {
                SetProperty(ref _center, value);
            }
        }

        public event EventHandler Moving;
        public event MoveBallHereHandler MoveBallHere;
        public delegate void MoveBallHereHandler(PongPoint point);


        public void Move(int Increment)
        {
            Center = MoveFunction.Move(Center, Increment);
            if (MoveBallHere != null)
                MoveBallHere.Invoke(Center);
        }

       

        public void Bouse()
        {
            MoveFunction.Bounce(Center);
            
        }

    }
}
