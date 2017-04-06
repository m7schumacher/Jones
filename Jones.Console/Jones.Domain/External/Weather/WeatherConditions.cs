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

        [Adjectives("cloudy")]
        public int CloudCover { get; set; }

        public int DewPoint { get; set; }

        [Adjectives("humid", "balmy", "sticky")]
        public int Humidity { get; set; }

        public int NearestStormBearing { get; set; }
        public int NearestStormDistance { get; set; }
        public int Ozone { get; set; }
        public int PrecipIntensity { get; set; }
        public int PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public int Pressure { get; set; }
        public string Summary { get; set; }

        [Adjectives("hot", "cold", "warm", "cool")]
        public int Temperature { get; set; }

        public long Time { get; set; }

        [Adjectives("clear")]
        public double Visibility { get; set; }

        public int WindBearing { get; set; }

        [Adjectives("windy")]
        public int WindSpeed { get; set; }

        public Data.Weather.Direction WindDirection { get; set; }
        public Data.Weather.Direction StormDirection { get; set; }
        public Data.Weather.PrecipIntensity Intensity { get; set; }
        public Data.Weather.PrecipType Type { get; set; }
    }
}
