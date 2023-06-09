﻿using ContactAPI.Models;

namespace ContactAPI.Services
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterContactDto contactDto);

        public string GenerateJwt(LoginDto loginDto);
    }
}
