using Jones.Domain;
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

        protected int CyclesPerUpdate { get; set; }
        private int CyclesSinceLastUpdate { get; set; }

        protected int FailuresBeforeQuit { get; set; }

        protected int RefreshHour { get; set; }
        protected int RefreshMinute { get; set; }

        public Monitor(string name, Pool pool) : base(name, pool)
        {
            SetRefresh(3, 0);
            SetMinutesToUpdate(1);
        }

        protected void SetRefresh(int hour, int minute)
        {
            RefreshHour = hour;
            RefreshMinute = minute;
        }

        protected void SetMinutesToUpdate(int minutes)
        {
            CyclesPerUpdate = minutes * (60 / Constants.SecondsPerCycle);
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
            CyclesSinceLastUpdate++;
            List<Notice> notifications = new List<Notice>();

            if (CyclesPerUpdate == CyclesSinceLastUpdate)
            {
                try
                {
                    CyclesSinceLastUpdate = 0;
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
