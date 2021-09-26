using DowntimeAlerter.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.BackgroundJobs
{
    public interface IBackgroundJobSender
    {
        void AddOrUpdateHealthCheckJob(int id, int intervalInMinutes, string userMail);
        void RemoveHealthCheckJob(int id);
        Task HealthCheckJob(int id, string userMail);
     }
}