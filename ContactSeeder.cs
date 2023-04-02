using ContactAPI.Entities;

namespace ContactAPI
{
    public class ContactSeeder 
    {
        private readonly ContactsDbContext _dbContext;

        public ContactSeeder(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Contacts.Any())
                {
                    _dbContext.Contacts.AddRange(GetContacts());
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact()
                {
                    Name = "admin",
                    Email = "admin@admin.com",
                    //Birthday = "020202",
                    PhoneNumber = "123456789",
                    HashedPassword = "admin",
                    Surname = "ADMIN",
                    Category = "chef"
                }
            };
            return contacts;
        }
    }
}
