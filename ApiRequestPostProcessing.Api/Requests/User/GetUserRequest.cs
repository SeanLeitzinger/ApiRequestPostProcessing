using ApiRequestPostProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using RequestInjector.NetCore;
using System.Threading.Tasks;

namespace ApiRequestPostProcessing.Api.Requests.User
{
    public class GetUserRequest : IRequest
    {
        public int Id { get; set; }

        public async Task<IActionResult> Handle()
        {
            return new OkObjectResult(new FakeUser().Generate())
            {
                DeclaredType = typeof(ApiRequestPostProcess.Core.Models.User)
            };
        }
    }
}
