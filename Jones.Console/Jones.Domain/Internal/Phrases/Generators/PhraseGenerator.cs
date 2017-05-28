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
        private static string[] Functions { get; set; }

        public static string[] Methods()
        {
            return Functions ?? typeof(PhraseGenerator).GetMethods()
                                          .Where(mth => mth.IsPublic && mth.IsStatic)
                                          .Select(mth => mth.Name)
                                          .ToArray();
        }

        #region How Doing

        private static SimplePhrase HowDoing(string[] phrases, string[] subjects)
        {
            SimplePhrase command = new SimplePhrase(phrases);
            command.AddTerms(subjects);

            return command;
        }

        public static SimplePhrase HowDoingPlural(params string[] subjects)
        {
            string[] commands = BasePhrases.HowDoing.TakeAllRight();
            return HowDoing(commands, subjects);
        }

        public static SimplePhrase HowDoingSingle(params string[] subjects)
        {
            string[] commands = BasePhrases.HowDoing.TakeAllLeft();
            return HowDoing(commands, subjects);
        }

        public static SimplePhrase HowDoing(string subject, bool plural = false)
        {
            return plural ? HowDoingPlural(subject) : HowDoingSingle(subject);
        }

        public static SimplePhrase HowDoing(bool plural = false, params string[] subjects)
        {
            return plural ? HowDoingPlural(subjects) : HowDoingSingle(subjects);
        }

        #endregion
    }
}
