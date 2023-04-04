using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class UpdateContactDto
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Category { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
