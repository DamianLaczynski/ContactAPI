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
                    Name = "chef"
                },
                new Role()
                {
                    Name= "client"
                },
                new Role()
                {
                    Name = "another"
                }
            };

            return roles;
        }
    }
}
