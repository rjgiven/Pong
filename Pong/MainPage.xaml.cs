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

        protected override void OnAppearing()
        {

            int xMax = (int)Window.Width;
            int yMax = (int)Window.Height;

            ControlCenter = new ControlCenter(0, xMax, 0, yMax, 10);
            ControlCenter.Ball.Width = (int)Ball.WidthRequest; 
            BindingContext = ControlCenter;

            ControlCenter.StartGame();
            base.OnAppearing();
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


    }

}
