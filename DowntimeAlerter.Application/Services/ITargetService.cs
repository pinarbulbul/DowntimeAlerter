using DowntimeAlerter.Application.Models.Target;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Services
{
    public interface ITargetService
    {
        List<TargetVm> GetTargets();
        Task<EditVm> GetTargetEditAsync(int id);
        Task<DetailVm> GetTargetDetail(int id);
        Task<int> CreateTargetAsync(CreateVm createVm);
        Task EditTargetAsync(EditVm updateVm);
        Task DeleteTargetAsync(int id);
    }
}
