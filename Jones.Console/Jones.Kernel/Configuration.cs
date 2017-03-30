using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jones.Core
{
    public class Configuration
    {
        public bool isLocal { get; set; }
        public bool isSpotifyOpen { get; set; }
        public bool IsPlayingSpotify { get; set; }

        public bool isAwake { get; set; }
        public bool isUsingKinect { get; set; }
        public bool isInDashMode { get; set; }

        public bool isQuiet { get; set; }
        public bool isDreaming { get; set; }
        public bool isLearning { get; set; }
        public bool isSpeaking { get; set; }

        public bool IsConnectedToInternet { get; set; }
        public bool IsConnectedToSpotify { get; set; }

        public Configuration(bool dreaming)
        {
            isLocal = true;
            InitializeValues(dreaming);
        }

        public void InitializeValues(bool dreaming = false)
        {
            isQuiet = false;
            isDreaming = dreaming;
            isLearning = false;

            isAwake = true;

            isInDashMode = false;
            isSpotifyOpen = false;
            isUsingKinect = false;
            IsPlayingSpotify = false;
            IsConnectedToInternet = false;
            IsConnectedToSpotify = false;
            isLocal = true;

            Task tsk = Task.Factory.StartNew(() =>
            {
                UpdateValues();
                Thread.Sleep(60000);
            });
        }

        private void UpdateValues()
        {
            IsConnectedToInternet = InternetUtility.CheckForInternetConnection();
        }
    }
}
