using Bank.Application.DTO.Person;
using Bank.Domain.Enums;

namespace Bank.Application.DTO.Client
{
    public class GetClientModel : GetPersonModel
    {
        public int ClientId { get; set; }

        public string Password { get; set; } = string.Empty;

        public StatusClientId StatusClientId { get; set; }

    }
}
