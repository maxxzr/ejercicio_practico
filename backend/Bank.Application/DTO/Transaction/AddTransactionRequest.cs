using Bank.Domain.Enums;

namespace Bank.Application.DTO.Transaction
{
    public class AddTransactionRequest
    {
        public int AccountId { get; set; }

        public TransactionTypeId TransactionTypeId { get; set; }

        public decimal Amount { get; set; }
    }
}