using Jones.Cells;
using Jones.Cells.Organelles;
using Jones.Cells.Weather;
using Jones.Domain;
using Jones.Domain.Internal.Notifications;
using Swiss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jones.Core
{
    public class Kernel
    {
        public static List<Notice> Notifications { get; set; }
        public List<KnownCommand> Commands { get; set; }

        private List<Cell> Cells { get; set; }

        private Timer Engine { get; set; }

        #region Initialization

        public void Initialize(bool dreaming = false)
        {
            Configuration.InitializeDefaultConfiguration(dreaming);
            Senses.AnalyzeEnvironment();

            Cells = InitializeCells();

            Commands = new List<KnownCommand>();

            foreach (var cell in Cells)
            {
                Commands.AddRange(cell.GatherCommands());
            }

            Console.WriteLine("{0} commands gathered", Commands.Count);
        }

        private List<Cell> InitializeCells()
        {
            AssemblyName cellAssembly = Assembly.GetExecutingAssembly()
                                                .GetReferencedAssemblies()
                                                .First(assem => assem.Name.Equals(Constants.CellsAssembly));

            return Assembly.Load(cellAssembly)
                           .GetTypes()
                           .Where(type => type.BaseType == typeof(Cell))
                           .Select(type => (Cell)Activator.CreateInstance(type))
                           .Where(cell => cell.Enabled)
                           .ToList();
        }

        #endregion

        #region Notifications and Monitoring

        private void BeginMonitoring()
        {
            Engine = new Timer(e => { CycleCells(); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(Constants.SecondsPerCycle));
        }

        private void CycleCells()
        {
            foreach (var cell in Cells)
            {
                Notifications.AddRange(cell.GatherNotifications());
            }

            ProcessNotifications();
        }

        private void ProcessNotifications()
        {

        }

        #endregion

        public string Process(string input)
        {
            string output = string.Empty;

            KnownCommand match = Commands.First(cmd => cmd.Phrase.EqualsIgnoreCase(input));
            Cell target = Cells.First(core => core.Name.Equals(match.Target));
            Command command = new Command(input);

            return target.Execute(command);
        }
    }
}
