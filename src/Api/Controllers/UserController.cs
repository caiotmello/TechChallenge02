using Application.Dtos.Request;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("signUp")]
        public async Task<ActionResult> SignUp(UserSignUpRequestDto user)
        {
            var result = await _identityService.SignUpAsync(user);
            if(result.IsSuccess)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginRequestDto user)
        {
            var result = await _identityService.LoginAsync(user);
            if (result.IsSuccess)
                return Ok(result);

            return Unauthorized(result);
        }
    }
}
