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
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRespository _seasonRepository;
        private readonly ILogger<ISeasonService> _logger;
        public SeasonService(ISeasonRespository seasonRespository, ILogger<ISeasonService> logger)
        {
            _seasonRepository = seasonRespository;
            _logger = logger;
        }
        public async Task<Result<SeasonResponse>> CreateAsync(SeasonRequest seasonRequest, CancellationToken cancellationToken)
        {
            try
            {
                var season = await _seasonRepository.GetByIdAsync(seasonRequest.Id, cancellationToken);

                if (season != null)
                {
                    return Result<SeasonResponse>.Failure("There is already an season with this {season.Id} registered");
                }

                var seasonValidation = new SeasonValidation();
                var seasonValidationResult = seasonValidation.Validate(season);

                if (!seasonValidationResult.IsValid)
                {
                    var errors = seasonValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    _logger.LogError("Validation failed: {ValidationErrors}", string.Join(", ", errors));
                    return Result<SeasonResponse>.Failure(string.Join(", ", errors));
                }

                var newSeason = new Season(season.Name, season.AirDate, season.Description, season.Episodes);

                await _seasonRepository.SaveAsync(newSeason, cancellationToken);

                var episodeResponse = MapperSeasonResponse(newSeason);

                return Result<SeasonResponse>.Success(episodeResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the data.", ex.Message);
                throw;
            }
        }

        public async Task<Result<IEnumerable<SeasonResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var seasonsResponse = new List<SeasonResponse>();

                var season = await _seasonRepository.GetAllAsync(cancellationToken);

                if (season == null)
                    return Result<IEnumerable<SeasonResponse>>.Failure("Character not found");

                seasonsResponse.AddRange(season.Select(MapperSeasonResponse));

                return Result<IEnumerable<SeasonResponse>>.Success(seasonsResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting seasons.", ex.Message);
                throw;
            }
        }

        public async Task<Result<SeasonResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var season = await _seasonRepository.GetByIdAsync(id);

                if (season is null)
                    return Result<SeasonResponse>.Failure("Season not found");

                var seasonResponse = MapperSeasonResponse(season);

                return Result<SeasonResponse>.Success(seasonResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting season.", ex.Message);
                throw;
            }
        }

        public async Task<Result<SeasonResponse>> UpdateAsync(SeasonRequest seasonRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var season = await _seasonRepository.GetByIdAsync(seasonRequest.Id, cancellationToken);

                if (season is null)
                {
                    return Result<SeasonResponse>.Failure($"There is no season with this {seasonRequest.Id} registered");
                }

                var seasonValidation = new SeasonValidation();
                var seasonValidationResult = seasonValidation.Validate(season);

                if (!seasonValidationResult.IsValid)
                {
                    var errors = seasonValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    _logger.LogInformation("Validation failed: {ValidationErrors}", string.Join(", ", errors));
                    return Result<SeasonResponse>.Failure(string.Join(", ", errors));
                }

                season.Update(season.Name, season.AirDate, season.Description, season.Episodes);

                await _seasonRepository.UpdateAsync(season, cancellationToken);

                var seasonResponse = MapperSeasonResponse(season);

                return Result<SeasonResponse>.Success(seasonResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the data.", ex.Message);
                throw;
            }
        }

        private SeasonResponse MapperSeasonResponse(Season season)
        {
            return new SeasonResponse
            {
               Id = season.Id,
               Name = season.Name,
               AirDate = season.AirDate,
               Description = season.Description,
               Episodes = season.Episodes
            };
        }
    }
}
