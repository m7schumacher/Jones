using Jones.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Kernel
{
    public class Kernel
    {
        public static Configuration Configuration { get; set; }
        public WeatherCore Weather { get; set; }

        public void Initialize(bool dreaming = false)
        {
            Configuration = new Configuration(dreaming);
        }
    }
}
