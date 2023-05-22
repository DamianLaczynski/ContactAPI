using ContactAPI.Entities;

namespace ContactAPI
{
    //Klasa inicjalizująca bazę danych podstawowymi danymi
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
                if (!_dbContext.Roles.Any())
                {
                    _dbContext.Roles.AddRange(GetRoles());
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles() 
        {
            List<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Name = "admin"
                },
                new Role()
                {
                    Name= "manager"
                },
                new Role()
                {
                    Name = "klient"
                }
            };

            return roles;
        }
    }
}
