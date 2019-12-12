using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2
{
    public class Messenger
    {
        ApplicationContext context;

        public Messenger()
        {
            context = new ApplicationContext();
        }

        public void SendMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public IEnumerable<Message> GetMessages(DateTime from)
        {
            return context.Messages.FromSqlRaw("SELECT * FROM Messages").ToList().Where(x => x.DateTime > from);
        }
    }
}
