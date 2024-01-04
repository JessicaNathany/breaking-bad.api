using breaking_bad.application.Validations;
using breaking_bad.domain.Entities;
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
        public async Task<Result<CharacterResponse>> CreateAsync(CharacterRequest characterRequest, CancellationToken cancellationToken)
        {
            try
            {
                var character = await _characterRepository.GetByIdAsync(characterRequest.Id, cancellationToken);

                if (character != null)
                {
                    return Result<CharacterResponse>.Failure("There is already an character with this {character.Id} registered");
                }

                var characterValidation = new CharacterValidation();
                var characterValidationResult = characterValidation.Validate(character);

                if (!characterValidationResult.IsValid)
                {
                    var errors = characterValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    _logger.LogError("Validation failed: {ValidationErrors}", string.Join(", ", errors));
                    return Result<CharacterResponse>.Failure(string.Join(", ", errors));
                }

                var newCharacter = new Character(
                    character.Name,
                    character.NameActor,
                    character.Status,
                    character.Gender,
                    character.ImageUrl,
                    character.Job,
                    character.Episodes);

                await _characterRepository.SaveAsync(newCharacter, cancellationToken);

                var episodeResponse = MapperCharacterResponse(newCharacter);

                return Result<CharacterResponse>.Success(episodeResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the data.", ex.Message);
                throw;
            }
        }

        public async Task<Result<IEnumerable<CharacterResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var characterResponse = new List<CharacterResponse>();

                var characters = await _characterRepository.GetAllAsync(cancellationToken);

                if (characters == null)
                    return Result<IEnumerable<CharacterResponse>>.Failure("Character not found");

                characterResponse.AddRange(characters.Select(MapperCharacterResponse));

                return Result<IEnumerable<CharacterResponse>>.Success(characterResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting characters.", ex.Message);
                throw;
            }
        }

        public async Task<Result<CharacterResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var character = await _characterRepository.GetByIdAsync(id);

                if (character is null)
                    return Result<CharacterResponse>.Failure("Character not found");

                var characterResponse = MapperCharacterResponse(character);

                return Result<CharacterResponse>.Success(characterResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting character.", ex.Message);
                throw;
            }
        }

        public async Task<Result<CharacterResponse>> UpdateAsync(CharacterRequest characterRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var character = await _characterRepository.GetByIdAsync(characterRequest.Id, cancellationToken);

                if (character is null)
                {
                    return Result<CharacterResponse>.Failure($"There is no character with this {characterRequest.Id} registered");
                }

                var characterValidation = new CharacterValidation();
                var characterValidationResult = characterValidation.Validate(character);

                if (!characterValidationResult.IsValid)
                {
                    var errors = characterValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    _logger.LogInformation("Validation failed: {ValidationErrors}", string.Join(", ", errors));
                    return Result<CharacterResponse>.Failure(string.Join(", ", errors));
                }

                character.Update(
                    character.Name, 
                    character.NameActor, 
                    character.Status, 
                    character.Gender, 
                    character.ImageUrl,
                    character.Job,
                    character.Episodes);

                await _characterRepository.UpdateAsync(character, cancellationToken);

                var episodeResponse = MapperCharacterResponse(character);

                return Result<CharacterResponse>.Success(episodeResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the data.", ex.Message);
                throw;
            }
        }

        private CharacterResponse MapperCharacterResponse(Character character)
        {
            return new CharacterResponse
            {
                Id = character.Id,
                Name = character.Name,
                NameActor = character.NameActor,
                Status = character.Status,
                Gender = character.Gender,
                ImageUrl = character.ImageUrl,
                Job = character.Job,
                Episodes = character.Episodes
            };
        }
    }
}
