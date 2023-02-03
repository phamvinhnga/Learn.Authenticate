using AutoMapper;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Model;
using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Learn.Authenticate.Biz.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public UserManager(
             UserManager<User> userManager,
             RoleManager<Role> roleManager,
             IMapper mapper
            ) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task RegisterStaffAsync(StaffRregisterInputModel input)
        {
            if(input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if(await _userManager.FindByNameAsync(input.UserName) != null)
            {
                throw new BadRequestException($"UserName {input.UserName} already exists", StatusCodes.Status409Conflict);
            }

            var user = _mapper.Map<User>(input);
            user.SetPasswordHasher(input.Password);

            var result = await _userManager.CreateAsync(user);
        }
    }
}
