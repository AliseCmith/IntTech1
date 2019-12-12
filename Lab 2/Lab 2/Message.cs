using System;

namespace Lab_2
{
    public class Message
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return Username + ": " + Text;
        }
    }
}
