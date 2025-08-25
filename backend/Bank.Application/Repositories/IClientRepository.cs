using Bank.Domain.Entities;

namespace Bank.Application.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client?> GetByIdAsync(int id);
    }
}
