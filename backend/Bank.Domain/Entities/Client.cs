using Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public int PersonId { get; set; }

        public string Password { get; set; } = string.Empty;

        public StatusClientId StatusClientId { get; set; } = StatusClientId.Active;

        public Person Person { get; set; } = new Person();

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
