using ContactAPI.Models;
using FluentValidation;

namespace ContactAPI.Validators
{
    //Validator dla modelu LoginDto
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator(ContactsDbContext dbContext) 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).NotEmpty();

        }
    }
}
