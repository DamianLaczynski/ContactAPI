using ContactAPI.Entities;
using ContactAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly ContactsDbContext _context;

        private readonly IPasswordHasher<Contact> _passwordHasher;

        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(ContactsDbContext contactsDbContext, IPasswordHasher<Contact> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = contactsDbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterContactDto dto)
        {
            // Tworzymy nowy obiekt Contact na podstawie przekazanych danych
            var newContact = new Contact()
            {
                Email = dto.Email,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Surname = dto.Surname,
                RoleID = dto.RoleID,
                DateOfBirth = dto.DateOfBirth
            };

            // Haszujemy hasło użytkownika i zapisujemy je w bazie danych
            var hashedPassword = _passwordHasher.HashPassword(newContact, dto.Password);
            newContact.HashedPassword = hashedPassword;
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
        }

        // Metoda służąca do generowania tokena JWT na podstawie danych logowania
        public string GenerateJwt(LoginDto loginDto)
        {
            // Sprawdzamy, czy użytkownik o podanym adresie email istnieje w bazie danych
            var user = _context.Contacts.FirstOrDefault(u=> u.Email == loginDto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            // Sprawdzamy, czy podane hasło jest poprawne
            var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, loginDto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            // Pobieramy rolę użytkownika z bazy danych
            var role = _context.Roles.FirstOrDefault(e => e.Id == user.RoleID);

            // Tworzymy listę claimów potrzebnych do wygenerowania tokenu użytkownika
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
                new Claim(ClaimTypes.Role, role.Name)
            };

            // Tworzymy klucz szyfrujący na podstawie ustawień autentykacji
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            // Tworzymy nowy token JWT na podstawie claimów i klucza szyfrującego
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,_authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            // Tworzymy nowy handler tokena i zwracamy zaszyfrowany token w postaci ciągu znaków
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
