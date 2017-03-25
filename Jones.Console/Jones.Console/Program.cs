using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool isDreaming = false;

            //Console.Write("Initializing Nucleus...  ");

            //Nucleus.Initialize(true, isDreaming);

            //nucleusWatch.Stop();
            //Console.Write("Initialization took {0} seconds\n\n", nucleusWatch.Elapsed.TotalSeconds.Round(2));

            //Console.Write("Waking the brain...  ");
            //brainWatch.Start();

            //Brain.Awaken(isDreaming);
            //while (Nucleus.Internal.State != SettingsHub.States.Ready) { }

            //brainWatch.Stop();
            //Console.Write("Waking took {0} seconds\n\n", brainWatch.Elapsed.TotalSeconds.Round(2));

            //if (!Nucleus.Internal.isDreaming)
            //{
            //    Console.Write("Initializing senses...  ");
            //    speechWatch.Start();

            //    EyesAndEars kinect = new EyesAndEars();
            //    kinect.Initialize();

            //    speechWatch.Stop();
            //    Console.Write("Initialization took {0} seconds\n\n", speechWatch.Elapsed.TotalSeconds.Round(2));
            //}

            //double totalTime = nucleusWatch.Elapsed.TotalSeconds + brainWatch.Elapsed.TotalSeconds + speechWatch.Elapsed.TotalSeconds;
            //Console.WriteLine("Total initializing time: " + totalTime.Round(2) + " seconds");

            //var commandsByMovement = Nucleus.Memory.GetNumberCommandsByMovement();
            //Console.WriteLine("Total commands known: " + (Nucleus.Memory.Commands.Count + 1) + "\n");

            //foreach (var pair in commandsByMovement.SortByValueDescending(val => val).Take(8))
            //{
            //    Console.WriteLine(Brain.Motor.GetNameOfMovement(pair.Key) + " - " + pair.Value);
            //}

            //Console.WriteLine("\nJones is now listening!\n\n\n");

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    Brain.Process(input);
            //}
        }
    }
}
