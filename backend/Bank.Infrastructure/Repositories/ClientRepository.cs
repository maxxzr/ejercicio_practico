using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class ClientRepository(BankDbContext context) : BaseRepository<Client>(context), IClientRepository
    {
        public async Task<Client?> GetByIdAsync(int id)
        {
            return await Fetch().FirstOrDefaultAsync(x => x.ClientId == id);
        }
    }
}
