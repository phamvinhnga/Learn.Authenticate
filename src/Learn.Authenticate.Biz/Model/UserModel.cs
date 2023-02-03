using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Model
{
    public class UserSignUpInputModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }

    public class UserSignInInputModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class UserSignInOutputModel
    {
        public string AccessToken { get; set; }

        public DateTime Expire { get; set; }
    }

    public class CurrentUserOutputModel
    {
        public int Id { get;set; }

        public string Surname { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }

        public Guid ExtentionId { get; set; }

    }
}
