using Swiss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Internal.Notifications
{
    public class Notice
    {
        public NotificationType Type { get; set; }

        public string Message { get; set; }
        public DateTime TimeOfInjection { get; set; }

        public int MinutesToPend { get; set; }
        public int MinutesPending { get { return (DateTime.Now - TimeOfInjection).TotalMinutes.ToInt(); } }

        public Notice(string message)
        {
            Message = message;
            TimeOfInjection = DateTime.Now;
        }

        public bool ShouldSend()
        {
            return MinutesPending >= MinutesToPend || Type == NotificationType.Send;
        }
    }
}
