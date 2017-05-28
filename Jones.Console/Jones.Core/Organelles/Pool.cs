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

        protected Pool()
        {
            Values = new Dictionary<string, string>();

            Initialize();
            Update();

            Entities = SetEntities();
        }

        public abstract void Update();
        protected abstract object[] SetEntities();
        protected abstract void Initialize();

        public List<string> GatherEntityPhrases()
        {
            return new List<string>();
        }
    }
}
