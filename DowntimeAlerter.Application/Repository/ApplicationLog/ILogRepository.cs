using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.EntityFrameworkCore.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Repository
{
    public interface ILogRepository : IRepository<Log>
    {
        IList<Log> GetLogsForWeek();
    }
}
