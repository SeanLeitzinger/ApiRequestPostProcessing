using ApiRequestPostProcess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using RequestInjector.NetCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRequestPostProcessing.Api.Requests.User
{
    public class GetUsersRequest : IRequest
    {
        public int Id { get; set; }

        public async Task<IActionResult> Handle()
        {
            return new OkObjectResult(new List<ApiRequestPostProcess.Core.Models.User>
            {
                new FakeUser().Generate(), new FakeUser().Generate()
            })
            {
                DeclaredType = typeof(List<ApiRequestPostProcess.Core.Models.User>)
            };
        }
    }
}
