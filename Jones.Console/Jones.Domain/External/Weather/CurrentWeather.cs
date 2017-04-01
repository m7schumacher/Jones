using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Weather
{
    public class CurrentWeather
    {
        public WeatherConditions Currently { get; set; }
        public List<Forecast> DailyForecasts { get; set; }

        public string WeekSummary { get; set; }
    }
}
