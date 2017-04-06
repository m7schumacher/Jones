using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports.MLB
{
    public enum BaseballPositions
    {
        FirstBase,
        SecondBase,
        ThirdBase,
        ShortStop,
        LeftField,
        CenterField,
        RightField,
        Catcher,
        Pitcher
    }

    public class BaseballPlayer : SportsPlayer
    {
        BaseballPositions Position { get; set; }

        public BaseballPlayer()
        {

        }

        public BaseballPlayer(string first, string last, string position) : base(first, last)
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {1}", First, Last);
        }
    }
}
