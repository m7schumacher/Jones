using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jones.Domain
{
    public static class Senses
    {
        private static Timer LookOut { get; set; }

        public static Data.State.TimeOfDay TimeOfDay { get; set; }
        public static Data.State.Temperature Temperature { get; set; }

        public static bool IsConnectedToInternet { get; set; }
        public static bool IsConnectedToSpotify { get; set; }

        public static bool isSpotifyOpen { get; set; }
        public static bool IsPlayingSpotify { get; set; }

        public static void AnalyzeEnvironment()
        {
            isSpotifyOpen = false;
            IsPlayingSpotify = false;
            IsConnectedToInternet = false;
            IsConnectedToSpotify = false;

            Task tsk = Task.Factory.StartNew(() =>
            {
                UpdateValues();
                Thread.Sleep(60000);
            });
        }

        private static void UpdateValues()
        {
            IsConnectedToInternet = InternetUtility.CheckForInternetConnection();
        }
    }
}
