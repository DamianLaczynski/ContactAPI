using ContactAPI.Entities;
using ContactAPI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;

namespace ContactAPI.Validators
{
    public class RegisterContactDtoValidator : AbstractValidator<RegisterContactDto>
    {
        public RegisterContactDtoValidator(ContactsDbContext dbContext) 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Contacts.Any(u => u.Email == value);
                if(emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });

            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
