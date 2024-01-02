using breaking_bad.domain.Requests;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;

namespace breaking_bad.domain.Interfaces.Service
{
    public interface IEpisodeService
    {
        Task<Result<IEnumerable<EpisodeResponse>>> GetAllAsync(CancellationToken cancellationToken);

        Task<Result<EpisodeResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<Result<EpisodeResponse>> CreateAsync(EpisodeRequest episodeRequest, CancellationToken cancellationToken);

        Task<Result<EpisodeResponse>> UpdateAsync(EpisodeRequest episodeRequest, CancellationToken cancellationToken = default);
    }
}
