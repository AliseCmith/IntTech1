using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IT_1
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string surname { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string patronymic { get; set; }
        [DataMember]
        public List<Subject> subjects { get; set; }
        [DataMember]
        public double averageMark;

        public Student(string surname, string name, string patronymic)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            subjects = new List<Subject>();

        }

        public void AddSubject(Subject subject)
        {
            subjects.Add(subject);
            CalcAvg();
        }

        public void CalcAvg()
        {
            averageMark = 0;
            foreach (Subject subject in subjects)
            {
                averageMark += subject.mark;
            }
            averageMark /= subjects.Count;
        }
    }
}
