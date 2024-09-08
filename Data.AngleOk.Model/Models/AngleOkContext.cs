using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

//Миграции
//в коре 
// cd .\Data.AngleOk.Model\
// dotnet ef migrations add CreateTableTextField

//dotnet ef database update
//или
//    dotnet ef database update -c Data.AngleOk.Model.Models.AngleOkContext

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

    public class AngleOkContext(DbContextOptions<AngleOkContext> options) : IdentityDbContext(options)
    {
        //Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
        }

        ////public static IDatabaseInitializer<AngleOkContext> DatabaseInitializer = new MigrateDatabaseToLatestVersion<AngleOkContext, Configuration>(true);

        public DbSet<Advertisement> Advertisements { get; set; }
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RealtyObject> RealtyObjects { get; set; }
        //public DbSet<RealtyObjectOwner> RealtyObjectOwners { get; set; }
        public DbSet<Stead> Steads { get; set; }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<RealtyObjectKind> RealtyObjectKinds { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<SteadUseKind> SteadUseKinds { get; set; }
    }
}
