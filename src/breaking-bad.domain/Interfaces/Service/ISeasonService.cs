using breaking_bad.domain.Requests;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;

namespace breaking_bad.domain.Interfaces.Service
{
    public interface ISeasonService
    {
        Task<Result<IEnumerable<SeasonResponse>>> GetAllAsync(CancellationToken cancellationToken);

        Task<Result<SeasonResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<Result<SeasonResponse>> CreateAsync(SeasonRequest seasonRequest, CancellationToken cancellationToken);

        Task<Result<SeasonResponse>> UpdateAsync(SeasonRequest seasonRequest, CancellationToken cancellationToken = default);
    }
}
