using breaking_bad.domain.Entities;
using breaking_bad.domain.Interfaces.Repository;
using breaking_bad.infrastructure.Data.Context;

namespace breaking_bad.infrastructure.Data.Repostory
{
    public class SeasonRepository : BaseRepository<Season>, ISeasonRespository
    {
        public SeasonRepository(BreakingBadContext context) : base(context)
        {
        }
    }
}
