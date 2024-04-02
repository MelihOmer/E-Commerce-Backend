using E_Commerce.Core;

namespace E_Commerce.Service.Abstract
{
    public interface IService<T> where T :BaseEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
