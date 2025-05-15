using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.Classes
{
    public class PongPoint : ObservableObject
    {
        public PongPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        int x, y;
        public int X
        {
            get { return x; }
            set { SetProperty(ref x, value); }
        }
        public int Y
        {
            get { return y; }
            set { SetProperty(ref y, value); }
        }
    }
}
