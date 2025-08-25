using Bank.Application.DTO.Person;

namespace Bank.Application.DTO.Client
{
    public class BaseClientRequest : BasePersonRequest
    {
        public string Password { get; set; } = string.Empty;

        public string RepeatPassword { get; set; } = string.Empty;
    }
}
