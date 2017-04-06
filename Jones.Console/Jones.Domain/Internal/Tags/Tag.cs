using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Internal.Tags
{
    public class Tag
    {
        public string Path { get; private set; }
        public string[] Adjectives { get; set; }

        public Tag(string path)
        {
            Path = path;
            Adjectives = new string[0];
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Path, Adjectives.Length);
        }
    }
}
