using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Swiss;

namespace Jones.Domain.Internal
{
    public class ResponseGenerator
    {
        public static string GenerateResponse(string template, object obj)
        {
            string[] quotes = template.GetAllTextInSingleQuotes();
            string value;

            foreach(string prop in quotes)
            {
                value = obj.GetProperty(prop).ToString();
                template = template.Replace("'" + prop + "'", value);
            }

            return template;
        }
    }
}
