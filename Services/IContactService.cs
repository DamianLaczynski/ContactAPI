using ContactAPI.Models;

namespace ContactAPI.Services
{
    public interface IContactService
    {
        bool Delete(int id);
        bool Update(int id, UpdateContactDto dto);
        IEnumerable<T> GetAll<T>() where T : IContact;
        T GetById<T>(int id) where T : IContact;

    }
}