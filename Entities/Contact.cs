using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ContactAPI.Entities
{
    [Index(nameof(Contact.Email), IsUnique = true)]
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        public string Category { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        
        //TODO public System.DateTime Birthday { get; set; }
        
    }
}
