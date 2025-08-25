using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class PersonRepository(BankDbContext context) : BaseRepository<Person>(context), IPersonRepository
    {
        public async Task<Person?> GetByIdAsync(int id)
        {
            return await Fetch().FirstOrDefaultAsync(x => x.PersonId == id);
        }
    }
}
