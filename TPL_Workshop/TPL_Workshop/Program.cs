using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TPL_Workshop
{
    class Program
    {
        static void Main()
        {

   
            FileOperations _fileOperations = new FileOperations();
            _fileOperations.generateTxtFiles();
            _fileOperations.replaceTxt();

            long totalSize = 0;
            String[] files = Directory.GetFiles("../../../../data_seriell");

            for (int i=0; i < files.Length; i++)
            {
                FileInfo fi = new FileInfo(files[i]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            }
            
            Parallel.For(0, files.Length,
                         index =>
                         {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });

            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);

            Console.ReadLine();
        }
    }
}
