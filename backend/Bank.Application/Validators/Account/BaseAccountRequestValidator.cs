using Bank.Application.DTO.Account;
using Bank.Application.Resources;
using FluentValidation;

namespace Bank.Application.Validators.Account
{
    public class BaseAccountRequestValidator : AbstractValidator<BaseAccountRequest>
    {
        public BaseAccountRequestValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Numero de cuenta requerido")
                .MinimumLength(6).WithMessage("Longitud de cuenta es 6");

            RuleFor(x => x.InitialBalance)
                .GreaterThanOrEqualTo(0).WithMessage("El saldo inicial debe ser mayor que 0");
        }
    }
}
