using Bank.Application.DTO.Person;
using FluentValidation;

namespace Bank.Application.Validators.Person
{
    public class AddPersonRequestValidator : AbstractValidator<AddPersonRequest>
    {
        public AddPersonRequestValidator()
        {
            Include(new BasePersonRequestValidator());
        }
    }
}
