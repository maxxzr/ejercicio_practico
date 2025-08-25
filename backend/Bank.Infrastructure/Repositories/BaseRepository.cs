using Bank.Application.Repositories;
using Bank.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Repositories
{
    public class BaseRepository<T>(BankDbContext context) : IBaseRepository<T> where T : class
    {
        public async Task<T> AddAsync(T entity)
        {
            var addEntityTask = await context.Set<T>().AddAsync(entity);
            return addEntityTask.Entity;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Fetch()
        {
            return context.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync(); ;
        }
    }
}
