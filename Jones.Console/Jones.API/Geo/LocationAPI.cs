using Jones.Domain.External.Geographical;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.API.Geography
{
    #region Shell Classes

    public class ShellGeoLocation
    {
        public string status { get; set; }
        public results[] results { get; set; }

        public Location GenerateGeoLocation()
        {
            results targetResult = results[0];

            LatAndLong latLong = new LatAndLong()
            {
                Lat = targetResult.geometry.location.lat,
                Long = targetResult.geometry.location.lng
            };

            return new Location()
            {
                ZipCode = targetResult.address_components[0].long_name,
                City = targetResult.address_components[1].long_name,
                County = targetResult.address_components[2].long_name,
                State = targetResult.address_components[3].short_name,
                Country = targetResult.address_components[4].long_name,
                LatAndLong = latLong,
            };
        }
    }

    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
        public address_component[] address_components { get; set; }
    }

    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    public class RootObject
    {
        public int dstOffset { get; set; }
        public int rawOffset { get; set; }
        public string status { get; set; }
        public string timeZoneId { get; set; }
        public string timeZoneName { get; set; }
    }

    internal struct ShellTimeZone
    {

    }

    public class GeographicCoordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public GeographicCoordinates()
        {
            Latitude = string.Empty;
            Longitude = string.Empty;
        }
    }

    #endregion

    public class LocationAPI : API
    {
        private string CityStateURL = "http://ziptasticapi.com/{0}";
        private string LatLongURL = "http://maps.googleapis.com/maps/api/geocode/json?address={0}";
        private string TimeZoneURL = "https://maps.googleapis.com/maps/api/timezone/json?location={0},{1}&timestamp=1458000000";

        public Location GetLocation(string zip)
        {
            ShellGeoLocation shell = GenerateLocation(zip);

            try
            {
                Location location = shell.GenerateGeoLocation();

                TimeZoneInfo timeZone = GetTimeZone(location.LatAndLong);

                location.SetTimeZone(timeZone);

                return location;
            }
            catch (Exception e)
            {
                return new Location();
            }
        }

        internal ShellGeoLocation GenerateLocation(string zip)
        {
            string fullURL = string.Format(LatLongURL, zip);
            var result = Deserialize<ShellGeoLocation>(fullURL);

            return result;
        }

        private TimeZoneInfo GetTimeZone(LatAndLong latAndLong)
        {
            var lat = latAndLong.Lat;
            var lon = latAndLong.Long;

            string fullURL = string.Format(TimeZoneURL, lat, lon);

            string json = InternetUtility.MakeWebRequest(fullURL);

            RootObject shellZone = Deserialize<RootObject>(fullURL);
            string timeZoneId = shellZone.timeZoneName.Replace("Daylight", "Standard");

            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
    }
}
