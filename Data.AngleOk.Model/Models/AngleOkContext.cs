using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    //public class AngleOkContext : DbContext
    public class AngleOkContext : IdentityDbContext<Person>
    {
        //public static IDatabaseInitializer<AngleOkContext> DatabaseInitializer = new MigrateDatabaseToLatestVersion<AngleOkContext, Configuration>(true);

        
        public AngleOkContext()
        {
            //Database.EnsureCreated(); //Создать БД если такой нет
        }
        public AngleOkContext(DbContextOptions<AngleOkContext> options) : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AngleOk;Username=postgres;Password=123456");
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<RealtyObject> RealtyObjects { get; set; }
        public DbSet<RealtyObjectType> RealtyObjectTypes { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Stead> Steads { get; set; }
        public DbSet<SteadKind> SteadKinds { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
