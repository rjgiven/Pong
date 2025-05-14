using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
    public class ScoreBoardUpdate : JsnModel
    {
        /// <summary>
        /// Required for json serialization / de-serialization
        /// </summary>
        public ScoreBoardUpdate() { }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ScoreBoardUpdate(int gameStatus, Player player1, Player player2)
        {
            this.gameStatus = gameStatus;
            this.player1 = player1;
            this.player2 = player2;
        }

        public int gameStatus { get; set; }

        public Player player1 { get; set; }

        public Player player2 { get; set; }
    }
}
