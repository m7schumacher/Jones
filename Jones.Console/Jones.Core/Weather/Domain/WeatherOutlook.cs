using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Core.Weather.Domain
{
    public class WeatherOutlook
    {
        public CurrentCondition Currently { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }

        public string WeekSummary { get; set; }
    }
}
