using Jones.API.Weather;
using Jones.Cells.Organelles;
using Jones.Domain.External.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Weather
{
    public class WeatherPool : Pool
    {
        private WeatherAPI API { get; set; }

        public CurrentWeather Weather { get; private set; }

        public WeatherPool() : base()
        {
            
        }

        protected override void Initialize()
        {
            API = new WeatherAPI();
        }

        public override void Update()
        {
            Weather = API.GetCurrentWeather(Data.Geo.FARGO_LATITUDE, Data.Geo.FARGO_LONGITUDE);
        }

        protected override object[] SetEntities()
        {
            return new object[] { Weather };
        }
    }
}
