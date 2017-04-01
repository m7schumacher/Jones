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
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Initializing Kernel...");

            Kernel kernel = new Kernel();
            int secondsToInitialize = Diagnostics.DoAndTime(() => kernel.Initialize());

            Console.WriteLine("Initialize took {0} seconds", secondsToInitialize);
            Console.WriteLine("\n\nJones is now listening!");

            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(kernel.Process(input));
            }
        }
    }
}
