using breaking_bad.domain.Entities;

namespace breaking_bad.domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> SaveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid code);

        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByCodeAsync(Guid code);

        Task<int> CountAsync();

        Task<int> SaveChangesAsync();
    }
}
