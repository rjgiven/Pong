using Pong.Classes;
using Pong.Services;

namespace Pong
{
    public partial class App : Application
    {
        static public Window appWindow; 
        public App()
        {
            InitializeComponent();
            
            MainPage = new MainPage();

            //StartGame();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            appWindow = base.CreateWindow(activationState);
            return appWindow; 
        }

        //public void StartGame()
        //{
        //    Scoreboard scoreboard = new Scoreboard("COM3", 9600);
        //    //scoreboard.Start();

        //    Player Player1 = new Player("Player 1");
        //    Player Player2 = new Player("Player 2");


        //    scoreboard.UpdateScoreboard(new Classes.ScoreBoardUpdate(1, Player1, Player2));

        //    Task.Delay(2000);

        //    Player1.IncrementScore();
        //    scoreboard.UpdateScoreboard(new Classes.ScoreBoardUpdate(1, Player1, Player2));
        //    Task.Delay(2000);
        //    Player2.IncrementScore();
        //    scoreboard.UpdateScoreboard(new Classes.ScoreBoardUpdate(1, Player1, Player2));
        //    Task.Delay(2000);
        //    Player1.IncrementScore();
        //    scoreboard.UpdateScoreboard(new Classes.ScoreBoardUpdate(1, Player1, Player2));
        //    Task.Delay(2000);
        //    scoreboard.UpdateScoreboard(new Classes.ScoreBoardUpdate(0, Player1, Player2));
        //    Task.Delay(2000);
        //    scoreboard.Stop();
        //}

    }
}
