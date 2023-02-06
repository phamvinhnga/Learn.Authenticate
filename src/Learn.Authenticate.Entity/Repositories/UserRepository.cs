using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Repositories.Interfaces;
using Learn.Authenticate.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public IQueryable<User> GetListUserStaff()
        {
            return from u in _context.Users
                     join ur in _context.UserRoles on u.Id equals ur.UserId
                     join r in _context.Roles on ur.RoleId equals r.Id
                     where r.Name == RoleExtension.Staff
                     select u;
        }
    }
}
