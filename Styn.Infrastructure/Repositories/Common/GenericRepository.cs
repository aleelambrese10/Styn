using Styn.Domain.Entities.Common;
using Styn.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Styn.Infrastructure.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StynContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(StynContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            // Note: Assuming that the entity has an 'Id' property.
            var existingEntity = await _entities.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Entity with the given ID not found");
            }
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Entity with the given ID not found");
            }
        }

        // ... Include other methods if needed, such as FindByCondition and GetWhere ...

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
             .Where(expression).AsNoTracking();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
    }
}
