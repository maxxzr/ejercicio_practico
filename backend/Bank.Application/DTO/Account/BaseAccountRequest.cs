using Bank.Application.DTO.Person;
using Bank.Domain.Enums;

namespace Bank.Application.DTO.Account
{
    public class BaseAccountRequest
    {
        public int ClientId { get; set; }

        public string Number { get; set; } = string.Empty;

        public int AccountTypeId { get; set; }

        public decimal InitialBalance { get; set; }
    }
}
