using Jones.Cells.Organelles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jones.Domain.Triggers;
using Jones.Domain.Phrases;

namespace Jones.Cells.Weather
{
    public class WeatherGate : Gate
    {
        public WeatherGate(string name, Pool pool) : base(name, pool)
        {

        }

        protected override List<string> GenerateCustomPrefixes()
        {
            return new List<string>()
            {
                "There is currently",
                "The current"
            };
        }

        protected override List<Instinct> GenerateInstincts()
        {
            return new List<Instinct>();
        }

        protected override ReflexPool GenerateReflexes()
        {
            return new WeatherReflexPool();
        }

        protected override List<Response> GenerateResponses()
        {
            return new List<Response>();
        }

        #region Reflex Methods

        

        #endregion
    }
}
