using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jones.Domain.Internal;
using Jones.Cells.Organelles;
using Jones.Domain.Internal.Notifications;

namespace Jones.Cells.Weather
{
    public class WeatherMonitor : Monitor
    {
        public WeatherMonitor(string name, Pool pool) : base(name, pool)
        {

        }

        protected override List<Notice> GatherNotifications()
        {
            throw new NotImplementedException();
        }

        protected override void Initialize()
        {
            
        }

        protected override void Refresh()
        {
            
        }
    }
}
