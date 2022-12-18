using Microsoft.EntityFrameworkCore;

namespace one_api.Infra
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
            base.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Domain.Entities.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder _builder)
        {
            base.OnModelCreating(_builder);

            _builder.Entity<Domain.Entities.Category>(new Map.CategoryMap().Configure);
        }
    }
}
