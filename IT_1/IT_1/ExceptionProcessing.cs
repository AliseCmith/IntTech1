using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IT_1
{
    class ExceptionProcessing
    {
        public static void LogEx(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("logs.txt", true, Encoding.Default))
            {
                sw.WriteLine(ex.ToString());
            }
            Console.WriteLine("Error. See logs");
        }
    }
}
