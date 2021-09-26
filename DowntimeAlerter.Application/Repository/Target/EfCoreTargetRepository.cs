using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.EntityFrameworkCore.Repository;
using DowntimeAlerter.EntityFrameworkCore.TargetDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Repository
{
    public class EfCoreTargetRepository : EfCoreRepository<Target, TargetDbContext>, ITargetRepository
    {
        private readonly TargetDbContext _context;

        public EfCoreTargetRepository(TargetDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Target> GetTargets(string userName)
        {
            return _context.Target.Where(x => x.CreatedBy == userName).ToList();
        }

        public async Task RemoveTarget(Target target)
        {
            _context.Target.Remove(target);
            await _context.SaveChangesAsync();
        }

        public IList<HealthCheckResult> GetHealthCheckResults(int targetID)
        {
            return _context.HealthCheckResult.Where(x => x.TargetId == targetID)
                .OrderByDescending(x => x.ExecutionTime)
                .ToList();
        }
    }
}
