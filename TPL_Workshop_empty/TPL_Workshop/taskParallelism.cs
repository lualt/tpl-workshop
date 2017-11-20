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
        private PerformanceMeasuring measureTime;

        public void implicitTasks()
        {
            /* TASK 2.1
             * TODO: 
             * write some code that calls the function 
             *      longMeanCalculations() and pintMinMaxValues() 
             *      and write some code lines that creates a file and saves the data in the file (every entry in a new line)
             *      
             * Do this ina first step as a sequentiel code and measure the time needed
             * In a scond step use implicit tasks to do the job and compare the results
             * 
            */
            double[] data = gernateData();
            measureTime = new PerformanceMeasuring("Sequential Calculations");
            //place here code for sequntial running the tasks


            measureTime.stopMeasuring();

            measureTime = new PerformanceMeasuring("Parallel Calculations");
            //place here code for parallel running the tasks

            measureTime.stopMeasuring();
        }

        public void explicitTasks()
        {
            /* TASK 2.2
             * TODO:
             *  Start a Task that generates a random String (use generateRandomString()) and return the value to the main
             *  in the main wait till the Task is finished
             *  
             *  Then Start a new Task that creates a new Object of class myData and set the data, the length of the data and the ID of the Thread (Thread.CurrentThread.ManagedThreadId)
             *  
             *  Continue after finishing of the task with a new Task (using ContinueWith). In this task print the Thread ID and the length f the String. 
             *  Then call the method checkResults(). Implement an execption Handling for the last Task and print the Exception if a exception is thrown to the Command Line.
            */

        }

        class MyData
        {
            public string dataStr { get; set; }
            public int threadID { get; set; }
            public int dataLength { get; set; }
        }


        private double[] gernateData()
        {
            Random random = new Random();
            double minimum = 5.0;
            double maximum = 10.0;
            int length = 1500;
            double[] retValu=new double[length];
            for (int i = 0; i < length; i++)
            {
                retValu[i]= random.NextDouble() * (maximum - minimum) + minimum;
            }
            return retValu;
        }


        private String generateRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[500];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                Thread.Sleep(1);
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        private void printMinMaxValues(double[] data)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Der Maximalwert lautet " + data.Max()+ "  der Minimalwert ist "+ data.Min());
        }

        private void longMeanCalculations(double[] data)
        {
            double mean=0;
            foreach(var temp in data)
            {
                mean += temp;
            }
            Thread.Sleep(1000);
            mean = mean / data.Length;
            Console.WriteLine("Der Mittelwert ist " + mean);
        }

        private void checkResults ()
        {
            throw new IOException("Can't print data");
        }
    }
}