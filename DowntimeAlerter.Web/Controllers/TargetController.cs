using DowntimeAlerter.Application.Models.Target;
using DowntimeAlerter.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DowntimeAlerter.Web.Controllers
{
    [Authorize]
    public class TargetController : Controller
    {
        private readonly ITargetService _targetService;
        private readonly ILogger<TargetController> _logger;

        public TargetController(ITargetService targetService, ILogger<TargetController> logger)
        {
            _targetService = targetService;
            _logger = logger;
        }

        public IActionResult List()
        {
            _logger.LogInformation("Welcome to Target List Page");
            var list=_targetService.GetTargets();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVm createVm)
        {
            if (ModelState.IsValid)
            {
                await _targetService.CreateTargetAsync(createVm);
               
                return RedirectToAction(nameof(List));
            }
            return View(createVm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var editVm = await _targetService.GetTargetEditAsync(id);
            return View(editVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVm editVm)
        {
            if (editVm.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _targetService.EditTargetAsync(editVm);
                return RedirectToAction(nameof(List));
            }
            return View(editVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var editVm = await _targetService.GetTargetEditAsync(id);
            return View(editVm);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            await _targetService.DeleteTargetAsync(id);

            return RedirectToAction(nameof(List));
        }


        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var detailVm = await _targetService.GetTargetDetail(id);
            return View(detailVm);
        }

    }
}
