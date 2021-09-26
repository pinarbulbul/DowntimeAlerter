using System;
using System.ComponentModel.DataAnnotations;

namespace DowntimeAlerter.Application.Models.Target
{
    public class EditVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Interval for Health Check (Minutes)")]
        public int MonitoringIntervalInMinutes { get; set; }
    }
}
