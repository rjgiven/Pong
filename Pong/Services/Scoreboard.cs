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
    public class Scoreboard
    {
        public Scoreboard() { }

        public Task UpdateScoreboard(ScoreBoardUpdate update)
        {
            ServiceHelper.GetService<ICommService>().SendCommand(update.ToJson());
            return Task.CompletedTask;
        }

    }
}
