using breaking_bad.domain.Requests;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;

namespace breaking_bad.domain.Interfaces.Service
{
    public interface ICharacterService
    {
        Task<Result<IEnumerable<CharacterResponse>>> GetAllAsync(CancellationToken cancellationToken);

        Task<Result<CharacterResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<Result<CharacterResponse>> CreateAsync(CharacterRequest characterRequest, CancellationToken cancellationToken);

        Task<Result<CharacterResponse>> UpdateAsync(CharacterRequest characterRequest, CancellationToken cancellationToken = default);
    }
}
