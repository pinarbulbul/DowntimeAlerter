using System;
using System.ComponentModel.DataAnnotations;

namespace DowntimeAlerter.Application.Models.Target
{
    public class TargetVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        [Display(Name = "Interval for Health Check (Minutes)")]
        public int MonitoringIntervalInMinutes { get; set; }

        [Display(Name = "Creator")]
        public string CreatedBy { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate{ get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

    }
}
