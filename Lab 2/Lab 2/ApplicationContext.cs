using Microsoft.EntityFrameworkCore;

namespace Lab_2
{
    class ApplicationContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-51JVMG9\SQLEXPRESS;Database=Alina;Trusted_Connection=True;");
        }
    }
}
