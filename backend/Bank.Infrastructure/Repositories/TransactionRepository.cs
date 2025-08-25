using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Infrastructure.Data;

namespace Bank.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BankDbContext context) : base(context)
        {
        }
    }
}
