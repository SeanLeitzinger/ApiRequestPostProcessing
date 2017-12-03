using ApiRequestPostProcess.Core.Models;
using System.Collections.Generic;

namespace ApiRequestPostProcessing.Api.ResponseStrategies
{
    public interface IUserResponseStrategy
    {
        void Execute(User user);
        void Execute(List<User> users);
    }
}
