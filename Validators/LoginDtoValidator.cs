using ContactAPI.Entities;
using ContactAPI.Models;
using FluentValidation;

namespace ContactAPI.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator(ContactsDbContext dbContext) 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).NotEmpty();

        }
    }
}
