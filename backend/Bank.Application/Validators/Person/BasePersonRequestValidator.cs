using Bank.Application.DTO.Person;
using Bank.Application.Resources;
using FluentValidation;

namespace Bank.Application.Validators.Person
{
    public class BasePersonRequestValidator : AbstractValidator<BasePersonRequest>
    {
        public BasePersonRequestValidator()
        {
            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage(PersonMessages.DocumentNumberIsRequired)
                .MinimumLength(8).WithMessage(PersonMessages.DocumentNumberMinimunLength);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(PersonMessages.NameIsRequired)
                .MinimumLength(3).WithMessage(PersonMessages.NameMinimunLength);

            RuleFor(x => x.GenderId)
                .IsInEnum().WithMessage(PersonMessages.InvalidGerder);

            RuleFor(x => x.BirthDate)
                .NotNull().WithMessage(PersonMessages.BirthDateIsRequired)
                .LessThanOrEqualTo(x => DateTime.Now.AddYears(-18)).WithMessage(PersonMessages.InvalidBirthDate);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(PersonMessages.PhoneIsRequired)
                .MinimumLength(6).WithMessage(PersonMessages.PhoneMinimunLegth);
        }
    }
}
