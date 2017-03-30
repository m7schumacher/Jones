using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jones.Nucleus;
using System.Diagnostics;
using Jones.Utility;

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

            while(true)
            {
                string input = Console.ReadLine();
                kernel.Process(input);
            }
        }
    }
}
