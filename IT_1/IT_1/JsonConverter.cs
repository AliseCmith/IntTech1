using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace IT_1
{
    class JsonConverter
    {
        public static void SaveGroup(Group group, string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Group));
                    jsonFormatter.WriteObject(fs, group);
                }
            }
            catch
            {
                ExceptionProcessing.LogEx(new Exception("Invalid file format or path."));
            }
        }
    }
}