using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.EntityFrameworkCore.TargetDb.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DowntimeAlerter.EntityFrameworkCore.TargetDb
{
    public class TargetDbContext : DbContext
    {
        public DbSet<Target> Target { get; set; }
        public DbSet<HealthCheckResult> HealthCheckResult { get; set; }

        public TargetDbContext(DbContextOptions<TargetDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TargetEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HealthCheckResultEntityConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TargetDbContext).Assembly);
        }
    }
}
