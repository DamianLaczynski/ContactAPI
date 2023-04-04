using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class RegisterContactDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        [MinLength(10)]
        public string Password { get; set; }

        [Required]
        public string ConfirmedPassword { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}