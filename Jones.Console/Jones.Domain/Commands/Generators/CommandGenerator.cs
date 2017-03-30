using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jones.Domain.Extensions;

namespace Jones.Domain.Commands
{
    public class CommandGenerator
    {
        public static BasicCommand HowDoing(string subject, bool plural = false)
        {
            string[] commands = plural ? BaseCommands.HowDoing.TakeAllRight()
                                       : BaseCommands.HowDoing.TakeAllLeft();

            commands = commands.Select(str => string.Format(str, subject)).ToArray();

            return new BasicCommand(commands);
        }

        public static BasicCommand HowDoing(bool plural = false, params string[] subjects)
        {
            string[] commands = plural ? BaseCommands.HowDoing.TakeAllRight()
                                       : BaseCommands.HowDoing.TakeAllLeft();

            BasicCommand command = new BasicCommand(commands);
            command.AddTerms(subjects);

            return command;
        }
    }
}
