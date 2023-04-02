using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ContactAPI.Entities
{
    [Index(nameof(Contact.Email), IsUnique = true)]
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
       
        //TODO public string Password { get; set; }

        public Category Category { get; set; }

        public string PhoneNumber { get; set; }

        
        //TODO public System.DateTime Birthday { get; set; }
        
    }
}
