using Jones.Domain.Triggers;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Core
{
    public class Core
    {
        protected string BaseURL { get; set; }

        private string Name { get; set; }
        private int MinutesBetweenUpdates { get; set; }

        public List<Instinct> Instincts { get; set; }
        public List<Reflex> Reflexes { get; set; }
        public List<Response> Responses { get; set; }

        protected Dictionary<string, string> Values { get; set; }

        public Core()
        {
            GenerateInstincts();
            GenerateReflexes();
            GenerateResponses();

            PopulateValues();
        }

        protected virtual void GenerateInstincts() { Instincts = new List<Instinct>(); }
        protected virtual void GenerateReflexes() { Reflexes = new List<Reflex>(); }
        protected virtual void GenerateResponses() { Responses = new List<Response>(); }

        protected virtual void PopulateValues() { Values = new Dictionary<string, string>(); }

        protected virtual void InitializeValues() { }
        protected virtual void Refresh() { }

        #region API Methods

        protected string FormatBaseURL(params object[] args)
        {
            return string.Format(BaseURL, args);
        }

        public static T Deserialize<T>(string url)
        {
            try
            {
                return InternetUtility.DeserializeResponse<T>(url);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public static T SafelyMakeAPICall<T>(Func<T> method)
        {
            try
            {
                var response = method();
                return response;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        #endregion

        #region Monitor Methods

        #region Notification Methods

        protected virtual void SendNotifications() { }

        //protected void RefreshNotifications()
        //{
        //    foreach (var notification in this.GetType().GetProperties().Where(prop => prop.PropertyType == typeof(Notification)))
        //    {
        //        notification.SetValue("Active", true);
        //    }
        //}

        #endregion

        #region Update Methods

        protected virtual void Update() { }

        //public void ManualUpdate()
        //{
        //    SendingNotifications = false;
        //    Update();
        //    Refresh();
        //    SendingNotifications = true;
        //}

        //public void UpdateData()
        //{
        //    UpdatesMade++;

        //    if (TimeToUpdate == UpdatesMade)
        //    {
        //        try
        //        {
        //            UpdatesMade = 0;
        //            Update();

        //            ConsecutiveFailures = 0;

        //            if (SendingNotifications)
        //            {
        //                SendNotifications();
        //            }

        //            if (Nucleus.Time.Date.Hour == RefreshHour && Nucleus.Time.Date.Minute == RefreshMinute)
        //            {
        //                Refresh();
        //                Console.WriteLine(Name + " was refreshed");
        //            }
        //        }
        //        catch (Exception trouble)
        //        {
        //            ConsecutiveFailures++;

        //            if (ConsecutiveFailures == 4)
        //            {
        //                string message = string.Format("{0} monitoring has failed {1} consecutive times... Stopping monitoring.", Name, FailuresBeforeQuit.ToString());
        //                Notification.Send(message);
        //            }
        //        }
        //    }
        //}


        #endregion

        #endregion
    }
}
