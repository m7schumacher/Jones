using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Geographical
{
    public class LatAndLong
    {
        public string Lat { get; set; }
        public string Long { get; set; }

        public LatAndLong()
        {
            Lat = string.Empty;
            Long = string.Empty;
        }
    }
}
