using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Classes;

namespace Pong.Services
{
    public class Scoreboard : CommService
    {
        public Scoreboard(string port, int baud) : base(port, 9600) { }

        public Task UpdateScoreboard(ScoreBoardUpdate update)
        {
            SendCommand(update.ToJson());
            return Task.CompletedTask;
        }

    }
}
