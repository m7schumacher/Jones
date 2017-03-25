using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Commands
{
    public abstract class Command
    {
        protected List<string> Phrases { get; set; }

        public Command(params string[] phrases)
        {
            Phrases = phrases.ToList();
        }

        public abstract List<string> GetCommands();
    }
}
