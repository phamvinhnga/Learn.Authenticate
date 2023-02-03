using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(
            IUserManager userManager,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("staff")]
        [Authorize(Roles = "Admin")]
        public async Task RegisterStaffAsync([FromBody] StaffRegisterInputDto input)
        {
            var staff = _mapper.Map<StaffRregisterInputModel>(input);
            await _userManager.RegisterStaffAsync(staff);
        }
    }
}
