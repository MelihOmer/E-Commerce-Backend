using E_Commerce.Core.DbEntities;
using E_Commerce.Core.Enums;
using E_Commerce.Core.Helpers;
using E_Commerce.Service.Dtos;
using E_Commerce.Service.Helpers;
using System.Linq.Expressions;

namespace E_Commerce.Service.Abstract
{
    public interface IProductService : IService<Product>
    {
        Task<PaginationResultWithInfoAndData<ProductResultDto>> GetProductsWithTypeAndBrandAsync(RequestParameters requestParameters, Expression<Func<Product, object>>[] orderByProperties = null, Expression<Func<Product, bool>>[] filter = null, OrderBy orderBy = OrderBy.None);
        Task<ProductResultDto> GetProductByIdWithTypeAndBrandAsync(int id);
    }
}
