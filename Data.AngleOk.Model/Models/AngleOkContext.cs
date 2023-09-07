using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    public class AngleOkContext : DbContext
    {
        public AngleOkContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AngleOk;Username=postgres;Password=123456");
        }
        public DbSet<Person> Persons { get; set; }
    }
}
