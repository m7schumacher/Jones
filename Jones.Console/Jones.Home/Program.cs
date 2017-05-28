using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Jones.Utility;
using Jones.Core;

namespace Jones.Home
{
    public class Program
    {
        private static Kernel kernel;

        public static void Main(string[] args)
        {
            Console.WriteLine("Initializing Kernel...\n");

            kernel = new Kernel();
            int secondsToInitialize = Diagnostics.DoAndTime(() => kernel.Initialize());

            Console.WriteLine("\nInitialize took {0} milliseconds", secondsToInitialize);
            Console.WriteLine("\n\nJones is now listening!");

            while (true)
            {
                string input = Console.ReadLine();
                string output = Process(input);
                Console.WriteLine(output);
            }
        }

        public static string Process(string input)
        {
            return kernel.Process(input);
        }
    }
}
