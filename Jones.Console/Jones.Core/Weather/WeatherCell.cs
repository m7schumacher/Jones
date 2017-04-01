using Jones.API;
using Jones.API.Geography;
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
    public class WeatherResponse
    {
        private string Condition { get; set; }
        private string Value { get; set; }
        private string Units { get; set; }

        public WeatherResponse(string cond, string val, string unit)
        {
            Condition = cond;
            Value = val;
            Units = unit;
        }

        public string Get()
        {
            return string.Format("The current {0} is {1} {2}", Condition, Value, Units);
        }
    }

    public class WeatherCell : Cell
    {
        private WeatherAPI API;
        private CurrentWeather Weather { get; set; }

        private Response BaseResponse;

        public WeatherCell() : base("Weather")
        {
            BaseResponse = new Response("The current {0} is {1}");
        }

        #region Base Methods

        protected override List<Instinct> GenerateInstincts()
        {
            return new List<Instinct>();
        }

        protected override List<Reflex> GenerateReflexes()
        {
            return new List<Reflex>()
            {
                new Reflex(() => GiveCurrentSummary(), "weather"),
                new Reflex(() => GiveCurrentSummary(), PhraseGenerator.HowDoing("weather"))
            };

            //Reflex outlook = new Reflex(() => GiveForecast(), "weather outlook", "how's the forecast look");
            //Reflex weekOutlook = new Reflex(() => GiveWeekSummary(), "how does the weather look this week", "weather for the week");

            //Reflexes = new List<Reflex>() { basicWeather, outlook, weekOutlook };
        }

        protected override List<string> GeneratePrefixes()
        {
            return new List<string>()
            {
                "There is currently",
                "The current"
            };
        }

        protected override object[] SetEntities()
        {
            return new object[] { Weather };
        }

        protected override void Initialize()
        {
            API = new WeatherAPI();
        }

        protected override void Update()
        {
            Weather = API.GetCurrentWeather(Data.Geo.FARGO_LATITUDE, Data.Geo.FARGO_LONGITUDE);
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

        public string GiveCurrentSummary()
        {
            var weather = Weather;

            string template = "It is currently 'Temperature' degrees outside with a 'WindSpeed' mile per hour wind coming from the 'WindDirection'";

            return ResponseGenerator.GenerateResponse(template, weather.Currently);

            //Dictionary<string, object> values = GatherValues();
            //return GenerateOutput(Name, "overview", values);
        }

        #endregion
    }
}
