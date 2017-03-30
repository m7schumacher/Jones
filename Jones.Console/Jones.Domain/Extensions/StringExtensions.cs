using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;
using System.Text.RegularExpressions;

namespace Jones.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string TakeLeft(this string input)
        {
            string expression = Constants.Delimeter + @"([^\s]+)";
            return Regex.Replace(input, expression, string.Empty);
        }

        public static string TakeRight(this string input)
        {
            string expression = @"(\s?[^\s]+)" + Constants.Delimeter;
            return Regex.Replace(input, expression, " ");
        }
    }
}
