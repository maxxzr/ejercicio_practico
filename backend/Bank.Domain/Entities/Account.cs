using Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Account
    {
        public int AccountId { get; set; }

        public int ClientId { get; set; }

        public string Number { get; set; } = string.Empty;

        public int AccountTypeId { get; set; }

        public decimal InitialBalance { get; set; }

        public decimal CurrentBalance { get; set; }

        public StatusAccountId StatusAccountId { get; set; } = StatusAccountId.Active;

        public required Client Client { get; set; }

        public required AccountType AccountType { get; set; }

        public required StatusAccount StatusAccount { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
