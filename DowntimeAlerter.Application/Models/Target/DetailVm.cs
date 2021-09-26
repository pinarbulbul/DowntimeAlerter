using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DowntimeAlerter.Application.Models.Target
{
    public class DetailVm
    {
        public string Name { get; set; }
        public string Url { get; set; }

        [Display(Name = "Interval for Health Check (Minutes)")]
        public int MonitoringIntervalInMinutes { get; set; }

        [Display(Name = "Health Check Results")]
        public IList<CheckResultVm> CheckResults { get; set; }
    }
}
