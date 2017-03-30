using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;

namespace Jones.Domain.Extensions
{
    public static class EnumerableExtensions
    {
        public static string[] TakeAllLeft(this IEnumerable<string> inputs)
        {
            return inputs.JoinOnDelimeter("~")
                         .TakeLeft()
                         .Split("~");
        }

        public static string[] TakeAllRight(this IEnumerable<string> inputs)
        {
            return inputs.JoinOnDelimeter("~")
                         .TakeRight()
                         .Split("~");
        }
    }
}
