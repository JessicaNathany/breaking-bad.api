using breaking_bad.domain.Entities;
using breaking_bad.domain.Share;

namespace breaking_bad.domain.Interfaces.Service
{
    public interface IEpisodeService
    {
        Task<Result<IEnumerable<Episode>>> GetAllAsync();

        Task<Result<Episode>> GetByIdAsync(int id);
    }
}
