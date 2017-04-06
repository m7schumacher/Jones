using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports
{
    public class Team
    {
        public bool IsHome { get; set; }
        public int Score { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }

        public string City { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public Team()
        {
            IsHome = false;
            Score = -1;
        }

        public Team(int score, bool isHome)
        {
            Score = score;
            IsHome = isHome;
        }
    }
}
