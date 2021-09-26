using DowntimeAlerter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DowntimeAlerter.EntityFrameworkCore.LogDb
{
    public class LogDbContext: DbContext
    {
        public DbSet<Log> Log { get; set; }
      
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogDbContext).Assembly);
        }
    }
}
