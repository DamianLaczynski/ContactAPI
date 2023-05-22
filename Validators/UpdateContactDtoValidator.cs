using ContactAPI.Models;
using FluentValidation;

namespace ContactAPI.Validators
{
    //Validator dla modelu UpdateContactDto
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator(ContactsDbContext dbContext)
        {
            RuleFor(e => e.Name).MaximumLength(30);

            RuleFor(e => e.Surname).MaximumLength(30);

            RuleFor(e => e.Email).EmailAddress();

        }
    }
}
