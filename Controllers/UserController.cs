using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Xiyi_Platform.Common;
using Xiyi_Platform.Entities;
using Xiyi_Platform.Services;

namespace Xiyi_Platform.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<ResponseFormat> AddUser([FromForm]User user)
        {
            try
            {
                _userService.AddUser(user);
                return ApiResponse.Ok(user);
            }catch (Exception ex)
            {
                return ApiResponse.BadRequest($"添加用户失败！，{ex.Message}");
            }
            
        }

        [HttpGet]
        public ActionResult<ResponseFormat> UserInfo()
        {
            return ApiResponse.Ok("x");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<ResponseFormat> Login([FromForm]String UserName, [FromForm] String PassWord) {
            var res = _userService.Login(UserName, PassWord);
            if (res.Equals(""))
            {
                return ApiResponse.NotAuth("登录失败！");
            }
            else
            {
                return ApiResponse.Ok(res);
            }
        }

    }
}
