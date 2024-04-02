using E_Commerce.Core;
using E_Commerce.Infrastructure.UnitOfWork;
using E_Commerce.Service.Abstract;

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
    }
}
