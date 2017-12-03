using ApiRequestPostProcess.Core.Models;
using System.Collections.Generic;

namespace ApiRequestPostProcessing.Api.ResponseStrategies
{
    public class EmployeeUserResponseStrategy : IUserResponseStrategy
    {
        public void Execute(User user)
        {
            user.CreatedBy = null;
            user.DateCreated = null;
            user.DateUpdated = null;
            user.UpdatedBy = null;
        }

        public void Execute(List<User> users)
        {
            users.ForEach(m =>
            {
                m.CreatedBy = null;
                m.DateCreated = null;
                m.DateUpdated = null;
                m.UpdatedBy = null;
            });
        }
    }
}
