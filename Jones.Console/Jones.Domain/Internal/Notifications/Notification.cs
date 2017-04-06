using Jones.Domain.Internal.Notifications;
using Swiss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Internal
{
    public enum NotificationType
    {
         Send,
         Speak
    }

    public class Notification
    {
        public NotificationType Type { get; set; }
        public string Message { get; set; }

        public int MinutesToPend { get; set; }
        public int StartOfWindow { get; set; }
        public int EndOfWindow { get; set; }

        public Notification(string message)
        {
            Message = message;
            Type = NotificationType.Speak;
        }

        public Notification SendAfter(int minutes)
        {
            MinutesToPend = minutes;
            return this;
        }

        public Notification OnlyBetween(int start, int end)
        {
            StartOfWindow = start;
            EndOfWindow = end;

            return this;
        }

        public Notification OnlySend()
        {
            Type = NotificationType.Send;
            return this;
        }

        public Notification Say(string message)
        {
            Message = message;
            return this;
        }

        private bool ShouldInject()
        {
            return DateTime.Now.Hour.IsBetween(StartOfWindow, EndOfWindow, true);
        }

        public Notice Inject()
        {
            Notice notice = null;

            if(ShouldInject())
            {
                notice = new Notice(Message)
                {
                    Type = this.Type,
                    MinutesToPend = this.MinutesToPend
                };
            }

            return notice;      
        }
    }
}
