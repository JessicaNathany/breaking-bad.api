using breaking_bad.domain.Interfaces.Repository;
using breaking_bad.domain.Interfaces.Service;
using breaking_bad.domain.Requests;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;
using Microsoft.Extensions.Logging;

namespace breaking_bad.application.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ILogger<CharacterService> _logger;
        public CharacterService(ICharacterRepository characterRepository, ILogger<CharacterService> logger)
        {
            _characterRepository = characterRepository;
            _logger = logger;
        }
        public Task<Result<CharacterResponse>> CreateAsync(CharacterRequest characterRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<CharacterResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CharacterResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CharacterResponse>> UpdateAsync(CharacterRequest characterRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
