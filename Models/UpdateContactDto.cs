using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class UpdateContactDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
