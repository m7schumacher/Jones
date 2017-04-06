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
        public static TagCollection GetTags(this object obj, string prefix = "")
        {
            return obj.GetType().GetTags(prefix);
        }

        public static TagCollection GetTags(this Type type, string prefix = "")
        {
            TagCollection result = new TagCollection(type.Name);

            string propPath;
            string[] adjs;

            if(prefix.Length > 0)
            {
                prefix = prefix + Constants.Delimeter;
            }

            foreach(PropertyInfo prop in type.GetProperties())
            {
                propPath = prefix + prop.Name;

                if(prop.PropertyType.Namespace.Equals("System"))
                {
                    adjs = prop.GetAdjectives();

                    if(adjs.Length > 0)
                    {
                        result.Tags.Add(new Tag(propPath) { Adjectives = adjs });
                    }
                }
                else
                {
                    result.Combine(prop.PropertyType.GetTags(propPath));
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
