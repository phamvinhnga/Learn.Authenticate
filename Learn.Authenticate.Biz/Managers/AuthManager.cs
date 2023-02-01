using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Model;
using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AuthManager(
            IMapper mapper,
            UserManager<User> userManager
        ) { 
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(UserSignInInputModel input)
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
    }
}
