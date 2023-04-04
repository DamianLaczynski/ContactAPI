using ContactAPI.Entities;
using ContactAPI.Models;
using FluentValidation;

namespace ContactAPI.Validators
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator(ContactsDbContext dbContext)
        {
            RuleFor(e => e.Name).MaximumLength(30);

            RuleFor(e => e.Surname).MaximumLength(30);

            RuleFor(e => e.Email).EmailAddress();

            RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.ConfirmedPassword).Equal(e => e.Password);
        }
    }
}
