using breaking_bad.domain.Entities;
using breaking_bad.domain.Interfaces.Repository;
using breaking_bad.domain.Interfaces.Service;
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

        public async Task<Result<IEnumerable<Episode>>> GetAllAsync()
        {
            try
            {
                var episodes =  await _episodeRepository.GetAllAsync();

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

        public async Task<Result<Episode>> GetByIdAsync(int id)
        {
            try
            {
                var episode = await _episodeRepository.GetByIdAsync(id);

                if (episode == null)
                    return Result<Episode>.Failure("Episode not found");

                return Result<Episode>.Success(episode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting episode.", ex.Message);
                throw;
            }
        }   
    }
}
