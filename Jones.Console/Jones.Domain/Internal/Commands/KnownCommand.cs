using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Swiss;

namespace Jones.Domain
{
    public class KnownCommand
    {
        public string Phrase { get; set; }
        public string Target { get; set; }

        public KnownCommand(string phrase, string target)
        {
            Phrase = phrase.ToLower();
            Target = target;
        }
    }
}
