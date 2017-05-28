using Jones.Domain.Phrases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Swiss;

namespace Jones.Domain.Internal.Tags
{
    public class ReflexMethod : Attribute
    {
        public string[] Phrases { get; set; }

        public ReflexMethod(Phrase phrase)
        {
            Phrases = phrase.GeneratePhrases().ToArray();
        }

        public ReflexMethod(params string[] commands)
        {
            List<string> phrases = new List<string>();

            foreach (string command in commands)
            {
                if (command.StartsWith(Constants.PhraseIdentifier))
                {
                    string method = command.Split('(')
                                           .First()
                                           .Remove(Constants.PhraseIdentifier);

                    string[] parameters = command.GetAllTextInSingleQuotes()
                                                 .First()
                                                 .SplitOnWhiteSpace();

                    var methods = typeof(PhraseGenerator).GetMethods();
                    MethodInfo meth = methods.First(mth => mth.Name.Equals(method));
                    Phrase phrase = (Phrase)meth.Invoke(null, new object[] { parameters });

                    phrases.AddRange(phrase.GeneratePhrases());
                }
                else
                {
                    phrases.Add(command);
                }
            }

            Phrases = phrases.ToArray();
        }
    }
}
