using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationEntity>().OwnsOne(c => c.Address).HasData(
                new
                {
                    OrganizationEntityId = 1,
                    Street = "ul. Testowa 1",
                    City = "Gdańsk",
                    PostalCode = "80-000"
                },
                new
                {
                    OrganizationEntityId = 2,
                    Street = "ul. sw filipa 17",
                    City = "Krakow",
                    PostalCode = "30-000"
                }
                );

            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity
                {
                    Id = 1,
                    Name = "Firma",
                    NIP = "1234567890",
                    REGON = "0987654321"
                },
                new OrganizationEntity
                {
                    Id = 2,
                    Name = "wsei",
                    NIP = "32342343242",
                    REGON = "09874422197"
                }
                );
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jankowalski@op.pl",
                    PhoneNumber = "123 456 789",
                    BirthDate = new DateOnly(2000, 11, 11),
                    Created = DateTime.Now,
                    Priority = Priority.High,
                    OrganizationId = 1,
                }
                );
        }
    }
}
