using E_Commerce.Core;
using E_Commerce.Infrastructure.UnitOfWork;
using E_Commerce.Service.Abstract;
using System.Linq.Expressions;

namespace E_Commerce.Service.Concrete
{
    public class Service<T> : IService<T> where T : BaseEntity, new()
    {
        readonly IUow _uow;

        public Service(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _uow.GetRepository<T>().GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _uow.GetRepository<T>().GetByIdAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAllWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _uow.GetRepository<T>().GetAllWithWhereAndIncludesAsync(filter, includeProperties);
        }
        public async Task<T> GetEntityWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _uow.GetRepository<T>().GetEntityWithWhereAndIncludesAsync(filter,includeProperties);
        }
    }
}
