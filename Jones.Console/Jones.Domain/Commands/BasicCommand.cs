using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Commands
{
    public class BasicCommand : Command
    {
        List<string[]> TermSets { get; set; }
        int NumberOfSets { get { return TermSets.Count; } }

        public BasicCommand(params string[] phrases) : base(phrases)
        {
            TermSets = new List<string[]>();
        }

        public void AddTerms(params string[] terms)
        {
            TermSets.Add(terms);
        }

        private List<string[]> GetPerms(string start)
        {
            List<string[]> perms = new List<string[]>();

            foreach(var set in TermSets)
            {
                perms.Add(new string[] { start, set.Last() });
            }

            return perms;
        }

        private List<string[]> GeneratePermutations()
        {
            List<string[]> permutations = new List<string[]>();

            foreach(var set in TermSets)
            {
                permutations.AddRange(GetPerms(set.First()));
            }

            return permutations;
        }

        public override List<string> GetCommands()
        {
            List<string> commands = new List<string>();
            List<string[]> permutations = GeneratePermutations();

            foreach (string phrase in Phrases)
            {
                foreach (string[] permutation in permutations)
                {
                    commands.Add(string.Format(phrase, permutation));
                }
            }

            return commands;
        }
    }
}
