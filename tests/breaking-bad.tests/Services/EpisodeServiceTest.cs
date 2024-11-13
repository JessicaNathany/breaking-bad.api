using breaking_bad.application.Service;
using breaking_bad.domain.Entities;
using breaking_bad.domain.Interfaces.Repository;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace breaking_bad.tests.Services
{
    public class EpisodeServiceTest
    {
        private readonly Mock<IEpisodeRepository> _episodeRepositoryMock;
        private readonly Mock<ILogger<EpisodeService>> _loggerMock;

        public EpisodeServiceTest()
        {
           _episodeRepositoryMock = new Mock<IEpisodeRepository>();
           _loggerMock = new Mock<ILogger<EpisodeService>>();
        }

        [Fact]
        public async void GetByIdAsync_ShoulBe_EpisodeNotFound()
        {
            // Arrange
            var idEpisode = 1;


            // Act
            var looggerMock = Mock.Of<ILogger<EpisodeService>>();
            var stringLocalizerMock = Mock.Of<IStringLocalizer<EpisodeService>>();

            _episodeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult<Episode>(null));

            var service = new EpisodeService(_episodeRepositoryMock.Object, looggerMock);
            
            var result = await service.GetByIdAsync(idEpisode, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Error);
            Assert.Equal($"Episode not found.", result.Error);
        }


    }
}
