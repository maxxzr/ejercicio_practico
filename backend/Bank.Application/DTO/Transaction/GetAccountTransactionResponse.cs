using Bank.Domain.Enums;

namespace Bank.Application.DTO.Transaction
{
    public class GetAccountTransactionResponse
    {
        public int AccountId { get; set; }

        public int TransactionId { get; set; }

        public TransactionTypeId TransactionTypeId { get; set; }

        public DateTime DateTransaction { get; set; }

        public decimal InitialBalance { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}