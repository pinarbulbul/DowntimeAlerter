using DowntimeAlerter.Domain.Entities;
using DowntimeAlertereAlerter.Application.Exceptions;
using System;

namespace DowntimeAlerter.Application.Validations
{
    public class TargetValidations : ITargetValidations
    {
        public void IsTargetExist(int id, Target target)
        {
            if (target == null || target?.Id != id)
                throw new NotFoundException(id);
        }
        public void IsTargetAuthorized(int id, Target target, string userName)
        {
            if (target?.CreatedBy != userName)
                throw new NotAuthorizedException(userName, id);
        }
    }
}
