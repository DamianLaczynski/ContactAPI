using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class CreateContactDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Category { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
