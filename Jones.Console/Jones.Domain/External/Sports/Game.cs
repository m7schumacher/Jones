using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports
{
    public enum GameState
    {
        NotStarted,
        InProgress,
        Final
    }

    public class SportsGame
    {
        public string Venue { get; set; }

        public GameState State { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public DateTime StartTime { get; set; }

        public SportsGame()
        {
            HomeTeam = new Team();
            AwayTeam = new Team();
            State = GameState.NotStarted;
        }

        public SportsGame(Team home, Team away, GameState state)
        {
            HomeTeam = home;
            AwayTeam = away;
            State = state;
        }
    }
}
