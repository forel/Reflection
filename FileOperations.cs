using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class FileOperations
    {
        

        public static void CSVWriter(string filePath, string csvString)
        {
            using (var fs = new StreamWriter(filePath))
            {
                fs.WriteLine(csvString);
            }
        }

        public static string CSVReader(string filePath)
        {
            using (var fs = new StreamReader(filePath))
            {
                return fs.ReadToEnd();
            }
        }
    }
}
