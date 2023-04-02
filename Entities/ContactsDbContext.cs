using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Entities
{
    public class ContactsDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\Contacts;Database=ContactsDb;Trusted_Connection=True;";

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(r => r.Id)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
