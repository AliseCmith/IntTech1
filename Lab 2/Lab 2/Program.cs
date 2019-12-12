using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var messenger = new Messenger();

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            DateTime start = DateTime.Now;
            while (true)
            {
                string text = Console.ReadLine();
                if(text!="") messenger.SendMessage(new Message
                {
                    Username = username,
                    Text = text,
                    DateTime = DateTime.Now
                });
                Console.Clear();
                var messages = messenger.GetMessages(start);
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}
