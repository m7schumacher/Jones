using Jones.Cells;
using Jones.Cells.Weather;
using Jones.Domain;
using Swiss;
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
        public WeatherCell Weather { get; set; }

        private List<Cell> Cells { get; set; }
        private List<Command> Commands { get; set; }

        public void Initialize(bool dreaming = false)
        {
            Configuration = new Configuration(dreaming);
            Cells = InitializeCells();

            Commands = new List<Command>();

            foreach(var core in Cells)
            {
                Commands.AddRange(core.GetCommands());
            }
        }

        private List<Cell> InitializeCells()
        {
            return this.GetType()
                       .GetProperties()
                       .Where(prop => prop.PropertyType.BaseType == typeof(Cell))
                       .Select(prop => (Cell)Activator.CreateInstance(prop.PropertyType))
                       .ToList();
        }

        public string Process(string input)
        {
            string output = string.Empty;

            Command match = Commands.First(cmd => cmd.Phrase.EqualsIgnoreCase(input));
            Cell target = Cells.First(core => core.Name.Equals(match.Target));

            return target.Execute(input);
        }
    }
}
