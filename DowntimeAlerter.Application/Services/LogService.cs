using AutoMapper;
using DowntimeAlerter.Application.Models.Log;
using DowntimeAlerter.Application.Repository;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogService(ILogRepository repository, 
            IMapper mapper,  
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<LogVm> GetLogs()
        {
            var logs = _repository.GetLogsForWeek();
            List<LogVm> list = new(logs.Count);
            foreach (var log in logs)
            {
                list.Add(_mapper.Map<LogVm>(log));
            }
            return list;
        }

        public async Task<LogVm> GetLogAsync(int id)
        {
            var log = await _repository.Get(id);
            return _mapper.Map<LogVm>(log);
        }
    }
}
