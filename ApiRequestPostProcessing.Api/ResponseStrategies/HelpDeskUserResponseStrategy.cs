using ApiRequestPostProcess.Core.Models;
using System.Collections.Generic;

namespace ApiRequestPostProcessing.Api.ResponseStrategies
{
    public class HelpDeskUserResponseStrategy : IUserResponseStrategy
    {
        public void Execute(User user)
        {
            //Return everything.
        }

        public void Execute(List<User> users)
        {
            //Return everything.
        }
    }
}
