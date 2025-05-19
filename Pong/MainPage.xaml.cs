using Pong.Classes;

namespace Pong
{
    public partial class MainPage : ContentPage
    {
        ControlCenter ControlCenter; 
        public MainPage()
        {
            InitializeComponent();
        }

        protected void SetControlCenter()
        {

            ControlCenter = new ControlCenter(0, (int)Width, 0, (int)Height, 10);
            ControlCenter.Ball.Width = (int)Ball.WidthRequest; 
            BindingContext = ControlCenter;
            ControlCenter.Ball.MoveBallHere += MoveBallHereHandler; 
            ControlCenter.StartGame();
          
        }

        private void MoveBallHereHandler(PongPoint point)
        {
            Ball.TranslateTo(point.X, point.Y, length: 1000); 
        }

        private void BindingBall()
        {
            //Ball.BindingContext = ControlCenter.Ball;
            
        }

        private void PanGestureRecognizer_PanUpdated_Player1(object sender, PanUpdatedEventArgs e)
        {
            Player1.TranslateTo(0, e.TotalY, 1, Easing.Linear);
        }

        private void PanGestureRecognizer_PanUpdated_Player2(object sender, PanUpdatedEventArgs e)
        {
            Player2.TranslateTo(0, e.TotalY, 1, Easing.Linear);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            SetControlCenter(); 
        }
    }

}
