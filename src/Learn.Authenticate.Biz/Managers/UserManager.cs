using AutoMapper;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Shared.Exceptions;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Learn.Authenticate.Entity.Repositories.Interfaces;

namespace Learn.Authenticate.Biz.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserRepository _userRepository;

        public UserManager(
             UserManager<User> userManager,
             RoleManager<Role> roleManager,
             IMapper mapper,
             IUserRepository userRepository
            ) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<StaffOutputModel>> GetListStaffAsync()
        {
            var query = await _userRepository.GetListUserStaff().ToListAsync();
            return _mapper.Map<List<StaffOutputModel>>(query);
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

            var resultUser = await _userManager.CreateAsync(user);

            if (!resultUser.Succeeded)
            {
                throw new BadRequestException(resultUser.Succeeded.ToString());
            }

            var resultRole = await _userManager.AddToRoleAsync(user, RoleExtension.Staff);

            if (!resultRole.Succeeded)
            {
                throw new BadRequestException(resultUser.Succeeded.ToString());
            }
        }
    }
}
