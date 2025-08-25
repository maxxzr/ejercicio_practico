using Bank.Application.DTO.Client;
using Bank.Application.Resources;
using Bank.Application.Validators.Person;
using FluentValidation;

namespace Bank.Application.Validators.Client
{
    public class BaseClientRequestValidator : AbstractValidator<BaseClientRequest>
    {
        public BaseClientRequestValidator()
        {
            Include(new BasePersonRequestValidator());

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ClientMessages.PasswordRequired)
                .MinimumLength(8).WithMessage(ClientMessages.PasswordMinimunLength)
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-._]).{8,}$").WithMessage(ClientMessages.InvalidPassword);

            RuleFor(x => x.RepeatPassword)
                .Equal(x => x.Password).WithMessage(ClientMessages.InvalidPasswordRepeat);
        }
    }
}
