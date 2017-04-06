using Jones.API;
using Jones.API.Geography;
using Jones.API.Weather;
using Jones.Domain.External.Weather;
using Jones.Domain.Internal;
using Jones.Domain.Phrases;
using Jones.Domain.Triggers;
using Swiss;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Weather
{
    public class WeatherCell : Cell
    {
        private const string Nm = "Weather";

        public WeatherCell() : base(Nm)
        {
            
        }

        protected override void Initialize()
        {
            Pool = new WeatherPool();
            Gate = new WeatherGate(Nm, Pool);
            Monitor = new WeatherMonitor(Nm, Pool);
        }
    }
}
