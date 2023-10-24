using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.AngleOk.Model.Models
{
    public class AngleOkContextFactory : IDesignTimeDbContextFactory<AngleOkContext>
    {
        public AngleOkContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AngleOkContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AngleOk;Username=postgres;Password=123456");

            return new AngleOkContext(optionsBuilder.Options);
        }
    }

    //public class AngleOkContext : DbContext
    public class AngleOkContext : IdentityDbContext
    {
        public AngleOkContext(DbContextOptions<AngleOkContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AngleOk;Username=postgres;Password=123456");

        }

        ////public static IDatabaseInitializer<AngleOkContext> DatabaseInitializer = new MigrateDatabaseToLatestVersion<AngleOkContext, Configuration>(true);

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
        public DbSet<TextField> TextFields { get; set; }
    }
}
