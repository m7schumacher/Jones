using Jones.Domain;
using Jones.Domain.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Organelles
{
    public abstract class Gate : Organelle
    {
        public ReflexPool Reflexes { get; set; }

        public List<Instinct> Instincts { get; set; }
        public List<Response> Responses { get; set; }

        protected List<string> Prefixes { get; set; }

        public Gate(string name, Pool pool) : base(name, pool)
        {

        }

        protected override void Initialize()
        {
            Instincts = GenerateInstincts();
            Responses = GenerateResponses();
            Reflexes = GenerateReflexes();
            Prefixes = GenerateCustomPrefixes();
        }

        protected abstract List<Instinct> GenerateInstincts();
        protected abstract ReflexPool GenerateReflexes();
        protected abstract List<Response> GenerateResponses();
        protected abstract List<string> GenerateCustomPrefixes();

        public string DirectCommand(Command input)
        {
            Instinct matchingInstinct = Instincts.FirstOrDefault(ins => ins.IsTriggered(input.Phrase));

            if (matchingInstinct != null)
            {
                return matchingInstinct.GetResult();
            }

            return Reflexes.Execute(input.Phrase);
        }

        public List<KnownCommand> GetCommands()
        {
            List<string> phrases = new List<string>();
            phrases.AddRange(Instincts.SelectMany(inst => inst.Phrases));
            phrases.AddRange(Reflexes.GetPhrases());
            phrases.AddRange(Pool.GatherEntityPhrases());

            return phrases.Select(phrase => new KnownCommand(phrase, Name)).ToList();
        }
    }
}
