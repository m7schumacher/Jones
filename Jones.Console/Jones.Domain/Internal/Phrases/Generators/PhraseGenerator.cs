using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jones.Domain.Extensions;
using Swiss;

namespace Jones.Domain.Phrases
{
    public class PhraseGenerator
    {
        public static SimplePhrase HowDoing(string subject, bool plural = false)
        {
            string[] commands = plural ? BasePhrases.HowDoing.TakeAllRight()
                                       : BasePhrases.HowDoing.TakeAllLeft();

            commands = commands.Select(str => string.Format(str, subject)).ToArray();

            return new SimplePhrase(commands);
        }

        public static SimplePhrase HowDoing(bool plural = false, params string[] subjects)
        {
            string[] commands = plural ? BasePhrases.HowDoing.TakeAllRight()
                                       : BasePhrases.HowDoing.TakeAllLeft();

            SimplePhrase command = new SimplePhrase(commands);
            command.AddTerms(subjects);

            return command;
        }
    }
}
