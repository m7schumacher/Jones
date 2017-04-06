using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Sports
{
    public class SportsPlayer
    {
        public string First { get; set; }
        public string Last { get; set; }

        public string FullName { get { return First + "  " + Last; } }

        public SportsPlayer()
        {
            First = string.Empty;
            Last = string.Empty;
        }

        public SportsPlayer(string first, string last)
        {
            First = first;
            Last = last;
        }
    }
}
