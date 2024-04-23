using AutoMapper;
using E_Commerce.Core.DbEntities;
using E_Commerce.Core.Enums;
using E_Commerce.Core.Helpers;
using E_Commerce.Infrastructure.UnitOfWork;
using E_Commerce.Service.Abstract;
using E_Commerce.Service.Dtos;
using E_Commerce.Service.Helpers;
using System.Linq.Expressions;

namespace E_Commerce.Service.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {
        readonly IMapper _mapper;
        public ProductService(IUow uow, IMapper mapper) : base(uow)
        {
            _mapper = mapper;
        }

        public async Task<PaginationResultWithInfoAndData<ProductResultDto>> GetProductsWithTypeAndBrandAsync(RequestParameters requestParameters,Expression<Func<Product, object>>[] orderByProperties = null,Expression<Func<Product, bool>>[]? filter = null,OrderBy orderBy = OrderBy.None)
        {
            int count = await GetCountAsync();
            var data = await GetAllWithWhereAndIncludesAsync(requestParameters, orderByProperties, orderBy, filter, x => x.ProductBrand, x => x.ProductType);
            var mappList = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResultDto>>(data);

            PaginationResultWithInfoAndData<ProductResultDto> result = new(requestParameters,count,mappList);



            return result;
        }
        public async Task<Product> GetProductByIdWithTypeAndBrandAsync(int id)
        {
            return await GetEntityWithWhereAndIncludesAsync(x => x.Id == id, x => x.ProductBrand, x => x.ProductType);
        }
    }
}
