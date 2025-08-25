using Bank.Domain.Entities;

namespace Bank.Application.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account?> GetByIdAsync(int id);
    }
}
