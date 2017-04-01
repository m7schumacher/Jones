using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.External.Geographical
{
    public class Location
    {
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public LatAndLong LatAndLong { get; set; }
        public DateTime LocalTime { get; set; }

        public Location()
        {

        }

        public Location(LatAndLong latlon, TimeZoneInfo timezone)
        {
            LatAndLong = latlon;
            LocalTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timezone.Id);
        }

        public Location(string city, string state, string zip, LatAndLong coordinates, TimeZoneInfo timezone)
            : this(coordinates, timezone)
        {
            City = city;
            State = state;
            ZipCode = zip;
        }

        public void SetTimeZone(TimeZoneInfo timezone)
        {
            LocalTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timezone.Id);
        }
    }
}
