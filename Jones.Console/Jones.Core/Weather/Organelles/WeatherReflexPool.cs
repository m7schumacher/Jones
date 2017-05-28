using Jones.Cells.Organelles;
using Jones.Domain.Internal.Tags;
using Jones.Domain.Phrases;

namespace Jones.Cells.Weather
{
    internal class WeatherReflexPool : ReflexPool
    {
        [ReflexMethod("-HowDoingSingle('weather')", "weather")]
        public string GiveCurrentSummary()
        {
            return "Test Summary";
            //Dictionary<string, object> values = GatherValues();
            //return GenerateOutput(Name, "overview", values);
        }
    }
}