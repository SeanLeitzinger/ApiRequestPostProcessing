using ApiRequestPostProcess.Core.Models;
using System.Collections.Generic;

namespace ApiRequestPostProcessing.Api.ResponseStrategies
{
    public class AdminUserResponseStrategy : IUserResponseStrategy
    {
        public void Execute(User user)
        {
            //Return everything
        }

        public void Execute(List<User> users)
        {
            //Return everything
        }
    }
}
