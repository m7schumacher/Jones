using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jones.Domain
{
    public enum CommandType
    {
        Adjective,
        Noun
    }
    
    public class Command
    {
        public string Phrase { get; set; }

        public bool IsQuestion { get; set; }
        public CommandType Type { get; set; }

        public Command(string phrase)
        {
            IsQuestion = DetermineIfQuestion(phrase);
            Type = phrase.StartsWith("how") ? CommandType.Adjective : CommandType.Noun;
        }

        private bool DetermineIfQuestion(string phrase)
        {
            Regex expression = new Regex(Data.Language.Questioners);
            return expression.IsMatch(phrase);
        }
    }
}
