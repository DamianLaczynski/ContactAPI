using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Services
{
    public class ContactService : IContactService
    {

        private readonly ContactsDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(ContactsDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public ContactDto GetById(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return null;
            }

            var resut = _mapper.Map<ContactDto>(contact);
            return resut;
        }

        public IEnumerable<ContactDto> GetAll()
        {
            var contacts = _context.Contacts.ToList();
            var contactsDtos = _mapper.Map<List<ContactDto>>(contacts);
            return contactsDtos;
        }

        public int Create(CreateContactDto dto)
        {

            var contact = _mapper.Map<Contact>(dto);
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        public bool Update(int id, UpdateContactDto dto)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return false;
            }

            contact.Name = dto.Name;
            contact.Email = dto.Email;
            contact.Surname = dto.Surname;
            contact.PhoneNumber = dto.PhoneNumber;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if(contact == null)
            {
                return false;
            }
            else
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return true;
            }

        }
    }
}
