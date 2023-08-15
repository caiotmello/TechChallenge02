using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);

    }
}
