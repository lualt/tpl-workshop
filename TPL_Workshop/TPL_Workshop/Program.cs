using System;

namespace TPL_Workshop
{
    class Program
    {
        static void Main()
        {

            DataParallelism dataParallelism = new DataParallelism();
            TaskParallelism taskParallelism = new TaskParallelism();
            Console.WriteLine("Starting the program ...");

            //TODO TASK 1 implemente these two functions
            //dataParallelism.generateTxtFiles();
            //dataParallelism.replaceTxt();

            //TODO TASK 2 implemente these two functions 
            //taskParallelism.implicitTasks();
            taskParallelism.explicitTasks();

            Console.WriteLine("Program finished press any key to exit");
            Console.ReadLine();
        }
    }
}
