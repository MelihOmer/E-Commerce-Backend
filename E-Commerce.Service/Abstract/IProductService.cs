using E_Commerce.Core.DbEntities;
using E_Commerce.Service.Dtos;

namespace E_Commerce.Service.Abstract
{
    public interface IProductService : IService<Product>
    {
        Task<IReadOnlyList<ProductResultDto>> GetProductsWithTypeAndBrandAsync();
        Task<Product> GetProductByIdWithTypeAndBrandAsync(int id);
    }
}
