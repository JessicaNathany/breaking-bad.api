using breaking_bad.domain.Entities;

namespace breaking_bad.domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid code, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, bool asNoTracking = false);

        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<TEntity> GetByCodeAsync(Guid code, CancellationToken cancellationToken = default);

        Task<int> CountAsync();

        Task<int> SaveChangesAsync();
    }
}
