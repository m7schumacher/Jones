using Jones.Domain.Internal;
using Jones.Domain.Internal.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Organelles
{
    public abstract class Monitor : Organelle
    {
        private int MinutesBetweenUpdates { get; set; }
        private bool SendingNotifications { get; set; }
        private int ConsecutiveFailures { get; set; }

        public int MinutesToUpdate { get; set; }
        public int MinutesSinceLastUpdate { get; set; }

        public int FailuresBeforeQuit { get; set; }

        public int RefreshHour { get; set; }
        public int RefreshMinute { get; set; }

        public bool IsFast { get; set; }

        public Monitor(string name, Pool pool) : base(name, pool)
        {
            SetRefresh(3, 0);
            IsFast = false;
        }

        protected void SetRefresh(int hour, int minute)
        {
            RefreshHour = hour;
            RefreshMinute = minute;
        }

        protected abstract List<Notice> GatherNotifications();
        protected abstract void Refresh();

        public void ManualUpdate()
        {
            SendingNotifications = false;
            Update();
            Refresh();
            SendingNotifications = true;
        }

        private bool ShouldRefresh()
        {
            return DateTime.Now.Hour == RefreshHour && DateTime.Now.Minute == RefreshMinute;
        }

        public List<Notice> Update()
        {
            MinutesSinceLastUpdate++;
            List<Notice> notifications = new List<Notice>();

            if (MinutesToUpdate == MinutesSinceLastUpdate)
            {
                try
                {
                    MinutesSinceLastUpdate = 0;
                    Pool.Update();

                    ConsecutiveFailures = 0;

                    if (SendingNotifications)
                    {
                        notifications = GatherNotifications();
                    }

                    if (ShouldRefresh())
                    {
                        Refresh();
                        Console.WriteLine(Name + " was refreshed");
                    }
                }
                catch (Exception trouble)
                {
                    ConsecutiveFailures++;

                    if (ConsecutiveFailures == 4)
                    {
                        string message = string.Format("{0} monitoring has failed {1} consecutive times... Stopping monitoring.", Name, FailuresBeforeQuit.ToString());
                        //Notification.Send(message);
                    }
                }
            }

            return notifications;
        }
    }
}
