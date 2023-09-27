using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    //public class AngleOkContext : DbContext
    public class AngleOkContext :DbContext
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            //base.OnModelCreating(builder);
            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = "de84fe4c-2eb8-439e-bebd-ce27e84958a2",
            //    Name = "admin",
            //    NormalizedName = "ADMIN"
            //});
            //builder.Entity<IdentityUser>().HasData(new IdentityUser
            //{
            //    Id= "6fc12c6d-99e7-444b-9bed-a0a8cf6f08b4",
            //    UserName= "admin",
            //    NormalizedUserName="ADMIN",
            //    Email="mesilin@mail.ru",
            //    NormalizedEmail="MESILIN@MAIL>RU",
            //    EmailConfirmed=true,
            //    PasswordHash=new PasswordHasher<IdentityUser>().HashPassword(null, "AngleOk"),
            //    SecurityStamp=string.Empty
            //});
            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = "de84fe4c-2eb8-439e-bebd-ce27e84958a2",
            //    UserId = "6fc12c6d-99e7-444b-9bed-a0a8cf6f08b4",
                
            //});
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
