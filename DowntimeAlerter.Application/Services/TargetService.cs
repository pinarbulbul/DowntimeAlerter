using AutoMapper;
using DowntimeAlerter.Application.BackgroundJobs;
using DowntimeAlerter.Application.Models.Target;
using DowntimeAlerter.Application.Repository;
using DowntimeAlerter.Application.Validations;
using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.EntityFrameworkCore.TargetDb;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Services
{
    public class TargetService : ITargetService
    {
        private readonly ITargetRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBackgroundJobSender _backgroundJobService;
        private readonly ITargetValidations _targetValidations;

        public TargetService(ITargetRepository repository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IBackgroundJobSender backgroundJobService,
            ITargetValidations targetValidations)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _backgroundJobService = backgroundJobService;
            _targetValidations = targetValidations;
        }

        private string GetUserName()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public void ControlTarget(int id, Target target, string userName)
        {
            _targetValidations.IsTargetExist(id, target);
            _targetValidations.IsTargetAuthorized(id, target, userName);
        }

        public List<TargetVm> GetTargets()
        {
            var targets = _repository.GetTargets(GetUserName());
            List<TargetVm> list = new(targets.Count);
            foreach (var target in targets)
            {
                list.Add(_mapper.Map<TargetVm>(target));
            }
            return list;
        }

        public async Task<int> CreateTargetAsync(CreateVm createVm)
        {
            var target = _mapper.Map<Target>(createVm);
            target.CreationDate = DateTime.Now;
            target.CreatedBy = GetUserName();

            await _repository.AddAsync(target);

            if (target.Id >0)
            {
                _backgroundJobService.AddOrUpdateHealthCheckJob(target.Id, target.MonitoringIntervalInMinutes, target.CreatedBy);
            }

            return target.Id;
        }

        private async Task<Target> GetTargetAsync(int id)
        {
            var target = await _repository.Get(id);
            ControlTarget(id, target, GetUserName());
            return target;
        }

        public async Task<EditVm> GetTargetEditAsync(int id)
        {
            var target = await GetTargetAsync(id);
            return _mapper.Map<EditVm>(target);
        }

        public async Task EditTargetAsync(EditVm editVm)
        {
            var target = await GetTargetAsync(editVm.Id);
            target.Name = editVm.Name;
            target.Url = editVm.Url;
            target.MonitoringIntervalInMinutes = editVm.MonitoringIntervalInMinutes;
            target.LastUpdateDate = DateTime.Now;
            await _repository.Update(target);

            if (editVm.Id >0)
            {
                _backgroundJobService.AddOrUpdateHealthCheckJob(target.Id, target.MonitoringIntervalInMinutes, target.CreatedBy);
            }
        }

        public async Task DeleteTargetAsync(int id)
        {
            var target = await GetTargetAsync(id);
            await _repository.RemoveTarget(target);
            _backgroundJobService.RemoveHealthCheckJob(id);
        }

        public async Task<DetailVm> GetTargetDetail(int id)
        {
            var target = await GetTargetAsync(id);
            var checkResults = _repository.GetHealthCheckResults(id);
            
            List<CheckResultVm> checkResultVmlist = new(checkResults.Count);
            foreach (var result in checkResults)
            {
                checkResultVmlist.Add(_mapper.Map<CheckResultVm>(result));
            }

            return new DetailVm()
            {
                Name = target.Name,
                Url = target.Url,
                MonitoringIntervalInMinutes = target.MonitoringIntervalInMinutes,
                CheckResults = checkResultVmlist
            };
        }
    }
}
