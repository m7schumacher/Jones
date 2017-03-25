using Jones.Domain.Commands;
using Swiss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Triggers
{
    public class Instinct : Trigger
    {
        public string Result { get; set; }

        public Instinct()
        {
            Result = string.Empty;
        }

        public Instinct(string result)
        {
            Result = result;
        }

        public Instinct(string result, params string[] bits) : base(bits)
        {
            Result = result;
        }

        public override string GetResult()
        {
            return Result;
        }
    }
}
