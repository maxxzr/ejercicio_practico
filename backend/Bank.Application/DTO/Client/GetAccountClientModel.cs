using Bank.Application.DTO.Person;
using Bank.Domain.Enums;

namespace Bank.Application.DTO.Client
{
    public class GetAccountClientModel
    {
        public int ClientId { get; set; }

        public int AccountId { get; set; }

        public string Number { get; set; } = string.Empty;

        public decimal InitialBalance { get; set; }

        public decimal CurrentBalance { get; set; }


        public StatusAccountId StatusAccountId { get; set; }

        public int AccountTypeId { get; set; }

        public string AccountTypeDescription { get; set; } = string.Empty;

        public string StatusAccountDescription { get; set; } = string.Empty;

    }
}
