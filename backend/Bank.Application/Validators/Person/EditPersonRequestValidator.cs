using Bank.Application.DTO.Person;
using Bank.Application.Resources;
using FluentValidation;

namespace Bank.Application.Validators.Person
{
    public class EditPersonRequestValidator : AbstractValidator<EditPersonRequest>
    {
        public EditPersonRequestValidator()
        {
            Include(new BasePersonRequestValidator());

            RuleFor(x => x.PersonId)
                .GreaterThan(0).WithMessage(PersonMessages.InvalidId);
        }
    }
}
