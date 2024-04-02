using E_Commerce.Core;
using E_Commerce.Core.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var datas = await _context.Set<T>().ToListAsync();
            return datas;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data =await _context.Set<T>().SingleOrDefaultAsync(t => t.Id == id);
            return data;
        }
    }
}
