using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Authorization.WebApi.Models;
using Authorization.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositories.UserRepository.Models;

namespace Authorization.WebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }

        [HttpGet]
        [Route("getuserright")]
        public async Task<IActionResult> GetUserRight()
        {
            var userId = Guid.Empty;
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                userId = new Guid(identity.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return Ok(await _userService.GetAllUserRights(userId));
        }
    }
}
