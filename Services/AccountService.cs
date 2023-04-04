using ContactAPI.Entities;
using ContactAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ContactAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly ContactsDbContext _context;

        private readonly IPasswordHasher<Contact> _passwordHasher;

        public AccountService(ContactsDbContext contactsDbContext, IPasswordHasher<Contact> passwordHasher)
        {
            _context = contactsDbContext;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterContactDto contactDto)
        {
            var newContact = new Contact()
            {
                Email = contactDto.Email,
                Name = contactDto.Name,
                PhoneNumber = contactDto.PhoneNumber,
                Surname = contactDto.Surname,
                Category = contactDto.Category
            };
            //TODO dodać mapper???

            var hashedPassword = _passwordHasher.HashPassword(newContact, contactDto.Password);
            newContact.HashedPassword = hashedPassword;
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
        }

        public void LoginUser(LoginDto loginDto)
        {
            //TODO autentication
        }
    }
}
