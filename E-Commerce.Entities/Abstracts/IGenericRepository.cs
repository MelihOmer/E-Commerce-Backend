using System.Linq.Expressions;

namespace E_Commerce.Core.Abstracts
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[]? includeProperties);
        Task<T> GetEntityWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[]? includeProperties);

    }
}
