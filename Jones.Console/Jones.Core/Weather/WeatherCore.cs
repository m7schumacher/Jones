using Jones.Core.Weather.Domain;
using Jones.Domain.Commands;
using Jones.Domain.Triggers;
using Swiss;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Core
{
    public class WeatherCore : Core
    {
        private const string Key = "9888d252b9801e7c1f36c712b9396661";

        public WeatherCore() : base()
        {
            BaseURL = "https://api.forecast.io/forecast/{0}/{1},{2}";
        }

        #region Base Methods

        protected override void GenerateInstincts()
        {
            Instincts = new List<Instinct>();
        }

        protected override void GenerateReflexes()
        {
            Reflexes = new List<Reflex>();

            //Reflex basicWeather = new Reflex(() => GiveCurrentSummary(), "weather");
            //Reflex outlook = new Reflex(() => GiveForecast(), "weather outlook", "how's the forecast look");
            //Reflex weekOutlook = new Reflex(() => GiveWeekSummary(), "how does the weather look this week", "weather for the week");

            //Reflexes = new List<Reflex>() { basicWeather, outlook, weekOutlook };
        }

        #endregion

        #region Reflex Methods

        //public string GiveForecast()
        //{
        //    Dictionary<string, object> values = GatherValues();
        //    return GenerateOutput(Name, "fore_today", values);
        //}

        //public string GiveWeekSummary()
        //{
        //    return Nucleus.Weather.CurrentConditions.WeekSummary;
        //}

        //public string GiveCurrentSummary()
        //{
        //    Dictionary<string, object> values = GatherValues();
        //    return GenerateOutput(Name, "overview", values);
        //}

        #endregion

        #region Misc Methods

        public string GiveWeekSummary(WeatherOutlook conditions)
        {
            List<DailyForecast> forecasts = conditions.DailyForecasts;

            DailyForecast highestHigh = forecasts.MaxOfField(dl => dl.ApparentTemperatureMax);
            double lowestHigh = forecasts.Min(dl => dl.ApparentTemperatureMax);

            double highestLow = forecasts.Max(dl => dl.ApparentTemperatureMin);
            DailyForecast lowestLow = forecasts.MinOfField(dl => dl.ApparentTemperatureMin);

            List<DailyForecast> withPrecip = forecasts.Where(dl => dl.PrecipProbability > 50).ToList();

            string tempSummary = string.Format("I see highs ranging from {0} to {1} degrees over the next seven days with lows from {2} to {3} degrees. ",
                lowestHigh, highestHigh.ApparentTemperatureMax, lowestLow.ApparentTemperatureMin, highestLow);

            string typeOfPrecip = withPrecip.GetNumberOfOccurencesForUniqueFields(fl => fl.PrecipType)
                                            .GetKeyWithLargestValue();

            string daysWithPrecip = withPrecip.Select(day => day.Day.ToString()).MakeIntoEnglishList();
            string precipPortion = string.Format("You can expect {0} on {1} ", typeOfPrecip, daysWithPrecip);

            string worstDays = DateTime.Now.Month > 9 ? string.Format("with the coldest day being {0} on which I see a low of {1} and {2} mile per hour wind speeds",
                                                                lowestLow.Day, lowestLow.ApparentTemperatureMin, lowestLow.WindSpeed)
                                                      : string.Format("with the hottest day being {0} on which I see a high of {1} and {2} percent humidity");

            return tempSummary + precipPortion + worstDays;
        }

        public WeatherOutlook GetCurrentWeather(double lat, double lon)
        {
            string FullURL = FormatBaseURL(Key, lat, lon);

            try
            {
                ShellWeatherResponse shellResponse = InternetUtility.DeserializeResponse<ShellWeatherResponse>(FullURL);
                WeatherOutlook currentConditions = shellResponse.ConvertToWeatherConditions();

                string weekSummary = GiveWeekSummary(currentConditions);
                currentConditions.WeekSummary = weekSummary;

                return currentConditions;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
