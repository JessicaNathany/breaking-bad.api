using breaking_bad.domain.Interfaces.Repository;
using breaking_bad.infrastructure.Data.Repostory;

namespace breaking_bad.api.ConfigDependency
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
