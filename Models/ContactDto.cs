using ContactAPI.Entities;
using ContactAPI.Services;

namespace ContactAPI.Models
{
    public class ContactDto : IContact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }

        //public DateTime? DateOfBirth { get; set; }
    }
}
