using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.EntityFrameworkCore.LogDb;
using DowntimeAlerter.EntityFrameworkCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Repository
{
    public class EfCoreLogRepository : EfCoreRepository<Log, LogDbContext>, ILogRepository
    {
        private readonly LogDbContext _context;
        public EfCoreLogRepository(LogDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Log> GetLogsForWeek()
        {
            return _context.Log.Where(x => x.TimeStamp > DateTime.Today.AddDays(-7))
                .OrderByDescending(x => x.TimeStamp)
                .ToList();
        }
    }
}
