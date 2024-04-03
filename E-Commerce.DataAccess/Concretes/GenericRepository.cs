using E_Commerce.Core;
using E_Commerce.Core.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IReadOnlyList<T>> GetAllWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = filter is not null ? query.Where(filter) : query;

            if(includeProperties is not null)
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            return await query.ToListAsync();
        }

        public async Task<T> GetEntityWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = filter is not null ? query.Where(filter) : query;

            if (includeProperties is not null)
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            return await query.FirstOrDefaultAsync();
        }
    }
}
