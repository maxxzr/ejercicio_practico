using Bank.Domain.Enums;

namespace Bank.Application.DTO.Account
{
    public class GetAccountModel : BaseAccountRequest
    {
        public int AccountId { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public StatusAccountId StatusAccountId { get; set; }

        public string StatusAccountDescription { get; set; } = string.Empty;

        public string AccountTypeDescription { get; set; } = string.Empty;

    }
}
