using breaking_bad.application.Validations;
using breaking_bad.domain.Entities;
using breaking_bad.domain.Interfaces.Repository;
using breaking_bad.domain.Interfaces.Service;
using breaking_bad.domain.Responses;
using breaking_bad.domain.Share;
using Microsoft.Extensions.Logging;

namespace breaking_bad.application.Service
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly ILogger<EpisodeService> _logger;
        public EpisodeService(IEpisodeRepository episodeRepository, ILogger<EpisodeService> logger)
        {
            _episodeRepository = episodeRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<Episode>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var episodes =  await _episodeRepository.GetAllAsync(cancellationToken);

                if (episodes == null)
                    return Result<IEnumerable<Episode>>.Failure("Episodes not found");

                return Result<IEnumerable<Episode>>.Success(episodes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting episodes.", ex.Message);
                throw;
            }
        }

        public async Task<Result<EpisodeResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var episode = await _episodeRepository.GetByIdAsync(id);

                if (episode is null)
                    return Result<EpisodeResponse>.Failure("Episode not found");

                var episodeResponse = MapperBannerResponse(episode);

                return Result<EpisodeResponse>.Success(episodeResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting episode.", ex.Message);
                throw;
            }
        }
        
        public async Task<Result<EpisodeResponse>> CreateAsync(Episode episode, CancellationToken cancellationToken = default)
        {
            try
            {
                var episodeRepository = await _episodeRepository.GetByIdAsync(episode.Id, cancellationToken);

                if(episodeRepository != null)
                {
                    return Result<EpisodeResponse>.Failure("There is already an episode with this {episode.Id} registered");
                }
                
                var episodeValidation = new EpoisodeValidation();
                var episodeValidationResult = episodeValidation.Validate(episode);

                if (!episodeValidationResult.IsValid)
                {
                    var errors = episodeValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    _logger.LogError("Validation failed: {ValidationErrors}", string.Join(", ", errors));
                    return Result<EpisodeResponse>.Failure(string.Join(", ", errors));
                }

                var newEpisode = new Episode(
                    episode.Name, 
                    episode.Description, 
                    episode.AirDate, 
                    episode.Season,
                    episode.Characters);

                await _episodeRepository.SaveAsync(newEpisode, cancellationToken);

                var episodeResponse = MapperBannerResponse(newEpisode);

                return Result<EpisodeResponse>.Success(episodeResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the data.", ex.Message);
                throw;
            }
        }
        
        public async Task<Result> UpdateAsync(Episode episode, CancellationToken cancellationToken = default)
        {
            try
            {
                var episodeRepository = await _episodeRepository.GetByIdAsync(episode.Id, cancellationToken);

                if(episodeRepository is null)
                {
                    return Result.Failure($"There is no episode with this {episode.Id} registered");
                }

                var episodeValidation = new EpoisodeValidation();
                var episodeValidationResult = episodeValidation.Validate(episode);

                if (!episodeValidationResult.IsValid)
                {
                    var errors = episodeValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    _logger.LogInformation("Validation failed: {ValidationErrors}", string.Join(", ", errors));
                    return Result.Failure(string.Join(", ", errors));
                }

                var episodeUpdate = new Episode(
                    episode.Name,
                    episode.Description,
                    episode.AirDate,
                    episode.Season,
                    episode.Characters);

                await _episodeRepository.UpdateAsync(episodeUpdate, cancellationToken);

                var episodeResponse = MapperBannerResponse(episodeUpdate);

                return Result<EpisodeResponse>.Success(episodeResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the data.", ex.Message);
                throw;
            }
        }

        private EpisodeResponse MapperBannerResponse(Episode newEpisode)
        {
            return new EpisodeResponse
            {
                Id = newEpisode.Id,
                Name = newEpisode.Name,
                Description = newEpisode.Description,
                AirDate = newEpisode.AirDate,
                SeasonId = newEpisode.SeasonId,
                Season = newEpisode.Season,
                Characters = newEpisode.Characters
            };
        }

    }
}
