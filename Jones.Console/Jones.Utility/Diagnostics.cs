using System;
using System.Diagnostics;

namespace Jones.Utility
{
    public class Diagnostics
    {
        public static int DoAndTime(Action action)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            action.Invoke();
            watch.Stop();

            return watch.Elapsed.Milliseconds;
        }
    }
}
