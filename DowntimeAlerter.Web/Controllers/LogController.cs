using DowntimeAlerter.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DowntimeAlerter.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;

        }
        public IActionResult List()
        {
            var list = _logService.GetLogs();
            return View(list);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var logVm = await _logService.GetLogAsync(id);
            return View(logVm);
        }
    }
}
