using Bank.Domain.Enums;

namespace Bank.Application.DTO.Person
{
    public class BasePersonRequest
    {
        public string DocumentNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public GenderId GenderId { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; } = string.Empty;

    }
}
