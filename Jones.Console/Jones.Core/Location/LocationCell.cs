using Jones.API.Geography;
using Swiss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Location
{
    public class LocationCell : Cell
    {
        private const string MAP_URL = "http://maps.google.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
        LocationAPI API;

        public Dictionary<string, string> StoredAddresses { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime LocalTime { get; set; }

        public LocationCell() : base("Location")
        {
            API = new LocationAPI();
            Enabled = false;
        }

        protected override void Initialize()
        {
            StoredAddresses = new Dictionary<string, string>()
            {
                { "home", "4822 Meadow Creek Drive, Fargo ND, 58104" },
                { "apartment", "1900 Dakota Drive North, Fargo ND, 58102" },
                { "work", "501 4th Street North, Fargo ND, 58102" }
            };
        }

        //protected override void Update()
        //{
        //    var location = API.GetLocation(Data.Geo.FARGO_ZIPCODE);

        //    Longitude = location.LatAndLong != null ? location.LatAndLong.Long.ToDouble() : Data.Geo.FARGO_LONGITUDE;
        //    Latitude = location.LatAndLong != null ? location.LatAndLong.Lat.ToDouble() : Data.Geo.FARGO_LATITUDE;

        //    City = location.City;
        //    State = location.State;
        //    ZipCode = location.ZipCode;
        //    Address = Data.Geo.CURRENT_ADDRESS;
        //    LocalTime = location.LocalTime;
        //}
    }
}
