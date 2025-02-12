using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity>(DataContext context) where TEntity : class
    {
        protected readonly DataContext _context = context;
        protected readonly DbSet<TEntity> _db = context.Set<TEntity>();

        public async Task<TEntity?> AddAsync(TEntity entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Addition failed, error message: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var entities = await _db.ToListAsync();
            return entities;
        }
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                Console.WriteLine("GetAsync, expression == null");
                return null;
            }
            var entity = await _db.FirstOrDefaultAsync(expression);
            return entity;
        }
        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                await _context.SaveChangesAsync();
                _db.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update process failed, error message: {ex.Message}");
            }
        }
        public async Task RemoveAsync(TEntity enity)
        {
            try
            {
                _db.Remove(enity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deletetion failed, error message: {ex.Message}");
            }
        }
    }

}
