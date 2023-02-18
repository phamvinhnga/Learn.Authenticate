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
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(
            ApplicationDbContext context
        ) 
        { 
            _context = context;
        }

        public Task<Post> GetByIdAsync(int id)
        {
            return _context.Post.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<BasePageOutputModel<Post>> GetListAsync(BasePageInputModel input)
        {
            var query = _context.Post.AsNoTracking().Where(w => w.Title.StartsWith(input.Search)).Select(s => new Post()
            {
                Id = s.Id,
                Title = s.Title,
                CreateDate = s.CreateDate
            });

            var count = await query.CountAsync();

            var items = await query.Skip(input.SkipCount).Take(input.MaxCountResult).ToListAsync();

            return new BasePageOutputModel<Post>(count, items);
        }
    
        public async Task<Post> CreateAsync(Post input)
        {
            await _context.Post.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(Post input)
        {
            return Task.Run(async () => {
                _context.Post.Remove(input);
                await _context.SaveChangesAsync();
            });
        }

        public Task UpdateAsync(Post input)
        {
            return Task.Run(async () => {
                _context.Attach(input);
                _context.Entry(input).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            });
        }
    }
}
