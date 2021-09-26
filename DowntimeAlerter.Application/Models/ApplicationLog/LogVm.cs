using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Models.ApplicationLog
{
    public class LogVm
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        [Display(Name = "Health Check Time")]
        public DateTime TimeStamp { get; set; }

        public string Exception { get; set; }
    }
}
