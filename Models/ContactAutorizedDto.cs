using ContactAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class ContactAutorizedDto : IContact
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
