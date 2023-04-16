using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class UpdateContactDto
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int RoleID { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
