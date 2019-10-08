using System;
using System.Collections.Generic;
using System.Text;

namespace IT_1
{
    class DataProcessing
    {
        public static void Run(string inputFile, string outputFile, string fileFormat)
        {
            List<string[]> data = CsvConverter.ReadData(inputFile);
            Group group = new Group(data);
            if (outputFile != null && fileFormat != null)
            {
                if (fileFormat.ToUpper() == "JSON")
                {
                    JsonConverter.SaveGroup(group, outputFile + ".json");
                    Console.WriteLine("Записано в JSON.");
                }
                else if (fileFormat.ToUpper() == "XLSX")
                {
                    ExcelConverter.SaveGroup(group, outputFile + ".xlsx");
                    Console.WriteLine("Записано в XLSX.");
                }
            }
        }
    }
}
