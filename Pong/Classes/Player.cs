using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
    public class Player
    {

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int score { get; set; } = 0;

        public void IncrementScore()
        {
            score++;
        }

        public void DecrementScore()
        {
            score--;
        }

        public void ClearScore()
        {
            score = 0;
        }
    }
}
