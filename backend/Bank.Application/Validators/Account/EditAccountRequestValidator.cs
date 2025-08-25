using Bank.Application.DTO.Account;
using Bank.Application.Resources;
using FluentValidation;

namespace Bank.Application.Validators.Account
{
    public class EditAccountRequestValidator : AbstractValidator<EditAccountRequest>
    {
        public EditAccountRequestValidator()
        {
            RuleFor(x => x.AccountId)
                .GreaterThan(0).WithMessage(AccountMessages.InvalidId);


        }
    }
}
