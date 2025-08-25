using Bank.Domain.Enums;

namespace Bank.Application.DTO.Account
{
    public class EditAccountRequest : BaseAccountRequest
    {
        public int AccountId { get; set; }

        public StatusAccountId StatusAccountId { get; set; }
    }
}