using ApiRequestPostProcess.Core.Models;
using System;
using System.Collections.Generic;

namespace ApiRequestPostProcessing.Api.ResponseStrategies
{
    public class UserResponseStrategyFactory : Dictionary<UserType, Func<IUserResponseStrategy>>, IUserResponseStrategyFactory
    {
        public UserResponseStrategyFactory()
        {
            Add(UserType.Admin, () => new AdminUserResponseStrategy());
            Add(UserType.Employee, () => new EmployeeUserResponseStrategy());
            Add(UserType.HelpDesk, () => new HelpDeskUserResponseStrategy());
        }

        public IUserResponseStrategy Create(UserType userType)
        {
            return this[userType]();
        }
    }
}
