using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports.MLB
{
    public enum PitcherStatus
    {
        Probable,
        Current,
        Winner,
        Loser,
        Saver
    }

    public class Pitcher : BaseballPlayer
    {
        public int W { get; set; }
        public int L { get; set; }

        public int ER { get; set; }
        public double ERA { get; set; }
        public int K { get; set; }
        public int H { get; set; }
        public int IP { get; set; }

        public PitcherStatus Status { get; set; }
        public bool IsHome { get; set; }
    }
}
