using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;

namespace Jones.Domain.Phrases
{
    public abstract class Phrase
    {
        protected List<string> Phrases { get; set; }

        public Phrase(params string[] phrases)
        {
            Phrases = phrases.ToList();
        }

        public abstract List<string> GeneratePhrases();

        public string ToReflex()
        {
            return GeneratePhrases().JoinOnDelimeter(Constants.PhraseIdentifier);
        }
    }
}
