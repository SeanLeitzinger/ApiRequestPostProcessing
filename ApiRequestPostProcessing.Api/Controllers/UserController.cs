using ApiRequestPostProcessing.Api.Requests.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiRequestPostProcessing.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUserRequest request)
        {
            return await request.Handle();
        }

        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return await request.Handle();
        }
    }
}
