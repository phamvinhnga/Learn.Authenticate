using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Model;

namespace Learn.Authenticate.Entity.Repositories.Interfaces
{
    public interface IShopRepository
    {
        Task<Shop> CreateAsync(Shop input);
        Task UpdateAsync(Shop input);
        Task<Shop> GetByIdAsync(int id);
        Task DeleteAsync(Shop input);
        Task<BasePageOutputModel<Shop>> GetListAsync(ShopPageInputModel input);
    }
}
