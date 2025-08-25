namespace Bank.Application.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T id);
        IQueryable<T> Fetch();
        Task CommitAsync();
    }
}
