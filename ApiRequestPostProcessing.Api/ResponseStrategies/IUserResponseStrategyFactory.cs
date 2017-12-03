using ApiRequestPostProcess.Core.Models;

namespace ApiRequestPostProcessing.Api.ResponseStrategies
{
    public interface IUserResponseStrategyFactory
    {
        IUserResponseStrategy Create(UserType userType);
    }
}
