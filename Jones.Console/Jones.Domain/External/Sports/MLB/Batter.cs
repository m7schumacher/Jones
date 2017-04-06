using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports.MLB
{
    public class Batter : BaseballPlayer
    {
        public int R { get; set; }
        public int RBI { get; set; }
        public int H { get; set; }
        public int SB { get; set; }
        public int HR { get; set; }
        public int AB { get; set; }

        public double SeasonAVG { get; set; }
        public int SeasonRBI { get; set; }
        public double SeasonSLG { get; set; }
        public int SeasonHR { get; set; }
    }
}
