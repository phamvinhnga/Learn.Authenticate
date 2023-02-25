using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Shop> CreateAsync(Shop input)
        {
            await _context.Shop.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(Shop input)
        {
            return Task.Run(async () => {
                _context.Shop.Remove(input);
                await _context.SaveChangesAsync();
            });
        }

        public Task<Shop> GetByIdAsync(int id)
        {
            return _context.Shop.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<BasePageOutputModel<Shop>> GetListAsync(ShopPageInputModel input)
        {
            var query = _context.Shop;
            if(input.ProvinceId > 0)
            {
                query = (DbSet<Shop>)query.Where(w => w.ProvinceId == input.ProvinceId);
            }
            if(input.CityId > 0)
            {
                query = (DbSet<Shop>)query.Where(w => w.CityId == input.CityId);
            }
            return new BasePageOutputModel<Shop>(await query.CountAsync(), await query.OrderBy(o => o.Name).ToListAsync());
        }

        public Task UpdateAsync(Shop input)
        {
            return Task.Run(async () => {
                _context.Attach(input);
                _context.Entry(input).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            });
        }
    }
}
