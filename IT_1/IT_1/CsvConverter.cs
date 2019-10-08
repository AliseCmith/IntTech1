using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace IT_1
{
    class CsvConverter
    {
        public static List<string[]> ReadData(string path)
        {
            List<string[]> CSVData = new List<string[]>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Regex CSVParser = new Regex("[,;]");
                        string[] X = CSVParser.Split(line);
                        CSVData.Add(X);
                    }
                }
            }
            catch
            {
                ExceptionProcessing.LogEx(new Exception("Invalid file format or path."));
            }

            return CSVData;
        }
    }
}
