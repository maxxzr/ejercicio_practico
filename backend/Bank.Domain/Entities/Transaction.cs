using Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

        public DateTime DateTransaction { get; set; }

        public TransactionTypeId TransactionTypeId { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }


        public decimal InitialBalance { get; set; }

        public Account Account { get; set; }
    }
}
