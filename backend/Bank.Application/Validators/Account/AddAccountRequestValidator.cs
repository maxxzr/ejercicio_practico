using Bank.Application.DTO.Account;
using FluentValidation;

namespace Bank.Application.Validators.Account
{
    public class AddAccountRequestValidator : AbstractValidator<AddAccountRequest>
    {
        public AddAccountRequestValidator()
        {
            Include(new BaseAccountRequestValidator());
        }
    }
}
