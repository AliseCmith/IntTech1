using System;

namespace IT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "", outputFile = "", fileFormat = "";
            try
            {
                for (int i = 0; i < args.Length; i += 2)
                    switch (args[i])
                    {
                        case "-i":
                            inputFile = args[i + 1];
                            break;
                        case "-o":
                            outputFile = args[i + 1];
                            break;
                        case "-f":
                            fileFormat = args[i + 1];
                            break;
                        default:
                            throw new Exception("Unknown flag");
                    }
            }
            catch (Exception ex)
            {
                ExceptionProcessing.LogEx(ex);
            }
            //DataProcessing.Run("test.csv", "out", "json");
            DataProcessing.Run(inputFile, outputFile, fileFormat);
        }
    }
}