using E_Commerce.Core.DbEntities;

namespace E_Commerce.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsAllAsync();
    }
}
