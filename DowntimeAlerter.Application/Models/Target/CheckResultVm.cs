using DowntimeAlerter.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DowntimeAlerter.Application.Models.Target
{
    public class CheckResultVm
    {
        [Display(Name = "Execution Time")]
        public DateTime ExecutionTime { get; set; }
        public HealthCheckResultEnum Result { get; set; }

        [Display(Name = "Status Code")]
        public int StatusCode { get; set; }
    }
}
