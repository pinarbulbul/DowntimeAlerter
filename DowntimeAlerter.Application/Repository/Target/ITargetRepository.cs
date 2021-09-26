using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Repository
{
    public interface ITargetRepository: IRepository<Target>
    {
        IList<Target> GetTargets(string userName);
        Task RemoveTarget(Target target);
        IList<HealthCheckResult> GetHealthCheckResults(int targetId);
    }
}
