using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
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

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync([FromBody] UserSignInInputDto input)
        {
            var user = _mapper.Map<UserSignInInputModel>(input);
            var result = await _authManager.SignUpAsync(user);
            return Ok(result);
        }
    }
}
