using DowntimeAlerter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.Application.Validations
{
    public interface ITargetValidations
    {
        void IsTargetExist(int id, Target target);
        void IsTargetAuthorized(int id, Target target, string userName);

    }
}
