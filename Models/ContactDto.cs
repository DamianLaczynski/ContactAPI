using ContactAPI.Entities;

namespace ContactAPI.Models
{
    public class ContactDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
    }
}
