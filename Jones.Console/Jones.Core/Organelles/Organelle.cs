using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Cells.Organelles
{
    public abstract class Organelle
    {
        protected string Name { get; set; }
        protected Pool Pool { get; set; }

        public Organelle(string name, Pool pool)
        {
            Name = name;
            Pool = pool;

            Initialize();
        }

        protected abstract void Initialize();
    }
}
