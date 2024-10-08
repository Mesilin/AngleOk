using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

//Миграции
//в коре 
// cd "C:\TUSUR\Git\tusur\1 semestr\DB\AngleOk\Data.AngleOk.Model"
// dotnet ef migrations add FillAddressData

//dotnet ef database update
//или
//    dotnet ef database update -c Data.AngleOk.Model.Models.AngleOkContext

//Нормальный мануал по откату в EF Core
//https://code-maze.com/efcore-how-to-revert-a-migration/https://code-maze.com/efcore-how-to-revert-a-migration/

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

            modelBuilder.Entity<Country>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(u => u.EnglishName).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(u => u.Alpha2).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(u => u.Alpha3).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(u => u.Iso).IsUnique();
            modelBuilder.Entity<Region>().HasIndex(u => new{u.Name, u.CountryId}).IsUnique();
            modelBuilder.Entity<City>().HasIndex(u => new{u.Name, u.RegionId}).IsUnique();
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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
