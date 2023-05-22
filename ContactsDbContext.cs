using ContactAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI
{
    public class ContactsDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\Contacts;Database=ContactsDb;Trusted_Connection=True;";

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(c => c.Id)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
