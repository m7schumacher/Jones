using Jones.API.Sports.MLB;
using Jones.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells
{
    public class BaseballCell : Cell
    {
        private const string Nm = "Baseball";

        public BaseballCell() : base(Nm)
        {
            Enabled = false;
        }

        protected override void Initialize()
        {
            
        }
    }
}
