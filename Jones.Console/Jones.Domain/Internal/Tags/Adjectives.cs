using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Internal.Tags
{
    public class Adjectives : Attribute
    {
        public string[] Tags { get; set; }

        public Adjectives(params string[] adjs)
        {
            Tags = adjs;
        }
    }
}
