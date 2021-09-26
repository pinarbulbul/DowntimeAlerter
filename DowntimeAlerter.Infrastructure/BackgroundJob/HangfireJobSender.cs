using DowntimeAlerter.Application.BackgroundJobs;
using Hangfire;
using Hangfire.Common;
using System;
using System.Threading.Tasks;

namespace DowntimeAlerter.Infrastructure.BackgroundJob
{
    public class HangfireJobSender : IBackgroundJobSender
    {       
        private readonly IRecurringJobManager _jobManager;
        private readonly IHealthCheckJob _healthCheckjob;

        public HangfireJobSender(IRecurringJobManager jobManager,
            IHealthCheckJob healthCheckjob)
        {
            _jobManager = jobManager;
            _healthCheckjob = healthCheckjob;
        }     

        public void AddOrUpdateHealthCheckJob(int id, int intervalInMinutes, string userMail)
        {
            var job = Job.FromExpression(() => HealthCheckJob(id, userMail));
            _jobManager.AddOrUpdate(id.ToString(), job, cronExpression: $"*/{intervalInMinutes} * * * *",
               new RecurringJobOptions { TimeZone = TimeZoneInfo.Utc, QueueName = "default" });
        }  

        public void RemoveHealthCheckJob(int id)
        {
            _jobManager.RemoveIfExists(id.ToString());
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task HealthCheckJob(int id, string userMail)
        {
            await _healthCheckjob.CheckHealth(id, userMail);
        }
    }
}
