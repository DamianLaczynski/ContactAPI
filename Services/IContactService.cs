﻿using ContactAPI.Models;

namespace ContactAPI.Services
{
    public interface IContactService
    {
        bool Delete(int id);
        bool Update(int id, UpdateContactDto dto);
        IEnumerable<ContactDto> GetAll();
        ContactDto GetById(int id);
    }
}