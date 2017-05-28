using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jones.Domain
{
    public static class Configuration
    {
        public static bool isLocal { get; set; }
        

        public static bool isUsingKinect { get; set; }

        public static bool IsSpeaking { get; set; }
        public static bool IsListening { get; set; }
        public static bool IsWatching { get; set; }
        public static bool IsSending { get; set; }

        public static bool isDreaming { get; set; }
        public static bool isLearning { get; set; }

        public static void InitializeDefaultConfiguration(bool dreaming = false)
        {
            IsSpeaking = true;
            isDreaming = dreaming;
            isLearning = false;
            isUsingKinect = false;


            isLocal = true;

            
        }

        
    }
}
