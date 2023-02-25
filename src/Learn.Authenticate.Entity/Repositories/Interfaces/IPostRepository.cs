using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Model;

namespace Learn.Authenticate.Entity.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> CreateAsync(Post input);
        Task UpdateAsync(Post input);
        Task<Post> GetByIdAsync(int id);
        Task<Post> GetByPermalinkAsync(string permalink);
        Task DeleteAsync(Post input);
        Task<BasePageOutputModel<Post>> GetListAsync(BasePageInputModel input);
    }
}
