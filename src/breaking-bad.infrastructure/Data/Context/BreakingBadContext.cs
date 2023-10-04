using breaking_bad.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace breaking_bad.infrastructure.Data.Context
{
    public class BreakingBadContext : DbContext
    {
        public BreakingBadContext(DbContextOptions<BreakingBadContext> options)
        : base(options)
        {
        }

        public DbSet<Episode> Episodes { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Season> Seasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreakingBadContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
