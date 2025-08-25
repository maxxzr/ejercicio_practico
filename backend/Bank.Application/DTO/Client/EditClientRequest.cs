using Bank.Domain.Enums;

namespace Bank.Application.DTO.Client
{
    public class EditClientRequest : BaseClientRequest
    {
        public int ClientId { get; set; }

        public int PersonId { get; set; }

        public StatusClientId StatusClientId { get; set; }
    }
}