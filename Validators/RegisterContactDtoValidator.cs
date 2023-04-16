using ContactAPI.Entities;
using ContactAPI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;

namespace ContactAPI.Validators
{
    //Validator dla modelu RegisterContactDto
    public class RegisterContactDtoValidator : AbstractValidator<RegisterContactDto>
    {
        public RegisterContactDtoValidator(ContactsDbContext dbContext) 
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(30);

            RuleFor(c => c.Surname).NotEmpty().MaximumLength(30);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.RoleID).NotEmpty();

            RuleFor(x => x.Password); //.MinimumLength(10).Matches("[A-Z]").Matches("[a-z]").Matches("[0-9]"); //wymaganie skomplikowanego hasła

            RuleFor(x => x.ConfirmedPassword).Equal(e => e.Password); 

            RuleFor(x => x.PhoneNumber).NotEmpty();

            //Metoda sprawdzająca czy podany email jest dostępny i nie jest już używany
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Contacts.Any(u => u.Email == value);
                if(emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });

        }
    }
}
