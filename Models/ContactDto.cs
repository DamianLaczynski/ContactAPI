using ContactAPI.Entities;

namespace ContactAPI.Models
{
    public class ContactDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? dateOfBirth { get; set; }
    }
}
