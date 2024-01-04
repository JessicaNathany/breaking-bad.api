using breaking_bad.domain.Interfaces.Service;
using breaking_bad.domain.Requests;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;

namespace breaking_bad.application.Service
{
    public class SeasonService : ISeasonService
    {
        public Task<Result<SeasonResponse>> CreateAsync(SeasonRequest seasonRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<SeasonResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<SeasonResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<SeasonResponse>> UpdateAsync(SeasonRequest seasonRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
