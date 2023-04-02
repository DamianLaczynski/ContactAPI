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
                    _dbContext.Categories.AddRange(GetCategories());
                    _dbContext.Contacts.AddRange(GetContacts());
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "client"
                },
                new Category()
                {
                    Name = "employee"
                }
            };
            return categories;
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
                    PhoneNumber = "1234567890",
                    //Password = "admin",Surname = "admin",
                    Category = new Category()
                    {
                        Name= "chef"
                    },
                    Surname = "ADMIN"

                }
            };
            return contacts;
        }
    }
}
