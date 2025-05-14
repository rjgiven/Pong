using Pong.Classes;

namespace Pong
{
    public partial class MainPage : ContentPage
    {
        ControlCenter ControlCenter; 
        public MainPage()
        {
           
            InitializeComponent();
            ControlCenter = new ControlCenter(0, (int)Canvas.X, 0, (int)Canvas.Y, 10);

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
