using AutoMapper;
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

        // Metoda pobierająca kontakt po podanym ID
        // - tylko dla modeli, które implementują interfejs IContact
        public T GetById<T>(int id) where T : IContact
        {
            var contact = _context.Contacts
                .Include(c => c.Role)
                .FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return default(T);
            }

            var result = _mapper.Map<T>(contact); // mapowanie obiektu na DTO
            return result;
        }

        // Metoda pobierająca wszystkie kontakty z bazy danych
        // - tylko dla modeli, które implementują interfejs IContact
        public IEnumerable<T> GetAll<T>() where T : IContact
        {
            var contacts = _context.Contacts
                .Include (c => c.Role)
                .ToList();
            var contactsDtos = _mapper.Map<List<T>>(contacts); // mapowanie obiektu na DTO
            return contactsDtos;
        }

        // Metoda aktualizująca dane kontaktu o podanym ID
        public bool Update(int id, UpdateContactDto dto)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return false; //Nie zanleziono pasującego obiektu
            }

            contact.Name = dto.Name;
            contact.Email = dto.Email;
            contact.Surname = dto.Surname;
            contact.PhoneNumber = dto.PhoneNumber;

            _context.SaveChanges();
            return true;
        }

        // Metoda usuwająca kontakt o podanym ID
        public bool Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if(contact == null)
            {
                return false; //Nie zanleziono pasującego obiektu
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
