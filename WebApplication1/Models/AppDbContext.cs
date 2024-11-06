using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
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
                    Priority = Priority.High
                }
                
                );
        }
    }
}
