using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TPL_Workshop
{
    class FileOperations
    {
        string path_seriell = @"../../../../data_seriell/";
        string path_parallel = @"../../../../data_parallel/";

        public void generateTxtFiles()
        {
            int i = 1;

                // sequential implementation
                PerformanceMeasuring _perfMes_sequential = new PerformanceMeasuring("File Generation (sequential)");
                for (i = 1; i <= 100; i++)        
                {
                    string FilePath = path_seriell + @"File" + i.ToString() + ".txt";
                    using (StreamWriter sw = File.CreateText(FilePath)) 
                    {
                        for(int j=1; j < 100000; j++)
                        sw.WriteLine(j+" I hate TPL");
                    }
                }
                _perfMes_sequential.stopMeasuring();


                // TO DO: implement parallel for
                PerformanceMeasuring _perfMes_parallel = new PerformanceMeasuring("File Generation (parallel)");
                Parallel.For(1, 100, d =>
                 {
                     string FilePath = path_parallel + @"File" + d.ToString() + ".txt";
                     using (StreamWriter sw = File.CreateText(FilePath))
                     {
                         for (int j = 1; j < 100000; j++)
                             sw.WriteLine(j + " I hate TPL");
                     }
                 });
                _perfMes_parallel.stopMeasuring();
                 
        }

        public void replaceTxt()
        {
            // sequential implementation 
            PerformanceMeasuring _perfMes_sequentialTxt = new PerformanceMeasuring("Text Replacement (sequential)");
            foreach (string file in Directory.EnumerateFiles(path_seriell, "*.txt"))
            {
                _replace(file);
            }
            _perfMes_sequentialTxt.stopMeasuring();


            // TO DO: parallel implementation 
            PerformanceMeasuring _perfMes_parallelTxt = new PerformanceMeasuring("Text Replacement (parallel)");
            Parallel.ForEach(Directory.EnumerateFiles(path_parallel, "*.txt"), d => {
                {
                    _replace(d);
                }
            });
            _perfMes_parallelTxt.stopMeasuring();

        }

        private void _replace(string file)
        {
            string text = File.ReadAllText(file);
            text = text.Replace("hate", "love");
            File.WriteAllText(file, text);
        }


    }
}


        

    

