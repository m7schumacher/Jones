using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Triggers
{
    public class Response : Trigger
    {
        private string Spec { get; set; }

        public Response(string spec, params string[] bits) : base(bits)
        {
            Spec = spec;
        }

        public override string GetResult()
        {
            return Spec;
        }
    }
}
