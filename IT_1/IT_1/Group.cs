using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IT_1
{
    [DataContract]
    class Group
    {
        public string[] header { get; set; }
        [DataMember]
        public List<Student> students { get; set; }
        [DataMember]
        public Dictionary<string, double> averageMarks { get; set; }

        public Group(List<string[]> data)
        {
            header = data[0];
            data.Remove(data[0]);
            averageMarks = new Dictionary<string, double>();
            students = new List<Student>();
            for (int i = 3; i < header.Length; i++)
            {
                averageMarks.Add(header[i], 0);
            }
            averageMarks.Add("Average", 0);
            foreach (string[] line in data)
            {
                Student student = new Student(line[0], line[1], line[2]);
                for (int i = 3; i < header.Length; i++)
                {
                    Subject subj = new Subject(header[i], double.Parse(line[i] == "" ? "0" : line[i]));
                    student.AddSubject(subj);
                    averageMarks[header[i]] = (averageMarks[header[i]] * students.Count + double.Parse(line[i] == "" ? "0" : line[i])) / (students.Count + 1);
                }
                averageMarks["Average"] = (averageMarks["Average"] * students.Count + student.averageMark) / (students.Count + 1);
                students.Add(student);
            }
        }
    }
}
