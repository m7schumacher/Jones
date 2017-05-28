using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Phrases
{
    public class SimplePhrase : Phrase
    {
        List<string> Terms { get; set; }

        public SimplePhrase(params string[] phrases) : base(phrases)
        {
            Terms = new List<string>();
        }

        public void AddTerms(params string[] terms)
        {
            Terms.AddRange(terms);
        }

        public override List<string> GeneratePhrases()
        {
            List<string> phrs = new List<string>();

            if (Terms.Count > 0)
            {
                foreach (var phrase in Phrases)
                {
                    foreach (var term in Terms)
                    {
                        phrs.Add(string.Format(phrase, term));
                    }
                }
            }
            else
            {
                phrs = Phrases;
            }

            return phrs;
        }
    }
}
