using Bank.Application.DTO.Client;
using Bank.Application.Resources;
using FluentValidation;

namespace Bank.Application.Validators.Client
{
    public class EditClientRequestValidator : AbstractValidator<EditClientRequest>
    {
        public EditClientRequestValidator()
        {
            Include(new BaseClientRequestValidator());

            RuleFor(x => x.ClientId)
                .GreaterThan(0).WithMessage(ClientMessages.InvalidId);

            RuleFor(x => x.PersonId)
                .GreaterThan(0).WithMessage(PersonMessages.InvalidId);

            RuleFor(x => x.StatusClientId)
                .IsInEnum().WithMessage(ClientMessages.InvalidStatusClientId);
        }
    }
}
