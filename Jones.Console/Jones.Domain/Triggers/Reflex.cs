using Swiss.Utilities.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Triggers
{
    public class Reflex : Trigger
    {
        Func<string> Method { get; set; }

        public Reflex(Func<string> method, params string[] bits) : base(bits)
        {
            Method = method;
        }

        public override string GetResult()
        {
            return Method.Invoke();
        }
    }
}
