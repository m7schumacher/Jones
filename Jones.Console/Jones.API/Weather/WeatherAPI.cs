using Jones.Domain.External.Weather;
using Jones.Domain.Internal;
using Jones.Domain.Internal.API;
using Swiss;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.API.Weather
{
    #region Shell Classes

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

        public WeatherConditions ConvertToCurrentCondition()
        {
            var curr = new WeatherConditions()
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
                WindDirection = WeatherApiUtilities.CalculateDirection(WindBearing),
                StormDirection = WeatherApiUtilities.CalculateDirection(NearestStormBearing),
                Intensity = WeatherApiUtilities.CalculatePrecipIntensity(PrecipIntensity),
                Type = WeatherApiUtilities.CalculatePrecipType(PrecipType)
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

        public Forecast ConvertToDailyForecast()
        {
            WeatherConditions expectedConditions = new WeatherConditions()
            {
                CloudCover = (int)(cloudCover * 100),
                DewPoint = (int)dewPoint,
                Humidity = (int)(humidity * 100),
                Ozone = (int)ozone,
                PrecipIntensity = (int)precipIntensity,
                PrecipProbability = (int)(precipProbability * 100),
                PrecipType = precipType,
                Pressure = (int)pressure,
                Summary = summary,
                WindSpeed = (int)windSpeed,
                Visibility = visibility,
                WindDirection = WeatherApiUtilities.CalculateDirection(windBearing),
                Intensity = WeatherApiUtilities.CalculatePrecipIntensity(precipIntensity),
                Type = WeatherApiUtilities.CalculatePrecipType(precipType)
            };

            var forecast = new Forecast()
            {
                ExpectedConditions = expectedConditions,
                TemperatureMax = temperatureMax.ToInt(),
                TemperatureMin = temperatureMin.ToInt(),
                ApparentTemperatureMax = apparentTemperatureMax.ToInt(),
                ApparentTemperatureMin = apparentTemperatureMin.ToInt(),
                ApparentTemperatureMaxTime = apparentTemperatureMaxTime.ToDate(),
                ApparentTemperatureMinTime = apparentTemperatureMinTime.ToDate(),
                TemperatureMaxTime = temperatureMaxTime.ToDate(),
                TemperatureMinTime = temperatureMinTime.ToDate(),
                PrecipIntensityMax = precipIntensityMax.ToInt(),
                PrecipIntensityMaxTime = precipIntensityMaxTime.ToDate(),
                SunriseTime = sunriseTime.ToDate(),
                SunsetTime = sunsetTime.ToDate(),

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

        public CurrentWeather ConvertToWeatherConditions()
        {
            return new CurrentWeather()
            {
                Currently = currently.ConvertToCurrentCondition(),
                DailyForecasts = daily.data.Select(dt => dt.ConvertToDailyForecast()).ToList()
            };
        }
    }

    #endregion

    #region Helpers

    internal class WeatherApiUtilities
    {
        internal static Data.Weather.Direction CalculateDirection(double degrees)
        {
            return (Data.Weather.Direction)Math.Floor(degrees / 45);
        }

        internal static Data.Weather.PrecipType CalculatePrecipType(string type)
        {
            switch (type)
            {
                case "rain": return Data.Weather.PrecipType.Rain;
                case "snow": return Data.Weather.PrecipType.Snow;
                case "sleet": return Data.Weather.PrecipType.Sleet;
                default: return Data.Weather.PrecipType.None;
            }
        }

        internal static Data.Weather.PrecipIntensity CalculatePrecipIntensity(double intensity)
        {
            var result = intensity > .4 ? Data.Weather.PrecipIntensity.Heavy :
                   intensity > .1 ? Data.Weather.PrecipIntensity.Moderate :
                   intensity > .016 ? Data.Weather.PrecipIntensity.Light :
                   intensity > 0 ? Data.Weather.PrecipIntensity.VeryLight :
                   Data.Weather.PrecipIntensity.None;

            return result;
        }

        internal static double MakePercentage(float value)
        {
            return (value * 100).ToDouble().Round(0);
        }
    }

    #endregion

    public class WeatherAPI : BaseAPI
    {
        public WeatherAPI()
        {
            Key = "9888d252b9801e7c1f36c712b9396661";
            BaseURL = "https://api.forecast.io/forecast/{0}/{1},{2}";
        }

        public string GiveWeekSummary(CurrentWeather conditions)
        {
            List<Forecast> forecasts = conditions.DailyForecasts;

            Forecast highestHigh = forecasts.MaxOfField(dl => dl.ApparentTemperatureMax);
            double lowestHigh = forecasts.Min(dl => dl.ApparentTemperatureMax);

            double highestLow = forecasts.Max(dl => dl.ApparentTemperatureMin);
            Forecast lowestLow = forecasts.MinOfField(dl => dl.ApparentTemperatureMin);

            List<Forecast> withPrecip = forecasts.Skip(1).Where(dl => dl.PrecipProbability > 50).ToList();

            string precipPortion = string.Empty;

            if (withPrecip.Count > 0)
            {
                string typeOfPrecip = withPrecip.GetNumberOfOccurencesForUniqueFields(fl => fl.PrecipType)
                                                .GetKeyWithLargestValue();

                string daysWithPrecip = withPrecip.Select(day => day.Day.ToString()).MakeIntoEnglishList();
                precipPortion = string.Format("expect a good chance of {0} on {1}. ", typeOfPrecip, daysWithPrecip);
            }

            string tempSummary = string.Format("I see highs ranging from {0} to {1} degrees over the next seven days with lows from {2} to {3}, ",
                lowestHigh, highestHigh.ApparentTemperatureMax, lowestLow.ApparentTemperatureMin, highestLow);

            string worstDays = DateTime.Now.Month > 9 ? string.Format("As for the chilliest day, that looks to be {0} on which I see a low of {1} degrees and wind speeds of {2} miles per hour",
                                                                lowestLow.Day, lowestLow.ApparentTemperatureMin, lowestLow.ExpectedConditions.WindSpeed)
                                                      : string.Format("As for the hottest day, that looks to be {0} on which I see a high of {1} and {2} percent humidity",
                                                                highestHigh.Day, highestHigh.ApparentTemperatureMax, highestHigh.ExpectedConditions.Humidity);

            string message = tempSummary + precipPortion + worstDays;

            return message;
        }

        public CurrentWeather GetCurrentWeather(double latitude, double longitude)
        {
            string FullURL = FormatBaseURL(Key, latitude, longitude);

            try
            {
                ShellWeatherResponse shellResponse = InternetUtility.DeserializeResponse<ShellWeatherResponse>(FullURL);
                CurrentWeather currentConditions = shellResponse.ConvertToWeatherConditions();

                string weekSummary = GiveWeekSummary(currentConditions);
                currentConditions.WeekSummary = weekSummary;

                return currentConditions;
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION: Weather API - " + e.Message.Substring(0, 50) + "...");
                return null;
            }
        }
    }
}
