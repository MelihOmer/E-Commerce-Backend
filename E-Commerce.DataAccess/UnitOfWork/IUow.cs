using E_Commerce.Core;
using E_Commerce.Core.Abstracts;

namespace E_Commerce.Infrastructure.UnitOfWork
{
    public interface IUow
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity,new();
        Task CommitAsync();
    }
}
