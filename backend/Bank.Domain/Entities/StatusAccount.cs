using Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class StatusAccount
    {
        public StatusAccountId StatusAccountId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
