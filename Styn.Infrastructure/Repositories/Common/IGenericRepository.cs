using System.Linq.Expressions;

namespace Styn.Infrastructure.Repositories.Common
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);

        // Métodos adicionales que podrían ser parte de IGenericRepository
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
