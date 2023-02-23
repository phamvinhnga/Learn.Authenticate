using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Model;

namespace Learn.Authenticate.Entity.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> CreateAsync(Location input);
        Task UpdateAsync(Location input);
        Task<Location> GetByIdAsync(int id);
        Task DeleteAsync(Location input);
        Task<BasePageOutputModel<Location>> GetListAsync(BasePageInputModel input);
    }
}
