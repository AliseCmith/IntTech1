using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IT_1
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public double mark { get; set; }
        public Subject(string name, double mark)
        {
            this.name = name;
            this.mark = mark;
        }
    }
}
