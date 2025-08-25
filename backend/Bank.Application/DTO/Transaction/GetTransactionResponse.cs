using Bank.Domain.Enums;

namespace Bank.Application.DTO.Transaction
{
    public class GetTransactionResponse
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;

        public string AccountTypeDescription { get; set; } = string.Empty;

        public string StatusAccountDescription { get; set; } = string.Empty;


        public int TransactionId { get; set; }

        public TransactionTypeId TransactionTypeId { get; set; }

        public DateTime DateTransaction { get; set; }

        public decimal InitialBalance { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}