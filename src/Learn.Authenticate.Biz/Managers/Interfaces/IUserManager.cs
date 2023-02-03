using Learn.Authenticate.Biz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Managers.Interfaces
{
    public interface IUserManager
    {
        Task RegisterStaffAsync(StaffRregisterInputModel input);
    }
}
