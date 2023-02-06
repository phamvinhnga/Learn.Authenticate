using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Managers;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Migrations;
using Learn.Authenticate.Shared.Exceptions;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Learn.Authenticate.Biz.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthManager> _logger;

        public AuthManager(
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager,
            ILogger<AuthManager> logger
        ) { 
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<CurrentUserOutputModel> GetCurrentUserByIdAsync(int userId)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException("Current User");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if(user == null)
            {
                throw new ArgumentNullException($"UserId {userId} cannot found in system");
            }

            return _mapper.Map<CurrentUserOutputModel>(user);
        }

        public async Task<IdentityResult> SignUpAsync(UserSignUpInputModel input)
        {
            var user = _mapper.Map<User>(input);

            var entity = await _userManager.FindByEmailAsync(input.Email);

            if (entity != null)
            {
                throw new BadRequestException("Account already exists", StatusCodes.Status409Conflict);
            }

            user.SetPasswordHasher(input.Password);

            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<UserSignInOutputModel> SignInAsync(UserSignInInputModel input)
        {
            var user = await _userManager.FindByNameAsync(input.UserName);

            if (user == null)
            {
                throw new ArgumentNullException($"Username {input.UserName} cannot found in system");
            }

            if (!await _userManager.CheckPasswordAsync(user, input.Password))
            {
                throw new UnauthorizedException("Incorrect account or password", StatusCodes.Status406NotAcceptable);
            }

            return await BuildTokenAsync(user);
        }

        private async Task<UserSignInOutputModel> BuildTokenAsync(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(AuthExtension.UserExtentionId, user.ExtentionId.ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            if (!userRoles.Any())
            {
                _logger.LogWarning($"UserName {user.UserName} have not role");
            }

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));

                var role = await _roleManager.FindByNameAsync(userRole);

                if (role == null)
                {
                    _logger.LogError($"Role {userRole} cant not found");
                    throw new ApplicationException($"Role {userRole} cant not found");
                }

                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (Claim roleClaim in roleClaims)
                {
                    claims.Add(roleClaim);
                }

            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:SecurityKey").Value));
            var expires = DateTime.Now.AddHours(int.Parse(_configuration.GetSection("JWT:Expires").Value));
            var audience = _configuration.GetSection("JWT:ValidAudience").Value;
            var issuer = _configuration.GetSection("JWT:ValidIssuer").Value;
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                audience: audience,
                issuer: issuer,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials
            );

            return new UserSignInOutputModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expire = expires
            };
        }
    }
}
