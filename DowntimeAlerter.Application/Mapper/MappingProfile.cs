﻿using AutoMapper;
using DowntimeAlerter.Application.Models.ApplicationLog;
using DowntimeAlerter.Application.Models.Target;
using DowntimeAlerter.Domain.Entities;

namespace DowntimeAlerter.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TargetVm, Target>();
            CreateMap<Target, TargetVm>();
            CreateMap<CreateVm, Target>();
            CreateMap<Target, CreateVm>();
            CreateMap<EditVm, Target>();
            CreateMap<Target, EditVm>();
            CreateMap<CheckResultVm, HealthCheckResult>();
            CreateMap<HealthCheckResult, CheckResultVm>();

            CreateMap<Log, LogVm>();

        }

    }
}
