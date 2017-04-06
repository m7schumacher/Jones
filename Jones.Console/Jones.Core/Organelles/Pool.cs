using Jones.Domain.Internal.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Organelles
{
    public abstract class Pool
    {
        public object[] Entities { get; set; }
        protected Dictionary<string, string> Values { get; set; }

        protected void Initialize()
        {
            Entities = SetEntities();
            Values = new Dictionary<string, string>();
        }

        public abstract void Update();
        protected abstract object[] SetEntities();

        public List<string> GatherEntityPhrases()
        {
            return new List<string>();
        }
    }
}
