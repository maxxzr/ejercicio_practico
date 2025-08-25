using Bank.Domain.Enums;

namespace Bank.Application.DTO.Person
{
    public class GetPersonModel : BasePersonRequest
    {
        public int PersonId { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

    }
}
