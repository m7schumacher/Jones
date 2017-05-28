using Jones.Domain.Internal.Tags;
using Jones.Domain.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Organelles
{
    public abstract class ReflexPool
    {
        private List<Reflex> Reflexes { get; set; }

        public ReflexPool()
        {
            Reflexes = this.GetType().GetMethods()
                                     .Where(mth => mth.CustomAttributes.Any(cst => cst.AttributeType == typeof(ReflexMethod)))
                                     .Select(mth => new Reflex(mth, mth.GetCustomAttribute<ReflexMethod>().Phrases))
                                     .ToList();
        }

        public List<string> GetPhrases()
        {
            return Reflexes.SelectMany(refl => refl.Phrases).ToList();
        }

        internal string Execute(string phrase)
        {
            Reflex reflex = Reflexes.FirstOrDefault(flex => flex.IsTriggered(phrase));
            return reflex != null ? reflex.GetResult() : string.Empty;
        }
    }
}