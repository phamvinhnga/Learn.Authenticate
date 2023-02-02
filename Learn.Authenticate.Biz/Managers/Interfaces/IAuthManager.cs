using Learn.Authenticate.Biz.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Managers.Interfaces
{
    public interface IAuthManager
    {
        Task<IdentityResult> SignUpAsync(UserSignUpInputModel input);

        Task<UserSignInOutputModel> SignInAsync(UserSignInInputModel input);

        Task<CurrentUserOutputModel> GetCurrentUserByIdAsync(int userId);
    }
}
