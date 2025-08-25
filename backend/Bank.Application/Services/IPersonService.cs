using Bank.Application.DTO.Person;
namespace Bank.Application.Services
{
    public interface IPersonService
    {
        Task<GetPersonModel> Get(int personId);

        Task<GetPersonModel> Add(AddPersonRequest person);

        Task Update(int personId, EditPersonRequest person);

        Task Delete(int personId);

        Task<List<GetPersonModel>> GetAll();
    }
}
