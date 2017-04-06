using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Data
{
    public class Geo
    {
        public static double FARGO_LONGITUDE = -96.7898;
        public static double FARGO_LATITUDE = 46.8772;

        public static string FARGO_ZIPCODE = "58104";
        public static string CURRENT_ADDRESS = "5301 27th street south fargo";
    }

    public class Weather
    {
        public enum Direction
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        };

        public enum PrecipType
        {
            Rain,
            Snow,
            Sleet,
            None
        }

        public enum PrecipIntensity
        {
            VeryLight,
            Light,
            Moderate,
            Heavy,
            None
        }
    }

    public class Language
    {
        public static string Questioners = "^who|^is|^what|^when|^where|^why|^how|[?]";
        public static string[] AdjectiveTargets = new string[] { "how" }; 
    }
}
