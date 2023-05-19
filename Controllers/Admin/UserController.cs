using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Xiyi_Platform.Common;
using Xiyi_Platform.Entities;
using Xiyi_Platform.Services;

namespace Xiyi_Platform.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("admin/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<ResponseFormat> UserList()
        {
            return ApiResponse.Ok(_userService.GetUserList().Result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseFormat>> GetUserByID(int id)
        {
            User user = await _userService.GetUserByID(id);
            if (user == null)
            {
                return ApiResponse.NotFound("未找到该用户！");
            }
            else
            {
                return ApiResponse.Ok(user);
            }
        }
    }
}
