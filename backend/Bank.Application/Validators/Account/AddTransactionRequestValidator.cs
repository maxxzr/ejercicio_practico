using Bank.Application.DTO.Transaction;
using FluentValidation;

namespace Bank.Application.Validators.Account
{
    public class AddTransactionRequestValidator : AbstractValidator<AddTransactionRequest>
    {
        public AddTransactionRequestValidator()
        {
            RuleFor(x => x.AccountId)
                .GreaterThan(0).WithMessage("Identiicador de cuenta no valido");
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El importe no debe ser menor o igual a 0");
            RuleFor(x => x.TransactionTypeId)
                .IsInEnum().WithMessage("Identificador de transaccion no valido");
        }
    }
}
