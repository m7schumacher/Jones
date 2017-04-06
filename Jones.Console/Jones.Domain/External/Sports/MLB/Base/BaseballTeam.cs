using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports.MLB
{
    public class BaseballTeam : Team
    {
        public int H { get; set; }
        public int ER { get; set; }
        public int HR { get; set; }
        public int SB { get; set; }
        public int K { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} | {2}/{3}", City, Name, Wins, Losses);
        }
    }
}
