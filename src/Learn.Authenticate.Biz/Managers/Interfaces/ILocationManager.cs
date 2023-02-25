using Learn.Authenticate.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Managers.Interfaces
{
    public interface ILocationManager
    {
        Task CreateAsync(LocationInputModel input, int userId);
        Task UpdateAsync(LocationInputModel input, int userId);
        Task<LocationOutputModel> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<BasePageOutputModel<LocationOutputModel>> GetListAsync(LocationBasePageInputModel input);
    }
}
