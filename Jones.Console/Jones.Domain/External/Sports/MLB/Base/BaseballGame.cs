using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports.MLB
{
    public class BaseballGame : SportsGame
    {
        public string Inning { get; set; }

        public Batter AtBat { get; set; }
        public Batter OnDeck { get; set; }
        public Batter InHole { get; set; }
        public Batter DueUp { get; set; }

        public Pitcher Pitcher { get; set; }
        public Pitcher ProbableHome { get; set; }
        public Pitcher ProbableAway { get; set; }

        public bool IsNoHitter { get; set; }
        public bool IsPerfectGame { get; set; }

        public string LastPlay { get; set; }

        public BaseballGame() : base()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} vs. {1} | {2}", HomeTeam.Abbreviation, AwayTeam.Abbreviation,
                State == GameState.NotStarted ? StartTime.ToShortTimeString()
                       : State == GameState.InProgress ? Inning + " inning"
                       : "F");
        }
    }
}
