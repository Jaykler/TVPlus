using Microsoft.EntityFrameworkCore;
using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Infrastructure.Context;

namespace TVPlus.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly TVPlusContext _dbContext;
        private readonly DbSet<TEntity> _DbEntity;
        public BaseRepository(TVPlusContext dbContext)
        {
            _dbContext = dbContext;
            _DbEntity = _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _DbEntity.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }


    }
}
