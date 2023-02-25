using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Managers.Interfaces
{
    public interface IPostManager
    {
        Task CreateAsync(PostInputModel input, int userId);
        Task UpdateAsync(PostInputModel input, int userId);
        Task<PostOutputModel> GetByIdAsync(int id);
        Task<PostOutputModel> GetByPermalinkAsync(string permalink);
        Task DeleteAsync(int id);
        Task<BasePageOutputModel<PostOutputModel>> GetListAsync(BasePageInputModel input);
    }
}
