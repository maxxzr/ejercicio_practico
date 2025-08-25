using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(BankDbContext context) : base(context)
        {
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await Fetch().FirstOrDefaultAsync(x => x.AccountId == id);
        }
    }
}
