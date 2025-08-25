using Bank.Application.DTO.Client;
using FluentValidation;

namespace Bank.Application.Validators.Client
{
    public class AddClientRequestValidator : AbstractValidator<AddClientRequest>
    {
        public AddClientRequestValidator()
        {
            Include(new BaseClientRequestValidator());
        }
    }
}
