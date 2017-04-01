using Jones.Domain.Phrases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;

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
            AddTriggers(phrases);
        }

        public Trigger(Phrase phrase) : this()
        {
            AddTriggers(phrase);
        }

        public Trigger(List<Phrase> phrases) : this()
        {
            foreach(Phrase phrase in phrases)
            {
                AddTriggers(phrase);
            }
        }

        #endregion

        public void AddTriggers(params string[] triggers)
        {
            Phrases.AddRange(triggers.AllToLower());
        }

        public void AddTriggers(Phrase phrase)
        {
            var phrases = phrase.GeneratePhrases().AllToLower();
            Phrases.AddRange(phrases);
        }

        public bool IsTriggered(string input)
        {
            return Phrases.Contains(input);
        }

        public abstract string GetResult();
    }
}
