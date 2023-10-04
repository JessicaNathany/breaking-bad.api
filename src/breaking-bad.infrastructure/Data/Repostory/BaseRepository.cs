using breaking_bad.domain.Entities;
using breaking_bad.domain.Interfaces.Repository;
using breaking_bad.infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace breaking_bad.infrastructure.Data.Repostory
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly BreakingBadContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(BreakingBadContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task DeleteAsync(Guid code)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Code == code);

            _dbSet.Remove(entity);
            await SaveAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false)
        {
            var query = _context.Set<TEntity>();

            if (asNoTracking)
                return await query.AsNoTracking().ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByCodeAsync(Guid code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async  Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync(entity);
        }
    }
}
