using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Model
{
    public class UserSignInInputModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
