using Swiss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Core.Weather.Domain
{
    public class Currently
    {
        public float ApparentTemperature { get; set; }
        public float CloudCover { get; set; }
        public float DewPoint { get; set; }
        public float Humidity { get; set; }
        public float NearestStormBearing { get; set; }
        public float NearestStormDistance { get; set; }
        public float Ozone { get; set; }
        public float PrecipIntensity { get; set; }
        public float PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public float Pressure { get; set; }
        public string Summary { get; set; }
        public float Temperature { get; set; }
        public long Time { get; set; }
        public float Visibility { get; set; }
        public float WindBearing { get; set; }
        public float WindSpeed { get; set; }

        public CurrentCondition ConvertToCurrentCondition()
        {
            var curr = new CurrentCondition()
            {
                ApparentTemperature = (int)ApparentTemperature,
                CloudCover = (int)(CloudCover * 100),
                DewPoint = (int)DewPoint,
                Humidity = (int)(Humidity * 100),
                NearestStormBearing = (int)NearestStormBearing,
                NearestStormDistance = (int)NearestStormDistance,
                Ozone = (int)Ozone,
                PrecipIntensity = (int)PrecipIntensity,
                PrecipProbability = (int)(PrecipProbability * 100),
                PrecipType = PrecipType,
                Pressure = (int)Pressure,
                Summary = Summary,
                Temperature = (int)Temperature,
                Time = Time,
                WindSpeed = (int)WindSpeed,
                Visibility = Visibility.ToDouble(),
                WindDirection = WeatherHelpers.CalculateDirection(WindBearing),
                StormDirection = WeatherHelpers.CalculateDirection(NearestStormBearing),
                Intensity = WeatherHelpers.CalculatePrecipIntensity(PrecipIntensity),
                Type = WeatherHelpers.CalculatePrecipType(PrecipType)
            };

            return curr;
        }
    }

    public class Datum3
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int sunriseTime { get; set; }
        public int sunsetTime { get; set; }
        public double moonPhase { get; set; }
        public double precipIntensity { get; set; }
        public double precipIntensityMax { get; set; }
        public int precipIntensityMaxTime { get; set; }
        public double precipProbability { get; set; }
        public string precipType { get; set; }
        public double temperatureMin { get; set; }
        public int temperatureMinTime { get; set; }
        public double temperatureMax { get; set; }
        public int temperatureMaxTime { get; set; }
        public double apparentTemperatureMin { get; set; }
        public int apparentTemperatureMinTime { get; set; }
        public double apparentTemperatureMax { get; set; }
        public int apparentTemperatureMaxTime { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public double visibility { get; set; }
        public double cloudCover { get; set; }
        public double pressure { get; set; }
        public double ozone { get; set; }

        public DailyForecast ConvertToDailyForecast()
        {
            var forecast = new DailyForecast()
            {
                TemperatureMax = temperatureMax.ToInt(),
                TemperatureMin = temperatureMin.ToInt(),
                ApparentTemperatureMax = apparentTemperatureMax.ToInt(),
                ApparentTemperatureMin = apparentTemperatureMin.ToInt(),
                ApparentTemperatureMaxTime = apparentTemperatureMaxTime.ToDate(),
                ApparentTemperatureMinTime = apparentTemperatureMinTime.ToDate(),
                TemperatureMaxTime = temperatureMaxTime.ToDate(),
                TemperatureMinTime = temperatureMinTime.ToDate(),
                PrecipIntensity = precipIntensity.ToInt(),
                PrecipIntensityMax = precipIntensityMax.ToInt(),
                PrecipIntensityMaxTime = precipIntensityMaxTime.ToDate(),
                Visibility = visibility.ToInt(),
                Pressure = pressure.ToInt(),
                DewPoint = dewPoint.ToInt(),
                PrecipType = precipType,
                SunriseTime = sunriseTime.ToDate(),
                SunsetTime = sunsetTime.ToDate(),
                CloudCover = (int)(cloudCover * 100),
                Humidity = (int)(humidity * 100),
                WindSpeed = windSpeed.ToInt(),
                PrecipProbability = (int)(precipProbability * 100),
                WindDirection = WeatherHelpers.CalculateDirection(windBearing),
                Intensity = WeatherHelpers.CalculatePrecipIntensity(precipIntensity),
                Type = WeatherHelpers.CalculatePrecipType(precipType),

                TimeOfHighestTemp = temperatureMaxTime.ToDate(),
                TimeOfLowestTemp = temperatureMinTime.ToDate(),

                TimeOfMostPrecip = precipIntensityMaxTime.ToDate(),
                Day = time.ToDate().DayOfWeek
            };

            return forecast;
        }
    }

    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum3> data { get; set; }
    }

    public class ShellWeatherResponse
    {
        public Currently currently { get; set; }
        public Daily daily { get; set; }

        public WeatherOutlook ConvertToWeatherConditions()
        {
            return new WeatherOutlook()
            {
                Currently = currently.ConvertToCurrentCondition(),
                DailyForecasts = daily.data.Select(dt => dt.ConvertToDailyForecast()).ToList()
            };
        }
    }
}
