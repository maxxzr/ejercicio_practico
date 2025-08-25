using Bank.Domain.Entities;

namespace Bank.Application.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person?> GetByIdAsync(int id);
    }
}
