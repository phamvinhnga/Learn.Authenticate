using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Model;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AuthController(
            IMapper mapper,
            IAuthManager authManager
        )
        {
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUserByIdAsync()
        {
            var userId = User.Claims.GetUserId();
            var user = await _authManager.GetCurrentUserByIdAsync(userId);
            return Ok(_mapper.Map<CurrentUserOutputDto>(user));
        }

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync([FromBody] UserSignUpInputDto input)
        {
            var user = _mapper.Map<UserSignUpInputModel>(input);
            var result = await _authManager.SignUpAsync(user);
            return Ok(result);
        }

        [HttpGet("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromQuery] UserSignInInputDto input)
        {
            var result = await _authManager.SignInAsync(
                new UserSignInInputModel 
                { 
                    UserName = input.UserName, 
                    Password = input.Password 
                }
            );
            return Ok(result);
        }
    }
}
