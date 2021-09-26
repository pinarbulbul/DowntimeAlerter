using System;
using System.Threading.Tasks;

namespace DowntimeAlerter.Infrastructure.BackgroundJob
{
    public interface IHealthCheckJob
    {
        Task CheckHealth(int targetId, string userMail);
    
    }
}
