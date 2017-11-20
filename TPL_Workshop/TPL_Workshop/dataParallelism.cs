using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_Workshop
{
    class DataParallelism
    {
        private string path_seriell = @"../../../../data_seriell/";
        private string path_parallel = @"../../../../data_parallel/";

        public DataParallelism()
        {
            Directory.CreateDirectory(path_seriell);
            Directory.CreateDirectory(path_parallel);
        }

        public void generateTxtFiles()
        {
            /** TASK 1.1
             * TODO implement a loop that generates 100 files (using a for-loop).
             * Therefore use the Method  _generateTextInFile(FilePath)
             * Hint: The path can be generated like:
             * string FilePath = path_seriell + @"File" + i.ToString() + ".txt"; //where i is the iteration number and change the path_seriell to path_parallel for paralel data
             * 
             * Implement ths function with a normal loop and a parallel loop and measure the time that is needed to generate the data
             * Save the data in two different folder (path_seriell and path_parallel)
            */

            PerformanceMeasuring _perfMes_sequential = new PerformanceMeasuring("File Generation (sequential)");
            //implement sequential file generation here
            for (int i = 1; i <= 100; i++)
            {
                string FilePath = path_seriell + @"File" + i.ToString() + ".txt";
                _generateTextInFile(FilePath);
            }
            _perfMes_sequential.stopMeasuring();


            PerformanceMeasuring _perfMes_parallel = new PerformanceMeasuring("File Generation (parallel)");
            //implement parallel file generation here
            Parallel.For(1, 100, d =>
            {
                string FilePath = path_parallel + @"File" + d.ToString() + ".txt";
                _generateTextInFile(FilePath);
            });
            _perfMes_parallel.stopMeasuring();

        }

        public void replaceTxt()
        {
            /** TASK 1.2
            * TODO implement a loop that replaces the word hate to love in the files generated before (using a foreach-loop).
            * Therefore use the Method  _replaceTextInFile(FilePath)
            * Hint: The path to all generated files can looks like
            * String[] path = Directory.EnumerateFiles(path_seriell, "*.txt")   //replace path_seriell to path_parallel for parallel data
            * 
            * Implement ths function with a normal loop and a parallel loop and measure the time that is needed to generate the data
            * Save the data in two different folder (path_seriell and path_parallel)
            */

            // sequential implementation 
            PerformanceMeasuring _perfMes_sequentialTxt = new PerformanceMeasuring("Text Replacement (sequential)");
            foreach (string file in Directory.EnumerateFiles(path_seriell, "*.txt"))
            {
                _replaceTextInFile(file);
            }
            _perfMes_sequentialTxt.stopMeasuring();


            // TO DO: parallel implementation 
            PerformanceMeasuring _perfMes_parallelTxt = new PerformanceMeasuring("Text Replacement (parallel)");
            //implement parallel string replacement here
            Parallel.ForEach(Directory.EnumerateFiles(path_parallel, "*.txt"), file => {
                {
                    _replaceTextInFile(file);
                }
            });
            _perfMes_parallelTxt.stopMeasuring();

        }


        private void _generateTextInFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int j = 1; j < 100000; j++)
                    sw.WriteLine(j + " I hate TPL");
            }
        }


        private void _replaceTextInFile(string path)
        {
            string text = File.ReadAllText(path);
            text = text.Replace("hate", "love");
            File.WriteAllText(path, text);
        }
    }
}
