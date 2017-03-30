using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Commands
{
    public class BaseCommands
    {
        public static string[] HowDoing = new string[]
        {
            "How is:are the {0}",
            "How is:are the {0} doing",
            "Update on the {0}",
            "How does:do the {0} look"
        };
    }
}
