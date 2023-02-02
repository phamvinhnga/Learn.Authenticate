using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Model;
using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Migrations;
using Learn.Authenticate.Shared.Exceptions;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Learn.Authenticate.Biz.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthManager(
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager,
            SignInManager<User> signInManager
        ) { 
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
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

            return BuildToken(user);
        }

        private UserSignInOutputModel BuildToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(AuthExtension.UserExtentionId, user.ExtentionId.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:SecurityKey").Value));
            var expires = DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("JWT:Expires").Value));
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
