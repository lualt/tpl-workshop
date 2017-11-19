using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPL_Workshop
{
    class TaskParallelism
    {
        public void implicitTasks()
        {
            Parallel.Invoke(() => {
                Thread.Sleep(500);
                Console.WriteLine("Thread1");
            },
                () => doSomeWork(),
                () => doSomeOtherWork("Hallo"));
            Console.WriteLine("Main");
        }






        private void doSomeWork()
        {

        }

        private void doSomeOtherWork(String data)
        {

        }
    }
}