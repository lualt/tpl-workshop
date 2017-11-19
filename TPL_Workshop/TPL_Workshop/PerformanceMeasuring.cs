using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_Workshop
{
    class PerformanceMeasuring
    {
        Stopwatch stopwatch;
        
        public PerformanceMeasuring()
        {
            stopwatch = Stopwatch.StartNew();
        }

        public TimeSpan stopMeasuring()
        {
            stopwatch.Stop();
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds,
            //    stopwatch.Elapsed.Milliseconds / 10);
            Console.WriteLine("Laufzeit des Programms " + stopwatch.Elapsed +" [hh:min:sec]");
            return stopwatch.Elapsed;
        }
    }
}
