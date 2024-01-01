using breaking_bad.domain.Entities;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;

namespace breaking_bad.domain.Interfaces.Service
{
    public interface IEpisodeService
    {
        Task<Result<IEnumerable<Episode>>> GetAllAsync(CancellationToken cancellationToken);

        Task<Result<Episode>> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<Result<EpisodeResponse>> CreateAsync(Episode episode, CancellationToken cancellationToken);

        Task<Result> UpdateAsync(Episode episode, CancellationToken cancellationToken = default);
    }
}
