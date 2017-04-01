using Jones.Domain;
using Jones.Domain.Triggers;
using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;

namespace Jones.Cells
{
    public class Cell
    {
        public string Name { get; private set; }

        private int MinutesBetweenUpdates { get; set; }

        public List<Instinct> Instincts { get; set; }
        public List<Reflex> Reflexes { get; set; }
        public List<Response> Responses { get; set; }

        public object[] Entities { get; set; }

        protected Dictionary<string, string> Values { get; set; }

        public bool SendingNotifications { get; set; }
        public int MinutesToUpdate { get; set; }
        public int MinutesSinceLastUpdate { get; set; }

        public int ConsecutiveFailures { get; set; }
        public int FailuresBeforeQuit { get; set; }

        public int RefreshHour { get; set; }
        public int RefreshMinute { get; set; }

        protected List<string> Prefixes { get; set; }

        public Cell(string name)
        {
            Name = name;
            SetRefresh(3, 0);

            Instincts = GenerateInstincts();
            Reflexes = GenerateReflexes();
            Responses = GenerateResponses();

            Prefixes = GeneratePrefixes();
            Entities = SetEntities();

            Initialize();
            InitializeLocal();


            ManualUpdate();
        }

        public void SetRefresh(int hour, int minute)
        {
            RefreshHour = hour;
            RefreshMinute = minute;
        }

        public List<Command> GetCommands()
        {
            List<string> phrases = new List<string>();
            phrases.AddRange(Instincts.SelectMany(inst => inst.Phrases));
            phrases.AddRange(Reflexes.SelectMany(refl => refl.Phrases));

            return phrases.Select(phrase => new Command(phrase, Name)).ToList();
        }

        public virtual string Execute(string input)
        {
            Instinct matchingInstinct = Instincts.FirstOrDefault(ins => ins.IsTriggered(input));

            if (matchingInstinct != null)
            {
                return matchingInstinct.GetResult();
            }

            Reflex matchingReflex = Reflexes.FirstOrDefault(reflex => reflex.IsTriggered(input));

            if (matchingReflex != null)
            {
                return matchingReflex.GetResult();
            }

            return string.Empty;
        }

        protected virtual List<Instinct> GenerateInstincts() { return new List<Instinct>(); }
        protected virtual List<Reflex> GenerateReflexes() { return new List<Reflex>(); }
        protected virtual List<Response> GenerateResponses() { return new List<Response>(); }

        protected virtual List<string> GeneratePrefixes() { return new List<string>(); }
        protected virtual object[] SetEntities() { return new object[0]; }

        protected virtual void Initialize() { }
        protected virtual void InitializeLocal() { Values = new Dictionary<string, string>(); }

        protected virtual void InitializeValues() { }
        protected virtual void Refresh() { }

        #region Monitor Methods

        #region Notification Methods

        protected virtual void SendNotifications() { }

        //protected void RefreshNotifications()
        //{
        //    foreach (var notification in this.GetType().GetProperties().Where(prop => prop.PropertyType == typeof(Notification)))
        //    {
        //        notification.SetValue("Active", true);
        //    }
        //}

        #endregion

        #region Update Methods

        protected virtual void Update() { }

        public void ManualUpdate()
        {
            SendingNotifications = false;
            Update();
            Refresh();
            SendingNotifications = true;
        }

        private bool ShouldRefresh()
        {
            return DateTime.Now.Hour == RefreshHour && DateTime.Now.Minute == RefreshMinute;
        }

        public void UpdateData()
        {
            MinutesSinceLastUpdate++;

            if (MinutesToUpdate == MinutesSinceLastUpdate)
            {
                try
                {
                    MinutesSinceLastUpdate = 0;
                    Update();

                    ConsecutiveFailures = 0;

                    if (SendingNotifications)
                    {
                        SendNotifications();
                    }

                    if (ShouldRefresh())
                    {
                        Refresh();
                        Console.WriteLine(Name + " was refreshed");
                    }
                }
                catch (Exception trouble)
                {
                    ConsecutiveFailures++;

                    if (ConsecutiveFailures == 4)
                    {
                        string message = string.Format("{0} monitoring has failed {1} consecutive times... Stopping monitoring.", Name, FailuresBeforeQuit.ToString());
                        //Notification.Send(message);
                    }
                }
            }
        }


        #endregion

        #endregion
    }
}
