using Jones.Domain;
using Jones.Domain.Triggers;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;
using Jones.Domain.Internal;
using Jones.Cells.Organelles;
using Jones.Domain.Internal.Notifications;

namespace Jones.Cells
{
    public abstract class Cell
    {
        public string Name { get; private set; }

        public Monitor Monitor { get; set; }
        public Gate Gate { get; set; }
        public Pool Pool { get; set; }

        public bool Enabled { get; set; }

        public Cell()
        {
            Initialize();
            Enabled = true;
        }

        public Cell(string name) : this()
        {
            Name = name;
        }

        public virtual string Execute(Command input)
        {
            return Gate.DirectCommand(input);
        }

        public virtual List<Notice> GatherNotifications()
        {
            return Monitor.Update()
                          .WhereNotNull()
                          .ToList();
        }

        public virtual List<KnownCommand> GatherCommands()
        {
            return Gate.GetCommands();
        }

        protected abstract void Initialize();
    }
}
