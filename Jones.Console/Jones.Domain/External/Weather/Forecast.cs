using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Weather
{
    public class Forecast
    {
        public WeatherConditions ExpectedConditions { get; set; }

        public double ApparentTemperatureMax { get; set; }
        public DateTime ApparentTemperatureMaxTime { get; set; }
        public double ApparentTemperatureMin { get; set; }
        public DateTime ApparentTemperatureMinTime { get; set; }

        public double PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double PrecipIntensityMax { get; set; }
        public DateTime PrecipIntensityMaxTime { get; set; }

        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }

        public double TemperatureMax { get; set; }
        public DateTime TemperatureMaxTime { get; set; }
        public double TemperatureMin { get; set; }
        public DateTime TemperatureMinTime { get; set; }

        public DateTime TimeOfHighestTemp { get; set; }
        public DateTime TimeOfLowestTemp { get; set; }

        public DateTime TimeOfMostPrecip { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
