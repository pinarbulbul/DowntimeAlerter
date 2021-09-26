using DowntimeAlerter.Application.Models.ApplicationLog;
using DowntimeAlerter.Application.Models.Target;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Services
{
    public interface ILogService
    {
        List<LogVm> GetLogs();
        Task<LogVm> GetLogAsync(int id);
    }
}
