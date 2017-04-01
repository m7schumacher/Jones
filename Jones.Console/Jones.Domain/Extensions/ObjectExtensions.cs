using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Swiss;
using Jones.Domain.Internal.Tags;

namespace Jones.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, string[]> GetTags(this object obj, string prefix = "")
        {
            return obj.GetType().GetTags(prefix);
        }

        public static Dictionary<string, string[]> GetTags(this Type type, string prefix = "")
        {
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            string propName;

            if(prefix.Length > 0)
            {
                prefix = prefix + Constants.Delimeter;
            }

            foreach(PropertyInfo prop in type.GetProperties())
            {
                propName = prefix + prop.Name;

                if(prop.PropertyType.Namespace.Equals("System"))
                {
                    result.Add(propName, prop.GetAdjectives());
                }
                else
                {
                    result.AddRange(prop.PropertyType.GetTags(propName));
                }
            }

            return result;
        }

        public static string[] GetAdjectives(this PropertyInfo prop)
        {
            Adjectives adjs = prop.GetCustomAttribute<Adjectives>();
            return adjs != null ? adjs.Tags : new string[0];
        }

        public static string GetValueFromChain(this object obj, string chain)
        {
            string[] bits = chain.Split(Constants.Delimeter);
            return string.Empty;
        }
    }
}
