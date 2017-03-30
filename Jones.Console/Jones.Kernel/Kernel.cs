using Jones.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Core
{
    public class Kernel
    {
        public static Configuration Configuration { get; set; }
        public WeatherCore Weather { get; set; }

        public void Initialize(bool dreaming = false)
        {
            Configuration = new Configuration(dreaming);
            List<Core> blocks = InitializeCores();
        }

        private List<Core> InitializeCores()
        {
            return this.GetType()
                       .GetProperties()
                       .Where(prop => prop.PropertyType.BaseType == typeof(Core))
                       .Select(prop => (Core)Activator.CreateInstance(prop.PropertyType))
                       .ToList();
        }

        public string Process(string input)
        {
            string output = string.Empty;

            //Logic

            return output;
        }
    }
}
