using E_Commerce.Core;
using E_Commerce.Core.Abstracts;
using E_Commerce.Infrastructure.Concretes;

namespace E_Commerce.Infrastructure.UnitOfWork
{
    public class Uow : IUow
    {
        readonly AppDbContext _context;

        public Uow(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            return new GenericRepository<T>(_context);
        }
    }
}
