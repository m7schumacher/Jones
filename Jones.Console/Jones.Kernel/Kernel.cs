using Jones.Cells;
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
        public static Configuration Configuration { get; set; }
        public static List<Notice> Notifications { get; set; }

        private List<Cell> Cells { get; set; }
        private List<KnownCommand> Commands { get; set; }

        private Timer FastEngine { get; set; }
        private Timer RegularEngine { get; set; }

        #region Initialization

        public void Initialize(bool dreaming = false)
        {
            Configuration = new Configuration(dreaming);
            Cells = InitializeCells();

            Commands = new List<KnownCommand>();

            foreach (var cell in Cells)
            {
                Commands.AddRange(cell.GatherCommands());
            }
        }

        private List<Cell> InitializeCells()
        {
            AssemblyName cellAssembly = Assembly.GetExecutingAssembly()
                                                .GetReferencedAssemblies()
                                                .First(assem => assem.Name.Equals("Jones.Cells"));
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
            List<Cell> fastCells = Cells.Where(cl => cl.Monitor.IsFast).ToList();
            List<Cell> slowCells = Cells.Where(cl => !cl.Monitor.IsFast).ToList();

            RegularEngine = new Timer(e => { CycleCells(slowCells); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            FastEngine = new Timer(e => { CycleCells(fastCells); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
        }

        private void CycleCells(List<Cell> cells)
        {
            foreach (var cell in cells)
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
