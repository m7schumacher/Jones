using Jones.Domain.Internal.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Weather
{
    public class WeatherConditions
    {
        [Adjectives("cold", "hot")]
        public int ApparentTemperature { get; set; }
        public int CloudCover { get; set; }
        public int DewPoint { get; set; }
        public int Humidity { get; set; }
        public int NearestStormBearing { get; set; }
        public int NearestStormDistance { get; set; }
        public int Ozone { get; set; }
        public int PrecipIntensity { get; set; }
        public int PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public int Pressure { get; set; }
        public string Summary { get; set; }
        public int Temperature { get; set; }
        public long Time { get; set; }
        public double Visibility { get; set; }
        public int WindBearing { get; set; }
        public int WindSpeed { get; set; }

        public Data.Weather.Direction WindDirection { get; set; }
        public Data.Weather.Direction StormDirection { get; set; }
        public Data.Weather.PrecipIntensity Intensity { get; set; }
        public Data.Weather.PrecipType Type { get; set; }
    }
}
