using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain
{
    public class Command
    {
        public string Phrase { get; set; }
        public string Target { get; set; }

        public Command(string phrase, string target)
        {
            Phrase = phrase;
            Target = target;
        }
    }
}
