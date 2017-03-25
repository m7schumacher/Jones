using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Core.Weather.Domain
{
    public class DailyForecast
    {
        public double ApparentTemperatureMax { get; set; }
        public DateTime ApparentTemperatureMaxTime { get; set; }
        public double ApparentTemperatureMin { get; set; }
        public DateTime ApparentTemperatureMinTime { get; set; }
        public double CloudCover { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double MoonPhase { get; set; }
        public double PrecipIntensity { get; set; }
        public double PrecipIntensityMax { get; set; }
        public DateTime PrecipIntensityMaxTime { get; set; }
        public double PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double Pressure { get; set; }
        public string Summary { get; set; }
        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }
        public double TemperatureMax { get; set; }
        public DateTime TemperatureMaxTime { get; set; }
        public double TemperatureMin { get; set; }
        public DateTime TemperatureMinTime { get; set; }
        public double Visibility { get; set; }
        public double WindBearing { get; set; }
        public double WindSpeed { get; set; }

        public WeatherEnums.Direction WindDirection { get; set; }
        public WeatherEnums.Direction StormDirection { get; set; }
        public WeatherEnums.PrecipIntensity Intensity { get; set; }
        public WeatherEnums.PrecipType Type { get; set; }

        public DateTime TimeOfHighestTemp { get; set; }
        public DateTime TimeOfLowestTemp { get; set; }

        public DateTime TimeOfMostPrecip { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
