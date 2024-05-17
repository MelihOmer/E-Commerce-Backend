using E_Commerce.Core;
using E_Commerce.Core.Enums;
using E_Commerce.Service.Helpers;
using System.Linq.Expressions;

namespace E_Commerce.Service.Abstract
{
    public interface IService<T> where T :BaseEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> GetCountWithApplyFilterAsync(Expression<Func<T, bool>>[] filter = null);
        Task<IReadOnlyList<T>> GetAllWithWhereAndIncludesAsync(RequestParameters requestParameters,Expression<Func<T, object>>[] orderByProperties = null, OrderBy orderBy = OrderBy.None, Expression<Func<T, bool>>[] filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetEntityWithWhereAndIncludesAsync(Expression<Func<T, bool>>[] filter = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
