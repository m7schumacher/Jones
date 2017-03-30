using Jones.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Triggers
{
    public abstract class Trigger
    {
        public List<string> Phrases { get; set; }

        #region Constructors

        public Trigger()
        {
            Phrases = new List<string>();
        }

        public Trigger(params string[] phrases) : this()
        {
            Phrases = phrases.ToList();
        }

        public Trigger(BasicCommand command) : this()
        {
            Phrases = command.GetCommands();
        }

        public Trigger(List<BasicCommand> commands) : this()
        {
            foreach(BasicCommand command in commands)
            {
                Phrases.AddRange(command.GetCommands());
            }
        }

        #endregion

        public void AddTriggers(params string[] triggers)
        {
            Phrases.AddRange(triggers);
        }

        public void AddTriggers(BasicCommand command)
        {
            Phrases.AddRange(command.GetCommands());
        }

        public bool IsTriggered(string input)
        {
            return Phrases.Contains(input);
        }

        public abstract string GetResult();
    }
}
